using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlobalVariables;

namespace Sparc
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = stName.Text;
            Properties.Settings.Default.hlAdmin = sthlAdmin.Checked;
            Properties.Settings.Default.hlName = sthlName.Checked;
            Properties.Settings.Default.qbTime = Convert.ToInt32(stqbTime.Value);
            Properties.Settings.Default.qbReason = stqbReason.Text;
            Properties.Settings.Default.qbRefreshInterval = Convert.ToInt32(stqbRefreshInterval.Value);
            Properties.Settings.Default.autoRefresh = stAutoRefresh.Checked;
            Properties.Settings.Default.saveLogs = stSaveLogs.Checked;
            Properties.Settings.Default.showKickAdmin = stShowAdminKick.Checked;
            Properties.Settings.Default.showBanAdmin = stShowAdminBan.Checked;
            Properties.Settings.Default.showBanLength = stShowBanLength.Checked;
            Properties.Settings.Default.loadBanConnect = stLoadBanConnect.Checked;
            Properties.Settings.Default.detectSrvHop = stDetectServhop.Checked;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            stName.Text = Properties.Settings.Default.Username;
            ToolTip1.SetToolTip(this.stName, "Your name to be used when chatting ingame. In example: [Name]: your message.");
            sthlAdmin.Checked = Properties.Settings.Default.hlAdmin;
            ToolTip1.SetToolTip(this.sthlAdmin, "Should Sparc highlight calls for admins in the chat?");
            sthlName.Checked = Properties.Settings.Default.hlName;
            ToolTip1.SetToolTip(this.sthlName, "Should Sparc highlight calls with your chosen admin name?");
            stqbTime.Value = Properties.Settings.Default.qbTime;
            ToolTip1.SetToolTip(this.stqbTime, "The duration of how long a player is banned when using the Quick Ban feature.");
            stqbReason.Text = Properties.Settings.Default.qbReason;
            ToolTip1.SetToolTip(this.stqbReason, "The ban reason that is set when using the Quick Ban feature.");
            stqbRefreshInterval.Value = Properties.Settings.Default.qbRefreshInterval;
            ToolTip1.SetToolTip(this.stqbRefreshInterval, "The time between automatic refreshes, requires auto refresh to be turned on.");
            stAutoRefresh.Checked = Properties.Settings.Default.autoRefresh;
            ToolTip1.SetToolTip(this.stAutoRefresh, "Should the list of players be automatically refreshed?");
            stSaveLogs.Checked = Properties.Settings.Default.saveLogs;
            ToolTip1.SetToolTip(this.stSaveLogs, "Should Sparc save its logs to a text file? NOTE: Requires you to re-connect to host!");
            stShowAdminKick.Checked = Properties.Settings.Default.showKickAdmin;
            ToolTip1.SetToolTip(this.stShowAdminKick, "Should Sparc add chosen admin name within the kick reason?");
            stShowAdminBan.Checked = Properties.Settings.Default.showBanAdmin;
            ToolTip1.SetToolTip(this.stShowAdminBan, "Should Sparc add chosen admin name within the ban reason?");
            stShowBanLength.Checked = Properties.Settings.Default.showBanLength;
            ToolTip1.SetToolTip(this.stShowBanLength, "Should Sparc add chosen ban length within the ban reason?");
            stLoadBanConnect.Checked = Properties.Settings.Default.loadBanConnect;
            ToolTip1.SetToolTip(this.stLoadBanConnect, "Should Sparc automatically load bans on connect? (Recommended to be turned off for servers with a big banlist!)");
            stDetectServhop.Checked = Properties.Settings.Default.detectSrvHop;
            ToolTip1.SetToolTip(this.stDetectServhop, "Detect players that are hopping between servers you are connected to (useful for detecting touble players)");
            sparcVersion.Text =  Globals.sparcVersion;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }
    }
}
