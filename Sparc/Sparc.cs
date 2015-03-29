using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BattleNET;
using System.Net;
using System.Xml.Linq;

namespace Sparc
{
    public partial class Sparc : Form
    {
        public Sparc()
        {
            InitializeComponent();
        }

        private void Sparc_Load(object sender, EventArgs e)
        {
            initXML();

            ServerComponent uc = new ServerComponent();
            uc.Dock = DockStyle.Fill;
            TabPage tp = new TabPage();
            tp.Controls.Add(uc);
            tp.Text = "New Server";
            tabServers.TabPages.Insert(tabServers.TabPages.Count - 1, tp);
            tabServers.SelectedIndex = 0;
        }

        private void tabServers_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabAddServer)
            {
                int si = tabServers.SelectedIndex;
                ServerComponent uc = new ServerComponent();
                uc.Dock = DockStyle.Fill;
                TabPage tp = new TabPage();
                tp.Controls.Add(uc);
                tp.Text = "New Server";
                tabServers.TabPages.Insert(tabServers.TabPages.Count - 1, tp);
                tabServers.SelectedIndex = si;
            }
        }

        private void initXML()
        {
            try
            {
                var doc = XDocument.Load(@"servers.xml");
            }
            catch
            {
                XElement servers = new XElement("Servers");
                servers.Add();
                servers.Save(@"servers.xml");
            }
        }
    }
}
