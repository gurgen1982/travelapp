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
    public class MvcApplication : HttpApplication
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
            Application["Settings"] = db.Settings.FirstOrDefault();
            Application["Currencies"] = db.Currencies.ToList();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
          //  Response.Redirect("/");
        }
    }
}