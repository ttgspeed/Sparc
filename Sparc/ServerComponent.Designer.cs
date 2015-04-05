namespace Sparc
{
    partial class ServerComponent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdOption = new System.Windows.Forms.ComboBox();
            this.autoRefresh = new System.Windows.Forms.CheckBox();
            this.autoScroll = new System.Windows.Forms.CheckBox();
            this.txSay = new System.Windows.Forms.TextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnSaveHost = new System.Windows.Forms.Button();
            this.btnLoadHost = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txPasswd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txHost = new System.Windows.Forms.TextBox();
            this.chatTabs = new System.Windows.Forms.TabControl();
            this.tabAll = new System.Windows.Forms.TabPage();
            this.txAll = new System.Windows.Forms.RichTextBox();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.txChat = new System.Windows.Forms.RichTextBox();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.txConsole = new System.Windows.Forms.RichTextBox();
            this.tabPlayer = new System.Windows.Forms.TabControl();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.listPlayers = new System.Windows.Forms.ListView();
            this.columnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBans = new System.Windows.Forms.TabPage();
            this.listBans = new System.Windows.Forms.ListView();
            this.playerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCopyGUID = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCopyIP = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.miMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.miKick = new System.Windows.Forms.ToolStripMenuItem();
            this.miBan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miQuickBan = new System.Windows.Forms.ToolStripMenuItem();
            this.executeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.exBans = new System.Windows.Forms.ToolStripMenuItem();
            this.exEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exLock = new System.Windows.Forms.ToolStripMenuItem();
            this.exUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.exRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.exShutdown = new System.Windows.Forms.ToolStripMenuItem();
            this.listServers = new System.Windows.Forms.ListView();
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverRefresh = new System.Windows.Forms.Button();
            this.deleteMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.chatTabs.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabPlayer.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.tabBans.SuspendLayout();
            this.playerMenu.SuspendLayout();
            this.executeMenu.SuspendLayout();
            this.deleteMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOption
            // 
            this.cmdOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdOption.FormattingEnabled = true;
            this.cmdOption.Items.AddRange(new object[] {
            "Say (Global)",
            "Command"});
            this.cmdOption.Location = new System.Drawing.Point(192, 537);
            this.cmdOption.Name = "cmdOption";
            this.cmdOption.Size = new System.Drawing.Size(121, 21);
            this.cmdOption.TabIndex = 58;
            // 
            // autoRefresh
            // 
            this.autoRefresh.AutoSize = true;
            this.autoRefresh.Checked = true;
            this.autoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRefresh.Location = new System.Drawing.Point(1191, 539);
            this.autoRefresh.Name = "autoRefresh";
            this.autoRefresh.Size = new System.Drawing.Size(88, 17);
            this.autoRefresh.TabIndex = 57;
            this.autoRefresh.Text = "Auto Refresh";
            this.autoRefresh.UseVisualStyleBackColor = true;
            // 
            // autoScroll
            // 
            this.autoScroll.AutoSize = true;
            this.autoScroll.Checked = true;
            this.autoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScroll.Location = new System.Drawing.Point(1095, 539);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(77, 17);
            this.autoScroll.TabIndex = 56;
            this.autoScroll.Text = "Auto Scroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            // 
            // txSay
            // 
            this.txSay.Enabled = false;
            this.txSay.Location = new System.Drawing.Point(319, 537);
            this.txSay.Name = "txSay";
            this.txSay.Size = new System.Drawing.Size(770, 20);
            this.txSay.TabIndex = 55;
            this.txSay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txSay_KeyDown);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(3, 501);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(160, 23);
            this.btnSettings.TabIndex = 54;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSaveHost
            // 
            this.btnSaveHost.Location = new System.Drawing.Point(88, 241);
            this.btnSaveHost.Name = "btnSaveHost";
            this.btnSaveHost.Size = new System.Drawing.Size(75, 23);
            this.btnSaveHost.TabIndex = 53;
            this.btnSaveHost.Text = "Save";
            this.btnSaveHost.UseVisualStyleBackColor = true;
            this.btnSaveHost.Click += new System.EventHandler(this.btnSaveHost_Click);
            // 
            // btnLoadHost
            // 
            this.btnLoadHost.Location = new System.Drawing.Point(3, 241);
            this.btnLoadHost.Name = "btnLoadHost";
            this.btnLoadHost.Size = new System.Drawing.Size(75, 23);
            this.btnLoadHost.TabIndex = 52;
            this.btnLoadHost.Text = "Load";
            this.btnLoadHost.UseVisualStyleBackColor = true;
            this.btnLoadHost.Click += new System.EventHandler(this.btnLoadHost_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(3, 472);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(160, 23);
            this.btnExecute.TabIndex = 51;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(3, 443);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 23);
            this.btnRefresh.TabIndex = 50;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(3, 414);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 23);
            this.btnConnect.TabIndex = 49;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Password";
            // 
            // txPasswd
            // 
            this.txPasswd.Location = new System.Drawing.Point(3, 388);
            this.txPasswd.Name = "txPasswd";
            this.txPasswd.PasswordChar = '*';
            this.txPasswd.Size = new System.Drawing.Size(160, 20);
            this.txPasswd.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Port";
            // 
            // txPort
            // 
            this.txPort.Location = new System.Drawing.Point(3, 338);
            this.txPort.Name = "txPort";
            this.txPort.Size = new System.Drawing.Size(160, 20);
            this.txPort.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Host";
            // 
            // txHost
            // 
            this.txHost.Location = new System.Drawing.Point(3, 288);
            this.txHost.Name = "txHost";
            this.txHost.Size = new System.Drawing.Size(160, 20);
            this.txHost.TabIndex = 43;
            // 
            // chatTabs
            // 
            this.chatTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.chatTabs.Controls.Add(this.tabAll);
            this.chatTabs.Controls.Add(this.tabChat);
            this.chatTabs.Controls.Add(this.tabConsole);
            this.chatTabs.Location = new System.Drawing.Point(169, 311);
            this.chatTabs.Multiline = true;
            this.chatTabs.Name = "chatTabs";
            this.chatTabs.SelectedIndex = 0;
            this.chatTabs.Size = new System.Drawing.Size(1110, 217);
            this.chatTabs.TabIndex = 41;
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.txAll);
            this.tabAll.Location = new System.Drawing.Point(23, 4);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(1083, 209);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            this.tabAll.UseVisualStyleBackColor = true;
            // 
            // txAll
            // 
            this.txAll.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAll.Location = new System.Drawing.Point(3, 3);
            this.txAll.Name = "txAll";
            this.txAll.ReadOnly = true;
            this.txAll.Size = new System.Drawing.Size(1077, 203);
            this.txAll.TabIndex = 0;
            this.txAll.Text = "";
            this.txAll.TextChanged += new System.EventHandler(this.txAll_TextChanged);
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.txChat);
            this.tabChat.Location = new System.Drawing.Point(23, 4);
            this.tabChat.Name = "tabChat";
            this.tabChat.Size = new System.Drawing.Size(1083, 209);
            this.tabChat.TabIndex = 2;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // txChat
            // 
            this.txChat.Location = new System.Drawing.Point(3, 3);
            this.txChat.Name = "txChat";
            this.txChat.ReadOnly = true;
            this.txChat.Size = new System.Drawing.Size(1077, 203);
            this.txChat.TabIndex = 1;
            this.txChat.Text = "";
            this.txChat.TextChanged += new System.EventHandler(this.txChat_TextChanged);
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.txConsole);
            this.tabConsole.Location = new System.Drawing.Point(23, 4);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(1083, 209);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txConsole
            // 
            this.txConsole.Location = new System.Drawing.Point(3, 3);
            this.txConsole.Name = "txConsole";
            this.txConsole.ReadOnly = true;
            this.txConsole.Size = new System.Drawing.Size(1077, 203);
            this.txConsole.TabIndex = 0;
            this.txConsole.Text = "";
            this.txConsole.TextChanged += new System.EventHandler(this.txConsole_TextChanged);
            // 
            // tabPlayer
            // 
            this.tabPlayer.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabPlayer.Controls.Add(this.tabPlayers);
            this.tabPlayer.Controls.Add(this.tabBans);
            this.tabPlayer.Location = new System.Drawing.Point(169, 6);
            this.tabPlayer.Multiline = true;
            this.tabPlayer.Name = "tabPlayer";
            this.tabPlayer.SelectedIndex = 0;
            this.tabPlayer.Size = new System.Drawing.Size(1111, 299);
            this.tabPlayer.TabIndex = 40;
            // 
            // tabPlayers
            // 
            this.tabPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPlayers.Controls.Add(this.listPlayers);
            this.tabPlayers.Location = new System.Drawing.Point(23, 4);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(1084, 291);
            this.tabPlayers.TabIndex = 0;
            this.tabPlayers.Text = "Players";
            this.tabPlayers.UseVisualStyleBackColor = true;
            // 
            // listPlayers
            // 
            this.listPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumber,
            this.columnName,
            this.columnStatus,
            this.columnGUID,
            this.columnIP,
            this.columnPing});
            this.listPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPlayers.FullRowSelect = true;
            this.listPlayers.GridLines = true;
            this.listPlayers.HideSelection = false;
            this.listPlayers.Location = new System.Drawing.Point(3, 3);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(1076, 283);
            this.listPlayers.TabIndex = 0;
            this.listPlayers.UseCompatibleStateImageBehavior = false;
            this.listPlayers.View = System.Windows.Forms.View.Details;
            this.listPlayers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listPlayers_ColumnClick);
            this.listPlayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listPlayers_MouseClick);
            // 
            // columnNumber
            // 
            this.columnNumber.Text = "#";
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 171;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 158;
            // 
            // columnGUID
            // 
            this.columnGUID.Text = "GUID";
            this.columnGUID.Width = 307;
            // 
            // columnIP
            // 
            this.columnIP.Text = "IP";
            this.columnIP.Width = 85;
            // 
            // columnPing
            // 
            this.columnPing.Text = "Ping";
            this.columnPing.Width = 51;
            // 
            // tabBans
            // 
            this.tabBans.Controls.Add(this.listBans);
            this.tabBans.Location = new System.Drawing.Point(23, 4);
            this.tabBans.Name = "tabBans";
            this.tabBans.Padding = new System.Windows.Forms.Padding(3);
            this.tabBans.Size = new System.Drawing.Size(1084, 291);
            this.tabBans.TabIndex = 1;
            this.tabBans.Text = "Bans";
            this.tabBans.UseVisualStyleBackColor = true;
            // 
            // listBans
            // 
            this.listBans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBans.HideSelection = false;
            this.listBans.Location = new System.Drawing.Point(3, 3);
            this.listBans.Name = "listBans";
            this.listBans.Size = new System.Drawing.Size(1078, 285);
            this.listBans.TabIndex = 1;
            this.listBans.UseCompatibleStateImageBehavior = false;
            // 
            // playerMenu
            // 
            this.playerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCopy,
            this.miMessage,
            this.miKick,
            this.miBan,
            this.toolStripSeparator2,
            this.miQuickBan});
            this.playerMenu.Name = "playerMenu";
            this.playerMenu.Size = new System.Drawing.Size(129, 120);
            // 
            // miCopy
            // 
            this.miCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiCopyGUID,
            this.msiCopyIP,
            this.msiCopyName});
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(128, 22);
            this.miCopy.Text = "Copy";
            // 
            // msiCopyGUID
            // 
            this.msiCopyGUID.Name = "msiCopyGUID";
            this.msiCopyGUID.Size = new System.Drawing.Size(106, 22);
            this.msiCopyGUID.Text = "GUID";
            this.msiCopyGUID.Click += new System.EventHandler(this.msiCopyGUID_Click);
            // 
            // msiCopyIP
            // 
            this.msiCopyIP.Name = "msiCopyIP";
            this.msiCopyIP.Size = new System.Drawing.Size(106, 22);
            this.msiCopyIP.Text = "IP";
            this.msiCopyIP.Click += new System.EventHandler(this.msiCopyIP_Click);
            // 
            // msiCopyName
            // 
            this.msiCopyName.Name = "msiCopyName";
            this.msiCopyName.Size = new System.Drawing.Size(106, 22);
            this.msiCopyName.Text = "Name";
            this.msiCopyName.Click += new System.EventHandler(this.msiCopyName_Click);
            // 
            // miMessage
            // 
            this.miMessage.Name = "miMessage";
            this.miMessage.Size = new System.Drawing.Size(128, 22);
            this.miMessage.Text = "Message";
            this.miMessage.Click += new System.EventHandler(this.miMessage_Click);
            // 
            // miKick
            // 
            this.miKick.Name = "miKick";
            this.miKick.Size = new System.Drawing.Size(128, 22);
            this.miKick.Text = "Kick";
            this.miKick.Click += new System.EventHandler(this.miKick_Click);
            // 
            // miBan
            // 
            this.miBan.Name = "miBan";
            this.miBan.Size = new System.Drawing.Size(128, 22);
            this.miBan.Text = "Ban";
            this.miBan.Click += new System.EventHandler(this.miBan_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // miQuickBan
            // 
            this.miQuickBan.BackColor = System.Drawing.Color.Red;
            this.miQuickBan.ForeColor = System.Drawing.SystemColors.Control;
            this.miQuickBan.Name = "miQuickBan";
            this.miQuickBan.Size = new System.Drawing.Size(128, 22);
            this.miQuickBan.Text = "Quick Ban";
            this.miQuickBan.Click += new System.EventHandler(this.miQuickBan_Click);
            // 
            // executeMenu
            // 
            this.executeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exScripts,
            this.exBans,
            this.exEvents,
            this.toolStripSeparator1,
            this.exLock,
            this.exUnlock,
            this.exRestart,
            this.exShutdown});
            this.executeMenu.Name = "executeMenu";
            this.executeMenu.Size = new System.Drawing.Size(164, 164);
            // 
            // exScripts
            // 
            this.exScripts.Name = "exScripts";
            this.exScripts.Size = new System.Drawing.Size(163, 22);
            this.exScripts.Text = "Reload Scripts";
            this.exScripts.Click += new System.EventHandler(this.exScripts_Click);
            // 
            // exBans
            // 
            this.exBans.Name = "exBans";
            this.exBans.Size = new System.Drawing.Size(163, 22);
            this.exBans.Text = "Reload Bans";
            this.exBans.Click += new System.EventHandler(this.exBans_Click);
            // 
            // exEvents
            // 
            this.exEvents.Name = "exEvents";
            this.exEvents.Size = new System.Drawing.Size(163, 22);
            this.exEvents.Text = "Reload Events";
            this.exEvents.Click += new System.EventHandler(this.exEvents_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // exLock
            // 
            this.exLock.Name = "exLock";
            this.exLock.Size = new System.Drawing.Size(163, 22);
            this.exLock.Text = "Lock Server";
            this.exLock.Click += new System.EventHandler(this.exLock_Click);
            // 
            // exUnlock
            // 
            this.exUnlock.Name = "exUnlock";
            this.exUnlock.Size = new System.Drawing.Size(163, 22);
            this.exUnlock.Text = "Unlock Server";
            this.exUnlock.Click += new System.EventHandler(this.exUnlock_Click);
            // 
            // exRestart
            // 
            this.exRestart.Name = "exRestart";
            this.exRestart.Size = new System.Drawing.Size(163, 22);
            this.exRestart.Text = "Restart Server";
            this.exRestart.Click += new System.EventHandler(this.exRestart_Click);
            // 
            // exShutdown
            // 
            this.exShutdown.Name = "exShutdown";
            this.exShutdown.Size = new System.Drawing.Size(163, 22);
            this.exShutdown.Text = "Shutdown Server";
            this.exShutdown.Click += new System.EventHandler(this.exShutdown_Click);
            // 
            // listServers
            // 
            this.listServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnServer});
            this.listServers.Location = new System.Drawing.Point(3, 10);
            this.listServers.Name = "listServers";
            this.listServers.Size = new System.Drawing.Size(160, 195);
            this.listServers.TabIndex = 59;
            this.listServers.UseCompatibleStateImageBehavior = false;
            this.listServers.View = System.Windows.Forms.View.Details;
            this.listServers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listServers_MouseClick);
            // 
            // columnServer
            // 
            this.columnServer.Text = "Server";
            // 
            // serverRefresh
            // 
            this.serverRefresh.Location = new System.Drawing.Point(3, 212);
            this.serverRefresh.Name = "serverRefresh";
            this.serverRefresh.Size = new System.Drawing.Size(160, 23);
            this.serverRefresh.TabIndex = 60;
            this.serverRefresh.Text = "Refresh Server List";
            this.serverRefresh.UseVisualStyleBackColor = true;
            this.serverRefresh.Click += new System.EventHandler(this.serverRefresh_Click);
            // 
            // deleteMenu
            // 
            this.deleteMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dmDelete});
            this.deleteMenu.Name = "deleteMenu";
            this.deleteMenu.Size = new System.Drawing.Size(143, 26);
            // 
            // dmDelete
            // 
            this.dmDelete.Name = "dmDelete";
            this.dmDelete.Size = new System.Drawing.Size(142, 22);
            this.dmDelete.Text = "Delete Server";
            this.dmDelete.Click += new System.EventHandler(this.dmDelete_Click);
            // 
            // ServerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.serverRefresh);
            this.Controls.Add(this.listServers);
            this.Controls.Add(this.cmdOption);
            this.Controls.Add(this.autoRefresh);
            this.Controls.Add(this.autoScroll);
            this.Controls.Add(this.txSay);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnSaveHost);
            this.Controls.Add(this.btnLoadHost);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txPasswd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txHost);
            this.Controls.Add(this.chatTabs);
            this.Controls.Add(this.tabPlayer);
            this.Name = "ServerComponent";
            this.Size = new System.Drawing.Size(1284, 564);
            this.Load += new System.EventHandler(this.ServerComponent_Load);
            this.HandleDestroyed += new System.EventHandler(this.FormClosing);
            this.chatTabs.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabPlayer.ResumeLayout(false);
            this.tabPlayers.ResumeLayout(false);
            this.tabBans.ResumeLayout(false);
            this.playerMenu.ResumeLayout(false);
            this.executeMenu.ResumeLayout(false);
            this.deleteMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmdOption;
        private System.Windows.Forms.CheckBox autoRefresh;
        private System.Windows.Forms.CheckBox autoScroll;
        private System.Windows.Forms.TextBox txSay;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSaveHost;
        private System.Windows.Forms.Button btnLoadHost;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txPasswd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txHost;
        private System.Windows.Forms.TabControl chatTabs;
        private System.Windows.Forms.TabPage tabAll;
        private System.Windows.Forms.RichTextBox txAll;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.RichTextBox txChat;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.RichTextBox txConsole;
        private System.Windows.Forms.TabControl tabPlayer;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.ListView listPlayers;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnGUID;
        private System.Windows.Forms.ColumnHeader columnIP;
        private System.Windows.Forms.ColumnHeader columnPing;
        private System.Windows.Forms.TabPage tabBans;
        private System.Windows.Forms.ListView listBans;
        private System.Windows.Forms.ContextMenuStrip playerMenu;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem msiCopyGUID;
        private System.Windows.Forms.ToolStripMenuItem msiCopyIP;
        private System.Windows.Forms.ToolStripMenuItem msiCopyName;
        private System.Windows.Forms.ToolStripMenuItem miMessage;
        private System.Windows.Forms.ToolStripMenuItem miKick;
        private System.Windows.Forms.ToolStripMenuItem miBan;
        private System.Windows.Forms.ContextMenuStrip executeMenu;
        private System.Windows.Forms.ToolStripMenuItem exScripts;
        private System.Windows.Forms.ToolStripMenuItem exBans;
        private System.Windows.Forms.ToolStripMenuItem exEvents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exLock;
        private System.Windows.Forms.ToolStripMenuItem exUnlock;
        private System.Windows.Forms.ToolStripMenuItem exRestart;
        private System.Windows.Forms.ToolStripMenuItem exShutdown;
        private System.Windows.Forms.ListView listServers;
        private System.Windows.Forms.ColumnHeader columnServer;
        private System.Windows.Forms.Button serverRefresh;
        private System.Windows.Forms.ContextMenuStrip deleteMenu;
        private System.Windows.Forms.ToolStripMenuItem dmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miQuickBan;
    }
}
