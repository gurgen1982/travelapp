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
    public class NewsController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: News
        public ActionResult Index()
        {
            var lang = RouteData.Values["lang"] as string;
            var LangID = db.Languages.Where(x => x.Locale.Equals(lang))?.First()?.LangID;

            ViewBag.LangID = LangID;


            var newsHeaders = (from h in db.NewsHeaders.Where(x => x.PhotoID > 0)
                               join d in db.NewsDetails on h.NewsID equals d.NewsID
                               where d.LangID == LangID
                               select new { h, d }).ToList();
            // News
            var newsList = new List<NewsViewModel>();

            foreach (var news in newsHeaders)
            {
                var newsViewModel = new NewsViewModel();
                newsViewModel.News= news.h;
                newsViewModel.NewsDetail= news.d;
                var photo = db.Photos.Find(news.h.PhotoID);
                if (photo != null)
                {
                    newsViewModel.PhotoPath = Helper.Images.GetThumbFullPath(photo);
                }
                newsList.Add(newsViewModel);
            }

            return View(newsList);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsHeader newsHeader = db.NewsHeaders.Find(id);
            if (newsHeader == null)
            {
                return HttpNotFound();
            }
            var lang = RouteData.Values["lang"] as string;
            var newsDetail = newsHeader.NewsDetail.FirstOrDefault(x => x.Language.Locale.Equals(lang));
            if (newsDetail == null)
            {
                //newsDetail = new NewsLocalizedDetail { Title = newsHeader.CommonName, Description="No data for this language!" };
                return RedirectToAction("index");
            }
            ViewBag.MainPhotoPath = Helper.Images.GetThumbFullPath(db.Photos.Find(newsDetail.NewsHeader?.PhotoID));
            return View(newsDetail);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
