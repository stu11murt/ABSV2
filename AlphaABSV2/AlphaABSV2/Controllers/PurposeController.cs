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
    public class PurposeController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: Purpose
        public ActionResult Index()
        {
            return View(db.Purposes.ToList());
        }

        // GET: Purpose/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purpose purpose = db.Purposes.Find(id);
            if (purpose == null)
            {
                return HttpNotFound();
            }
            return View(purpose);
        }

        // GET: Purpose/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purpose/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurposeID,PurposeOfEvent")] Purpose purpose)
        {
            if (ModelState.IsValid)
            {
                db.Purposes.Add(purpose);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purpose);
        }

        // GET: Purpose/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purpose purpose = db.Purposes.Find(id);
            if (purpose == null)
            {
                return HttpNotFound();
            }
            return View(purpose);
        }

        // POST: Purpose/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurposeID,PurposeOfEvent")] Purpose purpose)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purpose).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purpose);
        }

        // GET: Purpose/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purpose purpose = db.Purposes.Find(id);
            if (purpose == null)
            {
                return HttpNotFound();
            }
            return View(purpose);
        }

        // POST: Purpose/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purpose purpose = db.Purposes.Find(id);
            db.Purposes.Remove(purpose);
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
