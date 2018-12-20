using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.GetCurrencyRates;
using Travel.Models;
using Travel.ViewModels;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private DbEntity db = new DbEntity();

        public ActionResult Index()
        {
            var rate = 1;// GetRate();
            var lang = RouteData.Values["lang"] as string;
            var LangID = db.Languages.Where(x => x.Locale.Equals(lang))?.First()?.LangID;
            ViewBag.LangID = LangID;
            var model = new HomeIndexViewModel();
            model.MainCarouselList = db.MainCarousels.Where(x => !x.Disabled && x.LangID == LangID).ToList();
            model.VideoBox = db.VideoGallery.Where(x => x.ShowAsMain).OrderBy(x => x.ShowInOrder).ToList();
            model.PhotoGallery = db.Photos.Where(x => !x.PhotoGallery.InternalUse).ToList();
            model.Countries = db.CountryHeaders.Where(x => x.ShowInHomePage).ToList();

            // tours
            var tours = new List<TourViewModel>();


            var tourHeaders = (from h in db.TourHeaders.Where(x => x.TourPhoto.Count > 0 && x.BestOffer)
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
                    //tourViewModel.PhotoPath = Helper.Images.GetPath(photo.Path, photo.GalleryID);
                    tourViewModel.Photo = photo;
                }
                tourViewModel.Tour.Price = Math.Round(tourViewModel.Tour.Price * rate, 0);
                tours.Add(tourViewModel);
            }
            
            model.Tours = tours;
            
            // end tours

            return View(model);
        }

        public ActionResult About()
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var langs = HttpContext.Application["SupportedLanguages"] as List<Language>;
            if (langs.Any(x => x.LangCulture.ToLower().Equals(culture.Name.ToLower())))
            {
                ViewBag.culture = culture.Name.ToLower();
            }
            else
            {
                ViewBag.culture = langs.FirstOrDefault().LangCulture.ToLower();
            }
            return View();
        }

        //[ChildActionOnly]
        //[OutputCache(Duration = 360, VaryByParam = "currency")]
        private ExchangeRate CurrencyRates(string currency)
        {
            var curDate = Convert.ToDateTime(HttpContext.Application["CurrencyDate"+ currency]?.ToString());
            if (curDate.AddDays(1) < DateTime.Now)
            {
                var latestRates = (new GateSoapClient())?.ExchangeRatesLatest();
                var latest = latestRates?.Rates.FirstOrDefault(x => x.ISO.Equals(currency)) ?? new ExchangeRate { Rate = "1" };
                
                HttpContext.Cache.Insert("CurrencyRate", latest);
   HttpContext.Application["CurrencyDate" + currency] = DateTime.Now;
                return latest;
            }
            else
            {
             
                return HttpContext.Cache.Get("CurrencyRate") as ExchangeRate;
            }
        }

        public decimal GetRate()
        {
            var cur = Request.Cookies["Currency"]?.Value ?? "AMD";
            var currency = CurrencyRates(cur);
            //var rateInfo = JsonConvert.DeserializeObject<ExchangeRate>(currency.ToString());
            try
            {
                return Convert.ToDecimal(currency.Rate);
            }
            catch
            {
                return 1.0M;
            }
        }
    }
}