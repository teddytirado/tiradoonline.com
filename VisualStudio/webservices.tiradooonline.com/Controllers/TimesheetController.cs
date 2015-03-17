using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClassLibraryNameSpace;

namespace MVC3WebApplication.Controllers
{
    public class TimesheetController : Controller
    {
        //
        // GET: /Timesheet/

        public ActionResult Index(string TimesheetID, string redirectURL)
        {
            ClassLibraryPDF objPDF = new ClassLibraryPDF();

            objPDF.GeneratePDF(Convert.ToInt32(TimesheetID));
            return View();
        }

    }
}
