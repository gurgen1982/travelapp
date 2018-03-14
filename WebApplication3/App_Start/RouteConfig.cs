using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Travel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Default_Admin",
              url: "Admin",
              defaults: new { area = "Admin", controller = "Default", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Country_Route",
              url: "{lang}/Visit/{id}",
              defaults: new { controller = "Country", action = "Details", id = UrlParameter.Optional }
          );
            routes.MapRoute(
            name: "About_Route",
            url: "{lang}/About",
            defaults: new { controller = "Home", action = "About" }
        );
            routes.MapRoute(
                 name: "tours_Route",
                 url: "{lang}/Tours",
                 defaults: new { controller = "Tours", action = "Index" }
             );
            routes.MapRoute(
                 name: "tour_Route",
                 url: "{lang}/Tour/{id}",
                 defaults: new { controller = "Tours", action = "Info", id = UrlParameter.Optional }
             );
            routes.MapRoute(
            name: "blogs_Route",
            url: "{lang}/Blog",
            defaults: new { controller = "News", action = "Index"}
        );
            routes.MapRoute(
             name: "blog_Route",
             url: "{lang}/Blog/{id}",
             defaults: new { controller = "News", action = "Details", id = UrlParameter.Optional}
         );

            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = "" }//hy
            );
        }
    }
}
