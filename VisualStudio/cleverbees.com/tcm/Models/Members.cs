using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;

namespace tcm.Models
{
    public class MembersModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CurrentGrade { get; set; }
        public string Hive { get; set; }
        public string Status { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string MotherCell { get; set; }
        public string DadCell { get; set; }
        public string HomeNumber { get; set; }
        public string Code { get; set; }
    }

    public class Members
    {

        private static Hashtable myHashtable = new Hashtable();
        private static string processName = @"EXCEL";

        public static List<MembersModel> ImportExcel(string excelFileName)
        {
            // KILL ALL EXCEL PRCESSES
            KillExcel();

            List<MembersModel> listMembersModel = new List<MembersModel>();

            if (File.Exists(excelFileName))
            {
                Application app = new Application();
                Workbook book = null;
                Range range = null;

                try
                {
                    string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

                    book = app.Workbooks.Open(excelFileName, Missing.Value, Missing.Value, Missing.Value
                                                        , Missing.Value, Missing.Value, Missing.Value, Missing.Value
                                                        , Missing.Value, Missing.Value, Missing.Value, Missing.Value
                                                    , Missing.Value, Missing.Value, Missing.Value);
                    foreach (Worksheet sheet in book.Worksheets)
                    {

                        // get a range to work with
                        range = sheet.get_Range("A1", "N1000");
                        // get the end of values to the right (will stop at the first empty cell)
                        //range = range.get_End(XlDirection.xlToRight);
                        // get the end of values toward the bottom, looking in the last column (will stop at first empty cell)
                        //range = range.get_End(XlDirection.xlDown);

                        // get the address of the bottom, right cell
                        string downAddress = range.get_Address(
                            false, false, XlReferenceStyle.xlA1,
                            Type.Missing, Type.Missing);

                        // Get the range, then values from a1
                        range = sheet.get_Range("A1", downAddress);
                        object[,] values = (object[,])range.Value2;

                        // View the values
                        //Debug.Write("\t");
                        //Debug.WriteLine("");




                        //Debug.Print(values.GetLength(0).ToString());

                        for (int i = 2; i <= 1000; i++)
                        {
                            int x = 1;

                            MembersModel objMembersModel = new MembersModel();
                            objMembersModel.LastName = Convert.ToString(values[i, x]);
                            if(string.IsNullOrEmpty(objMembersModel.LastName))
                                break;

                            x++;
                            objMembersModel.FirstName = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.CurrentGrade = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.Hive = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.Status = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.DOB = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.Address = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.City = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.State = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.Zip = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.MotherCell = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.DadCell = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.HomeNumber = Convert.ToString(values[i, x]);
                            x++;
                            objMembersModel.Code = Convert.ToString(values[i, x]);

                            listMembersModel.Add(objMembersModel);
                            //for (int j = 1; j <= values.GetLength(1); j++)
                            //{

                            //    Debug.Write(String.Format("{0}\t", values[i, j]));
                            //}
                            objMembersModel = null;

                            Debug.WriteLine("");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    range = null;
                    if (book != null)
                        book.Close(false, Missing.Value, Missing.Value);
                    book = null;
                    KillExcel();
                }
            }
            return listMembersModel;
        }

        private static void CheckExcellProcesses()
        {
            //Process[] AllProcesses = Process.GetProcesses("TEDDY_LAPTOP");
            Process[] AllProcesses = Process.GetProcessesByName(processName);
            int totalExcels = AllProcesses.Count();

            myHashtable = new Hashtable();
            int iCount = 0;

            foreach (Process ExcelProcess in AllProcesses)
            {
                Debug.Print(ExcelProcess.Id.ToString() + ": " + ExcelProcess.ProcessName);
                myHashtable.Add(ExcelProcess.Id, iCount);
                iCount = iCount + 1;
            }
        }

        private static void KillExcel()
        {
            CheckExcellProcesses();

            Process[] AllProcesses = Process.GetProcessesByName(processName);

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                if (myHashtable.ContainsKey(ExcelProcess.Id) == true)
                    ExcelProcess.Kill();
            }

            AllProcesses = null;
        }
    }
}
