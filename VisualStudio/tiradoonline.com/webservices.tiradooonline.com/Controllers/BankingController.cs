using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using ClassLibraryNameSpace;

namespace MVC3WebApplication.Controllers
{
    public class BankingController : Controller
    {

        public JsonResult GetBankingAccount(int? UserID)
        {
            List<ClassLibraryBankingObject> lsClassLibraryBankingObject = new List<ClassLibraryBankingObject>();
            if (UserID != null)
            {
                lsClassLibraryBankingObject = ClassLibraryBanking.getBankingAccount(UserID ?? 0);
            }

            return Json(lsClassLibraryBankingObject, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBanking(string BankingDate, int? BankingAccountID = 0)
        {
            BankingDate = BankingDate.Replace("-", "/");
            DateTime datetimeBankingDate = Convert.ToDateTime(BankingDate);

            List<ClassLibraryBankingObject> lsClassLibraryBankingObject = new List<ClassLibraryBankingObject>();
            if (BankingAccountID != null)
            {
                lsClassLibraryBankingObject = ClassLibraryBanking.getBanking(BankingAccountID ?? 0, datetimeBankingDate);
            }

            return Json(lsClassLibraryBankingObject, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBankingEmailBlast(int? UserID)
        {
            List<ClassLibraryBankingObject> lsClassLibraryBankingObject = new List<ClassLibraryBankingObject>();
            if (UserID != null)
            {
                lsClassLibraryBankingObject = ClassLibraryBanking.getBankingEmailBlast();
            }

            return Json(lsClassLibraryBankingObject, JsonRequestBehavior.AllowGet);
        }
    }
}
