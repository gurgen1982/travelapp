using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Travel.Models;

namespace Travel
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Database.SetInitializer(new DAL.StudentInitializer());
            var db = new DbEntity();
            var languages = db.Languages.ToList();

            Application["SupportedLanguages"] = languages;// new string[] { "hy", "en" };
            Application["ImagePath"] = "uploads";
            Application["ImageThumb"] = "thumb_";
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
          //  Response.Redirect("/");
        }
    }
}