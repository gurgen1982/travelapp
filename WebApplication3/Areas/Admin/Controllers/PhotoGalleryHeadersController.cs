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
    public class PhotoGalleryHeadersController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/PhotoGalleryHeaders
        public ActionResult Index()
        {
            return View(db.PhotoGalleryHeaders.ToList());
        }

        // GET: Admin/PhotoGalleryHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);
            if (photoGalleryHeader == null)
            {
                return HttpNotFound();
            }
            return View(photoGalleryHeader);
        }

        // GET: Admin/PhotoGalleryHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhotoGalleryHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GalleryID,InternalUse,GalleryCommonName")] PhotoGalleryHeader photoGalleryHeader)
        {
            if (ModelState.IsValid)
            {
                db.PhotoGalleryHeaders.Add(photoGalleryHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoGalleryHeader);
        }

        // GET: Admin/PhotoGalleryHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);
            if (photoGalleryHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.Localized = db.PhotoGalleryLocalizedHeaders.Where(x => x.GalleryID == photoGalleryHeader.GalleryID).Include(x => x.Language);
            return View(photoGalleryHeader);
        }

        // POST: Admin/PhotoGalleryHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GalleryID,InternalUse,GalleryCommonName")] PhotoGalleryHeader photoGalleryHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoGalleryHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photoGalleryHeader);
        }

        // GET: Admin/PhotoGalleryHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);
            if (photoGalleryHeader == null)
            {
                return HttpNotFound();
            }
            return View(photoGalleryHeader);
        }

        // POST: Admin/PhotoGalleryHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);
            db.PhotoGalleryHeaders.Remove(photoGalleryHeader);
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
    }
}
