using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using BattleNET;
using System.Net;
using System.Xml;
using Extensions;
using System.Threading.Tasks;
using GlobalVariables;
using System.IO;

namespace Sparc
{
    public partial class ServerComponent : UserControl
    {
        BattlEyeClient b;
        BattlEyeLoginCredentials loginCredentials;

        private bool isConnected = false;

        private LinkedList<Player> PlayerCache = new LinkedList<Player>();
        private LinkedList<BannedPlayer> BanCache = new LinkedList<BannedPlayer>();
        private LinkedList<Admin> AdminCache = new LinkedList<Admin>();
        private LinkedList<XmlNode> ServerCache = new LinkedList<XmlNode>();

        private Sort plSorter;
        private Sort slSorter;

        private Timer refreshTimer;
        private Timer cooldownTimer;

        private string dir;
        private string timestamp;
        private string host;

        private ListViewItem lastSelected;

        public ServerComponent()
        {
            InitializeComponent();
        }

        private void ServerComponent_Load(object sender, EventArgs e)
        {
            cmdOption.SelectedIndex = 0;

            string currentDir = Environment.CurrentDirectory;
            dir = currentDir + @"\logs";
            timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); // I.E. 2014-01-05_06-49-23

            plSorter = new Sort();
            slSorter = new Sort();
            this.listPlayers.ListViewItemSorter = plSorter;
            this.listServers.ListViewItemSorter = slSorter;

            searchBox.SelectedIndex = 0;
            cooldownTimer = new Timer();
            cooldownTimer.Tick += new EventHandler(cooldownTimer_Tick);
            cooldownTimer.Enabled = false;

            txAll.Text = ("Sparc " + Globals.sparcVersion + " initialized!");
            txConsole.Text = ("Sparc " + Globals.sparcVersion + " initialized!");
            txChat.Text = ("Sparc " + Globals.sparcVersion + " initialized!");
            txAlert.Text = ("Sparc " + Globals.sparcVersion + " initialized!");

            loadServerList();
        }

