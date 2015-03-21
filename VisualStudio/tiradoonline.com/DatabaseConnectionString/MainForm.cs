using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibraryNameSpace;

namespace DatabaseConnectionStringNameSpace
{
    public partial class MainForm : Form
    {
        public ClassLibraryRegistry objClassLibraryRegistry = new ClassLibraryRegistry();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objClassLibraryRegistry.DatabaseConnectionString = txtDatabaseConnectionString.Text;
            btnSave.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtDatabaseConnectionString.Text = objClassLibraryRegistry.DatabaseConnectionString;
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
