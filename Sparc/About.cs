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
            createdLabel.Text = "Created by SPEED\nWith help from DJScias";
        }

        private void lblDonate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for being awesome, \nbut this button doesn't do anything right now!");
        }

        private void linkSpeed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkSpeed.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://github.com/ttgspeed/");
        }

        private void linkDJScias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkDJScias.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://github.com/DJScias/");
        }

        private void imageDonate_Click(object sender, EventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QKP6MP5DNXJD4");
        }

        private void imageDonate_MouseEnter(object sender, EventArgs e)
        {
            imageDonate.Cursor = Cursors.Hand;
        }

        private void imageDonate_MouseLeave(object sender, EventArgs e)
        {
            imageDonate.Cursor = Cursors.Default;
        }
    }
}
