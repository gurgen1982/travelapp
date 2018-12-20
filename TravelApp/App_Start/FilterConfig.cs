using System;
using System.Web;
using System.Web.Mvc;
using Travel.App_Start;

namespace Travel
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NullRefExceptionHandler());
            
            filters.Add(new LanguageFilter());
        }
    }
}
