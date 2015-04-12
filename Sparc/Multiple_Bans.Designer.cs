namespace Sparc
{
    partial class Multiple_Bans
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
            this.mbtnSend = new System.Windows.Forms.Button();
            this.mtxBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mbtnSend
            // 
            this.mbtnSend.Location = new System.Drawing.Point(177, 250);
            this.mbtnSend.Name = "mbtnSend";
            this.mbtnSend.Size = new System.Drawing.Size(311, 23);
            this.mbtnSend.TabIndex = 5;
            this.mbtnSend.Text = "Confirm";
            this.mbtnSend.UseVisualStyleBackColor = true;
            this.mbtnSend.Click += new System.EventHandler(this.mbtnSend_Click);
            // 
            // mtxBan
            // 
            this.mtxBan.Location = new System.Drawing.Point(12, 25);
            this.mtxBan.Multiline = true;
            this.mtxBan.Name = "mtxBan";
            this.mtxBan.Size = new System.Drawing.Size(637, 219);
            this.mtxBan.TabIndex = 4;
            this.mtxBan.Click += new System.EventHandler(this.mtxBan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Paste your bans in the box below";
            // 
            // Multiple_Bans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 285);
            this.Controls.Add(this.mbtnSend);
            this.Controls.Add(this.mtxBan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Multiple_Bans";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manually add ban(s)";
            this.Load += new System.EventHandler(this.Multiple_Bans_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mbtnSend;
        public System.Windows.Forms.TextBox mtxBan;
        private System.Windows.Forms.Label label1;
    }
}