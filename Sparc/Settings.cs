using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Properties.Settings.Default.flashOnCall = stflashOnCall.Checked;
            Properties.Settings.Default.qbTime = Convert.ToInt32(stqbTime.Value);
            Properties.Settings.Default.qbReason = stqbReason.Text;
            Properties.Settings.Default.autoRefresh = stAutoRefresh.Checked;
            Properties.Settings.Default.saveLogs = stSaveLogs.Checked;
            Properties.Settings.Default.showKickAdmin = stShowAdminKick.Checked;
            Properties.Settings.Default.showBanAdmin = stShowAdminBan.Checked;
            Properties.Settings.Default.showBanLength = stShowBanLength.Checked;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            stName.Text = Properties.Settings.Default.Username;
            sthlAdmin.Checked = Properties.Settings.Default.hlAdmin;
            sthlName.Checked = Properties.Settings.Default.hlName;
            stflashOnCall.Checked = Properties.Settings.Default.flashOnCall;
            stqbTime.Value = Properties.Settings.Default.qbTime;
            stqbReason.Text = Properties.Settings.Default.qbReason;
            stAutoRefresh.Checked = Properties.Settings.Default.autoRefresh;
            stSaveLogs.Checked = Properties.Settings.Default.saveLogs;
            stShowAdminKick.Checked = Properties.Settings.Default.showKickAdmin;
            stShowAdminBan.Checked = Properties.Settings.Default.showBanAdmin;
            stShowBanLength.Checked = Properties.Settings.Default.showBanLength;
            sparcVersion.Text = "v0.0.1";
        }
    }
}
