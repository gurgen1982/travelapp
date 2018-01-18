using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.App_Start
{
    public class LanguageFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = filterContext.RouteData.Values["lang"] as string;
            var supportedLangs = filterContext.HttpContext.Application.Get("SupportedLanguages");
            string[] SupportedLanguages = { };
            if(supportedLangs!= null)
            {
                SupportedLanguages = supportedLangs as string[];
            }
            if (string.IsNullOrEmpty(lang) || !SupportedLanguages.Contains(lang))
            {

                filterContext.HttpContext.Request.RequestContext.RouteData.Values.Remove("lang");
                filterContext.HttpContext.Request.RequestContext.RouteData.Values.Add("lang", SupportedLanguages[0]);
                //filterContext.HttpContext.Response.RedirectToRoute(new { lang = SupportedLanguages[0] });
                //var newUrl = filterContext.HttpContext.Request.Url.ToString().ToLower().Replace("/" + lang + "/", SupportedLanguages[0]);
                //filterContext.HttpContext.Response.Redirect(newUrl);
                //return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}