using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.App_Start
{
    public class LanguageFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = filterContext.RouteData.Values["lang"] as string;
            if (string.IsNullOrEmpty(lang))
            {
                lang = filterContext.HttpContext.Request["language"];
                filterContext.HttpContext.Request.RequestContext.RouteData.Values.Remove("lang");
                filterContext.HttpContext.Request.RequestContext.RouteData.Values.Add("lang", lang);
            }
            var supportedLangs = filterContext.HttpContext.Application.Get("SupportedLanguages");
            IList<Language> SupportedLanguages = null;
            if (supportedLangs != null)
            {
                SupportedLanguages = supportedLangs as IList<Language>;
            }
            if (string.IsNullOrEmpty(lang) || !SupportedLanguages.Any(x => x.Locale.Equals(lang)))
            {
                lang = "en";// SupportedLanguages.FirstOrDefault(x=>x.CommonName.Equals("Eng")).Locale;
                filterContext.HttpContext.Request.RequestContext.RouteData.Values.Remove("lang");
                filterContext.HttpContext.Request.RequestContext.RouteData.Values.Add("lang", lang);
                //filterContext.HttpContext.Response.RedirectToRoute(new { lang = SupportedLanguages[0] });
                //var newUrl = filterContext.HttpContext.Request.Url.ToString().ToLower().Replace("/" + lang + "/", SupportedLanguages[0]);
                //filterContext.HttpContext.Response.Redirect(newUrl);
                //return;
            }

            filterContext.HttpContext.Response.Cookies.Set(new HttpCookie("language", lang));

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(SupportedLanguages.First(x => x.Locale.Equals(lang)).LangCulture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(SupportedLanguages.First(x => x.Locale.Equals(lang)).LangCulture);

            base.OnActionExecuting(filterContext);
        }
    }
}