namespace ContactsSyncNameSpace
{
    partial class ContactsSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsSync));
            this.txtResults = new System.Windows.Forms.TextBox();
            this.frmProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(3, 4);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(793, 491);
            this.txtResults.TabIndex = 0;
            // 
            // frmProgressBar
            // 
            this.frmProgressBar.Location = new System.Drawing.Point(5, 501);
            this.frmProgressBar.Name = "frmProgressBar";
            this.frmProgressBar.Size = new System.Drawing.Size(773, 21);
            this.frmProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.frmProgressBar.TabIndex = 1;
            // 
            // ContactsSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 529);
            this.Controls.Add(this.frmProgressBar);
            this.Controls.Add(this.txtResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContactsSync";
            this.Text = "ContactsSync";
            this.Load += new System.EventHandler(this.ContactsSync_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResults;
        public System.Windows.Forms.ProgressBar frmProgressBar;
    }
}