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
    public class MainCarouselsController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/MainCarousels
        public ActionResult Index()
        {
            return View(db.MainCarousels.ToList());
        }

        // GET: Admin/MainCarousels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCarousel mainCarousel = db.MainCarousels.Find(id);
            if (mainCarousel == null)
            {
                return HttpNotFound();
            }
            return View(mainCarousel);
        }

        // GET: Admin/MainCarousels/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/MainCarousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,SubTitle,Details,SubDetails,Price,LinkUrl,ImageUrl,Disabled,LangID")] MainCarousel mainCarousel)
        {
            if (ModelState.IsValid)
            {
                db.MainCarousels.Add(mainCarousel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View(mainCarousel);
        }

        // GET: Admin/MainCarousels/Edit/5
        public ActionResult Edit(int? id)
        {
            SetViewBag();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCarousel mainCarousel = db.MainCarousels.Find(id);
            if (mainCarousel == null)
            {
                return HttpNotFound();
            }
            return View(mainCarousel);
        }

        // POST: Admin/MainCarousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SubTitle,Details,SubDetails,Price,LinkUrl,ImageUrl,Disabled,LangID")] MainCarousel mainCarousel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainCarousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View(mainCarousel);
        }

        // GET: Admin/MainCarousels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainCarousel mainCarousel = db.MainCarousels.Find(id);
            if (mainCarousel == null)
            {
                return HttpNotFound();
            }
            return View(mainCarousel);
        }

        // POST: Admin/MainCarousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainCarousel mainCarousel = db.MainCarousels.Find(id);
            db.MainCarousels.Remove(mainCarousel);
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
        private void SetViewBag()
        {
            ViewBag.LangID = new SelectList(db.Languages, "LangID", "Name");
        }
    }
}
