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
    [Authorize]
    public class PhotoGalleryLocalizedHeadersController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/PhotoGalleryLocalizedHeaders
        public ActionResult Index()
        {
            return View(db.PhotoGalleryLocalizedHeaders.ToList());
        }

        // GET: Admin/PhotoGalleryLocalizedHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGalleryLocalizedHeader photoGalleryLocalizedHeader = db.PhotoGalleryLocalizedHeaders.Find(id);
            if (photoGalleryLocalizedHeader == null)
            {
                return HttpNotFound();
            }
            return View(photoGalleryLocalizedHeader);
        }

        // GET: Admin/PhotoGalleryLocalizedHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhotoGalleryLocalizedHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LangID,GalleryID,GalleryName")] PhotoGalleryLocalizedHeader photoGalleryLocalizedHeader)
        {
            if (ModelState.IsValid)
            {
                db.PhotoGalleryLocalizedHeaders.Add(photoGalleryLocalizedHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoGalleryLocalizedHeader);
        }

        // GET: Admin/PhotoGalleryLocalizedHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGalleryLocalizedHeader photoGalleryLocalizedHeader = db.PhotoGalleryLocalizedHeaders.Find(id);
            if (photoGalleryLocalizedHeader == null)
            {
                return HttpNotFound();
            }
            return View(photoGalleryLocalizedHeader);
        }

        // POST: Admin/PhotoGalleryLocalizedHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LangID,GalleryID,GalleryName")] PhotoGalleryLocalizedHeader photoGalleryLocalizedHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photoGalleryLocalizedHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photoGalleryLocalizedHeader);
        }

        // GET: Admin/PhotoGalleryLocalizedHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoGalleryLocalizedHeader photoGalleryLocalizedHeader = db.PhotoGalleryLocalizedHeaders.Find(id);
            if (photoGalleryLocalizedHeader == null)
            {
                return HttpNotFound();
            }
            return View(photoGalleryLocalizedHeader);
        }

        // POST: Admin/PhotoGalleryLocalizedHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoGalleryLocalizedHeader photoGalleryLocalizedHeader = db.PhotoGalleryLocalizedHeaders.Find(id);
            db.PhotoGalleryLocalizedHeaders.Remove(photoGalleryLocalizedHeader);
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
