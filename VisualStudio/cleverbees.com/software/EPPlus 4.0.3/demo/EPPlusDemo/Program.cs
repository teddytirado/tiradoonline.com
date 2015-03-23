/*
Copyright (c) 2010 Brendan G Fry a.k. FryHard

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in 
the Software without restriction, including without limitation the rights to 
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software is furnished to do 
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all 
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;

namespace Fryhard.EPPlusDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                const string fileName = "data\\ExampleData.xlsx";
                const int startRow = 4;

                string folder = Assembly.GetEntryAssembly().Location;
                if (folder != null)
                {
                    folder = Path.GetDirectoryName(folder);
                    string filePath = Path.Combine(folder, fileName);
                    IList<ExampleData> exampleDataList = new List<ExampleData>();


                    // Get the file we are going to process
                    var existingFile = new FileInfo(filePath); 
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
                                object col1Header = currentWorksheet.Cells[startRow, 1].Value;
                                object col2Header = currentWorksheet.Cells[startRow, 2].Value;

                                if (((col1Header != null) && (col1Header.ToString() == "Type of Accident")) &&
                                    ((col2Header != null) && (col2Header.ToString() == "Google Results")))
                                {

                                    for (int rowNumber = startRow + 1; rowNumber <= currentWorksheet.Dimension.End.Row; rowNumber++)
                                        // read each row from the start of the data (start row + 1 header row) to the end of the spreadsheet.
                                    {
                                        object col1Value = currentWorksheet.Cells[rowNumber, 1].Value;
                                        object col2Value = currentWorksheet.Cells[rowNumber, 2].Value;

                                        if ((col1Value != null) && (col2Value != null))
                                        {
                                            exampleDataList.Add(new ExampleData {KillingOccurance = col1Value.ToString(), NumberResults = Convert.ToInt32(col2Value)});
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Example data incorrectly formatted.");
                                }
                            }
                        }
                    }

                    Console.WriteLine("Type of Accident\t\t | Google Results");
                    Console.WriteLine("----------------\t\t | --------------");
                    Console.WriteLine();

                    //Display the data
                    foreach (ExampleData exampleData in exampleDataList)
                    {
                        Console.WriteLine(exampleData);
                    }
                }
                else
                {
                    Console.WriteLine("Could not find excecuting path.");
                }
            }
            catch (IOException ioEx)
            {
                if (!String.IsNullOrEmpty(ioEx.Message))
                {
                    if (ioEx.Message.Contains("because it is being used by another process."))
                    {
                        Console.WriteLine("Could not read example data. Please make sure it not open in Excel.");
                    }
                }
                Console.WriteLine("Could not read example data. " + ioEx.Message, ioEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while reading example data. " + ex.Message, ex);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("press any key to exit.");
                Console.ReadKey();
            }
        }
    }

    class ExampleData
    {
        public string KillingOccurance { get; set; }
        public int NumberResults { get; set; }

        public override string ToString()
        {
            return KillingOccurance.PadRight(8, ' ') + "\t\t\t | " + NumberResults.ToString().PadLeft(3, ' ');
        }
    }
}

