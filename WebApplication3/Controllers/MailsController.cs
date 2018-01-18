using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class MailsController : Controller
    {
        private DbEntity db = new DbEntity();
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Send([Bind(Include = "Name,Email,Message")] ContactMail contactMail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactMails.Add(contactMail);
                    db.SaveChanges();

                    await SendContactMail(contactMail);
                }
                else
                {
                    return Json(HttpStatusCode.BadRequest, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
            }
            return Json(HttpStatusCode.OK, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Subscribe([Bind(Include = "Email")] Subscription subscription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Subscriptions.Add(subscription);
                    db.SaveChanges();

                    await SendSubscriptionMail(subscription);
                }
                else
                {
                    return Json(HttpStatusCode.BadRequest, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
            }
            return Json(HttpStatusCode.OK, JsonRequestBehavior.AllowGet);
        }

        private Task SendSubscriptionMail(Subscription subscription)
        {
            return Task.FromResult(0);
        }

        private Task SendContactMail(ContactMail contactMail)
        {
            return Task.FromResult(0);
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
