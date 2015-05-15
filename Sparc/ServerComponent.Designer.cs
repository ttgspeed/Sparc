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
            this.btnPlayerRefresh = new System.Windows.Forms.Button();
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
            this.columnbanNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGUIDIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMinutesLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAdmins = new System.Windows.Forms.TabPage();
            this.listAdmins = new System.Windows.Forms.ListView();
            this.adminNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adminIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDisconnected = new System.Windows.Forms.TabPage();
            this.listDisconnected = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCopyGUID = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCopyIP = new System.Windows.Forms.ToolStripMenuItem();
            this.msiCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exAddMultipleBans = new System.Windows.Forms.ToolStripMenuItem();
            this.listServers = new System.Windows.Forms.ListView();
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverRefresh = new System.Windows.Forms.Button();
            this.deleteMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBanRefresh = new System.Windows.Forms.Button();
            this.bannedMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyGUIDIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unbanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.removeAllExpiredBansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charCount = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.playersLabel = new System.Windows.Forms.Label();
            this.playerCount = new System.Windows.Forms.Label();
            this.adminLabel = new System.Windows.Forms.Label();
            this.adminCount = new System.Windows.Forms.Label();
            this.banLabel = new System.Windows.Forms.Label();
            this.banCount = new System.Windows.Forms.Label();
            this.disconnectedPlayerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dmsiCopyGUID = new System.Windows.Forms.ToolStripMenuItem();
            this.dmsiCopyIP = new System.Windows.Forms.ToolStripMenuItem();
            this.dmsiCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.dmiBan = new System.Windows.Forms.ToolStripMenuItem();
            this.chatTabs.SuspendLayout();
            this.tabAll.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabPlayer.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.tabBans.SuspendLayout();
            this.tabAdmins.SuspendLayout();
            this.tabDisconnected.SuspendLayout();
            this.playerMenu.SuspendLayout();
            this.executeMenu.SuspendLayout();
            this.deleteMenu.SuspendLayout();
            this.bannedMenu.SuspendLayout();
            this.disconnectedPlayerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOption
            // 
            this.cmdOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdOption.FormattingEnabled = true;
            this.cmdOption.Items.AddRange(new object[] {
            "Say (Global)",
            "Command"});
            this.cmdOption.Location = new System.Drawing.Point(192, 536);
            this.cmdOption.Name = "cmdOption";
            this.cmdOption.Size = new System.Drawing.Size(86, 21);
            this.cmdOption.TabIndex = 58;
            // 
            // autoRefresh
            // 
            this.autoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoRefresh.AutoSize = true;
            this.autoRefresh.Location = new System.Drawing.Point(1191, 539);
            this.autoRefresh.Name = "autoRefresh";
            this.autoRefresh.Size = new System.Drawing.Size(88, 17);
            this.autoRefresh.TabIndex = 57;
            this.autoRefresh.Text = "Auto Refresh";
            this.autoRefresh.UseVisualStyleBackColor = true;
            this.autoRefresh.CheckedChanged += new System.EventHandler(this.autoRefresh_CheckedChanged);
            // 
            // autoScroll
            // 
            this.autoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txSay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txSay.Enabled = false;
            this.txSay.Location = new System.Drawing.Point(338, 537);
            this.txSay.MaxLength = 400;
            this.txSay.Name = "txSay";
            this.txSay.Size = new System.Drawing.Size(751, 20);
            this.txSay.TabIndex = 55;
            this.txSay.TextChanged += new System.EventHandler(this.txSay_TextChanged);
            this.txSay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txSay_KeyDown);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.Location = new System.Drawing.Point(3, 530);
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
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(3, 501);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(160, 23);
            this.btnExecute.TabIndex = 51;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnPlayerRefresh
            // 
            this.btnPlayerRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlayerRefresh.Enabled = false;
            this.btnPlayerRefresh.Location = new System.Drawing.Point(3, 443);
            this.btnPlayerRefresh.Name = "btnPlayerRefresh";
            this.btnPlayerRefresh.Size = new System.Drawing.Size(160, 23);
            this.btnPlayerRefresh.TabIndex = 50;
            this.btnPlayerRefresh.Text = "Refresh Players";
            this.btnPlayerRefresh.UseVisualStyleBackColor = true;
            this.btnPlayerRefresh.Click += new System.EventHandler(this.btnPlayerRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.chatTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatTabs.Controls.Add(this.tabAll);
            this.chatTabs.Controls.Add(this.tabChat);
            this.chatTabs.Controls.Add(this.tabConsole);
            this.chatTabs.Location = new System.Drawing.Point(169, 322);
            this.chatTabs.Multiline = true;
            this.chatTabs.Name = "chatTabs";
            this.chatTabs.SelectedIndex = 0;
            this.chatTabs.Size = new System.Drawing.Size(1110, 206);
            this.chatTabs.TabIndex = 41;
            // 
            // tabAll
            // 
            this.tabAll.BackColor = System.Drawing.Color.Transparent;
            this.tabAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabAll.Controls.Add(this.txAll);
            this.tabAll.Location = new System.Drawing.Point(23, 4);
            this.tabAll.Name = "tabAll";
            this.tabAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabAll.Size = new System.Drawing.Size(1083, 198);
            this.tabAll.TabIndex = 0;
            this.tabAll.Text = "All";
            // 
            // txAll
            // 
            this.txAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txAll.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txAll.Location = new System.Drawing.Point(3, 3);
            this.txAll.Name = "txAll";
            this.txAll.ReadOnly = true;
            this.txAll.Size = new System.Drawing.Size(1075, 190);
            this.txAll.TabIndex = 0;
            this.txAll.Text = "";
            this.txAll.TextChanged += new System.EventHandler(this.txAll_TextChanged);
            // 
            // tabChat
            // 
            this.tabChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabChat.Controls.Add(this.txChat);
            this.tabChat.Location = new System.Drawing.Point(23, 4);
            this.tabChat.Name = "tabChat";
            this.tabChat.Size = new System.Drawing.Size(1083, 198);
            this.tabChat.TabIndex = 2;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // txChat
            // 
            this.txChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txChat.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.txChat.Location = new System.Drawing.Point(3, 3);
            this.txChat.Name = "txChat";
            this.txChat.ReadOnly = true;
            this.txChat.Size = new System.Drawing.Size(1075, 190);
            this.txChat.TabIndex = 1;
            this.txChat.Text = "";
            this.txChat.TextChanged += new System.EventHandler(this.txChat_TextChanged);
            // 
            // tabConsole
            // 
            this.tabConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabConsole.Controls.Add(this.txConsole);
            this.tabConsole.Location = new System.Drawing.Point(23, 4);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(1083, 198);
            this.tabConsole.TabIndex = 1;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // txConsole
            // 
            this.txConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txConsole.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txConsole.Location = new System.Drawing.Point(3, 3);
            this.txConsole.Name = "txConsole";
            this.txConsole.ReadOnly = true;
            this.txConsole.Size = new System.Drawing.Size(1075, 190);
            this.txConsole.TabIndex = 0;
            this.txConsole.Text = "";
            this.txConsole.TextChanged += new System.EventHandler(this.txConsole_TextChanged);
            // 
            // tabPlayer
            // 
            this.tabPlayer.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPlayer.Controls.Add(this.tabPlayers);
            this.tabPlayer.Controls.Add(this.tabBans);
            this.tabPlayer.Controls.Add(this.tabAdmins);
            this.tabPlayer.Controls.Add(this.tabDisconnected);
            this.tabPlayer.Location = new System.Drawing.Point(169, 6);
            this.tabPlayer.Multiline = true;
            this.tabPlayer.Name = "tabPlayer";
            this.tabPlayer.SelectedIndex = 0;
            this.tabPlayer.Size = new System.Drawing.Size(1111, 292);
            this.tabPlayer.TabIndex = 40;
            this.tabPlayer.SelectedIndexChanged += new System.EventHandler(this.tabPlayer_SelectedIndexChanged);
            // 
            // tabPlayers
            // 
            this.tabPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPlayers.Controls.Add(this.listPlayers);
            this.tabPlayers.Location = new System.Drawing.Point(23, 4);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayers.Size = new System.Drawing.Size(1084, 284);
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
            this.listPlayers.MultiSelect = false;
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(1076, 276);
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
            this.columnIP.Width = 95;
            // 
            // columnPing
            // 
            this.columnPing.Text = "Ping";
            this.columnPing.Width = 51;
            // 
            // tabBans
            // 
            this.tabBans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabBans.Controls.Add(this.listBans);
            this.tabBans.Location = new System.Drawing.Point(23, 4);
            this.tabBans.Name = "tabBans";
            this.tabBans.Padding = new System.Windows.Forms.Padding(3);
            this.tabBans.Size = new System.Drawing.Size(1084, 284);
            this.tabBans.TabIndex = 1;
            this.tabBans.Text = "Bans";
            this.tabBans.UseVisualStyleBackColor = true;
            // 
            // listBans
            // 
            this.listBans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnbanNumber,
            this.columnGUIDIP,
            this.columnMinutesLeft,
            this.columnReason});
            this.listBans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBans.FullRowSelect = true;
            this.listBans.GridLines = true;
            this.listBans.HideSelection = false;
            this.listBans.Location = new System.Drawing.Point(3, 3);
            this.listBans.MultiSelect = false;
            this.listBans.Name = "listBans";
            this.listBans.Size = new System.Drawing.Size(1076, 276);
            this.listBans.TabIndex = 1;
            this.listBans.UseCompatibleStateImageBehavior = false;
            this.listBans.View = System.Windows.Forms.View.Details;
            this.listBans.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBans_MouseClick);
            // 
            // columnbanNumber
            // 
            this.columnbanNumber.Text = "#";
            // 
            // columnGUIDIP
            // 
            this.columnGUIDIP.Text = "GUID/IP";
            this.columnGUIDIP.Width = 307;
            // 
            // columnMinutesLeft
            // 
            this.columnMinutesLeft.Text = "Minutes left";
            this.columnMinutesLeft.Width = 158;
            // 
            // columnReason
            // 
            this.columnReason.Text = "Reason";
            this.columnReason.Width = 307;
            // 
            // tabAdmins
            // 
            this.tabAdmins.Controls.Add(this.listAdmins);
            this.tabAdmins.Location = new System.Drawing.Point(23, 4);
            this.tabAdmins.Name = "tabAdmins";
            this.tabAdmins.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmins.Size = new System.Drawing.Size(1084, 284);
            this.tabAdmins.TabIndex = 2;
            this.tabAdmins.Text = "Admins";
            this.tabAdmins.UseVisualStyleBackColor = true;
            // 
            // listAdmins
            // 
            this.listAdmins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.adminNumber,
            this.adminIP});
            this.listAdmins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAdmins.FullRowSelect = true;
            this.listAdmins.GridLines = true;
            this.listAdmins.HideSelection = false;
            this.listAdmins.Location = new System.Drawing.Point(3, 3);
            this.listAdmins.MultiSelect = false;
            this.listAdmins.Name = "listAdmins";
            this.listAdmins.Size = new System.Drawing.Size(1078, 278);
            this.listAdmins.TabIndex = 2;
            this.listAdmins.UseCompatibleStateImageBehavior = false;
            this.listAdmins.View = System.Windows.Forms.View.Details;
            // 
            // adminNumber
            // 
            this.adminNumber.Text = "#";
            // 
            // adminIP
            // 
            this.adminIP.Text = "IP";
            this.adminIP.Width = 95;
            // 
            // tabDisconnected
            // 
            this.tabDisconnected.Controls.Add(this.listDisconnected);
            this.tabDisconnected.Location = new System.Drawing.Point(23, 4);
            this.tabDisconnected.Name = "tabDisconnected";
            this.tabDisconnected.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisconnected.Size = new System.Drawing.Size(1084, 284);
            this.tabDisconnected.TabIndex = 3;
            this.tabDisconnected.Text = "Disconnected";
            this.tabDisconnected.UseVisualStyleBackColor = true;
            // 
            // listDisconnected
            // 
            this.listDisconnected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listDisconnected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDisconnected.FullRowSelect = true;
            this.listDisconnected.GridLines = true;
            this.listDisconnected.HideSelection = false;
            this.listDisconnected.Location = new System.Drawing.Point(3, 3);
            this.listDisconnected.MultiSelect = false;
            this.listDisconnected.Name = "listDisconnected";
            this.listDisconnected.Size = new System.Drawing.Size(1078, 278);
            this.listDisconnected.TabIndex = 1;
            this.listDisconnected.UseCompatibleStateImageBehavior = false;
            this.listDisconnected.View = System.Windows.Forms.View.Details;
            this.listDisconnected.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listDisconnected_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 171;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Status";
            this.columnHeader3.Width = 158;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "GUID";
            this.columnHeader4.Width = 307;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "IP";
            this.columnHeader5.Width = 95;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ping";
            this.columnHeader6.Width = 51;
            // 
            // playerMenu
            // 
            this.playerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCopy,
            this.toolStripSeparator4,
            this.miMessage,
            this.miKick,
            this.miBan,
            this.toolStripSeparator2,
            this.miQuickBan});
            this.playerMenu.Name = "playerMenu";
            this.playerMenu.Size = new System.Drawing.Size(129, 126);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(125, 6);
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
            this.exShutdown,
            this.toolStripSeparator3,
            this.exAddMultipleBans});
            this.executeMenu.Name = "executeMenu";
            this.executeMenu.Size = new System.Drawing.Size(222, 192);
            // 
            // exScripts
            // 
            this.exScripts.Name = "exScripts";
            this.exScripts.Size = new System.Drawing.Size(221, 22);
            this.exScripts.Text = "Reload Scripts";
            this.exScripts.Click += new System.EventHandler(this.exScripts_Click);
            // 
            // exBans
            // 
            this.exBans.Name = "exBans";
            this.exBans.Size = new System.Drawing.Size(221, 22);
            this.exBans.Text = "Reload Bans";
            this.exBans.Click += new System.EventHandler(this.exBans_Click);
            // 
            // exEvents
            // 
            this.exEvents.Name = "exEvents";
            this.exEvents.Size = new System.Drawing.Size(221, 22);
            this.exEvents.Text = "Reload Events";
            this.exEvents.Click += new System.EventHandler(this.exEvents_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // exLock
            // 
            this.exLock.Name = "exLock";
            this.exLock.Size = new System.Drawing.Size(221, 22);
            this.exLock.Text = "Lock Server";
            this.exLock.Click += new System.EventHandler(this.exLock_Click);
            // 
            // exUnlock
            // 
            this.exUnlock.Name = "exUnlock";
            this.exUnlock.Size = new System.Drawing.Size(221, 22);
            this.exUnlock.Text = "Unlock Server";
            this.exUnlock.Click += new System.EventHandler(this.exUnlock_Click);
            // 
            // exRestart
            // 
            this.exRestart.Name = "exRestart";
            this.exRestart.Size = new System.Drawing.Size(221, 22);
            this.exRestart.Text = "Restart Server";
            this.exRestart.Click += new System.EventHandler(this.exRestart_Click);
            // 
            // exShutdown
            // 
            this.exShutdown.BackColor = System.Drawing.Color.Red;
            this.exShutdown.ForeColor = System.Drawing.Color.White;
            this.exShutdown.Name = "exShutdown";
            this.exShutdown.Size = new System.Drawing.Size(221, 22);
            this.exShutdown.Text = "Shutdown Server";
            this.exShutdown.Click += new System.EventHandler(this.exShutdown_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // exAddMultipleBans
            // 
            this.exAddMultipleBans.Name = "exAddMultipleBans";
            this.exAddMultipleBans.Size = new System.Drawing.Size(221, 22);
            this.exAddMultipleBans.Text = "Manually add multiple bans";
            this.exAddMultipleBans.Click += new System.EventHandler(this.exAddMultipleBans_Click);
            // 
            // listServers
            // 
            this.listServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnServer});
            this.listServers.FullRowSelect = true;
            this.listServers.Location = new System.Drawing.Point(3, 10);
            this.listServers.MultiSelect = false;
            this.listServers.Name = "listServers";
            this.listServers.Scrollable = false;
            this.listServers.Size = new System.Drawing.Size(160, 195);
            this.listServers.TabIndex = 59;
            this.listServers.UseCompatibleStateImageBehavior = false;
            this.listServers.View = System.Windows.Forms.View.Details;
            this.listServers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listServers_ColumnClick);
            this.listServers.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listServers_ColumnWidthChanging);
            this.listServers.Click += new System.EventHandler(this.listServers_Click);
            this.listServers.DoubleClick += new System.EventHandler(this.listServers_DoubleClick);
            this.listServers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listServers_MouseClick);
            // 
            // columnServer
            // 
            this.columnServer.Text = "Server (double click)";
            this.columnServer.Width = 158;
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
            // btnBanRefresh
            // 
            this.btnBanRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBanRefresh.Enabled = false;
            this.btnBanRefresh.Location = new System.Drawing.Point(3, 472);
            this.btnBanRefresh.Name = "btnBanRefresh";
            this.btnBanRefresh.Size = new System.Drawing.Size(160, 23);
            this.btnBanRefresh.TabIndex = 61;
            this.btnBanRefresh.Text = "Refresh Bans";
            this.btnBanRefresh.UseVisualStyleBackColor = true;
            this.btnBanRefresh.Click += new System.EventHandler(this.btnBanRefresh_Click);
            // 
            // bannedMenu
            // 
            this.bannedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGUIDIPToolStripMenuItem,
            this.unbanToolStripMenuItem,
            this.toolStripSeparator5,
            this.removeAllExpiredBansToolStripMenuItem});
            this.bannedMenu.Name = "bannedMenu";
            this.bannedMenu.Size = new System.Drawing.Size(202, 76);
            // 
            // copyGUIDIPToolStripMenuItem
            // 
            this.copyGUIDIPToolStripMenuItem.Name = "copyGUIDIPToolStripMenuItem";
            this.copyGUIDIPToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyGUIDIPToolStripMenuItem.Text = "Copy GUID/IP";
            this.copyGUIDIPToolStripMenuItem.Click += new System.EventHandler(this.banCopyGUIDIP_Click);
            // 
            // unbanToolStripMenuItem
            // 
            this.unbanToolStripMenuItem.Name = "unbanToolStripMenuItem";
            this.unbanToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.unbanToolStripMenuItem.Text = "Unban";
            this.unbanToolStripMenuItem.Click += new System.EventHandler(this.banUnban_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(198, 6);
            // 
            // removeAllExpiredBansToolStripMenuItem
            // 
            this.removeAllExpiredBansToolStripMenuItem.Name = "removeAllExpiredBansToolStripMenuItem";
            this.removeAllExpiredBansToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeAllExpiredBansToolStripMenuItem.Text = "Remove all expired bans";
            this.removeAllExpiredBansToolStripMenuItem.Click += new System.EventHandler(this.banRemoveAllExpiredBans_Click);
            // 
            // charCount
            // 
            this.charCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.charCount.BackColor = System.Drawing.SystemColors.Control;
            this.charCount.Location = new System.Drawing.Point(284, 540);
            this.charCount.Name = "charCount";
            this.charCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.charCount.Size = new System.Drawing.Size(48, 13);
            this.charCount.TabIndex = 62;
            this.charCount.Text = "0/400";
            this.charCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(193, 306);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(44, 13);
            this.searchLabel.TabIndex = 63;
            this.searchLabel.Text = "Search:";
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchBox.FormattingEnabled = true;
            this.searchBox.Items.AddRange(new object[] {
            "Name",
            "GUID",
            "IP"});
            this.searchBox.Location = new System.Drawing.Point(243, 302);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(89, 21);
            this.searchBox.TabIndex = 64;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(338, 303);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(751, 20);
            this.searchTextBox.TabIndex = 65;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // playersLabel
            // 
            this.playersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(1095, 306);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(44, 13);
            this.playersLabel.TabIndex = 67;
            this.playersLabel.Text = "Players:";
            // 
            // playerCount
            // 
            this.playerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playerCount.AutoSize = true;
            this.playerCount.Location = new System.Drawing.Point(1135, 306);
            this.playerCount.Name = "playerCount";
            this.playerCount.Size = new System.Drawing.Size(13, 13);
            this.playerCount.TabIndex = 68;
            this.playerCount.Text = "0";
            // 
            // adminLabel
            // 
            this.adminLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adminLabel.AutoSize = true;
            this.adminLabel.Location = new System.Drawing.Point(1156, 306);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(44, 13);
            this.adminLabel.TabIndex = 69;
            this.adminLabel.Text = "Admins:";
            // 
            // adminCount
            // 
            this.adminCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adminCount.AutoSize = true;
            this.adminCount.Location = new System.Drawing.Point(1197, 306);
            this.adminCount.Name = "adminCount";
            this.adminCount.Size = new System.Drawing.Size(13, 13);
            this.adminCount.TabIndex = 70;
            this.adminCount.Text = "0";
            // 
            // banLabel
            // 
            this.banLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.banLabel.AutoSize = true;
            this.banLabel.Location = new System.Drawing.Point(1216, 306);
            this.banLabel.Name = "banLabel";
            this.banLabel.Size = new System.Drawing.Size(34, 13);
            this.banLabel.TabIndex = 71;
            this.banLabel.Text = "Bans:";
            // 
            // banCount
            // 
            this.banCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.banCount.AutoSize = true;
            this.banCount.Location = new System.Drawing.Point(1246, 306);
            this.banCount.Name = "banCount";
            this.banCount.Size = new System.Drawing.Size(13, 13);
            this.banCount.TabIndex = 72;
            this.banCount.Text = "0";
            // 
            // disconnectedPlayerMenu
            // 
            this.disconnectedPlayerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator6,
            this.dmiBan});
            this.disconnectedPlayerMenu.Name = "playerMenu";
            this.disconnectedPlayerMenu.Size = new System.Drawing.Size(103, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dmsiCopyGUID,
            this.dmsiCopyIP,
            this.dmsiCopyName});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Copy";
            // 
            // dmsiCopyGUID
            // 
            this.dmsiCopyGUID.Name = "dmsiCopyGUID";
            this.dmsiCopyGUID.Size = new System.Drawing.Size(106, 22);
            this.dmsiCopyGUID.Text = "GUID";
            this.dmsiCopyGUID.Click += new System.EventHandler(this.msiCopyGUID_Click);
            // 
            // dmsiCopyIP
            // 
            this.dmsiCopyIP.Name = "dmsiCopyIP";
            this.dmsiCopyIP.Size = new System.Drawing.Size(106, 22);
            this.dmsiCopyIP.Text = "IP";
            this.dmsiCopyIP.Click += new System.EventHandler(this.msiCopyIP_Click);
            // 
            // dmsiCopyName
            // 
            this.dmsiCopyName.Name = "dmsiCopyName";
            this.dmsiCopyName.Size = new System.Drawing.Size(106, 22);
            this.dmsiCopyName.Text = "Name";
            this.dmsiCopyName.Click += new System.EventHandler(this.msiCopyName_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(99, 6);
            // 
            // dmiBan
            // 
            this.dmiBan.Name = "dmiBan";
            this.dmiBan.Size = new System.Drawing.Size(102, 22);
            this.dmiBan.Text = "Ban";
            this.dmiBan.Click += new System.EventHandler(this.miBan_Click);
            // 
            // ServerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.banCount);
            this.Controls.Add(this.banLabel);
            this.Controls.Add(this.adminCount);
            this.Controls.Add(this.adminLabel);
            this.Controls.Add(this.playerCount);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.charCount);
            this.Controls.Add(this.btnBanRefresh);
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
            this.Controls.Add(this.btnPlayerRefresh);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txPasswd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txHost);
            this.Controls.Add(this.chatTabs);
            this.Controls.Add(this.tabPlayer);
            this.MinimumSize = new System.Drawing.Size(1100, 564);
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
            this.tabAdmins.ResumeLayout(false);
            this.tabDisconnected.ResumeLayout(false);
            this.playerMenu.ResumeLayout(false);
            this.executeMenu.ResumeLayout(false);
            this.deleteMenu.ResumeLayout(false);
            this.bannedMenu.ResumeLayout(false);
            this.disconnectedPlayerMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnPlayerRefresh;
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
        private System.Windows.Forms.TabControl tabPlayer;
        private System.Windows.Forms.TabPage tabPlayers;
        private System.Windows.Forms.ListView listPlayers;
        private System.Windows.Forms.ColumnHeader columnbanNumber;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnGUID;
        private System.Windows.Forms.ColumnHeader columnIP;
        private System.Windows.Forms.ColumnHeader columnPing;
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
        private System.Windows.Forms.TabPage tabBans;
        private System.Windows.Forms.ListView listBans;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnGUIDIP;
        private System.Windows.Forms.ColumnHeader columnMinutesLeft;
        private System.Windows.Forms.ColumnHeader columnReason;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exAddMultipleBans;
        private System.Windows.Forms.Button btnBanRefresh;
        private System.Windows.Forms.ContextMenuStrip bannedMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem copyGUIDIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unbanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem removeAllExpiredBansToolStripMenuItem;
        private System.Windows.Forms.Label charCount;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.ComboBox searchBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.RichTextBox txConsole;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label playerCount;
        private System.Windows.Forms.TabPage tabAdmins;
        private System.Windows.Forms.ListView listAdmins;
        private System.Windows.Forms.ColumnHeader adminNumber;
        private System.Windows.Forms.ColumnHeader adminIP;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Label adminCount;
        private System.Windows.Forms.Label banLabel;
        private System.Windows.Forms.Label banCount;
        private System.Windows.Forms.TabPage tabDisconnected;
        private System.Windows.Forms.ListView listDisconnected;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip disconnectedPlayerMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dmsiCopyGUID;
        private System.Windows.Forms.ToolStripMenuItem dmsiCopyIP;
        private System.Windows.Forms.ToolStripMenuItem dmsiCopyName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem dmiBan;
    }
}
