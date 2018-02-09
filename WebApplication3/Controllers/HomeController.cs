﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using Travel.ViewModels;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private DbEntity db = new DbEntity();

        public ActionResult Index()
        {
            var lang = RouteData.Values["lang"] as string;
            var LangID = db.Languages.Where(x => x.Locale.Equals(lang))?.First()?.LangID;

            var model = new HomeIndexViewModel();
            model.MainCarouselList = db.MainCarousels.Where(x => !x.Disabled).ToList();
            model.VideoBox = db.VideoGallery.Where(x => x.ShowAsMain).OrderBy(x => x.ShowInOrder).Take(4).ToList();
            model.PhotoGallery = db.Photos.ToList();

            // tours
            var tours = new List<TourViewModel>();


            var tourHeaders =( from h in db.TourHeaders.Where(x => x.TourPhoto.Count > 0)
                    join d in db.TourDetails on h.TourID equals d.TourID
                    where d.LangID == LangID
                    select new { h, d}).ToList();


            ////var tourHeaders = db.TourHeaders.Where(x => x.TourPhoto.Count > 0 && x.TourDetail.Any(xx=>xx.LangID.Equals(LangID))).OrderByDescending(x => x.TourID).Take(10);
            //    .Join(xx=>xx.Photos,tt=>tt.TourPhoto.PhotoID, gg=>gg.PhotoID, (h, d)=>new {h.CommonName });
            foreach (var tour in tourHeaders)
            {
                var tourViewModel = new TourViewModel();
                tourViewModel.Tour = tour.h;
                tourViewModel.TourDetail = tour.d;

                var phId = tour.h.TourPhoto.Where(x => x.ShowAsMain).First().PhotoID;
                var photo = db.Photos.Find(phId);
                if (photo!= null)
                {
                    tourViewModel.PhotoPath = Helper.Images.GetPath(photo.Path, photo.GalleryID);
                }
                tours.Add(tourViewModel);
            }
            model.Tours = tours;
            // end tours

            return View(model);
        }

    }
}