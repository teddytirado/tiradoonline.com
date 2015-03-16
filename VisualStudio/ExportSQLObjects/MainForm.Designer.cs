namespace ExportSQLObjectsNameSpace
{
    partial class FormExportSQLObjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportSQLObjects));
            this.panel_Form = new System.Windows.Forms.Panel();
            this.textBox_Database = new System.Windows.Forms.TextBox();
            this.label_Database = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.label_Password = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_SelectOutputFolder = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.folderBrowserDialog_Form = new System.Windows.Forms.FolderBrowserDialog();
            this.statusBar_Form = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Form = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarLabel_Form = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_Form.SuspendLayout();
            this.statusBar_Form.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Form
            // 
            this.panel_Form.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Form.Controls.Add(this.textBox_Database);
            this.panel_Form.Controls.Add(this.label_Database);
            this.panel_Form.Controls.Add(this.button_Connect);
            this.panel_Form.Controls.Add(this.label_Password);
            this.panel_Form.Controls.Add(this.button_Start);
            this.panel_Form.Controls.Add(this.button_SelectOutputFolder);
            this.panel_Form.Controls.Add(this.textBox_Password);
            this.panel_Form.Controls.Add(this.textBox_Username);
            this.panel_Form.Controls.Add(this.label_Username);
            this.panel_Form.Controls.Add(this.textBox_Server);
            this.panel_Form.Controls.Add(this.label_Server);
            this.panel_Form.Location = new System.Drawing.Point(1, 0);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(339, 107);
            this.panel_Form.TabIndex = 0;
            // 
            // textBox_Database
            // 
            this.textBox_Database.Location = new System.Drawing.Point(67, 78);
            this.textBox_Database.Name = "textBox_Database";
            this.textBox_Database.Size = new System.Drawing.Size(139, 20);
            this.textBox_Database.TabIndex = 4;
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Location = new System.Drawing.Point(9, 82);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(56, 13);
            this.label_Database.TabIndex = 7;
            this.label_Database.Text = "Database:";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(215, 26);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(117, 23);
            this.button_Connect.TabIndex = 5;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(9, 56);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(56, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password:";
            // 
            // button_Start
            // 
            this.button_Start.Enabled = false;
            this.button_Start.Location = new System.Drawing.Point(214, 78);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(118, 23);
            this.button_Start.TabIndex = 7;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_SelectOutputFolder
            // 
            this.button_SelectOutputFolder.Enabled = false;
            this.button_SelectOutputFolder.Location = new System.Drawing.Point(214, 51);
            this.button_SelectOutputFolder.Name = "button_SelectOutputFolder";
            this.button_SelectOutputFolder.Size = new System.Drawing.Size(118, 23);
            this.button_SelectOutputFolder.TabIndex = 6;
            this.button_SelectOutputFolder.Text = "Select Output Folder";
            this.button_SelectOutputFolder.UseVisualStyleBackColor = true;
            this.button_SelectOutputFolder.Click += new System.EventHandler(this.button_SelectOutputFolder_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(67, 53);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(140, 20);
            this.textBox_Password.TabIndex = 3;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(66, 27);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(142, 20);
            this.textBox_Username.TabIndex = 2;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(7, 30);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(58, 13);
            this.label_Username.TabIndex = 2;
            this.label_Username.Text = "Username:";
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(66, 1);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(261, 20);
            this.textBox_Server.TabIndex = 1;
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(23, 4);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(41, 13);
            this.label_Server.TabIndex = 0;
            this.label_Server.Text = "Server:";
            // 
            // folderBrowserDialog_Form
            // 
            this.folderBrowserDialog_Form.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // statusBar_Form
            // 
            this.statusBar_Form.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Form,
            this.toolStripStatusLabel1,
            this.statusBarLabel_Form});
            this.statusBar_Form.Location = new System.Drawing.Point(0, 110);
            this.statusBar_Form.Name = "statusBar_Form";
            this.statusBar_Form.Size = new System.Drawing.Size(342, 22);
            this.statusBar_Form.TabIndex = 4;
            this.statusBar_Form.Text = "ss";
            // 
            // toolStripStatusLabel_Form
            // 
            this.toolStripStatusLabel_Form.Name = "toolStripStatusLabel_Form";
            this.toolStripStatusLabel_Form.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // statusBarLabel_Form
            // 
            this.statusBarLabel_Form.Name = "statusBarLabel_Form";
            this.statusBarLabel_Form.Size = new System.Drawing.Size(0, 17);
            // 
            // FormExportSQLObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(342, 132);
            this.Controls.Add(this.statusBar_Form);
            this.Controls.Add(this.panel_Form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormExportSQLObjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportSQLObjects";
            this.Load += new System.EventHandler(this.FormExportSQLObjects_Load);
            this.panel_Form.ResumeLayout(false);
            this.panel_Form.PerformLayout();
            this.statusBar_Form.ResumeLayout(false);
            this.statusBar_Form.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Form;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_SelectOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Form;
        private System.Windows.Forms.StatusStrip statusBar_Form;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Form;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel_Form;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.TextBox textBox_Database;
        private System.Windows.Forms.Label label_Database;
    }
}

