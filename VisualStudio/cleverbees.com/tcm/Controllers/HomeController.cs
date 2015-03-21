using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcm.Models;

namespace tcm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            string excelFileName = Server.MapPath("/uploads/Members.xlsx");
            List<MembersModel> listMembersModel = tcm.Models.Members.ImportExcel(excelFileName);
            return View(listMembersModel);
        }
}
}
