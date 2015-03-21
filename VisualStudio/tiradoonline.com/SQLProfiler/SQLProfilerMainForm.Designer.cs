namespace SQLProfilerNameSpace
{
    partial class SQLProfilerMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLProfilerMainForm));
            this.frmDataGridView = new System.Windows.Forms.DataGridView();
            this.frmTimer = new System.Windows.Forms.Timer(this.components);
            this.profileType1 = new System.Windows.Forms.RadioButton();
            this.profilerType2 = new System.Windows.Forms.RadioButton();
            this.profilerType3 = new System.Windows.Forms.RadioButton();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frmDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // frmDataGridView
            // 
            this.frmDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.frmDataGridView.Location = new System.Drawing.Point(4, 36);
            this.frmDataGridView.Name = "frmDataGridView";
            this.frmDataGridView.Size = new System.Drawing.Size(1091, 481);
            this.frmDataGridView.TabIndex = 0;
            this.frmDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.frmDataGridView_CellContentClick);
            // 
            // frmTimer
            // 
            this.frmTimer.Enabled = true;
            this.frmTimer.Interval = 5000;
            this.frmTimer.Tick += new System.EventHandler(this.frmTimer_Tick);
            // 
            // profileType1
            // 
            this.profileType1.AutoSize = true;
            this.profileType1.Enabled = false;
            this.profileType1.Location = new System.Drawing.Point(13, 13);
            this.profileType1.Name = "profileType1";
            this.profileType1.Size = new System.Drawing.Size(46, 17);
            this.profileType1.TabIndex = 1;
            this.profileType1.TabStop = true;
            this.profileType1.Text = "SQL";
            this.profileType1.UseVisualStyleBackColor = true;
            this.profileType1.CheckedChanged += new System.EventHandler(this.profileType1_CheckedChanged);
            // 
            // profilerType2
            // 
            this.profilerType2.AutoSize = true;
            this.profilerType2.Enabled = false;
            this.profilerType2.Location = new System.Drawing.Point(65, 13);
            this.profilerType2.Name = "profilerType2";
            this.profilerType2.Size = new System.Drawing.Size(48, 17);
            this.profilerType2.TabIndex = 2;
            this.profilerType2.TabStop = true;
            this.profilerType2.Text = "Logs";
            this.profilerType2.UseVisualStyleBackColor = true;
            this.profilerType2.CheckedChanged += new System.EventHandler(this.profilerType2_CheckedChanged);
            // 
            // profilerType3
            // 
            this.profilerType3.AutoSize = true;
            this.profilerType3.Location = new System.Drawing.Point(119, 13);
            this.profilerType3.Name = "profilerType3";
            this.profilerType3.Size = new System.Drawing.Size(47, 17);
            this.profilerType3.TabIndex = 3;
            this.profilerType3.TabStop = true;
            this.profilerType3.Text = "Both";
            this.profilerType3.UseVisualStyleBackColor = true;
            this.profilerType3.CheckedChanged += new System.EventHandler(this.profilerType3_CheckedChanged);
            // 
            // btnOn
            // 
            this.btnOn.Enabled = false;
            this.btnOn.Location = new System.Drawing.Point(945, 4);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(72, 30);
            this.btnOn.TabIndex = 4;
            this.btnOn.Text = "&On";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOff
            // 
            this.btnOff.Location = new System.Drawing.Point(1023, 4);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(72, 30);
            this.btnOff.TabIndex = 5;
            this.btnOff.Text = "&Off";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // SQLProfilerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 520);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.profilerType3);
            this.Controls.Add(this.profilerType2);
            this.Controls.Add(this.profileType1);
            this.Controls.Add(this.frmDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLProfilerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.frmDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView frmDataGridView;
        private System.Windows.Forms.Timer frmTimer;
        private System.Windows.Forms.RadioButton profileType1;
        private System.Windows.Forms.RadioButton profilerType2;
        private System.Windows.Forms.RadioButton profilerType3;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;


    }
}