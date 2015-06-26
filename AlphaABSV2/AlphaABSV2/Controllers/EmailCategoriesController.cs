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
    public class EmailCategoriesController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: EmailCategories
        public ActionResult Index()
        {
            return View(db.EmailCategories.ToList());
        }

        // GET: EmailCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailCategories emailCategories = db.EmailCategories.Find(id);
            if (emailCategories == null)
            {
                return HttpNotFound();
            }
            return View(emailCategories);
        }

        // GET: EmailCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmailCategoriesID,CategoryName")] EmailCategories emailCategories)
        {
            if (ModelState.IsValid)
            {
                db.EmailCategories.Add(emailCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emailCategories);
        }

        // GET: EmailCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailCategories emailCategories = db.EmailCategories.Find(id);
            if (emailCategories == null)
            {
                return HttpNotFound();
            }
            return View(emailCategories);
        }

        // POST: EmailCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmailCategoriesID,CategoryName")] EmailCategories emailCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailCategories);
        }

        // GET: EmailCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailCategories emailCategories = db.EmailCategories.Find(id);
            if (emailCategories == null)
            {
                return HttpNotFound();
            }
            return View(emailCategories);
        }

        // POST: EmailCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailCategories emailCategories = db.EmailCategories.Find(id);
            db.EmailCategories.Remove(emailCategories);
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
