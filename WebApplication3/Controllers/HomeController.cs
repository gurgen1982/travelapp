using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using Travel.ViewModels;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private DbEntity db = new DbEntity();

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.MainCarouselList = db.MainCarousels.Where(x => !x.Disabled).ToList();
            model.VideoBox = db.VideoGallery.Where(x => x.ShowAsMain).OrderBy(x=>x.ShowInOrder).Take(4).ToList();
            return View(model);
        }
        
    }
}