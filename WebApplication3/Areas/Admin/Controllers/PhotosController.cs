using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Areas.Admin.Controllers
{
    public class PhotosController : Controller
    {
        public const string UploadedImagePath = "~/Uploads/";
        private DbEntity db = new DbEntity();

        public class FileNames
        {
            public string name { get; set; }
            public string val { get; set; }
        }

        // GET: Admin/Photos
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var photoGallery = db.PhotoGalleryHeaders.Find((int)id);
            if (photoGallery == null)
            {
                return HttpNotFound();
            }
            return View(photoGallery);
        }

        public ActionResult GetPhotoList(int? galleryID/*, int page=0, int pageSize=20*/)
        {
            //var l = db.Photos.Where(x => x.GalleryID.Equals((int)galleryID)).ToList();

            //l.Select(x => new Photo
            //{
            //    GalleryID = x.GalleryID,
            //    Path = x.Path,
            //    PhotoGallery = null,
            //    PhotoID = x.PhotoID,
            //    Title = x.Title
            //})
            //  if (page > 0) page--;
            var galId = (int)galleryID;
            db.Configuration.ProxyCreationEnabled = false;
            var l = db.Photos.Where(x => x.GalleryID.Equals(galId)).OrderByDescending(x => x.PhotoID).ToList();
            //var ll = l;//.Skip(page * pageSize).Take(pageSize);

            return Json(l, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Admin/Photos/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!db.PhotoGalleryHeaders.Any(x => x.GalleryID.Equals((int)id)))
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            string path = Server.MapPath(UploadedImagePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Server.MapPath(UploadedImagePath + id);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            TempData.Clear();
            TempData["galid"] = id;
            TempData.Keep("galid");

            ViewBag.GalleryID = id;
            return View();
        }

        //[HttpPost]
        //public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
        //{
        //    return null;
        //}

        [HttpPost]
        public ActionResult Save(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                var galId = TempData["galid"].ToString();
                TempData.Keep("galid");
                string path = Server.MapPath(UploadedImagePath + galId);
                foreach (var file in files)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var guid = Guid.NewGuid().ToString().Replace("-", "");
                    var uid = guid + ext;
                    // Some browsers send file names with full path. This needs to be stripped.
                    var fileName = Path.GetFileName(file.FileName);
                    TempData.Add(fileName, uid);
                    TempData.Keep();

                    var physicalPath = Path.Combine(path, uid);

                    file.SaveAs(physicalPath);

                    System.Drawing.Image img = System.Drawing.Image.FromFile(physicalPath);
                    db.Photos.Add(new Photo { GalleryID = Convert.ToInt32(galId), Path = uid, Title = "", Width = img.Width, Height = img.Height });
                    img.Dispose();
                    db.SaveChanges();
                }
            }

            // Return an empty string to signify success
            return Content("");
        }
        public ActionResult Remove(string fileName)
        {
            if (fileName != null)
            {
                fileName = Path.GetFileName(fileName);
                var uid = TempData[fileName] as string;
                var galId = TempData["galid"].ToString();
                TempData.Keep("galid");
                if (!string.IsNullOrEmpty(uid))
                {
                    var physicalPath = Path.Combine(Server.MapPath(UploadedImagePath + galId), uid);
                    try
                    {
                        var photo = db.Photos.First(x => x.Path.Equals(uid));
                        if (photo != null)
                        {
                            db.Photos.Remove(photo);
                            db.SaveChanges();
                        }
                    }
                    catch { }
                    // TODO: Verify user permissions
                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        // POST: Admin/Photos/Create
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public ActionResult Create(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                return Save(files);
            }
            else if (Request.Form["fileNames"] != null)
            {
                return Remove(Request.Form["fileNames"]);
            }
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveGallery(IEnumerable<FileNames> files)
        {
            foreach (var item in files)
            {
                if (TempData.ContainsKey(item.name))
                {
                    var path = TempData[item.name] as string;
                    TempData.Keep(item.name);
                    try
                    {
                        var photo = db.Photos.First(x => x.Path.Equals(path));
                        if (photo != null)
                        {
                            photo.Title = item.val;
                            db.Entry(photo).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    catch
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Admin/Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID,GalleryID,Path,Title")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = photo.GalleryID });
            }
            return View(photo);
        }

        // GET: Admin/Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Admin/Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();

            string path = Server.MapPath(UploadedImagePath + photo.GalleryID + "/" + photo.Path);

            try
            {
                System.IO.File.Delete(path);
            }
            catch { }
            return RedirectToAction("Index", new { id = photo.GalleryID });
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
