namespace Sparc
{
    partial class Sparc
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabServers = new System.Windows.Forms.TabControl();
            this.tabAddServer = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabServers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 590);
            this.panel1.TabIndex = 3;
            // 
            // tabServers
            // 
            this.tabServers.Controls.Add(this.tabAddServer);
            this.tabServers.Location = new System.Drawing.Point(0, 0);
            this.tabServers.Name = "tabServers";
            this.tabServers.SelectedIndex = 0;
            this.tabServers.Size = new System.Drawing.Size(1292, 590);
            this.tabServers.TabIndex = 21;
            this.tabServers.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabServers_Selected);
            // 
            // tabAddServer
            // 
            this.tabAddServer.Location = new System.Drawing.Point(4, 22);
            this.tabAddServer.Name = "tabAddServer";
            this.tabAddServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddServer.Size = new System.Drawing.Size(1284, 564);
            this.tabAddServer.TabIndex = 1;
            this.tabAddServer.Text = "Add Server";
            this.tabAddServer.UseVisualStyleBackColor = true;
            // 
            // Sparc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 590);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Sparc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sparc";
            this.Load += new System.EventHandler(this.Sparc_Load);
            this.panel1.ResumeLayout(false);
            this.tabServers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabServers;
        private System.Windows.Forms.TabPage tabAddServer;
    }
}

