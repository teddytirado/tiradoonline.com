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
        public void GeneratePDF(string PDF_FileName, string HTML)
        {
            try
            {

                FileStream fs = new FileStream(PDF_FileName, FileMode.Create);

                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.Add(new Paragraph(HTML));

                doc.Close();
                fs.Close();

                doc = null;
                fs = null;                
            }
            catch (Exception e)
            {
                string s = e.ToString();
            }
        }
    
    
    }
}
