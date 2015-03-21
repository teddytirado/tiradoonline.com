namespace Pop3Application
{
    partial class Form1
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
            this.dataPop3GridView = new System.Windows.Forms.DataGridView();
            this.progressBarPOP3 = new System.Windows.Forms.ProgressBar();
            this.txtLogs = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataPop3GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataPop3GridView
            // 
            this.dataPop3GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPop3GridView.Location = new System.Drawing.Point(-1, -3);
            this.dataPop3GridView.Name = "dataPop3GridView";
            this.dataPop3GridView.Size = new System.Drawing.Size(982, 335);
            this.dataPop3GridView.TabIndex = 0;
            // 
            // progressBarPOP3
            // 
            this.progressBarPOP3.Location = new System.Drawing.Point(-1, 599);
            this.progressBarPOP3.Name = "progressBarPOP3";
            this.progressBarPOP3.Size = new System.Drawing.Size(982, 23);
            this.progressBarPOP3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarPOP3.TabIndex = 1;
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(4, 338);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(977, 255);
            this.txtLogs.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 625);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.progressBarPOP3);
            this.Controls.Add(this.dataPop3GridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPop3GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataPop3GridView;
        private System.Windows.Forms.ProgressBar progressBarPOP3;
        private System.Windows.Forms.TextBox txtLogs;

    }
}

