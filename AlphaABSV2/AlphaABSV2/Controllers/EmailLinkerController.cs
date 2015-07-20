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

namespace AlphaABSV2.Controllers
{
    public class EmailLinkerController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: EmailLinker
        public ActionResult Index()
        {
            var emailLinkers = db.EmailLinkers.Include(e => e.EmailCategories).Include(e => e.EmailTemplates);
            return View(emailLinkers.ToList());
        }

        // GET: EmailLinker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLinker emailLinker = db.EmailLinkers.Find(id);
            if (emailLinker == null)
            {
                return HttpNotFound();
            }
            return View(emailLinker);
        }

        // GET: EmailLinker/Create
        public ActionResult Create()
        {
            ViewBag.EmailCategoriesID = new SelectList(db.EmailCategories, "EmailCategoriesID", "CategoryName");
            ViewBag.EmailTemplatesID = new SelectList(db.EmailTemplates, "EmailTemplatesID", "TemplateTitle");
            return View();
        }

        // POST: EmailLinker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailLinkerID,EmailTemplatesID,EmailCategoriesID")] EmailLinker emailLinker)
        {
            if (ModelState.IsValid)
            {
                db.EmailLinkers.Add(emailLinker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailCategoriesID = new SelectList(db.EmailCategories, "EmailCategoriesID", "CategoryName", emailLinker.EmailCategoriesID);
            ViewBag.EmailTemplatesID = new SelectList(db.EmailTemplates, "EmailTemplatesID", "TemplateTitle", emailLinker.EmailTemplatesID);
            return View(emailLinker);
        }

        // GET: EmailLinker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLinker emailLinker = db.EmailLinkers.Find(id);
            if (emailLinker == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailCategoriesID = new SelectList(db.EmailCategories, "EmailCategoriesID", "CategoryName", emailLinker.EmailCategoriesID);
            ViewBag.EmailTemplatesID = new SelectList(db.EmailTemplates, "EmailTemplatesID", "TemplateTitle", emailLinker.EmailTemplatesID);
            return View(emailLinker);
        }

        // POST: EmailLinker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailLinkerID,EmailTemplatesID,EmailCategoriesID")] EmailLinker emailLinker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailLinker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailCategoriesID = new SelectList(db.EmailCategories, "EmailCategoriesID", "CategoryName", emailLinker.EmailCategoriesID);
            ViewBag.EmailTemplatesID = new SelectList(db.EmailTemplates, "EmailTemplatesID", "TemplateTitle", emailLinker.EmailTemplatesID);
            return View(emailLinker);
        }

        // GET: EmailLinker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLinker emailLinker = db.EmailLinkers.Find(id);
            if (emailLinker == null)
            {
                return HttpNotFound();
            }
            return View(emailLinker);
        }

        // POST: EmailLinker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailLinker emailLinker = db.EmailLinkers.Find(id);
            db.EmailLinkers.Remove(emailLinker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateEmailTemplatesDropDownList(object selectedTemplates = null)
        {
            var emailTemplatesQuery = from e in db.EmailTemplates
                                 orderby e.TemplateTitle
                                 select e;
            ViewBag.EmailTemplates = new SelectList(emailTemplatesQuery, "EmailTemplatesID", "TemplateTitle", selectedTemplates);
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
