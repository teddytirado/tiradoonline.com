using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExportSQLObjectsNameSpace.classes;
using ClassLibraryNameSpace;

namespace ExportSQLObjectsNameSpace
{
    public partial class FormExportSQLObjects : Form
    {
        private string ExportFolderName = string.Empty;
        private string proceduresText = string.Empty;
        private string tablesText = string.Empty;
        private string viewsText = string.Empty;
        private string foreignkeysText = string.Empty;
        private SqlConnection objSQLConnection;
        private string registryFolder = @"HKEY_CURRENT_USER\Software\tiradoonline.com\ExportSQLObjects";

        public FormExportSQLObjects()
        {
            InitializeComponent();
        }

        private void FormExportSQLObjects_Load(object sender, EventArgs e)
        {

            Process[] processlist = Process.GetProcessesByName("ExportSQLObjects");
            if (processlist.Length > 1)
            {
                string Message = "Application is already running!!!";
                string Caption = "ExportSQLObjects";
                MessageBoxButtons Buttons = MessageBoxButtons.OK;
                MessageBox.Show(Message, Caption, Buttons, MessageBoxIcon.Error);

                Application.Exit();
            }

            this.ExportFolderName = this.GetRegistry();
            textBox_Server.Focus();
            this.Refresh();
            //textBox_Server.Text = @".\SQL2K8";
            //textBox_Username.Text = "Bankingintranet_user";
            //textBox_Password.Text = "Bankingintranet";
            //textBox_Database.Text = "BankingIntranet";
        }

        private void button_SelectOutputFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_Form.SelectedPath = Convert.ToString(Registry.GetValue(registryFolder, "ExportFolder", this.ExportFolderName));

            DialogResult result = folderBrowserDialog_Form.ShowDialog();
            if (result == DialogResult.OK)
            {

                this.ExportFolderName = folderBrowserDialog_Form.SelectedPath;
                statusBarLabel_Form.Text = "Export Folder: " + this.ExportFolderName;
                button_Start.Enabled = true;
                button_Start.Focus();
                this.Refresh();
            }

        }


