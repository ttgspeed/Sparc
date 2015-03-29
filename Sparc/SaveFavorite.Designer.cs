namespace Sparc
{
    partial class SaveFavorite
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
            this.label1 = new System.Windows.Forms.Label();
            this.mtxNickname = new System.Windows.Forms.TextBox();
            this.mbtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a nickname for this server";
            // 
            // mtxNickname
            // 
            this.mtxNickname.Location = new System.Drawing.Point(12, 40);
            this.mtxNickname.Name = "mtxNickname";
            this.mtxNickname.Size = new System.Drawing.Size(156, 20);
            this.mtxNickname.TabIndex = 1;
            // 
            // mbtnSave
            // 
            this.mbtnSave.Location = new System.Drawing.Point(12, 66);
            this.mbtnSave.Name = "mbtnSave";
            this.mbtnSave.Size = new System.Drawing.Size(156, 23);
            this.mbtnSave.TabIndex = 2;
            this.mbtnSave.Text = "Save";
            this.mbtnSave.UseVisualStyleBackColor = true;
            this.mbtnSave.Click += new System.EventHandler(this.mbtnSave_Click);
            // 
            // SaveFavorite
            // 
            this.AcceptButton = this.mbtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 103);
            this.Controls.Add(this.mbtnSave);
            this.Controls.Add(this.mtxNickname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveFavorite";
            this.ShowIcon = false;
            this.Text = "Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox mtxNickname;
        private System.Windows.Forms.Button mbtnSave;
    }
}