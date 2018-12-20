using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Areas.Admin.Models;
using Travel.Models;

namespace Travel.Areas.Admin.Controllers
{
    [Authorize]
    public class PhotoGalleryController : Controller
    {
        private DbEntity db = new DbEntity();
        
        // GET: Admin/PhotoGalleryHeaders
        public ActionResult Index()
        {
            return View(db.PhotoGalleryHeaders.ToList());
        }

        //// GET: Admin/PhotoGalleryHeaders/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);
        //    if (photoGalleryHeader == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(photoGalleryHeader);
        //}

        //// GET: Admin/PhotoGalleryHeaders/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/PhotoGalleryHeaders/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "GalleryID,InternalUse,GalleryCommonName")] PhotoGalleryHeader photoGalleryHeader)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PhotoGalleryHeaders.Add(photoGalleryHeader);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(photoGalleryHeader);
        //}

        // GET: Admin/PhotoGalleryHeaders/Edit/5
        public ActionResult Item(int? id)
        {
            PhotoGalleryViewModel model = new PhotoGalleryViewModel();
            if (id == null) // create new!
            {
                model.GalleryHeader = new PhotoGalleryHeader();
                var list = new List<LPhotoGalleryName>();

                foreach (var lang in db.Languages.OrderBy(x => x.LangID))
                {
                    list.Add(new LPhotoGalleryName { GalleryID = 0, LangID = lang.LangID, LanguageName = lang.Name });
                }
                model.GalleryNameList = list.ToArray();
            }
            else // edit
            {
                PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);
                if (photoGalleryHeader == null)
                {
                    return HttpNotFound();
                }

                model.GalleryHeader = photoGalleryHeader;
                model.GalleryNameList =
                    db.PhotoGalleryLocalizedHeaders
                    .Where(x => x.GalleryID == photoGalleryHeader.GalleryID)
                    .Include(x => x.Language)
                    .Select(x => new LPhotoGalleryName { LanguageName = x.Language.Name, GalleryName = x.GalleryName, GalleryID = x.GalleryID, LangID = x.LangID }).ToArray();
            }
            return View(model);
        }

        // POST: Admin/PhotoGalleryHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Item(PhotoGalleryViewModel gallery)
        {
            if (ModelState.IsValid)
            {
                if (gallery.GalleryHeader.GalleryID == 0)// adding
                {
                    db.PhotoGalleryHeaders.Add(gallery.GalleryHeader);
                    db.SaveChanges();
                    foreach (var item in gallery.GalleryNameList)
                    {
                        db.PhotoGalleryLocalizedHeaders.Add(new PhotoGalleryLocalizedHeader { GalleryID = gallery.GalleryHeader.GalleryID, GalleryName = item.GalleryName, LangID = item.LangID });
                    }
                    db.SaveChanges();
                }
                else // edit
                {
                    db.Entry(gallery.GalleryHeader).State = EntityState.Modified;
                    db.SaveChanges();
                    var localHeader = db.PhotoGalleryLocalizedHeaders.Where(x => x.GalleryID.Equals(gallery.GalleryHeader.GalleryID));
                    foreach (var item in localHeader)
                    {
                        item.GalleryName = gallery.GalleryNameList.First(x => x.LangID.Equals(item.LangID)).GalleryName;
                        db.Entry(item).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(gallery);
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
            var UploadedImagePath= "~/" + HttpContext.Application["ImagePath"].ToString() + "/";
            PhotoGalleryHeader photoGalleryHeader = db.PhotoGalleryHeaders.Find(id);

            db.PhotoGalleryHeaders.Remove(photoGalleryHeader);
            db.SaveChanges();
            try
            {/// TODO: is Photo table deleted too ????
                string path = Server.MapPath(UploadedImagePath + photoGalleryHeader.GalleryID);
                System.IO.Directory.Delete(path,true);
            }
            catch{ }
         
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
