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
    public class ToursController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/Tours
        public ActionResult Index()
        {
            return View(db.TourHeaders.ToList());
        }

        // GET: Admin/Tours/Details/5
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
            return View(tourHeader);
        }

        //// GET: Admin/Tours/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/Tours/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "TourID,CountryID,CategoryID,Price")] TourHeader tourHeader)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TourHeaders.Add(tourHeader);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tourHeader);
        //}

        // GET: Admin/Tours/Edit/5
        public ActionResult Item(int? id)
        {
            if (id == null)
            {
                SetViewBagForItem(null);
                return View(new TourHeader());
            }
            TourHeader tourHeader = db.TourHeaders.Find(id);
            if (tourHeader == null)
            {
                return HttpNotFound();
            }
            SetViewBagForItem(tourHeader);

            //db.TourHeaders.Where(x=>x.TourID.Equals(id)).Include(x=>x.ga)
            //foreach (var photo in tourHeader.TourPhoto)
            //{

            //    photo.TourHeader = null;
            //}
            return View(tourHeader);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Item(TourHeader tourHeader)
        {
            var photos = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<Photo>>(Request.Form["PhotoList"]) ?? new List<Photo>();

            if (ModelState.IsValid)
            {
                var bAdding = false;
                if (tourHeader.TourID == 0) // adding
                {
                    db.TourHeaders.Add(tourHeader);
                    db.SaveChanges();
                    bAdding = true;
                    //return RedirectToAction("Details", new { id = tourHeader.TourID });
                }// end adding
                else// saving
                {
                    //  db.TourPhotos.RemoveRange(db.TourPhotos.Where(x => x.TourID.Equals(tourHeader.TourID)));
                    db.Entry(tourHeader).State = EntityState.Modified;
                    db.SaveChanges();
                }
                db.TourPhotos.RemoveRange(db.TourPhotos.Where(x => x.TourID.Equals(tourHeader.TourID)));
                foreach (var photo in photos)
                {
                    if (photo.Width > 1) photo.Width = 0;
                    db.TourPhotos.Add(new TourPhoto { PhotoID=photo.PhotoID, TourID= tourHeader.TourID, ShowAsMain = Convert.ToBoolean(photo.Width) });
                    db.SaveChanges();
                }
                if (bAdding)
                {
                    SetViewBagForItem(tourHeader);
                    return RedirectToAction("Item", new { id = tourHeader.TourID });
                }
                else
                {
                    return RedirectToAction("Details", new { id = tourHeader.TourID });
                }
            }

            SetViewBagForItem(tourHeader);
            return View(tourHeader);
        }

        public ActionResult ItemDetail(int id = 0, short id2 = 0, int id3 = 0) // detTourId, langId, tourId
        {
            if (id == 0 && id2 == 0 && id3 == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tourDetail = new TourLocalizedDetail();
            if (id != 0)
            {
                tourDetail = db.TourDetails.Find(id);
                if (tourDetail == null)
                {
                    return HttpNotFound();
                }
            }
            if (id2 != 0 && id3 != 0)
            {
                var lang = db.Languages.Find(id2);
                if (lang != null)
                {
                    tourDetail.LangID = id2;
                    tourDetail.Language = lang;

                    tourDetail.TourID = id3;
                    tourDetail.TourHeader = db.TourHeaders.Find(id3);
                }
            }
            SetViewBagForDetailItem(tourDetail);

            return View(tourDetail);
        }

        [HttpPost]
        public ActionResult ItemDetail(TourLocalizedDetail tourDetail)
        {
            if (ModelState.IsValid)
            {
                if (tourDetail.ID == 0) // adding
                {
                    db.TourDetails.Add(tourDetail);
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = tourDetail.TourID });
                }// end adding
                else// saving
                {
                    db.Entry(tourDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = tourDetail.TourID });
                }
            }
            SetViewBagForDetailItem(tourDetail);
            return View(tourDetail);
        }
        // GET: Admin/Tours/Delete/5
        public ActionResult Delete(int? id)
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
            return View(tourHeader);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourHeader tourHeader = db.TourHeaders.Find(id);
            db.TourHeaders.Remove(tourHeader);
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

        private void SetViewBagForItem(TourHeader tourHeader)
        {
            ViewBag.CountryID = new SelectList(db.CountryHeaders.OrderBy(x => x.CommonName), "CountryID", "CommonName", tourHeader?.CountryID);
            ViewBag.CategoryID = new SelectList(db.CategoryHeaders.Where(x => x.ParentCategoryID == 0).OrderBy(x => x.CommonName), "CategoryID", "CommonName", tourHeader?.CategoryID);

            ViewBag.Categories = db.CategoryHeaders.ToList();
            ViewBag.Languages = db.Languages.ToList();
            var lst = new List<Photo>();
            if (tourHeader?.TourPhoto != null && tourHeader?.TourPhoto?.Count > 0)
            {
                foreach (var item in tourHeader.TourPhoto)
                {
                    var d = db.Photos.Find(item.PhotoID);
                    if (d != null)
                        lst.Add(new Photo { GalleryID = d.GalleryID, Path = Helper.Images.GetThumbFullPath(d), PhotoID = d.PhotoID, Title = d.Title, Width = d.Width, Height = d.Height });
                }
            }
            ViewBag.Photos = lst;
            ViewBag.Gallery = db.PhotoGalleryHeaders.Where(x => x.InternalUse).ToList();
        }

        private void SetViewBagForDetailItem(TourLocalizedDetail tourDetail)
        {
            ViewBag.LangID = new SelectList(db.Languages, "LangID", "Name", tourDetail?.LangID);
        }
    }
}
