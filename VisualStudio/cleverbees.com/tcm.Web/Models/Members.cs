using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;
using tcm.App_Data;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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

        public IQueryable<Member> listMembersTable;
    }

    public class Members
    {

        private static Hashtable myHashtable = new Hashtable();
        private static string processName = @"EXCEL";
        private static DBDataContext db = new DBDataContext();

        //public static List<MembersModel> ImportExcel(string excelFileName)
        //{
        //    // KILL ALL EXCEL PRCESSES
        //    //KillExcel();

        //    List<MembersModel> listMembersModel = new List<MembersModel>();

        //    if (File.Exists(excelFileName))
        //    {
        //        //Thread.Sleep(5000);

        //        Excel.Application app = new Excel.Application();
        //        Excel.Workbook book = null;
        //        Excel.Range range = null;

        //        try
        //        {
        //            string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

        //            book = app.Workbooks.Open(excelFileName, Missing.Value, Missing.Value, Missing.Value
        //                                                , Missing.Value, Missing.Value, Missing.Value, Missing.Value
        //                                                , Missing.Value, Missing.Value, Missing.Value, Missing.Value
        //                                            , Missing.Value, Missing.Value, Missing.Value);
        //            foreach (Excel.Worksheet sheet in book.Worksheets)
        //            {

        //                // get a range to work with
        //                range = sheet.get_Range("A1", "N1000");
        //                // get the end of values to the right (will stop at the first empty cell)
        //                //range = range.get_End(XlDirection.xlToRight);
        //                // get the end of values toward the bottom, looking in the last column (will stop at first empty cell)
        //                //range = range.get_End(XlDirection.xlDown);

        //                // get the address of the bottom, right cell
        //                string downAddress = range.get_Address(
        //                    false, false, Excel.XlReferenceStyle.xlA1,
        //                    Type.Missing, Type.Missing);

        //                // Get the range, then values from a1
        //                range = sheet.get_Range("A1", downAddress);
        //                object[,] values = (object[,])range.Value2;

        //                // View the values
        //                //Debug.Write("\t");
        //                //Debug.WriteLine("");




        //                //Debug.Print(values.GetLength(0).ToString());

        //                for (int i = 2; i <= 1000; i++)
        //                {
        //                    int x = 1;

        //                    MembersModel objMembersModel = new MembersModel();
        //                    objMembersModel.LastName = Convert.ToString(values[i, x]);
        //                    if(string.IsNullOrEmpty(objMembersModel.LastName))
        //                        break;

        //                    x++;
        //                    objMembersModel.FirstName = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.CurrentGrade = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.Hive = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.Status = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.DOB = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.Address = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.City = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.State = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.Zip = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.MotherCell = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.DadCell = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.HomeNumber = Convert.ToString(values[i, x]);
        //                    x++;
        //                    objMembersModel.Code = Convert.ToString(values[i, x]);

        //                    listMembersModel.Add(objMembersModel);
        //                    //for (int j = 1; j <= values.GetLength(1); j++)
        //                    //{

        //                    //    Debug.Write(String.Format("{0}\t", values[i, j]));
        //                    //}
        //                    objMembersModel = null;

        //                    Debug.WriteLine("");
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex.ToString());
        //        }
        //        finally
        //        {
        //            range = null;
        //            if (book != null)
        //                book.Close(false, Missing.Value, Missing.Value);
        //            book = null;
        //            //KillExcel();
        //        }
        //    }
        //    return listMembersModel;
        //}

        public static List<MembersModel> ImportExcel(string excelFileName)
        {
            // KILL ALL EXCEL PRCESSES
            //KillExcel();

            List<MembersModel> listMembersModel = new List<MembersModel>();

            if (File.Exists(excelFileName))
            {
        
                try
                {
                    // Get the file we are going to process
                    var existingFile = new FileInfo(excelFileName);

                    // Open and read the XlSX file.
                    using (var package = new ExcelPackage(existingFile))
                    {
                        // Get the work book in the file
                        ExcelWorkbook workBook = package.Workbook;

                        if (workBook != null)
                        {
                            if (workBook.Worksheets.Count > 0)
                            {
                                // Get the first worksheet
                                ExcelWorksheet currentWorksheet = workBook.Worksheets.First();

                                // read some data
            
                                for (int i = 2; i <= 1000; i++)
                                {
                                    Debug.Print("Row: " + i.ToString());
                                    object col1Value = currentWorksheet.Cells[i, 1].Value;
                                    object col2Value = currentWorksheet.Cells[i, 2].Value;
                                    object col3Value = currentWorksheet.Cells[i, 3].Value;
                                    object col4Value = currentWorksheet.Cells[i, 4].Value;
                                    object col5Value = currentWorksheet.Cells[i, 5].Value;
                                    object col6Value = currentWorksheet.Cells[i, 6].Value;
                                    object col7Value = currentWorksheet.Cells[i, 7].Value;
                                    object col8Value = currentWorksheet.Cells[i, 8].Value;
                                    object col9Value = currentWorksheet.Cells[i, 9].Value;
                                    object col10Value = currentWorksheet.Cells[i, 10].Value;
                                    object col11Value = currentWorksheet.Cells[i, 11].Value;
                                    object col12Value = currentWorksheet.Cells[i, 12].Value;
                                    object col13Value = currentWorksheet.Cells[i, 13].Value;
                                    object col14Value = currentWorksheet.Cells[i, 14].Value;

                                    MembersModel objMembersModel = new MembersModel();
                                    objMembersModel.LastName = Convert.ToString(col1Value);
                                    Debug.Print("LastName");

                                    if (string.IsNullOrEmpty(objMembersModel.LastName))
                                        break;
                                
                                    objMembersModel.FirstName = Convert.ToString(col2Value);
                                    Debug.Print("FirstName: " + objMembersModel.FirstName);
                                    objMembersModel.CurrentGrade = Convert.ToString(col3Value);
                                    Debug.Print("CurrentGrade: " + objMembersModel.CurrentGrade);
                                    objMembersModel.Hive = Convert.ToString(col4Value);
                                    Debug.Print("Hive: " + objMembersModel.Hive);
                                    objMembersModel.Status = Convert.ToString(col5Value);
                                    Debug.Print("Status: " + objMembersModel.Status);
                                    objMembersModel.DOB = Convert.ToString(col6Value);
                                    Debug.Print("DOB: " + objMembersModel.DOB);
                                    objMembersModel.Address = Convert.ToString(col7Value);
                                    Debug.Print("Address: " + objMembersModel.Address);
                                    objMembersModel.City = Convert.ToString(col8Value);
                                    Debug.Print("City: " + objMembersModel.City);
                                    objMembersModel.State = Convert.ToString(col9Value);
                                    Debug.Print("State.: " + objMembersModel.State);
                                    objMembersModel.Zip = Convert.ToString(col10Value);
                                    Debug.Print("Zip: " + objMembersModel.Zip);
                                    objMembersModel.MotherCell = Convert.ToString(col11Value);
                                    Debug.Print("MotherCell: " + objMembersModel.MotherCell);
                                    objMembersModel.DadCell = Convert.ToString(col12Value);
                                    Debug.Print("DadCell: " + objMembersModel.DadCell);
                                    objMembersModel.HomeNumber = Convert.ToString(col13Value);
                                    Debug.Print("HomeNumber: " + objMembersModel.HomeNumber);
                                    objMembersModel.Code = Convert.ToString(col14Value);
                                    Debug.Print("Code: " + objMembersModel.Code);

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
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                finally
                {

                    //KillExcel();
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

        public static void KillExcel()
        {
            CheckExcellProcesses();

            Process[] AllProcesses = Process.GetProcessesByName(processName);

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                if (myHashtable.ContainsKey(ExcelProcess.Id) == true)
                {
                    //ExcelProcess.Kill();
                    //Thread.Sleep(2000);
                }
            }

            AllProcesses = null;
        }

        public static IQueryable<Member> Get_Members_Table()
        {
            var ors = (from members in db.Members
                       select members);

            return ors;
        }

        public static IQueryable<School> Get_Schools_Table()
        {
            var ors = (from Schools in db.Schools
                       select Schools);

            return ors;
        }

        public static IQueryable<School_StudentMember> Get_School_StudentMember_Table()
        {
            var ors = (from members in db.School_StudentMembers
                       select members);

            return ors;
        }

        public static IQueryable<Member_School> Get_Member_School_Table()
        {
            var ors = (from members in db.Member_Schools
                       select members);

            return ors;
        }


        public static bool Add_Members(MembersModel modelMembers)
        {
            try
            {
            }
            catch (Exception ex)
            {
                string errorMessage = ex.ToString();
            }

            return true;

        }
    }
}
