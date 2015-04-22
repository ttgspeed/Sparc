namespace Sparc
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.createdLabel = new System.Windows.Forms.Label();
            this.sparcVersion = new System.Windows.Forms.Label();
            this.linkSpeed = new System.Windows.Forms.LinkLabel();
            this.linkDJScias = new System.Windows.Forms.LinkLabel();
            this.imageDonate = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sparc";
            // 
            // createdLabel
            // 
            this.createdLabel.AutoSize = true;
            this.createdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdLabel.Location = new System.Drawing.Point(301, 113);
            this.createdLabel.Name = "createdLabel";
            this.createdLabel.Size = new System.Drawing.Size(174, 40);
            this.createdLabel.TabIndex = 2;
            this.createdLabel.Text = "Created by SPEED\r\nWith help from DJScias";
            this.createdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sparcVersion
            // 
            this.sparcVersion.AutoSize = true;
            this.sparcVersion.Location = new System.Drawing.Point(378, 67);
            this.sparcVersion.Name = "sparcVersion";
            this.sparcVersion.Size = new System.Drawing.Size(37, 13);
            this.sparcVersion.TabIndex = 7;
            this.sparcVersion.Text = "v0.0.0";
            // 
            // linkSpeed
            // 
            this.linkSpeed.AutoSize = true;
            this.linkSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.linkSpeed.Location = new System.Drawing.Point(398, 113);
            this.linkSpeed.Name = "linkSpeed";
            this.linkSpeed.Size = new System.Drawing.Size(64, 20);
            this.linkSpeed.TabIndex = 8;
            this.linkSpeed.TabStop = true;
            this.linkSpeed.Text = "SPEED";
            this.linkSpeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSpeed_LinkClicked);
            // 
            // linkDJScias
            // 
            this.linkDJScias.AutoSize = true;
            this.linkDJScias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.linkDJScias.Location = new System.Drawing.Point(409, 133);
            this.linkDJScias.Name = "linkDJScias";
            this.linkDJScias.Size = new System.Drawing.Size(68, 20);
            this.linkDJScias.TabIndex = 9;
            this.linkDJScias.TabStop = true;
            this.linkDJScias.Text = "DJScias";
            this.linkDJScias.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDJScias_LinkClicked);
            // 
            // imageDonate
            // 
            this.imageDonate.Image = ((System.Drawing.Image)(resources.GetObject("imageDonate.Image")));
            this.imageDonate.Location = new System.Drawing.Point(291, 183);
            this.imageDonate.Name = "imageDonate";
            this.imageDonate.Size = new System.Drawing.Size(199, 58);
            this.imageDonate.TabIndex = 10;
            this.imageDonate.TabStop = false;
            this.imageDonate.Click += new System.EventHandler(this.imageDonate_Click);
            this.imageDonate.MouseEnter += new System.EventHandler(this.imageDonate_MouseEnter);
            this.imageDonate.MouseLeave += new System.EventHandler(this.imageDonate_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sparc.Properties.Resources.Sparc;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 255);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 278);
            this.Controls.Add(this.imageDonate);
            this.Controls.Add(this.linkDJScias);
            this.Controls.Add(this.linkSpeed);
            this.Controls.Add(this.sparcVersion);
            this.Controls.Add(this.createdLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label createdLabel;
        private System.Windows.Forms.Label sparcVersion;
        private System.Windows.Forms.LinkLabel linkSpeed;
        private System.Windows.Forms.LinkLabel linkDJScias;
        private System.Windows.Forms.PictureBox imageDonate;
    }
}