        private void button_Start_Click(object sender, EventArgs e)
        {
            button_Connect.Enabled = false;
            button_SelectOutputFolder.Enabled = false;
            button_Start.Enabled = false;
            textBox_Server.Enabled = false;
            textBox_Username.Enabled = false;
            textBox_Password.Enabled = false;
            textBox_Database.Enabled = false;

            proceduresText = string.Empty;
            tablesText = string.Empty;
            viewsText = string.Empty;

            //this.ExportAllStoredProcedures(this.ExportFolderName + @"\procedures");

            //this.ExportAllTables(this.ExportFolderName + @"\tables");

            //this.ExportAllViews(this.ExportFolderName + @"\views");

            //StreamWriter SW;

            //string DirectoryPath = this.ExportFolderName + "\\procedures.sql";
            //SW = File.CreateText(DirectoryPath);
            //SW.WriteLine(proceduresText);
            //SW.Close();
            //SW = null;
            //Application.DoEvents();

            //StreamWriter SW2;
            //DirectoryPath = this.ExportFolderName + "\\tables.sql";
            //SW2 = File.CreateText(DirectoryPath);
            //SW2.WriteLine(tablesText);
            //SW2.Close();
            //SW2 = null;
            //Application.DoEvents();

            //StreamWriter SW3;
            //DirectoryPath = this.ExportFolderName + "\\foreign_keys.sql";
            //SW3 = File.CreateText(DirectoryPath);
            //try
            //{
            //    SW3.WriteLine(foreignkeysText);
            //}
            //catch (Exception ex)
            //{
            //    string error_message = ex.ToString(); ;
            //}
            //SW3.Close();
            //SW3 = null;
            //Application.DoEvents();

            //StreamWriter SW4;
            //DirectoryPath = this.ExportFolderName + "\\views.sql";
            //SW4 = File.CreateText(DirectoryPath);
            //SW4.WriteLine(viewsText);
            //SW4.Close();
            //SW4 = null;

            //StreamWriter SW5;
            //DirectoryPath = this.ExportFolderName + "\\schema.sql";
            //SW5 = File.CreateText(DirectoryPath);
            //SW5.WriteLine(tablesText + Environment.NewLine + Environment.NewLine + foreignkeysText + Environment.NewLine + viewsText + Environment.NewLine + Environment.NewLine + proceduresText);
            //SW5.Close();
            //SW5 = null;

            ClassLibrarySQLServer objExcel = new ClassLibrarySQLServer();
            objExcel.SQLServerName = textBox_Server.Text;
            objExcel.SQLServerDatabaseName = textBox_Database.Text;
            objExcel.SQLUserName = textBox_Username.Text;
            objExcel.SQLPassword = textBox_Password.Text;
            objExcel.OutputDirectory = folderBrowserDialog_Form.SelectedPath;
            objExcel.ExportTablesToExcel();
            objExcel = null;

            Application.DoEvents();


            if (objSQLConnection.State == ConnectionState.Open)
            {
                objSQLConnection.Close();
                objSQLConnection = null;

            }

            button_Connect.Enabled = true;
            button_SelectOutputFolder.Enabled = false;
            button_Start.Enabled = false;
            textBox_Server.Enabled = true;
            textBox_Username.Enabled = true;
            textBox_Password.Enabled = true;
            textBox_Database.Enabled = true;
            this.WriteToRegistry(ExportFolderName);

            string Message = "Export Complete!";
            statusBarLabel_Form.Text = Message;
            string Caption = "ExportSQLObjects";
            MessageBoxButtons Buttons = MessageBoxButtons.OK;
            MessageBox.Show(Message, Caption, Buttons);

            Process Explorer = new Process();

            Explorer.StartInfo.FileName = "Explorer.exe";
            Explorer.StartInfo.Arguments = this.ExportFolderName;

            Explorer.Start();


            statusBarLabel_Form.Text = "";
            this.Refresh();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            statusBarLabel_Form.Text = "Connecting....";
            this.Refresh();
            objSQLConnection = new SqlConnection(@"Data Source=" + textBox_Server.Text + ";Initial Catalog=" + textBox_Database.Text + ";User ID=" + textBox_Username.Text + ";Password=" + textBox_Password.Text);
            try
            {
                button_Connect.Enabled = false;
                button_SelectOutputFolder.Enabled = false;
                button_Start.Enabled = false;
                textBox_Server.Enabled = false;
                textBox_Username.Enabled = false;
                textBox_Password.Enabled = false;
                textBox_Database.Enabled = false;
                
                objSQLConnection.Open();
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    button_Connect.Enabled = false;
                    button_SelectOutputFolder.Enabled = true;
                    statusBarLabel_Form.Text = "Connected.";
                    button_SelectOutputFolder.Focus();
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                string ErrorMessage = ex.Message.ToString();
                string Message = "Cannot connect to server.";
                string Caption = "SQL Server Error";
                MessageBoxButtons Buttons = MessageBoxButtons.OK;
                MessageBox.Show(Message, Caption, Buttons);
                button_Connect.Enabled = true;
                textBox_Server.Enabled = true;
                textBox_Username.Enabled = true;
                textBox_Password.Enabled = true;
                textBox_Database.Enabled = true;
                statusBarLabel_Form.Text = "";
                this.Refresh();
            }
        }
        private void ExportAllStoredProcedures(string Export_Folder_Name)
        {
            //CHECK IF DIRECTORY EXISTS
            if (!Directory.Exists(Export_Folder_Name))
            {
                Directory.CreateDirectory(Export_Folder_Name);
            }


            statusBarLabel_Form.Text = "Exporting Stored Procedures....";
            this.Refresh();
            string ProcedureName = string.Empty;
            string ProcedureText = string.Empty;
            string DirectorySQLPath = string.Empty;
            string DirectoryPath = string.Empty;

            //string SQL = "SELECT NAME as ProcedureName, ProcedureText = (SELECT TEXT FROM SYSCOMMENTS WHERE id = sysobjects.id) FROM sysobjects WHERE TYPE = 'p' AND name not in ('sp_alterdiagram', 'sp_creatediagram', 'sp_dropdiagram', 'sp_helpdiagrams', 'sp_helpdiagramdefinition', 'sp_renamediagram', 'sp_upgraddiagrams') order by name";
            string SQL = "select a.name AS ProcedureName, B.TEXT AS ProcedureText FROM SYSOBJECTS a, SYSCOMMENTS b WHERE a.id = b.id AND a.type = 'P' AND LEFT(a.name, 3) <> 'dt_' AND a.name not in ('sp_alterdiagram', 'sp_creatediagram', 'sp_dropdiagram', 'sp_helpdiagrams', 'sp_helpdiagramdefinition', 'sp_renamediagram', 'sp_upgraddiagrams') order by name";

            try
            {
                SqlCommand objSQLCommand = new SqlCommand(SQL, objSQLConnection);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objTableNames = new DataTable();
                objSqlDataAdapter.Fill(objTableNames);

                if (objTableNames != null)
                {
                    if (objTableNames.Rows.Count > 0)
                    {

                        for (int x = 0; x < objTableNames.Rows.Count; x++)
                        {
                            DirectoryPath = Export_Folder_Name;
                            DataRow objDataRow = objTableNames.Rows[x];
                            ProcedureName = objTableNames.Rows[x]["ProcedureName"].ToString();
                            ProcedureText = objTableNames.Rows[x]["ProcedureText"].ToString();
                            bool contains = proceduresText.Contains("[teddy_user]");
                            ProcedureText = ProcedureText.Replace("[teddy_user]", "dbo");


                            StringBuilder objStringBuilder = new StringBuilder();
                            objStringBuilder.AppendLine("IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = '" + ProcedureName + "' AND TYPE = 'P')");
                            objStringBuilder.AppendLine("DROP PROCEDURE " + ProcedureName + ";");
                            objStringBuilder.AppendLine("GO");
                            objStringBuilder.AppendLine("");
                            objStringBuilder.AppendLine("");
                            objStringBuilder.AppendLine(ProcedureText);

                            proceduresText += ProcedureText;
                            proceduresText += Environment.NewLine;

                            objStringBuilder.AppendLine("GO");
                            StreamWriter SW;
                            DirectoryPath = DirectoryPath + "\\" + ProcedureName + ".sql";
                            SW = File.CreateText(DirectoryPath);
                            SW.WriteLine(objStringBuilder.ToString());
                            SW.Close();

                            // destroy
                            //objStringBuilder = null;
                            objDataRow = null;
                            SW = null;
                        }
                        // destroy

                    }
                }
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.ToString();
            }
        }

