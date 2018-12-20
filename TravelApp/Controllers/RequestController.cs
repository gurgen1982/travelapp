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
    public class RequestController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Request
        [ChildActionOnly]
        public ActionResult Index(int? id)
        {
            var model = new Request { TourID = id, CountOfTourist = 1, TourDate = DateTime.Now.AddDays(1) };
            return PartialView("Create", model);
        }


        // POST: Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,TourID,Email,OtherContacts,Name,Title,CountOfTourist,TourDate,Message")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return PartialView();
            }

            return PartialView(request);
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
