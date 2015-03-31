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
    public partial class Ban : Form
    {
        public Ban()
        {
            InitializeComponent();
        }

        private void Ban_Load(object sender, EventArgs e)
        {
            bpLengthMult.SelectedIndex = 0;
        }
    }
}
