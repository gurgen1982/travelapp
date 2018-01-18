using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;

namespace Travel.App_Start
{
    public class NullRefExceptionHandler : HandleErrorAttribute
    {
        public override bool Match(object obj)
        {
            return base.Match(obj);
        }
        public override void OnException(ExceptionContext filterContext)
        {
            if(ExceptionType == typeof(NullReferenceException))
            {
                filterContext.HttpContext.Response.RedirectToRoute(new { lang = "hy" });
                return;
            }
            base.OnException(filterContext);
        }
    }
}