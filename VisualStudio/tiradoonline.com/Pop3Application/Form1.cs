using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibraryNameSpace;

namespace Pop3Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassLibrarySQLServer objSQL = new ClassLibrarySQLServer();
            
            objSQL.SQLServerName = @".\SQL2K8";
            objSQL.SQLServerDatabaseName = "HebrewHome";
            objSQL.SQLUserName = "hebrewhome_user";
            objSQL.SQLPassword = "hebrewhome";
            objSQL.OutputDirectory = @"C:\Storage\";
            objSQL.ExportTablesToExcel();

            objSQL = null;

            this.Close();
            //this.Show();
            //POP3 objPop3 = new POP3();

            //DataTable objDataTable = objPop3.POPEmailMessages(txtLogs, progressBarPOP3, "pop.tiradoonline.com", 110, false, "developer@tiradoonline.com", "sixpak1414");

            //dataPop3GridView.DataSource = objDataTable;
        }
    }
}