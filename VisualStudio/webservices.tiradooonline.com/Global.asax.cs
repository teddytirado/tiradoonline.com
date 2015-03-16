using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC3WebApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Banking", // Route name 
                "Banking/{BankingAccountID}/{BankingDate}", // URL with parameters 
                new { controller = "Banking", action = "GetBanking", BankingAccountID = "", BankingDate = "" }
            );

            routes.MapRoute(
                "BankingEmailBlast", // Route name 
                "BankingEmailBlast/{UserID}", // URL with parameters 
                new { controller = "Banking", action = "GetBankingEmailBlast", UserID = "" }
            );

            routes.MapRoute(
                "BankingAccount", // Route name 
                "Banking/{UserID}", // URL with parameters 
                new { controller = "Banking", action = "GetBankingAccount", UserID = "" }
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            
 }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}