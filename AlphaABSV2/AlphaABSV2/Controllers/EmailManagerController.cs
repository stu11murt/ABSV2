using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlphaABSV2.DAL;
using AlphaABSV2.Models;
using AlphaABSV2.Helpers;

namespace AlphaABSV2.Controllers
{
    public class EmailManagerController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: EmailManager
        public ActionResult Index()
        {
            return View(db.EmailTemplates.ToList());
        }


        
        // GET: EmailManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailManager emailManager = db.EmailManager.Find(id);
            if (emailManager == null)
            {
                return HttpNotFound();
            }
            return View(emailManager);
        }

        // GET: EmailManager/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string sHTML)
        {
            EmailTemplates emailTemplate = new EmailTemplates();
            emailTemplate.TemplateContent = sHTML;
            emailTemplate.TemplateTitle = "Template" + DateTime.Now.ToShortTimeString();
            db.EmailTemplates.Add(emailTemplate);
            db.SaveChanges();
            return View();
        }

        // GET: EmailManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplate);
        }

        // POST: EmailManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailManagerID")] EmailManager emailManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailManager);
        }

        // GET: EmailManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailManager emailManager = db.EmailManager.Find(id);
            if (emailManager == null)
            {
                return HttpNotFound();
            }
            return View(emailManager);
        }

        // POST: EmailManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailManager emailManager = db.EmailManager.Find(id);
            db.EmailManager.Remove(emailManager);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult EditEmail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplate);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmail(EmailTemplates template)
        {
            EmailTemplates emailTemplate = db.EmailTemplates.Find(template.EmailTemplatesID);
            emailTemplate.TemplateContent = template.TemplateContent;
            emailTemplate.TemplateTitle = template.TemplateTitle;
            //db.EmailTemplates.Add(emailTemplate);
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
