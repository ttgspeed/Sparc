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
    public partial class Message_Kick : Form
    {
        public Message_Kick()
        {
            InitializeComponent();
        }

        private void mbtnSend_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
