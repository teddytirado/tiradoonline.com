using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using ClassLibraryNameSpace;

namespace SQLProfilerNameSpace
{
    public partial class SQLProfilerMainForm : Form
    {
        private string ApplicationTitle = "Bankingintranet.tiradoonline.com - SQL Profiler";
        private int profileType = 3;
        private bool AppRunning = true;

        public SQLProfilerMainForm()
        {
            InitializeComponent();
            profilerType3.Checked = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            frmDataGridView_Bind(profileType);
            this.Text = ApplicationTitle + ": Last Refreshed: " + DateTime.Now.ToString();
            frmTimer.Interval = 2000;
        }

        private void frmDataGridView_Bind(int profilerType)
        {
            if (AppRunning)
            {
                try
                {
                    ClassLibraryDataProvider objDataProvider = new ClassLibraryDataProvider();
                    SqlParameter[] sqlParameterArray = 
                    {
                        new SqlParameter("@ProfilerType", profilerType)
                    };

                    DataTable objDataTable = objDataProvider.GetDataTable("sp_Profiler_get", CommandType.StoredProcedure, sqlParameterArray);

                    frmDataGridView.DataSource = objDataTable;

                    frmDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    frmDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    frmDataGridView.Columns[0].Width = 120;
                    frmDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    frmDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    frmDataGridView.Columns[2].Width = frmDataGridView.Width - frmDataGridView.Columns[0].Width - frmDataGridView.Columns[1].Width - 65;

                    for (int x = 0; x < objDataTable.Rows.Count; x++)
                    {
                        DataGridViewRow row = frmDataGridView.Rows[x];
                        row.Height = 50;
                        if (x % 2 == 0)
                            row.DefaultCellStyle.BackColor = Color.LightGray;

                        row = null;
                    }

                    objDataProvider = null;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "SQL Profiler - Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }

        /*
         ALLOWS WORD WRAPPING
        */
        private void frmDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null)
                return;
            var s = e.Graphics.MeasureString(e.Value.ToString(), frmDataGridView.Font);
            if (s.Width > frmDataGridView.Columns[e.ColumnIndex].Width)
            {
                using (Brush gridBrush = new SolidBrush(this.frmDataGridView.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    e.Graphics.DrawString(e.Value.ToString(), frmDataGridView.Font, Brushes.Black, e.CellBounds, StringFormat.GenericDefault);
                    frmDataGridView.Rows[e.RowIndex].Height = (int)(s.Height * Math.Ceiling(s.Width / frmDataGridView.Columns[e.ColumnIndex].Width));
                    e.Handled = true;
                }
            }
        }

        private void frmTimer_Tick(object sender, EventArgs e)
        {
            if (AppRunning)
            {
                this.Text = ApplicationTitle + ": Last Refreshed: " + DateTime.Now.ToString();
                frmDataGridView_Bind(profileType);
            }
        }

        private void profileType1_CheckedChanged(object sender, EventArgs e)
        {
            profileType = 1;
            frmDataGridView_Bind(profileType);
        }

        private void profilerType2_CheckedChanged(object sender, EventArgs e)
        {
            profileType = 2;
            frmDataGridView_Bind(profileType);
        }

        private void profilerType3_CheckedChanged(object sender, EventArgs e)
        {
            profileType = 3;
            frmDataGridView_Bind(profileType);
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            AppRunning = true;
            btnOff.Enabled = true;
            btnOn.Enabled = false;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            AppRunning = false;
            btnOff.Enabled = false;
            btnOn.Enabled = true;
        }

        private void frmDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2) {
                DataGridViewRow objGridViewRow = frmDataGridView.Rows[e.RowIndex];
                string cellContents = objGridViewRow.Cells[e.ColumnIndex].Value.ToString();
                Clipboard.SetText(cellContents);
            }
        }

    }
}
