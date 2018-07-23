namespace PdfPasswordRemover
{
    partial class PwdWindow
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
            this.PwdLabel = new System.Windows.Forms.Label();
            this.PwdTxt = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PwdLabel
            // 
            this.PwdLabel.AutoSize = true;
            this.PwdLabel.Location = new System.Drawing.Point(13, 13);
            this.PwdLabel.Name = "PwdLabel";
            this.PwdLabel.Size = new System.Drawing.Size(53, 13);
            this.PwdLabel.TabIndex = 0;
            this.PwdLabel.Text = "Password";
            // 
            // PwdTxt
            // 
            this.PwdTxt.Location = new System.Drawing.Point(84, 10);
            this.PwdTxt.Name = "PwdTxt";
            this.PwdTxt.Size = new System.Drawing.Size(177, 20);
            this.PwdTxt.TabIndex = 1;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(280, 10);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(106, 20);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // PwdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 54);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.PwdTxt);
            this.Controls.Add(this.PwdLabel);
            this.Name = "PwdWindow";
            this.Text = "PwdWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PwdLabel;
        private System.Windows.Forms.TextBox PwdTxt;
        private System.Windows.Forms.Button OkBtn;
    }
}