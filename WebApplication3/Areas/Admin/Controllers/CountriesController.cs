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
    public class CountriesController : Controller
    {
        private DbEntity db = new DbEntity();

        // GET: Admin/Countries
        public ActionResult Index()
        {
            return View(db.CountryHeaders.ToList());
        }

        // GET: Admin/Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryHeader countryHeader = db.CountryHeaders.Find(id);
            if (countryHeader == null)
            {
                return HttpNotFound();
            }
            return View(countryHeader);
        }

        // GET: Admin/Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryID,CommonName,PhotoID")] CountryHeader countryHeader)
        {
            if (ModelState.IsValid)
            {
                db.CountryHeaders.Add(countryHeader);
                db.SaveChanges();
                foreach (var lang in db.Languages)
                {
                    db.CountryDetails.Add(new CountryLocalizedDetail { LangID = lang.LangID, CountryID = countryHeader.CountryID, CountryName = countryHeader.CommonName });
                }
                return RedirectToAction("edit", new { id = countryHeader.CountryID });
            }

            return View(countryHeader);
        }

        // GET: Admin/Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryHeader countryHeader = db.CountryHeaders.Find(id);
            if (countryHeader == null)
            {
                return HttpNotFound();
            }
            var model = new CountryViewModel
            {
                CountryHeader = countryHeader,
                Languages = db.Languages.ToList(),
                Gallery = db.PhotoGalleryHeaders.Where(x => x.InternalUse).ToList(),
                IsEditMode = id > 0
            };
            return View(model);
        }

        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryHeader countryHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryHeader);
        }
        // GET: Admin/Countries/Edit/5
        public ActionResult EditLocal(int? id, int? id2)
        {
            if (id == null && id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // if id is localized id then we don't pass second param
            if (id != null && id2 == null)
            {
                CountryLocalizedDetail countryDetail = db.CountryDetails.Find(id);
                if (countryDetail == null)
                {
                    return HttpNotFound();
                }

                return View(countryDetail);
            }
            // if both params are passed then first is header id, second is language
            if (id != null && id2 != null)
            {
                CountryLocalizedDetail countryDetail = new CountryLocalizedDetail { CountryID = id.Value, LangID = (short)id2.Value };
                var lng = db.Languages.FirstOrDefault(x => x.LangID == (short)id2.Value);
                countryDetail.Language = lng;
                return View(countryDetail);
            }
            return View();
        }

        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLocal(CountryLocalizedDetail countryDetail)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["IsNew"] != null)
                {
                    countryDetail.ID = 0;
                    db.CountryDetails.Add(countryDetail);
                }
                else
                {
                    db.Entry(countryDetail).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = countryDetail.CountryID });
            }
            return View(countryDetail);
        }

        // GET: Admin/Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryHeader countryHeader = db.CountryHeaders.Find(id);
            if (countryHeader == null)
            {
                return HttpNotFound();
            }
            return View(countryHeader);
        }

        // POST: Admin/Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryHeader countryHeader = db.CountryHeaders.Find(id);
            db.CountryHeaders.Remove(countryHeader);
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
