using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class LanguageController : Controller
    {
        // set language
        [HttpPost]
        public ActionResult Set(string lang)
        {
            var prevLang = "";
            var supportedLangs = HttpContext.Application.Get("SupportedLanguages");
            IList<Language> SupportedLanguages = null;
            if (supportedLangs != null)
            {
                SupportedLanguages = supportedLangs as IList<Language>;
            }
            var language = SupportedLanguages.FirstOrDefault(x => x.Locale.Equals(lang));
            if (language != null)
            {
                prevLang = Request.Cookies["language"]?.Value;

                var langCookie = new HttpCookie("language", lang);
                langCookie.Expires = DateTime.Now.AddYears(5);
                Response.Cookies.Set(langCookie);
            }
            var url = Request.UrlReferrer.AbsoluteUri;
            if (url.Contains(prevLang))
            {
                url = url.Replace("/" + prevLang, "/" + lang);
            }
            return Json(url, JsonRequestBehavior.AllowGet);
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}