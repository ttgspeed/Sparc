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

namespace Sparc
{
    public partial class ServerComponent : UserControl
    {
        BattlEyeClient b;
        BattlEyeLoginCredentials loginCredentials;

        private bool isConnected;

        private LinkedList<Player> PlayerCache = new LinkedList<Player>();
        private LinkedList<XmlNode> ServerCache = new LinkedList<XmlNode>();

        private Sort plSorter;

        public ServerComponent()
        {
            InitializeComponent();
        }

        private void ServerComponent_Load(object sender, EventArgs e)
        {
            cmdOption.SelectedIndex = 0;

            plSorter = new Sort();
            this.listPlayers.ListViewItemSorter = plSorter;

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

        private void handleConnect()
        {
            isConnected = true;
            btnConnect.Text = "Disconnect";
            this.Parent.Text = txHost.Text;
            btnExecute.Enabled = true;
            btnRefresh.Enabled = true;
            txSay.Enabled = true;

            getPlayerList();
        }

        private void handleDisconnect()
        {
            clearPlayerList();
            isConnected = false;
            btnConnect.Text = "Connect";
            btnExecute.Enabled = false;
            btnRefresh.Enabled = false;
            txSay.Enabled = false;
        }
        #endregion

        /*
         * MAIN BATTLEYE CALLBACK FUNCTIONS
         */
        #region BE_INTF_MAIN

        private void BattlEyeConnected(BattlEyeConnectEventArgs args)
        {
            bool connected = false;
            if (args.ConnectionResult == BattlEyeConnectionResult.Success) { this.Invoke((MethodInvoker)delegate() { appendChat("Connection successful\n", Color.Black); connected = true; }); }
            if (args.ConnectionResult == BattlEyeConnectionResult.InvalidLogin) { this.Invoke((MethodInvoker)delegate() { appendChat("Invalid login details\n", Color.Black); }); }
            if (args.ConnectionResult == BattlEyeConnectionResult.ConnectionFailed) { this.Invoke((MethodInvoker)delegate() { appendChat("Connection failed\n", Color.Black); }); }

            if(connected)
                this.Invoke((MethodInvoker)delegate() { handleConnect(); });
            else
                this.Invoke((MethodInvoker)delegate() { handleDisconnect(); });
        }

        private void BattlEyeDisconnected(BattlEyeDisconnectEventArgs args)
        {
            if (args.DisconnectionType == BattlEyeDisconnectionType.ConnectionLost) { this.Invoke((MethodInvoker)delegate() { this.BeginInvoke((MethodInvoker)delegate() { appendChat("Connection lost (timeout). Attempting to reconnect.\n", Color.Black); }); }); };
            if (args.DisconnectionType == BattlEyeDisconnectionType.SocketException) { this.Invoke((MethodInvoker)delegate() { appendChat("Connection closed (socket error)\n", Color.Black); }); }
            //if (args.DisconnectionType == BattlEyeDisconnectionType.Manual) { /* Disconnected by implementing application, that would be you */ }

            this.BeginInvoke((MethodInvoker)delegate() { this.txAll.AppendText("\n" + args.Message + "\n"); });
            this.Invoke((MethodInvoker)delegate() { handleDisconnect(); });
        }

        private void BattlEyeMessageReceived(BattlEyeMessageEventArgs args)
        {
            if (args.Message.Contains("[#] [IP Address]:[Port] [Ping] [GUID] [Name]"))
            {
                parsePlayerList(args.Message);
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

            txAll.AppendText(txHost.Text+" ("+Dns.GetHostAddresses(txHost.Text)[0] + ")\n");

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
                appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.DodgerBlue);
            }
            else if (text.Contains("(Unknown)"))
            {
                appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.MediumPurple);
            }
            else if (text.Contains("(Group)"))
            {
                appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.ForestGreen);
            }
            else if (text.Contains("(Vehicle)"))
            {
                appendChat("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text, Color.DarkOrange);
            }
            else
            {
                txAll.SelectionColor = Color.Black;
                txAll.SelectionFont = new Font("Lucida Console", 8);
                txAll.AppendText("\n" + DateTime.Now.ToString("[dd MMM, yyyy | HH:mm:ss] ") + text);
            }
        }

        private void chatAlert(string text)
        {
            if (stringContains(text, "admin") && Properties.Settings.Default.flashOnCall)
            {
                Flash.FlashWindowEx(this.ParentForm);
            }
            if (stringContains(text, Properties.Settings.Default.Username) && Properties.Settings.Default.flashOnCall)
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
         * Player list handlers
         */
        #region PLIST_HANDLE

        private void parsePlayerList(string list)
        {
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

        private void getPlayerList()
        {
            clearPlayerList();
            b.SendCommand("players");
        }

        private void clearPlayerList()
        {
            PlayerCache.Clear();
            this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Clear(); });
        }

        private void updatePlayerList()
        {
            //cleanCache();

            foreach (Player p in PlayerCache)
            {
                this.listPlayers.BeginInvoke((MethodInvoker)delegate() { this.listPlayers.Items.Add(new ListViewItem(p.getPlayerInfo())); });
            }

            this.listPlayers.BeginInvoke((MethodInvoker)delegate() { listPlayers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); });
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getPlayerList();
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
            }
            modal.Dispose();

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

            b.SendCommand("ban " + listPlayers.SelectedItems[0].SubItems[0].Text + " "+ time + " " + message);
        }

        private void miQuickBan_Click(object sender, System.EventArgs e)
        {
            string message = Properties.Settings.Default.qbReason;
            int time = Properties.Settings.Default.qbTime;

            if (Properties.Settings.Default.showBanLength)
                message += " " + time + " minutes";

            if (Properties.Settings.Default.showBanAdmin)
                message += " (" + Properties.Settings.Default.Username + ")";

            b.SendCommand("ban " + listPlayers.SelectedItems[0].SubItems[0].Text + " " + time + " " + message);
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
            b.SendCommand("bans");
        }

        private void exEvents_Click(object sender, System.EventArgs e)
        {
            b.SendCommand("loadEvents");
        }

        private void exLock_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void exUnlock_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void exRestart_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void exShutdown_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Not implemented");
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
                if (isConnected && txSay.Text != "")
                {
                    if (cmdOption.SelectedIndex == 0)
                        b.SendCommand("say -1 (" + Properties.Settings.Default.Username + "): "+txSay.Text);
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
            }
            modal.Dispose();

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
            string name = listServers.SelectedItems[0].SubItems[0].Text;
            foreach (XmlNode server in ServerCache)
            {
                if(server.Attributes["Name"].Value == name)
                {
                    txHost.Text = server["Host"].InnerText;
                    txPort.Text = server["Port"].InnerText;
                    txPasswd.Text = server["Password"].InnerText;
                }
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
            st.Show();
        }

        public static bool stringContains(string source, string toCheck)
        {
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private string getTimestamp()
        {
            return "[dd MMM, yyyy | HH:mm:ss] ";
        }
    }
}
