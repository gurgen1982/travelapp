using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using Travel.ViewModels;

namespace Travel.Controllers
{
    public class ToursController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Tour
        public ActionResult Index()
        {
            SetViewBag();
            var LangID = (int)ViewBag.LangID;
            return View();
        }
        
        public virtual ActionResult TourList(int? countryId, int? categoryId, int pageNumber =0)
        {
            var pageSize = db.Settings.FirstOrDefault().PageSize;
            var lang = RouteData.Values["lang"] as string;
            var LangID = db.Languages.Where(x => x.Locale.Equals(lang))?.First()?.LangID;

            // tours
            var tours = new List<TourViewModel>();

            var tourHeaders = (from h in db.TourHeaders.Where(x => x.TourPhoto.Count > 0)
                               join d in db.TourDetails on h.TourID equals d.TourID
                               where d.LangID == LangID
                               select new { h, d }).ToList();

            if (countryId != null && countryId > 0)
            {
                tourHeaders = tourHeaders.Where(x => x.h.CountryID.Equals(countryId)).ToList();
            }
            if (categoryId != null && categoryId > 0)
            {
                tourHeaders = tourHeaders.Where(x => x.h.CategoryID.Equals(categoryId)).ToList();
            }
            tourHeaders = tourHeaders.OrderByDescending(x=>x.h.TourID).Skip(pageNumber * pageSize).Take(pageSize).ToList();

            if(tourHeaders.Count == 0)
            {
                return PartialView("_NoTourFound");
            }
            foreach (var tour in tourHeaders)
            {
                var tourViewModel = new TourViewModel();
                tourViewModel.Tour = tour.h;
                tourViewModel.TourDetail = tour.d;

                var phId = tour.h.TourPhoto.Where(x => x.ShowAsMain).First().PhotoID;
                var photo = db.Photos.Find(phId);
                if (photo != null)
                {
                    tourViewModel.Photo = photo;
                }
                tours.Add(tourViewModel);
            }

            return PartialView("_Tours", tours);
        }

        // GET: Tour/Details/5
        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourHeader tourHeader = db.TourHeaders.Find(id);
            if (tourHeader == null)
            {
                return HttpNotFound();
            }
            var lang = RouteData.Values["lang"] as string;
            if (tourHeader.TourDetail.FirstOrDefault(x => x.Language.Locale.Equals(lang)) == null)
            {
                return Redirect("/");
            }
            SetViewBag();
            return View(tourHeader);
        }

        [ChildActionOnly]
        public ActionResult RelatedTours(TourHeader Tour)
        {
            var lang = RouteData.Values["lang"] as string;
            var LangID = db.Languages.Where(x => x.Locale.Equals(lang))?.First()?.LangID;

            var headers = db.TourHeaders.Where(x => x.TourPhoto.Count > 0 && x.TourID != Tour.TourID);
            var headersByCountry = headers.Where(x => x.CountryID == Tour.CountryID);
            var headersByCategory = headers.Where(x => x.CategoryID == Tour.CategoryID && !headersByCountry.Any(y => y.TourID == x.TourID));
            headers = headersByCountry.Concat(headersByCategory);

            if (headers.Count() == 0) return null;

            var tours = new List<TourViewModel>();

            var tourHeaders = (from h in headers
                               join d in db.TourDetails on h.TourID equals d.TourID
                               where d.LangID == LangID
                               select new { h, d }).ToList();

            foreach (var tour in tourHeaders)
            {
                var tourViewModel = new TourViewModel();
                tourViewModel.Tour = tour.h;
                tourViewModel.TourDetail = tour.d;

                var phId = tour.h.TourPhoto.Where(x => x.ShowAsMain).First().PhotoID;
                var photo = db.Photos.Find(phId);
                if (photo != null)
                {
                    tourViewModel.Photo = photo;
                }
                tours.Add(tourViewModel);
            }

            return PartialView("_Tours", tours);
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
            ViewBag.Countries = new SelectList(db.CountryDetails.Where(x => x.LangID == LangID), "CountryID", "CountryName");
            ViewBag.Categories = new SelectList(db.CategoryDetails.Where(x => x.LangID == LangID), "CategoryID", "CategoryName");

            ViewBag.CountriesInfo = db.CountryHeaders.ToList();

            ViewBag.LangID = LangID;
        }
    }
}
