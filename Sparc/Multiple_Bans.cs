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
    public partial class Multiple_Bans : Form
    {
        public Multiple_Bans()
        {
            InitializeComponent();
        }

        private void mbtnSend_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Multiple_Bans_Load(object sender, EventArgs e)
        {
            mtxBan.Text = "Add bans like this:\r\nguidoripguidoripguidorip -1 Reason\r\nguidoripguidoripguidorip -1 Reason\r\nEtc..";
            this.ActiveControl = label1;
        }

        private void mtxBan_Click(object sender, EventArgs e)
        {
            mtxBan.Clear();
            mtxBan.Click -= mtxBan_Click;
        }
    }
}