        private void ExportAllTables(string Export_Folder_Name)
        {
            string errorstring = string.Empty;
            string TableName = string.Empty;
            string TableText = string.Empty;
            string DirectoryPath = string.Empty;
            string SQL = string.Empty;

            //CHECK IF DIRECTORY EXISTS
            if (!Directory.Exists(Export_Folder_Name))
            {
                Directory.CreateDirectory(Export_Folder_Name);
            }

            statusBarLabel_Form.Text = "Exporting tables, primary keys and foreign keys....";
            this.Refresh();


            //foreignkeysText = string.Empty;
            //******************************
            //******** LIST OF TABLES ******
            //******************************
            SQL = "SELECT ID AS ObjectID, NAME AS ObjectName FROM SYSOBJECTS WHERE LEFT(NAME, 2) <> 'dt' AND TYPE = 'U' ORDER BY NAME";

            try
            {
                SqlCommand objSQLCommand = new SqlCommand(SQL, objSQLConnection);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objTableNames = new DataTable();
                objSqlDataAdapter.Fill(objTableNames);

                if (objTableNames != null)
                {
                    if (objTableNames.Rows.Count > 0)
                    {
                        //******************************
                        //******** LOOP THRU TABLES ******
                        //******************************
                        for (int x = 0; x < objTableNames.Rows.Count; x++)
                        {
                            DirectoryPath = Export_Folder_Name;
                            TableName = objTableNames.Rows[x]["ObjectName"].ToString();

                            //******************************
                            //******** LIST OF COLUMNS *****
                            //******************************

                            clsTables cls_Schema = new clsTables();
                            TableText = cls_Schema.GenerateTable(TableName, objSQLConnection, objTableNames);
                            TableText.Replace("teddy_user", "dbo");
                            StringBuilder objStringBuilder = new StringBuilder();
                            objStringBuilder.AppendLine("IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = '" + TableName + "' AND TYPE = 'U')");
                            objStringBuilder.AppendLine("DROP TABLE " + TableName + ";");
                            objStringBuilder.AppendLine("GO");
                            objStringBuilder.AppendLine("");
                            objStringBuilder.AppendLine(TableText);
                            objStringBuilder.AppendLine("");

                            tablesText += TableText;
                            tablesText += Environment.NewLine;

                            SqlCommand objSQLCommand2 = new SqlCommand("sp_pkeys", objSQLConnection);
                            objSQLCommand2.CommandType = CommandType.StoredProcedure;
                            objSQLCommand2.Parameters.AddWithValue("@table_name", TableName);
                            objSqlDataAdapter = new SqlDataAdapter(objSQLCommand2);
                            DataTable objPK = new DataTable();
                            objSqlDataAdapter.Fill(objPK);

                            if (objPK.Rows.Count > 0)
                            {
                                objStringBuilder.AppendLine("");

                                for (int y = 0; y < objPK.Rows.Count; y++)
                                {
                                    string pk_name = objPK.Rows[y]["PK_NAME"].ToString();
                                    string column_name = objPK.Rows[y]["COLUMN_NAME"].ToString();

                                    objStringBuilder.AppendLine("");
                                    string pkstring = "ALTER TABLE " + TableName + " ADD CONSTRAINT " + pk_name + " PRIMARY KEY (" + column_name + ");";
                                    objStringBuilder.AppendLine("GO");
                                    objStringBuilder.AppendLine("");
                                    tablesText += pkstring + Environment.NewLine + "GO" + Environment.NewLine + Environment.NewLine;
                                    tablesText += Environment.NewLine;
                                }

                            }

                            string sql = "SELECT K_Table = FK.TABLE_NAME, FK_Column = CU.COLUMN_NAME, PK_Table = PK.TABLE_NAME, PK_Column = PT.COLUMN_NAME, Constraint_Name = C.CONSTRAINT_NAME FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME INNER JOIN ( SELECT i1.TABLE_NAME, i2.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY' ) PT ON PT.TABLE_NAME = PK.TABLE_NAME WHERE FK.TABLE_NAME='" + TableName + "' ORDER BY 1,2,3,4";
                            SqlCommand objSQLCommand3 = new SqlCommand(sql, objSQLConnection);
                            objSQLCommand3.CommandType = CommandType.Text;
                            objSqlDataAdapter = new SqlDataAdapter(objSQLCommand3);
                            DataTable objFK = new DataTable();
                            objSqlDataAdapter.Fill(objFK);

                            if (objFK.Rows.Count > 0)
                            {
                                objStringBuilder.AppendLine("");

                                for (int y = 0; y < objFK.Rows.Count; y++)
                                {
                                    string constraint_name = objFK.Rows[y]["CONSTRAINT_NAME"].ToString();
                                    string fk_table = objFK.Rows[y]["PK_TABLE"].ToString();
                                    string fk_column_name = objFK.Rows[y]["FK_COLUMN"].ToString();
                                    string pk_column_name = objFK.Rows[y]["pK_COLUMN"].ToString();

                                    foreignkeysText += "ALTER TABLE " + TableName + " ADD CONSTRAINT " + constraint_name + " FOREIGN KEY (" + fk_column_name + ") REFERENCES " + fk_table + "(" + pk_column_name + ");" + Environment.NewLine;
                                    foreignkeysText += "GO" + Environment.NewLine + Environment.NewLine;
                                }

                            }


                            
                            objStringBuilder.AppendLine("GO");


                            StreamWriter SW;
                            DirectoryPath = DirectoryPath + "\\" + TableName + ".sql";
                            SW = File.CreateText(DirectoryPath);
                            SW.WriteLine(objStringBuilder.ToString());
                            SW.Close();

                            
                            string s = string.Empty;

                        }
                    }
                }
            }
            catch (SqlException objSqlException)
            {
                errorstring = objSqlException.ToString();
            }
        }

