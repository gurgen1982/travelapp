using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Areas.Admin.Controllers
{
    public class NewsListController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/NewsList
        public ActionResult Index()
        {
            return View(db.NewsHeaders.ToList());
        }

        // GET: Admin/NewsList/Details/5
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
            SetViewBagForItem(newsHeader);
            return View(newsHeader);
        }

        // POST: Admin/NewsList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsID,CommonName")] NewsHeader newsHeader)
        {
            if (ModelState.IsValid)
            {
                db.NewsHeaders.Add(newsHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsHeader);
        }

        // GET: Admin/NewsList/Edit/5
        public ActionResult Item(int? id)
        {
            if (id == null)
            {
                SetViewBagForItem(null);
                return View(new NewsHeader());
            }
            NewsHeader newsHeader = db.NewsHeaders.Find(id);
            if (newsHeader == null)
            {
                return HttpNotFound();
            }

            SetViewBagForItem(newsHeader);
            return View(newsHeader);
        }

        // POST: Admin/NewsList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Item([Bind(Include = "NewsID,CommonName,PhotoID")] NewsHeader newsHeader)
        {
            if (ModelState.IsValid)
            {
                var bAdding = false;
                if (newsHeader.NewsID == 0) // adding
                {
                    db.NewsHeaders.Add(newsHeader);
                    db.SaveChanges();
                    bAdding = true;
                }// end adding
                else
                {
                    db.Entry(newsHeader).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            SetViewBagForItem(newsHeader);
            return View(newsHeader);
        }

        public ActionResult ItemDetail(int id = 0, short id2 = 0, int id3 = 0) // detNewsId, langId, NewsId
        {
            if (id == 0 && id2 == 0 && id3 == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var newsDetail = new NewsLocalizedDetail();
            if (id != 0)
            {
                newsDetail = db.NewsDetails.Find(id);
                if (newsDetail == null)
                {
                    return HttpNotFound();
                }
            }
            if (id2 != 0 && id3 != 0)
            {
                var lang = db.Languages.Find(id2);
                if (lang != null)
                {
                    newsDetail.LangID = id2;
                    newsDetail.Language = lang;

                    newsDetail.NewsID = id3;
                    newsDetail.NewsHeader = db.NewsHeaders.Find(id3);
                }
            }
            SetViewBagForDetailItem(newsDetail);

            return View(newsDetail);
        }

        [HttpPost]
        public ActionResult ItemDetail(NewsLocalizedDetail newsDetail)
        {
            if (ModelState.IsValid)
            {
                if (newsDetail.ID == 0) // adding
                {
                    db.NewsDetails.Add(newsDetail);
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = newsDetail.NewsID });
                }// end adding
                else// saving
                {
                    db.Entry(newsDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = newsDetail.NewsID });
                }
            }
            SetViewBagForDetailItem(newsDetail);
            return View(newsDetail);
        }

        // GET: Admin/NewsList/Delete/5
        public ActionResult Delete(int? id)
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
            SetViewBagForItem(newsHeader);
            return View(newsHeader);
        }

        // POST: Admin/NewsList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsHeader newsHeader = db.NewsHeaders.Find(id);
            db.NewsHeaders.Remove(newsHeader);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SetViewBagForItem(NewsHeader p)
        {
            ViewBag.Languages = db.Languages.ToList();
            var photo = db.Photos.Find(p?.PhotoID);
            ViewBag.MainPhotoPath = Helper.Images.GetThumbFullPath(photo);

            ViewBag.Gallery = db.PhotoGalleryHeaders.Where(x => x.InternalUse).ToList();
        }
        private void SetViewBagForDetailItem(NewsLocalizedDetail tourDetail)
        {
            var photo = db.Photos.Find(tourDetail.NewsHeader.PhotoID);
            ViewBag.MainPhotoPath = Helper.Images.GetThumbFullPath(photo);
        }
    }
}
