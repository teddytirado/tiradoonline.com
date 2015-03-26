using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tcm.App_Data;

namespace tcm.Models
{
    public class Logs
    {
        private static DBDataContext db = new DBDataContext();

        public Logs()
        {
        }

        public static void Insert(string nameSpace, string className, string methodName, Exception ex, string comments)
        {
            db.sp_Member_Logs_insert(nameSpace, className, methodName, ex.Message.ToString(), ex.ToString(), comments);
        }
    }
}