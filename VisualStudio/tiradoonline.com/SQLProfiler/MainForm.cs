using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLProfilerNameSpace
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string registryFolder = @"HKEY_CURRENT_USER\Software\tiradoonline.com\ExportSQLObjects";
        }
    }
}
