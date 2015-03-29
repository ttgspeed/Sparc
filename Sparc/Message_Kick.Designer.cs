namespace Sparc
{
    partial class Message_Kick
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
            this.mtxMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mbtnSend
            // 
            this.mbtnSend.Location = new System.Drawing.Point(12, 51);
            this.mbtnSend.Name = "mbtnSend";
            this.mbtnSend.Size = new System.Drawing.Size(311, 23);
            this.mbtnSend.TabIndex = 5;
            this.mbtnSend.Text = "Confirm";
            this.mbtnSend.UseVisualStyleBackColor = true;
            this.mbtnSend.Click += new System.EventHandler(this.mbtnSend_Click);
            // 
            // mtxMessage
            // 
            this.mtxMessage.Location = new System.Drawing.Point(12, 25);
            this.mtxMessage.Name = "mtxMessage";
            this.mtxMessage.Size = new System.Drawing.Size(311, 20);
            this.mtxMessage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Message";
            // 
            // Message_Kick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 82);
            this.Controls.Add(this.mbtnSend);
            this.Controls.Add(this.mtxMessage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Message_Kick";
            this.ShowIcon = false;
            this.Text = "Message/Kick Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mbtnSend;
        public System.Windows.Forms.TextBox mtxMessage;
        private System.Windows.Forms.Label label1;
    }
}