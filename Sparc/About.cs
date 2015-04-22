using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalVariables;

namespace Sparc
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            sparcVersion.Text = Globals.sparcVersion;
        }

        private void lblDonate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for being awesome, \nbut this button doesn't do anything right now!");
        }
    }
}
