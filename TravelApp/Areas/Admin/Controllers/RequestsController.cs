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
    public class RequestsController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/Requests
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        // GET: Admin/Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            if(request.TourID > 0)
            {
                var tour = db.TourHeaders.Find(request.TourID);
                if (tour != null)
                {
                    ViewBag.TourCommonName = tour.CommonName;
                }
            }
            return View(request);
        }
        
        // GET: Admin/Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            if (request.TourID > 0)
            {
                var tour = db.TourHeaders.Find(request.TourID);
                if (tour != null)
                {
                    ViewBag.TourCommonName = tour.CommonName;
                }
            }
            return View(request);
        }

        // POST: Admin/Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
