using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class CountryController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Country
        public ActionResult Index()
        {
            SetViewBag();
            var countryHeaders = db.CountryHeaders.Include(c => c.Photo);
            return View(countryHeaders.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(string id)
        {
            SetViewBag();
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("index");
            }
            if(!db.CountryHeaders.Any(x=>x.CommonName == id))
            {
                return RedirectToAction("index");
            }
            CountryHeader countryHeader = db.CountryHeaders.FirstOrDefault(x => x.CommonName.Equals(id));
            if (countryHeader == null)
            {
                return HttpNotFound();
            }
            var local = countryHeader.Countries.Where(x => x.LangID == ViewBag.LangID);
            if (local == null )
            {
                if (countryHeader.Countries.Count > 0)
                {
                    ViewBag.LangID = countryHeader.Countries.First().LangID;
                }
                else
                {
                    return RedirectToAction("index");
                }
            }
            return View(countryHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void SetViewBag()
        {
            var lang = RouteData.Values["lang"] as string;
            var LangID = db.Languages.Where(x => x.Locale.Equals(lang))?.First()?.LangID;
            ViewBag.LangID = LangID;
        }
    }
}
