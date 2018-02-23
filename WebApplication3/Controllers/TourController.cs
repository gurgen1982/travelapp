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
    public class TourController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Tour
        public ActionResult Index()
        {
            SetViewBag();
            var LangID = (int)ViewBag.LangID;
            //var tourHeaders = db.TourHeaders.Include(t => t.Category).Include(t => t.Country);
            //return View(tourHeaders.ToList());



            // tours
            var tours = new List<TourViewModel>();


            var tourHeaders = (from h in db.TourHeaders.Where(x => x.TourPhoto.Count > 0)
                               join d in db.TourDetails on h.TourID equals d.TourID
                               where d.LangID == LangID
                               select new { h, d }).ToList();


            ////var tourHeaders = db.TourHeaders.Where(x => x.TourPhoto.Count > 0 && x.TourDetail.Any(xx=>xx.LangID.Equals(LangID))).OrderByDescending(x => x.TourID).Take(10);
            //    .Join(xx=>xx.Photos,tt=>tt.TourPhoto.PhotoID, gg=>gg.PhotoID, (h, d)=>new {h.CommonName });
            foreach (var tour in tourHeaders)
            {
                var tourViewModel = new TourViewModel();
                tourViewModel.Tour = tour.h;
                tourViewModel.TourDetail = tour.d;

                var phId = tour.h.TourPhoto.Where(x => x.ShowAsMain).First().PhotoID;
                var photo = db.Photos.Find(phId);
                if (photo != null)
                {
                    tourViewModel.PhotoPath = Helper.Images.GetPath(photo.Path, photo.GalleryID);
                }
                tours.Add(tourViewModel);
            }

            return View(tours);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int? id)
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
