using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class VideoGalleryController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: VideoGallery
        public ActionResult Index()
        {
            return View(db.VideoGallery.ToList());
        }

        // GET: VideoGallery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.VideoGallery.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
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