        private void ExportAllViews(string Export_Folder_Name)
        {
            //CHECK IF DIRECTORY EXISTS
            if (!Directory.Exists(Export_Folder_Name))
            {
                Directory.CreateDirectory(Export_Folder_Name);
            }


            statusBarLabel_Form.Text = "Exporting Views....";
            this.Refresh();
            string ViewName = string.Empty;
            string ViewText = string.Empty;
            string DirectorySQLPath = string.Empty;
            string DirectoryPath = string.Empty;

            //string SQL = "SELECT NAME as ViewName, ViewText = (SELECT TEXT FROM SYSCOMMENTS WHERE id = sysobjects.id) FROM sysobjects WHERE TYPE = 'p' AND name not in ('sp_alterdiagram', 'sp_creatediagram', 'sp_dropdiagram', 'sp_helpdiagrams', 'sp_helpdiagramdefinition', 'sp_renamediagram', 'sp_upgraddiagrams') order by name";
            string SQL = "select a.name AS ViewName, B.TEXT AS ViewText FROM SYSOBJECTS a, SYSCOMMENTS b WHERE a.id = b.id AND a.type = 'V' AND LEFT(a.name, 3) <> 'dt_' AND a.name not in ('sp_alterdiagram', 'sp_creatediagram', 'sp_dropdiagram', 'sp_helpdiagrams', 'sp_helpdiagramdefinition', 'sp_renamediagram', 'sp_upgraddiagrams') order by name";

            try
            {
                SqlCommand objSQLCommand = new SqlCommand(SQL, objSQLConnection);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objTableNames = new DataTable();
                objSqlDataAdapter.Fill(objTableNames);

                if (objTableNames != null)
                {
                    if (objTableNames.Rows.Count > 0)
                    {

                        for (int x = 0; x < objTableNames.Rows.Count; x++)
                        {
                            DirectoryPath = Export_Folder_Name;
                            DataRow objDataRow = objTableNames.Rows[x];
                            ViewName = objTableNames.Rows[x]["ViewName"].ToString();
                            ViewText = objTableNames.Rows[x]["ViewText"].ToString();
                            ViewText.Replace("teddy_user", "dbo");

                            StringBuilder objStringBuilder = new StringBuilder();
                            objStringBuilder.AppendLine("IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = '" + ViewName + "' AND TYPE = 'P')");
                            objStringBuilder.AppendLine("DROP View " + ViewName + ";");
                            objStringBuilder.AppendLine("GO");
                            objStringBuilder.AppendLine("");
                            objStringBuilder.AppendLine("");
                            objStringBuilder.AppendLine(ViewText);

                            viewsText += ViewText;
                            viewsText += Environment.NewLine;

                            objStringBuilder.AppendLine("GO");
                            StreamWriter SW;
                            DirectoryPath = DirectoryPath + "\\" + ViewName + ".sql";
                            SW = File.CreateText(DirectoryPath);
                            SW.WriteLine(objStringBuilder.ToString());
                            SW.Close();

                            // destroy
                            //objStringBuilder = null;
                            objDataRow = null;
                            SW = null;
                        }
                        // destroy

                    }
                }
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.ToString();
            }
        }


        private void WriteToRegistry(string ExportFolderName)
        {
            Registry.SetValue(registryFolder, "ExportFolder", ExportFolderName);
            Registry.SetValue(registryFolder, "Server", textBox_Server.Text);
            Registry.SetValue(registryFolder, "UserName", textBox_Username.Text);
            //Registry.SetValue(registryFolder, "Password", textBox_Password.Text);
            Registry.SetValue(registryFolder, "Database", textBox_Database.Text);
        }

        private string GetRegistry()
        {
            textBox_Server.Text = Convert.ToString(Registry.GetValue(registryFolder, "Server", textBox_Server.Text));
            textBox_Username.Text = Convert.ToString(Registry.GetValue(registryFolder, "UserName", textBox_Username.Text));
            //textBox_Password.Text =  Convert.ToString(Registry.GetValue(registryFolder, "Password", textBox_Password.Text));
            textBox_Database.Text = Convert.ToString(Registry.GetValue(registryFolder, "Database", textBox_Database.Text));
            return Convert.ToString(Registry.GetValue(registryFolder, "ExportFolder", ""));
        }
    }
}