        /*
         * Primary connect and disconnect handlers
         */
        #region CXN_MAIN

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                handleDisconnect();
                b.Disconnect();
            }
            else
            {
                txAll.Text = ("Sparc " + Globals.sparcVersion + " initialized!");
                txConsole.Text = ("Sparc " + Globals.sparcVersion + " initialized!");
                txChat.Text = ("Sparc " + Globals.sparcVersion + " initialized!");
                txAlert.Text = ("Sparc " + Globals.sparcVersion + " initialized!");

                loginCredentials = GetLoginCredentials();
                b = new BattlEyeClient(loginCredentials);
                b.BattlEyeMessageReceived += BattlEyeMessageReceived;
                b.BattlEyeConnected += BattlEyeConnected;
                b.BattlEyeDisconnected += BattlEyeDisconnected;
                b.ReconnectOnPacketLoss = true;
                b.Connect();

                //handleConnect();
            }
        }

        private void FormClosing(object sender, EventArgs e)
        {
            if (isConnected)
            {
                handleDisconnect();
                b.Disconnect();
            }
        }

        private async void handleConnect()
        {
            isConnected = true;
            btnConnect.Text = "Disconnect";
            this.Parent.Text = txHost.Text;
            host = txHost.Text;
            btnExecute.Enabled = true;
            btnPlayerRefresh.Enabled = true;
            btnBanRefresh.Enabled = true;
            txSay.Enabled = true;

            if (Properties.Settings.Default.saveLogs)
            {
                if (!Directory.Exists(dir))  // if it doesn't exist, create
                    Directory.CreateDirectory(dir);
            }

            getConnectedClients();

            if (Properties.Settings.Default.autoRefresh || autoRefresh.Checked)
            {
                cooldownTimer.Interval = 5000; // 5 seconds should be enough for the first interval, don't want two refreshes going on at connect!
                cooldownTimer.Start();
            }
            if (Properties.Settings.Default.loadBanConnect)
            {
                //btnBanRefresh.PerformClick();
                getBanList();
            }

            if (Properties.Settings.Default.autoRefresh || autoRefresh.Checked)
            {
                enableRefreshManual();
            }
        }

        private async void handleDisconnect()
        {
            clearPlayerList();
            clearBanList();
            clearAdminList();
            isConnected = false;
            btnConnect.Text = "Connect";
            btnExecute.Enabled = false;
            btnPlayerRefresh.Enabled = false;
            btnBanRefresh.Enabled = false;
            txSay.Enabled = false;

            await Task.Delay(1000);
            playerCount.Text = PlayerCache.Count().ToString();
            adminCount.Text = listAdmins.Items.Count.ToString();
            banCount.Text = listBans.Items.Count.ToString();

            if (Properties.Settings.Default.autoRefresh)
            {
                refreshTimer.Stop();
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            getConnectedClients();
        }

        #endregion

        /*
         * MAIN BATTLEYE INTERFACE
         */
        #region BE_INTF_MAIN

        private void BattlEyeConnected(BattlEyeConnectEventArgs args)
        {
            bool connected = false;
            if (args.ConnectionResult == BattlEyeConnectionResult.Success) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection successful!"); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection successful!"); connected = true; }); }
            if (args.ConnectionResult == BattlEyeConnectionResult.InvalidLogin) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Invalid login details!"); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Invalid login details!"); }); }
            if (args.ConnectionResult == BattlEyeConnectionResult.ConnectionFailed) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection failed!"); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection failed!"); }); }

            if (connected)
                this.Invoke((MethodInvoker)delegate() { handleConnect(); });
            else
                this.Invoke((MethodInvoker)delegate() { handleDisconnect(); });
        }

        private void BattlEyeDisconnected(BattlEyeDisconnectEventArgs args)
        {
            if (args.DisconnectionType == BattlEyeDisconnectionType.ConnectionLost) { this.Invoke((MethodInvoker)delegate() { this.BeginInvoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection lost (timeout). Attempting to reconnect."); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection lost (timeout). Attempting to reconnect."); }); }); };
            if (args.DisconnectionType == BattlEyeDisconnectionType.SocketException) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection closed (socket error)"); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection closed (socket error)"); }); }
            //if (args.DisconnectionType == BattlEyeDisconnectionType.Manual) { /* Disconnected by implementing application, that would be you */ }

            this.BeginInvoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Disconnected."); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Disconnected."); });
            this.Invoke((MethodInvoker)delegate() { handleDisconnect(); });
        }

        private void BattlEyeMessageReceived(BattlEyeMessageEventArgs args)
        {
            if (args.Message.Contains("Player #") && (args.Message.Contains("disconnected")||args.Message.Contains("kicked")))
            {
                this.listPlayers.BeginInvoke((MethodInvoker)delegate() { removePlayer(parsePlayerDisconnect(args.Message)); });
            }
            if (args.Message.Contains("Verified GUID") && args.Message.Contains("of player #"))
            {
                listPlayers.BeginInvoke((MethodInvoker)delegate () { updatePlayer(parsePlayerConnect(args.Message)); });
            }
            if (args.Message.Contains("[#] [IP Address]:[Port] [Ping] [GUID] [Name]"))
            {
                parsePlayerList(args.Message);
            }
            else if (args.Message.Contains("[#] [GUID] [Minutes left] [Reason]") || args.Message.Contains("[#] [IP Address] [Minutes left] [Reason]"))
            {
                parseBanList(args.Message);
            }
            else if (args.Message.Contains("[#] [IP Address]:[Port]"))
            {
                parseAdminList(args.Message);
            }
            else
            {
                if (IsHandleCreated)
                {
                    if (InvokeRequired)
                        this.Invoke((MethodInvoker)delegate() { this.formatChat(args.Message); });
                    else
                        this.formatChat(args.Message);
                }
            }
        }

        private BattlEyeLoginCredentials GetLoginCredentials()
        {
            BattlEyeLoginCredentials loginCredentials = new BattlEyeLoginCredentials();
            try
            {
                loginCredentials.Host = Dns.GetHostAddresses(txHost.Text)[0];
            }
            catch
            {
                MessageBox.Show("Error resolving hostname. Are you using the right address?");
            }

            try { loginCredentials.Port = Convert.ToInt32(txPort.Text); }
            catch { loginCredentials.Port = 3202; };

            loginCredentials.Password = txPasswd.Text;

            txAll.SelectionColor = Color.Black;
            txAll.SelectionFont = new Font("Lucida Console", 8);
            txConsole.SelectionColor = Color.Black;
            txConsole.SelectionFont = new Font("Lucida Console", 8);
            txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connecting to " + txHost.Text + " (" + Dns.GetHostAddresses(txHost.Text)[0] + ")");
            txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connecting to " + txHost.Text + " (" + Dns.GetHostAddresses(txHost.Text)[0] + ")");

            return loginCredentials;
        }
        #endregion

        /*
         * Console / Chat Box handlers
         */
        #region CHAT_CONSL_HANDLE

        private void formatChat(string text)
        {
            if (text.Contains("(Direct)"))
            {
                if ((text.containsIgnoreCase("admin") && Properties.Settings.Default.hlAdmin) || text.containsIgnoreCase(Properties.Settings.Default.Username)) // Logic:(i f admin is called and admin hightlighting is selected) OR (if username highlighting is selected)
                    appendBoldChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.DodgerBlue);
                else
                    appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.DodgerBlue);
            }
            else if (text.Contains("(Unknown)"))
            {
                if ((text.containsIgnoreCase("admin") && Properties.Settings.Default.hlAdmin) || text.containsIgnoreCase(Properties.Settings.Default.Username))
                    appendBoldChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.MediumPurple);
                else
                    appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.MediumPurple);
            }
            else if (text.Contains("(Group)"))
            {
                if ((text.containsIgnoreCase("admin") && Properties.Settings.Default.hlAdmin) || text.containsIgnoreCase(Properties.Settings.Default.Username))
                    appendBoldChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.ForestGreen);
                else
                    appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.ForestGreen);
            }
            else if (text.Contains("(Vehicle)"))
            {
                if ((text.containsIgnoreCase("admin") && Properties.Settings.Default.hlAdmin) || text.containsIgnoreCase(Properties.Settings.Default.Username))
                    appendBoldChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.DarkOrange);
                else
                    appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.DarkOrange);
            }
            else if (text.Contains("(Global)"))
            {
                    appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.Red);
            }
            else
            {
                txAll.SelectionColor = Color.Black;
                txAll.SelectionFont = new Font("Lucida Console", 8);
                txAll.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
                txConsole.SelectionColor = Color.Black;
                txConsole.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
                txConsole.SelectionFont = new Font("Lucida Console", 8);

                if (Properties.Settings.Default.RefreshPlayerChange && (text.Contains("Player") && (text.Contains("disconnected") || text.Contains("connected"))))
                {
                    if (!cooldownTimer.Enabled)
                    {
                        cooldownTimer.Interval = 5000; // this should honestly be enough
                        cooldownTimer.Start();
                        getConnectedClients();
                    }
                }
            }

            if (Properties.Settings.Default.saveLogs)
            {
                string log = Path.Combine(dir, "log_" + host + "_" + timestamp + ".txt");
                string chatlog = Path.Combine(dir, "chatlog_" + host + "_" + timestamp + ".txt");
                string consolelog = Path.Combine(dir, "consolelog_" + host + "_" + timestamp + ".txt");

                txAll.SaveFile(log, RichTextBoxStreamType.PlainText);
                txChat.SaveFile(chatlog, RichTextBoxStreamType.PlainText);
                txConsole.SaveFile(consolelog, RichTextBoxStreamType.PlainText);
            }
        }

        private void cooldownTimer_Tick(object sender, EventArgs e)
        {
            cooldownTimer.Stop();
        }

        private void chatAlert(string text)
        {
            if (text.containsIgnoreCase("admin") && Properties.Settings.Default.flashOnCall)
            {
                Flash.FlashWindowEx(this.ParentForm);
                txAlert.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            }
            if (text.containsIgnoreCase(Properties.Settings.Default.Username) && Properties.Settings.Default.flashOnCall)
            {
                Flash.FlashWindowEx(this.ParentForm);
                txAlert.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
                //this.Parent.color
            }
        }

        private void appendChat(string text, Color color)
        {
            chatAlert(text);

            txAll.SelectionColor = color;
            txChat.SelectionColor = color;
            txAll.SelectionFont = new Font("Lucida Console", 8);
            txChat.SelectionFont = new Font("Lucida Console", 8);
            txAll.AppendText(text);
            txChat.AppendText(text);
        }

        private void appendBoldChat(string text, Color color)
        {
            chatAlert(text);

            txAll.SelectionColor = color;
            txChat.SelectionColor = color;
            txAll.SelectionFont = new Font("Lucida Console", 8, FontStyle.Bold);
            txChat.SelectionFont = new Font("Lucida Console", 8, FontStyle.Bold);
            txAll.AppendText(text);
            txChat.AppendText(text);
        }
        
        #endregion

        /*
         * Autoscroll handlers
         */
        #region SCROLL_HANDLE

        private void txAll_TextChanged(object sender, EventArgs e)
        {
            if (autoScroll.Checked)
            {
                txAll.SelectionStart = txAll.TextLength;
                txAll.ScrollToCaret();
            }
        }


        private void txChat_TextChanged(object sender, EventArgs e)
        {
            if (autoScroll.Checked)
            {
                txChat.SelectionStart = txChat.TextLength;
                txChat.ScrollToCaret();
            }
        }

        private void txConsole_TextChanged(object sender, EventArgs e)
        {
            if (txConsole.Visible && autoScroll.Checked)
            {
                txConsole.SelectionStart = txConsole.TextLength;
                txConsole.ScrollToCaret();
            }
        }
        #endregion

        /*
         * Lists handlers
         */
        #region LIST_HANDLE

        private void parsePlayerList(string list)
        {
            string[] lines = list.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                Player p = parsePlayer(line);

                if (p != null)
                    this.listPlayers.BeginInvoke((MethodInvoker)delegate() { updatePlayer(p); });
            }
        }

        private void updatePlayer(Player p)
        {
            bool newplayer = true;

            foreach (Player pc in PlayerCache)
            {
                if (p.getPlayerNumber() == pc.getPlayerNumber())
                {
                    //"update" the cached player
                    PlayerCache.Remove(pc);
                    PlayerCache.AddLast(p);
                    newplayer = false;
                    break;
                }
            }

            for (int i = 0; i < listPlayers.Items.Count; i++)
            {
                if (listPlayers.Items[i].SubItems[0].Text == p.getPlayerNumber())
                {
                    //listPlayers.Items[i] = new ListViewItem(p.getPlayerInfo());
                    listPlayers.Items[i].SubItems[0].Text = p.getPlayerNumber();
                    listPlayers.Items[i].SubItems[1].Text = p.getPlayerName();
                    listPlayers.Items[i].SubItems[2].Text = (p.getPlayerStatus().Contains("Lobby")) ? listPlayers.Items[i].SubItems[2].Text : p.getPlayerStatus(); //only update they're not still in the lobby
                    listPlayers.Items[i].SubItems[3].Text = p.getPlayerGuid();
                    listPlayers.Items[i].SubItems[4].Text = p.getPlayerIP();
                    listPlayers.Items[i].SubItems[5].Text = p.getPlayerPing();
                    newplayer = false;
                    break;
                }
            }

            if (newplayer)
            {
                this.listPlayers.Items.Add(new ListViewItem(p.getPlayerInfo()));
                PlayerCache.AddLast(p);

                if (Properties.Settings.Default.detectSrvHop)
                    checkServerHop(p);
            }

            playerCount.Text = PlayerCache.Count().ToString();
        }

        private void removePlayer(string playerNumber)
        {
            foreach (Player p in PlayerCache)
            {
                if (p.getPlayerNumber() == playerNumber)
                {
                    PlayerCache.Remove(p);
                    p.setPlayerTime();
                    Globals.GlobalPlayerCache.AddLast(p);
                    break;
                }
            }

            foreach (ListViewItem lvi in listPlayers.Items)
            {
                if (lvi.SubItems[0].Text == playerNumber)
                {
                    lvi.Remove();
                    listDisconnected.Items.Add(lvi);
                    break;
                }
            }

            playerCount.Text = PlayerCache.Count().ToString();
        }

        private void checkServerHop(Player p)
        {
            foreach (Player historicalPlayer in Globals.GlobalPlayerCache)
            {
                string hopTime = DateTime.Now.Subtract(historicalPlayer.getPlayerTime()).Minutes + " minutes, "+ DateTime.Now.Subtract(historicalPlayer.getPlayerTime()).Seconds+" seconds";
                if (p.getPlayerGuid() == historicalPlayer.getPlayerGuid() /*&& hopTime < 60*/)
                {
                    txAlert.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + p.getPlayerName() + " disconnected from " + historicalPlayer.getPlayerHost() +" "+ hopTime + " ago.");
                }
            }
        }

        private Player parsePlayer(string line)
        {
            Player p = null;
            string[] data = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Split(null, 5);
            int x;

            if (data.Length >= 5 && int.TryParse(data[0], out x))
            {
                /*
                 * data[0] = player Number
                 * data[1] = player IP
                 * data[2] = player Ping
                 * data[3] = player GUID
                 * data[4] = player Name
                 */
                bool lobby = false;

                try
                {
                    data[3] = data[3].Remove(32);
                }
                catch
                {
                    Console.WriteLine("Error parsing player name: " + data[3]);
                }


                if (data[4].Contains("(Lobby)"))
                {
                    data[4] = data[4].Substring(0, data[4].Length - 8);
                    lobby = true;
                }

                string ip = data[1].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0];

                p = new Player(host, data[0], ip, data[2], data[3], data[4], lobby);
            }
            return p;
        }

        private Player parsePlayerConnect(string line)
        {
            //we really don't need to use regex for this, but whatever
            string[] data = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Split(null, 7);

            string guid = data[2].Trim(new Char[] { '(', ')'});
            string pn = data[5].Substring(1);
            string name = data[6];

            Player p = new Player(host, pn, "Unknown", "Unknown", guid, name, true);

            return p;
        }

        private string parsePlayerDisconnect(string line)
        {
            //we really don't need to use regex for this, but whatever
            string[] data = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Split(null, 3);

            string pn = data[1].Substring(1);

            return pn;
        }

        private void parseBanList(string list)
        {
            clearBanList();

            string[] lines = list.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                BannedPlayer p = parseBan(line);

                if (p != null)
                    BanCache.AddLast(p);
            }

            updateBanList();
        }

        private BannedPlayer parseBan(string line)
        {
            BannedPlayer p = null;

            string[] data = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Split(null, 4);
            int x;

            if (data.Length >= 4 && int.TryParse(data[0], out x))
            {
                /*
                 * data[0] = bannedPlayer Number
                 * data[1] = bannedPlayer IPGUID
                 * data[2] = bannedPlayer Minutes Left
                 * data[3] = bannedPlayer Reason
                 */
                string ipguid;

                try
                {
                    data[1] = data[1].Remove(32);
                }
                catch
                {
                    Console.WriteLine("Error parsing ban: " + data[1]);
                }

                if (data[1].ToLowerInvariant().Contains("."))
                {
                    ipguid = data[1].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                else
                {
                    ipguid = data[1];
                }


                p = new BannedPlayer(data[0], ipguid, data[2], data[3]);
            }
            return p;
        }

        private void parseAdminList(string list)
        {
            clearAdminList();

            string[] lines = list.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                Admin p = parseAdmin(line);

                if (p != null)
                    AdminCache.AddLast(p);
            }

            updateAdminList();
        }

        private Admin parseAdmin(string line)
        {
            Admin p = null;

            string[] data = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Split(null, 2);
            int x;

            if (data.Length >= 2 && int.TryParse(data[0], out x))
            {
                /*
                 * data[0] = Admin Number
                 * data[1] = Admin IP
                 */

                string ip = data[1].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0];

                p = new Admin(data[0], ip);
            }
            return p;
        }

        private void getConnectedClients()
        {
            //clearPlayerList();
            //PlayerCache.Clear();
            b.SendCommand("players");
            clearAdminList();
            b.SendCommand("admins");
        }

        private void getBanList()
        {
            clearBanList();
            b.SendCommand("bans");
        }

        private void clearPlayerList()
        {
            PlayerCache.Clear();
            this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Clear(); });
        }

        private void clearBanList()
        {
            BanCache.Clear();
            this.listBans.BeginInvoke((MethodInvoker)delegate() { this.listBans.Items.Clear(); });
        }

        private void clearAdminList()
        {
            AdminCache.Clear();
            this.listAdmins.BeginInvoke((MethodInvoker)delegate() { this.listAdmins.Items.Clear(); });
        }

        private void reloadPlayerList()
        {
            this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Clear(); });

            foreach (Player p in PlayerCache)
                this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Add(new ListViewItem(p.getPlayerInfo())); });
        }

        private void updateBanList()
        {
            this.listBans.BeginInvoke((MethodInvoker)delegate() { this.listBans.Items.Clear(); });

            foreach (BannedPlayer p in BanCache)
                this.listBans.BeginInvoke((MethodInvoker)delegate() { this.listBans.Items.Add(new ListViewItem(p.getPlayerInfo())); });
        }

        private void updateAdminList()
        {
            foreach (Admin p in AdminCache)
                this.listAdmins.BeginInvoke((MethodInvoker)delegate() { this.listAdmins.Items.Add(new ListViewItem(p.getPlayerInfo())); adminCount.Text = listAdmins.Items.Count.ToString(); });
        }

        private async void btnPlayerRefresh_Click(object sender, EventArgs e)
        {
            getConnectedClients();

            string text = "Refreshing players...";
            txAll.SelectionColor = Color.Black;
            txAll.SelectionFont = new Font("Lucida Console", 8);
            txAll.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            txConsole.SelectionColor = Color.Black;
            txConsole.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            txConsole.SelectionFont = new Font("Lucida Console", 8);

            await Task.Delay(1000);
            //playerCount.Text = PlayerCache.Count().ToString();
            adminCount.Text = listAdmins.Items.Count.ToString();
        }

        private async void btnBanRefresh_Click(object sender, EventArgs e)
        {
            getBanList();

            string text = "Refreshing bans...";
            txAll.SelectionColor = Color.Black;
            txAll.SelectionFont = new Font("Lucida Console", 8);
            txAll.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            txConsole.SelectionColor = Color.Black;
            txConsole.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            txConsole.SelectionFont = new Font("Lucida Console", 8);

            await Task.Delay(1000);
            banCount.Text = listBans.Items.Count.ToString();
        }

        private void listPlayers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == plSorter.SortColumn)
            {
                plSorter.Order = (plSorter.Order == SortOrder.Ascending) ? plSorter.Order = SortOrder.Descending : plSorter.Order = SortOrder.Ascending;
            }
            else
            {
                plSorter.SortColumn = e.Column;
                plSorter.Order = SortOrder.Ascending;
            }

            this.listPlayers.Sort();
        }

        private void listServers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == slSorter.SortColumn)
            {
                slSorter.Order = (slSorter.Order == SortOrder.Ascending) ? slSorter.Order = SortOrder.Descending : slSorter.Order = SortOrder.Ascending;
            }
            else
            {
                slSorter.SortColumn = e.Column;
                slSorter.Order = SortOrder.Ascending;
            }

            this.listServers.Sort();
        }

        #endregion

        /*
         * Player list context menu handlers
         */
        #region PLIST_CNTX_HANDLE

        private void listPlayers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listPlayers.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    //create an object that can still be accessed even after the item has been deselected (list refresh crash fix)
                    lastSelected = listPlayers.SelectedItems[0];
                    playerMenu.Show(Cursor.Position);
                }
            }
        }

        private void listDisconnected_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listDisconnected.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    //create an object that can still be accessed even after the item has been deselected (list refresh crash fix)
                    lastSelected = listDisconnected.SelectedItems[0];
                    disconnectedPlayerMenu.Show(Cursor.Position);
                }
            }
        }

        private void msiCopyGUID_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(lastSelected.SubItems[3].Text);
        }

        private void msiCopyIP_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(lastSelected.SubItems[4].Text);
        }

        private void msiCopyName_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(lastSelected.SubItems[1].Text);
        }

        private void miKick_Click(object sender, System.EventArgs e)
        {
            string message = "";

            Message_Kick modal = new Message_Kick();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                message = (modal.mtxMessage.Text == "") ? "Admin kick" : modal.mtxMessage.Text;

                if (Properties.Settings.Default.showKickAdmin)
                    message += " (" + Properties.Settings.Default.Username + ")";

                b.SendCommand("kick " + lastSelected.SubItems[0].Text + " " + message);
            }
            modal.Dispose();
        }

        private void miMessage_Click(object sender, System.EventArgs e)
        {
            string message = "(" + Properties.Settings.Default.Username + "): ";

            Message_Kick modal = new Message_Kick();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                message += modal.mtxMessage.Text;

                b.SendCommand("say " + lastSelected.SubItems[0].Text + " " + message);
            }
            modal.Dispose();
        }

        private void miBan_Click(object sender, System.EventArgs e)
        {
            string message = "";
            int time = 0;
            int timeMessage = 0;
            string mult = "";

            Ban modal = new Ban();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                message = modal.bpBanMessage.Text;
                mult = modal.bpLengthMult.Text;
                time = Convert.ToInt32(modal.bpLengthInt.Value);
                timeMessage = Convert.ToInt32(modal.bpLengthInt.Value);

                switch (mult)
                {
                    case "Minutes":
                        break;
                    case "Hours":
                        time = (time * 60);
                        break;
                    case "Days":
                        time = (time * 1440);
                        break;
                    case "Permanent":
                        time = 0;
                        break;
                    default:
                        //prevent the player from accidentally being banned forever
                        time = 5;
                        break;
                }

                message = (message == "") ? "Admin ban" : message;

                if (Properties.Settings.Default.showBanLength)
                    message += " " + timeMessage + " " + mult;

                if (Properties.Settings.Default.showBanAdmin)
                    message += " (" + Properties.Settings.Default.Username + ")";

                b.SendCommand("ban " + lastSelected.SubItems[0].Text + " " + time + " " + message);
            }
            modal.Dispose();
        }

        private void miQuickBan_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Quick Ban", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string message = Properties.Settings.Default.qbReason;
                int time = Properties.Settings.Default.qbTime;

                if (Properties.Settings.Default.showBanLength)
                    message += " " + time + " minutes";

                if (Properties.Settings.Default.showBanAdmin)
                    message += " (" + Properties.Settings.Default.Username + ")";

                b.SendCommand("ban " + lastSelected.SubItems[0].Text + " " + time + " " + message);
            }
        }
        #endregion

        /*
         * Banned List context menu handlers
         */

        #region BLIST_CNTX_HANDLE

        private void listBans_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBans.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    bannedMenu.Show(Cursor.Position);
                }
            }
        }
        private void banCopyGUIDIP_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBans.SelectedItems[0].SubItems[1].Text);
        }

        private void banUnban_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Unban", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
                b.SendCommand("removeBan " + listBans.SelectedItems[0].SubItems[0].Text);

            btnBanRefresh.PerformClick();
        }

        private void banRemoveAllExpiredBans_Click(object sender, EventArgs e)
        {
            b.SendCommand("writeBans");
        }
        #endregion

        /*
         * Server execute context menu handlers
         */
        #region EXECUTE_CNTX_HANDLE
        private void btnExecute_Click(object sender, EventArgs e)
        {
            executeMenu.Show(Cursor.Position);
        }

        private void exScripts_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Reload Scripts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("loadScripts");
            }
        }

        private void exBans_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Reload Bans", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("loadBans");
            }
        }

        private void exEvents_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Reload Events", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("loadEvents");
            }
        }

        private void exLock_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Lock Server", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("#lock");
            }
        }

        private void exUnlock_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Unlock Server", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("#unlock");
            }
        }

        private void exRestart_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Restart Server", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("#restart");
            }
        }

        private void exShutdown_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Shutdown Server", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                b.SendCommand("#shutdown");
            }
        }

        private void exAddMultipleBans_Click(object sender, EventArgs e)
        {
            string guidorip = "";
            string time = "";
            string message = "";

            Multiple_Bans modal = new Multiple_Bans();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                string inputtedLines = modal.mtxBan.Text;
                string[] lines = inputtedLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] data = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ").Split(null, 3);

                    if (data.Length >= 3)
                    {
                        /*
                         * data[0] = ban GUIDORIP
                         * data[1] = ban Time
                         * data[2] = ban Reason
                         */
                        guidorip = data[0];

                        if (data[1] == "-1") // if time -1 then change to 0, to stay uniform
                            data[1] = "0";
                        time = data[1];

                        message = (data[2] == "") ? "Admin ban" : data[2];

                        b.SendCommand("addBan " + guidorip + " " + time + " " + message);
                    }
                }
            }
            modal.Dispose();
            //btnBanRefresh.PerformClick();
            getBanList();
        }
        #endregion

        /*
         * Global say / command box
         */
        #region GB_SAY_CMD

        private void btnSay_Click(object sender, EventArgs e)
        {
            b.SendCommand(txSay.Text);
        }

        private void txSay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (isConnected && txSay.Text != "")
                {
                    if (cmdOption.SelectedIndex == 0)
                        b.SendCommand("say -1 [" + Properties.Settings.Default.Username + "]: " + txSay.Text);
                    else
                        b.SendCommand(txSay.Text);

                    txSay.Text = "";
                }
            }
        }
        #endregion

        /*
         * Server list handling
         */
        #region SRV_SAVEDATA

        private void btnSaveHost_Click(object sender, EventArgs e)
        {
            bool newServer = true;
            SaveFavorite modal = new SaveFavorite();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"servers.xml");

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node["Host"].InnerText == txHost.Text && node["Port"].InnerText == txPort.Text)
                    {
                        newServer = false;
                        DialogResult dialogResult = MessageBox.Show(txHost.Text + ":"+ txPort.Text + " already exists as " + node.Attributes["Name"].Value + ". \nDo you wish to overwrite it?", "Overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            node["Password"].InnerText = txPasswd.Text;
                            doc.Save(@"servers.xml");
                        }
                        break;
                    }
                }

                if (newServer)
                    if (modal.ShowDialog(this) == DialogResult.OK)
                        addServer(modal.mtxNickname.Text);
            }
            catch
            {
                MessageBox.Show("The server list could not be loaded");
            }

            updateServerList();
            modal.Dispose();
        }

        private void addServer(string nickname)
        {
            try
            {
                var doc = XDocument.Load(@"servers.xml");

                XElement servers = doc.Element("Servers");

                // Add child nodes
                XElement server = new XElement("Server");
                server.Add(new XAttribute("Name", nickname));
                server.Add(new XElement("Host", txHost.Text));
                server.Add(new XElement("Port", txPort.Text));
                server.Add(new XElement("Password", txPasswd.Text));

                servers.Add(server);

                servers.Save(@"servers.xml");
            }
            catch
            {
                MessageBox.Show("The server list could not be loaded");
            }
            updateServerList();
        }

        private void loadServerList()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"servers.xml");

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    listServers.Items.Add(node.Attributes["Name"].Value);
                    ServerCache.AddLast(node);
                }
            }
            catch
            {
                MessageBox.Show("The server list could not be loaded");
            }
        }

        private void btnLoadHost_Click(object sender, EventArgs e)
        {
            try
            {
                string name = listServers.SelectedItems[0].SubItems[0].Text;

                foreach (XmlNode server in ServerCache)
                {
                    if (server.Attributes["Name"].Value == name)
                    {
                        txHost.Text = server["Host"].InnerText;
                        txPort.Text = server["Port"].InnerText;
                        txPasswd.Text = server["Password"].InnerText;
                    }
                }
            }

            catch
            {
                MessageBox.Show("You have not selected a server to load from.");
            }
        }

        private void clearServerList()
        {
            ServerCache.Clear();
            listServers.Items.Clear();
        }

        private void updateServerList()
        {
            clearServerList();
            loadServerList();
        }

        private void serverRefresh_Click(object sender, EventArgs e)
        {
            updateServerList();
        }

        private void listServers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listServers.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    deleteMenu.Show(Cursor.Position);
                }
            }
        }

        private void dmDelete_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"servers.xml");

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.Attributes["Name"].Value == listServers.SelectedItems[0].SubItems[0].Text)
                    {
                        doc.DocumentElement.RemoveChild(node);
                    }
                }

                doc.Save(@"servers.xml");

                updateServerList();
            }
            catch
            {
                MessageBox.Show("The server could not be deleted");
            }
        }

        private void dmiClear_Click(object sender, EventArgs e)
        {
            this.listDisconnected.BeginInvoke((MethodInvoker)delegate() { this.listDisconnected.Items.Clear(); });
        }
        #endregion

        /*
         * Misc functions
         */
        #region SPARC_MISC
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.ShowDialog();
        }

        private void listServers_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listServers.Columns[e.ColumnIndex].Width;
        }

        private void listServers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string name = listServers.SelectedItems[0].SubItems[0].Text;

                foreach (XmlNode server in ServerCache)
                {
                    if (server.Attributes["Name"].Value == name)
                    {
                        txHost.Text = server["Host"].InnerText;
                        txPort.Text = server["Port"].InnerText;
                        txPasswd.Text = server["Password"].InnerText;
                    }
                }

                if (isConnected)
                {
                    handleDisconnect();
                    b.Disconnect();
                }
                btnConnect.PerformClick();
            }

            catch
            {
                MessageBox.Show("You have not selected a server to load from.");
            }
        }

        private void listServers_Click(object sender, EventArgs e)
        {
            try
            {
                string name = listServers.SelectedItems[0].SubItems[0].Text;

                foreach (XmlNode server in ServerCache)
                {
                    if (server.Attributes["Name"].Value == name)
                    {
                        txHost.Text = server["Host"].InnerText;
                        txPort.Text = server["Port"].InnerText;
                        txPasswd.Text = server["Password"].InnerText;
                    }
                }
            }

            catch
            {
                MessageBox.Show("You have not selected a server to load from.");
            }
        }

        private void txSay_TextChanged(object sender, EventArgs e)
        {
            charCount.Text = txSay.TextLength.ToString() + "/400";
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Length > 1)
            {
                switch (searchBox.SelectedItem.ToString().Trim())
                {
                    case "Name": // pList
                        {
                            foreach (ListViewItem item in listPlayers.Items)
                            {
                                //Selected = true, won't show until the listview has focus, but setting it to true puts it in the 
                                //SelectedItems collection.
                                if (!item.SubItems[1].Text.containsIgnoreCase(searchTextBox.Text))
                                {
                                    listPlayers.Items.Remove(item);
                                }
                            }
                            break;
                        }
                    case "GUID": // pList
                        {
                            foreach (ListViewItem item in listPlayers.Items)
                            {
                                //Selected = true, won't show until the listview has focus, but setting it to true puts it in the 
                                //SelectedItems collection.
                                if (!item.SubItems[3].Text.containsIgnoreCase(searchTextBox.Text))
                                {
                                    listPlayers.Items.Remove(item);
                                }
                            }
                            break;
                        }
                    case "IP": // pList
                        {
                            foreach (ListViewItem item in listPlayers.Items)
                            {
                                //Selected = true, won't show until the listview has focus, but setting it to true puts it in the 
                                //SelectedItems collection.
                                if (!item.SubItems[4].Text.containsIgnoreCase(searchTextBox.Text))
                                {
                                    listPlayers.Items.Remove(item);
                                }
                            }
                            break;
                        }
                    case "GUID/IP": // bList
                        {
                            foreach (ListViewItem item in listBans.Items)
                            {
                                //Selected = true, won't show until the listview has focus, but setting it to true puts it in the 
                                //SelectedItems collection.
                                if (!item.SubItems[1].Text.containsIgnoreCase(searchTextBox.Text))
                                {
                                    listBans.Items.Remove(item);
                                }
                            }
                            break;
                        }
                    case "Reason": // bList
                        {
                            foreach (ListViewItem item in listBans.Items)
                            {
                                //Selected = true, won't show until the listview has focus, but setting it to true puts it in the 
                                //SelectedItems collection.
                                if (!item.SubItems[3].Text.containsIgnoreCase(searchTextBox.Text))
                                {
                                    listBans.Items.Remove(item);
                                }
                            }
                            break;
                        }
                }
            }
            else if (searchTextBox.Text.Length == 0)
            {
                reloadPlayerList();
                updateBanList();
            }
        }

        private void tabPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabPlayer.SelectedIndex)
            {
                case 0:
                    {
                        searchBox.Items.Clear();
                        searchBox.Items.AddRange(new object[] {
                    "Name",
                    "GUID",
                    "IP"});
                        searchBox.SelectedIndex = 0;
                        break;
                    }

                case 1:
                    {
                        searchBox.Items.Clear();
                        searchBox.Items.AddRange(new object[] {
                    "GUID/IP",
                    "Reason"});
                        searchBox.SelectedIndex = 0;
                        break;
                    }
            }
        }

        private void autoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRefresh.Checked)
                enableRefreshManual();
            else
                refreshTimer.Stop();
        }

        private void enableRefreshManual()
        {
            refreshTimer = new Timer();
            refreshTimer.Tick += new EventHandler(refreshTimer_Tick);
            refreshTimer.Interval = Properties.Settings.Default.qbRefreshInterval * 1000;
            refreshTimer.Start();

            string text = "Auto refresh interval set to " + Properties.Settings.Default.qbRefreshInterval + " seconds.";
            txAll.SelectionColor = Color.Black;
            txAll.SelectionFont = new Font("Lucida Console", 8);
            txConsole.SelectionColor = Color.Black;
            txConsole.SelectionFont = new Font("Lucida Console", 8);
            txAll.AppendText("\n" + text);
            txConsole.AppendText("\n" + text);
        }
        #endregion
    }
}