using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryNameSpace;

namespace pdf.tiradoonline.com
{
    public partial class PDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassLibraryPDF objPDF = new ClassLibraryPDF();

            string htmlFileName = @"C:\Storage\www\balanceintranet.tiradoonline.com\www\timesheet\invoices\1001\Manhattan_Information_Systems_Invoice_1030.html";

            objPDF.GeneratePDF(htmlFileName);

            objPDF = null;


        }
    }
}