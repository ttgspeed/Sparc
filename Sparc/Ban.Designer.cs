namespace Sparc
{
    partial class Ban
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
            this.bpBanConfirm = new System.Windows.Forms.Button();
            this.bpBanMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bpLengthInt = new System.Windows.Forms.NumericUpDown();
            this.bpLengthMult = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bpLengthInt)).BeginInit();
            this.SuspendLayout();
            // 
            // bpBanConfirm
            // 
            this.bpBanConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bpBanConfirm.Location = new System.Drawing.Point(15, 103);
            this.bpBanConfirm.Name = "bpBanConfirm";
            this.bpBanConfirm.Size = new System.Drawing.Size(205, 23);
            this.bpBanConfirm.TabIndex = 8;
            this.bpBanConfirm.Text = "Confirm";
            this.bpBanConfirm.UseVisualStyleBackColor = true;
            // 
            // bpBanMessage
            // 
            this.bpBanMessage.Location = new System.Drawing.Point(15, 77);
            this.bpBanMessage.Name = "bpBanMessage";
            this.bpBanMessage.Size = new System.Drawing.Size(205, 20);
            this.bpBanMessage.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ban message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ban length";
            // 
            // bpLengthInt
            // 
            this.bpLengthInt.Location = new System.Drawing.Point(15, 25);
            this.bpLengthInt.Name = "bpLengthInt";
            this.bpLengthInt.Size = new System.Drawing.Size(100, 20);
            this.bpLengthInt.TabIndex = 11;
            // 
            // bpLengthMult
            // 
            this.bpLengthMult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bpLengthMult.FormattingEnabled = true;
            this.bpLengthMult.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days",
            "Permanent"});
            this.bpLengthMult.Location = new System.Drawing.Point(120, 25);
            this.bpLengthMult.Name = "bpLengthMult";
            this.bpLengthMult.Size = new System.Drawing.Size(100, 21);
            this.bpLengthMult.TabIndex = 12;
            // 
            // Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 136);
            this.Controls.Add(this.bpLengthMult);
            this.Controls.Add(this.bpLengthInt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bpBanConfirm);
            this.Controls.Add(this.bpBanMessage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ban";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ban";
            this.Load += new System.EventHandler(this.Ban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bpLengthInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bpBanConfirm;
        public System.Windows.Forms.TextBox bpBanMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown bpLengthInt;
        public System.Windows.Forms.ComboBox bpLengthMult;
    }
}