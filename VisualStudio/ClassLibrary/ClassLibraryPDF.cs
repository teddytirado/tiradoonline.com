using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryPDF
    {
        private DBDataContext db = new DBDataContext();

        //public void GeneratePDF(string templateFile)
        //{
        //    try
        //    {
        //        string pdfFileName = templateFile.Replace(".html", ".pdf");
        //        ClassLibraryFileIO objFileIO = new ClassLibraryFileIO();
        //        string invoiceContents = ClassLibraryFileIO.ReadFile(templateFile);

        //        FileStream fs = new FileStream(pdfFileName, FileMode.Create);
                
        //        Document doc = new Document();
        //        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
        //        doc.Open();
        //        doc.Add(new Paragraph(invoiceContents));

        //        doc.Close();
        //        fs.Close();

        //        doc = null;
        //        fs = null;
        //    }
        //    catch (Exception e)
        //    {
        //        string s = e.ToString();
        //    }
        //}

        public void GeneratePDF(int TimesheetID)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                string s = e.ToString();
            }
        }
    
    
    }
}
