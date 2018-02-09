using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class ImageController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Image
        public ActionResult GetThumb(int id)
        {
            var photo = db.Photos.Find(id);
            var thumb = Helper.Images.GetThumbPath(photo.Path);


            return File(thumb, "image/jpeg");
        }
    }
}