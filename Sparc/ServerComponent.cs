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

namespace Sparc
{
    public partial class ServerComponent : UserControl
    {
        BattlEyeClient b;
        BattlEyeLoginCredentials loginCredentials;

        private bool isConnected;

        private LinkedList<Player> PlayerCache = new LinkedList<Player>();
        private LinkedList<BannedPlayer> BanCache = new LinkedList<BannedPlayer>();
        private LinkedList<Admin> AdminCache = new LinkedList<Admin>();
        private LinkedList<XmlNode> ServerCache = new LinkedList<XmlNode>();

        private Sort plSorter;
        private Sort slSorter;

        private Timer refreshTimer;
        private Timer cooldownTimer;

        public ServerComponent()
        {
            InitializeComponent();
        }

        private void ServerComponent_Load(object sender, EventArgs e)
        {
            cmdOption.SelectedIndex = 0;

            plSorter = new Sort();
            slSorter = new Sort();
            this.listPlayers.ListViewItemSorter = plSorter;
            this.listServers.ListViewItemSorter = slSorter;
            searchBox.SelectedIndex = 0;
            cooldownTimer = new Timer();
            cooldownTimer.Tick += new EventHandler(cooldownTimer_Tick);
            cooldownTimer.Enabled = false;
            txAll.AppendText("Sparc " + Globals.sparcVersion + " initialized!\n");
            txConsole.AppendText("Sparc " + Globals.sparcVersion + " initialized!\n");
            txChat.AppendText("Sparc " + Globals.sparcVersion + " initialized!\n");

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
            btnExecute.Enabled = true;
            btnPlayerRefresh.Enabled = true;
            btnBanRefresh.Enabled = true;
            txSay.Enabled = true;

            getPlayerandAdminList();

            await Task.Delay(1000);
            playerCount.Text = listPlayers.Items.Count.ToString();
            adminCount.Text = listAdmins.Items.Count.ToString();
            if (Properties.Settings.Default.RefreshPlayerChange)
            {
                cooldownTimer.Interval = 5000; // 5 seconds should be enough for the first interval, don't want two refreshes going on at connect!
                cooldownTimer.Start();
            }
            if (Properties.Settings.Default.loadBanConnect)
            {
                btnBanRefresh.PerformClick();
            }

            if (Properties.Settings.Default.autoRefresh)
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
            playerCount.Text = listPlayers.Items.Count.ToString();
            adminCount.Text = listAdmins.Items.Count.ToString();
            banCount.Text = listBans.Items.Count.ToString();

            if (Properties.Settings.Default.autoRefresh)
            {
                refreshTimer.Stop();
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            btnBanRefresh.PerformClick();
            btnPlayerRefresh.PerformClick();
        }

        #endregion

        /*
         * MAIN BATTLEYE CALLBACK FUNCTIONS
         */
        #region BE_INTF_MAIN

        private void BattlEyeConnected(BattlEyeConnectEventArgs args)
        {
            bool connected = false;
            if (args.ConnectionResult == BattlEyeConnectionResult.Success) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection successful!"); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Connection successful!"); connected = true; }); }
            if (args.ConnectionResult == BattlEyeConnectionResult.InvalidLogin) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Invalid login details!"); this.txConsole.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Invalid login details!"); }); }
            if (args.ConnectionResult == BattlEyeConnectionResult.ConnectionFailed) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connection failed!"); this.txConsole.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connection failed!"); }); }

            if (connected)
                this.Invoke((MethodInvoker)delegate() { handleConnect(); });
            else
                this.Invoke((MethodInvoker)delegate() { handleDisconnect(); });
        }

        private void BattlEyeDisconnected(BattlEyeDisconnectEventArgs args)
        {
            if (args.DisconnectionType == BattlEyeDisconnectionType.ConnectionLost) { this.Invoke((MethodInvoker)delegate() { this.BeginInvoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connection lost (timeout). Attempting to reconnect."); this.txConsole.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connection lost (timeout). Attempting to reconnect."); }); }); };
            if (args.DisconnectionType == BattlEyeDisconnectionType.SocketException) { this.Invoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connection closed (socket error)"); this.txConsole.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connection closed (socket error)"); }); }
            //if (args.DisconnectionType == BattlEyeDisconnectionType.Manual) { /* Disconnected by implementing application, that would be you */ }

            this.BeginInvoke((MethodInvoker)delegate() { this.txAll.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Disconnected."); this.txConsole.AppendText(DateTime.Now.ToString("\n[dd MMM, yyyy | HH:mm:ss] ") + "Disconnected."); });
            this.Invoke((MethodInvoker)delegate() { handleDisconnect(); });
        }

        private void BattlEyeMessageReceived(BattlEyeMessageEventArgs args)
        {
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
            txAll.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connecting to " + txHost.Text + " (" + Dns.GetHostAddresses(txHost.Text)[0] + ")");
            txConsole.AppendText(DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + "Connecting to " + txHost.Text + " (" + Dns.GetHostAddresses(txHost.Text)[0] + ")");

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
                        btnPlayerRefresh.PerformClick();
                    }
                }
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
            }
            if (text.containsIgnoreCase(Properties.Settings.Default.Username) && Properties.Settings.Default.flashOnCall)
            {
                Flash.FlashWindowEx(this.ParentForm);
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
            clearPlayerList();
            string[] lines = list.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                Player p = parsePlayer(line);

                if (p != null)
                    PlayerCache.AddLast(p);
            }

            updatePlayerList();
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

                p = new Player(data[0], ip, data[2], data[3], data[4], lobby);
            }
            return p;
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

        private void getPlayerandAdminList()
        {
            clearPlayerList();
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

        private void updatePlayerList()
        {
            this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Clear(); });

            foreach (Player p in PlayerCache)
                this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Add(new ListViewItem(p.getPlayerInfo())); });
        }

        private void updateBanList()
        {
            //cleanCache();
            this.listBans.BeginInvoke((MethodInvoker)delegate() { this.listBans.Items.Clear(); });

            foreach (BannedPlayer p in BanCache)
                this.listBans.BeginInvoke((MethodInvoker)delegate() { this.listBans.Items.Add(new ListViewItem(p.getPlayerInfo())); });
        }

        private void updateAdminList()
        {
            //cleanCache();

            foreach (Admin p in AdminCache)
                this.listAdmins.BeginInvoke((MethodInvoker)delegate() { this.listAdmins.Items.Add(new ListViewItem(p.getPlayerInfo())); });
        }

        /*private void cleanCache()
        {
            foreach(Player p in PlayerCache)
                if (playerCached(p))
                    PlayerCache.Remove(p);
        }

        private bool playerCached(Player p)
        {
            bool isCached = false;

            foreach(Player player in PlayerCache)
            {
                if (player.getPlayerGuid() == p.getPlayerGuid())
                    isCached = true;
            }

            return isCached;
        }*/

        private async void btnPlayerRefresh_Click(object sender, EventArgs e)
        {
            getPlayerandAdminList();

            string text = "Refreshing players...";
            txAll.SelectionColor = Color.Black;
            txAll.SelectionFont = new Font("Lucida Console", 8);
            txAll.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            txConsole.SelectionColor = Color.Black;
            txConsole.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            txConsole.SelectionFont = new Font("Lucida Console", 8);

            await Task.Delay(1000);
            playerCount.Text = listPlayers.Items.Count.ToString();
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
                    playerMenu.Show(Cursor.Position);
                }
            }
        }

        private void msiCopyGUID_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(listPlayers.SelectedItems[0].SubItems[3].Text);
        }

        private void msiCopyIP_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(listPlayers.SelectedItems[0].SubItems[4].Text);
        }

        private void msiCopyName_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(listPlayers.SelectedItems[0].SubItems[1].Text);
        }

        private void miKick_Click(object sender, System.EventArgs e)
        {
            string message = "";

            Message_Kick modal = new Message_Kick();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                message = modal.mtxMessage.Text;
            }
            modal.Dispose();

            message = (message == "") ? "Admin kick" : message;

            if (Properties.Settings.Default.showKickAdmin)
                message += " (" + Properties.Settings.Default.Username + ")";

            b.SendCommand("kick " + listPlayers.SelectedItems[0].SubItems[0].Text + " " + message);
        }

        private void miMessage_Click(object sender, System.EventArgs e)
        {
            string message = "(" + Properties.Settings.Default.Username + "): ";

            Message_Kick modal = new Message_Kick();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                message += modal.mtxMessage.Text;
            }
            modal.Dispose();

            b.SendCommand("say " + listPlayers.SelectedItems[0].SubItems[0].Text + " " + message);
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

                b.SendCommand("ban " + listPlayers.SelectedItems[0].SubItems[0].Text + " " + time + " " + message);
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

                b.SendCommand("ban " + listPlayers.SelectedItems[0].SubItems[0].Text + " " + time + " " + message);
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
            b.SendCommand("loadScripts");
        }

        private void exBans_Click(object sender, System.EventArgs e)
        {
            b.SendCommand("loadBans");
        }

        private void exEvents_Click(object sender, System.EventArgs e)
        {
            b.SendCommand("loadEvents");
        }

        private void exLock_Click(object sender, System.EventArgs e)
        {
            b.SendCommand("#lock");
        }

        private void exUnlock_Click(object sender, System.EventArgs e)
        {
            b.SendCommand("#unlock");
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
            string nickname = "";
            SaveFavorite modal = new SaveFavorite();

            if (modal.ShowDialog(this) == DialogResult.OK)
            {
                nickname = modal.mtxNickname.Text;

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
            modal.Dispose();
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
        #endregion

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
            btnBanRefresh.PerformClick();
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

        /*private void searchTextBox_TextChanged(object sender, EventArgs e) // UNFINISHED FILTER FOR LISTS
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
                updatePlayerList();
                updateBanList();
            }
        }*/
    }
}