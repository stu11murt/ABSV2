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
    public class OfficeRefController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: OfficeRef
        public ActionResult Index()
        {
            return View(db.OfficeRefs.ToList());
        }

        // GET: OfficeRef/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeRef officeRef = db.OfficeRefs.Find(id);
            if (officeRef == null)
            {
                return HttpNotFound();
            }
            return View(officeRef);
        }

        // GET: OfficeRef/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficeRef/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfficeRefID,OfficeRefPeople")] OfficeRef officeRef)
        {
            if (ModelState.IsValid)
            {
                db.OfficeRefs.Add(officeRef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officeRef);
        }

        // GET: OfficeRef/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeRef officeRef = db.OfficeRefs.Find(id);
            if (officeRef == null)
            {
                return HttpNotFound();
            }
            return View(officeRef);
        }

        // POST: OfficeRef/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfficeRefID,OfficeRefPeople")] OfficeRef officeRef)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeRef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officeRef);
        }

        // GET: OfficeRef/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeRef officeRef = db.OfficeRefs.Find(id);
            if (officeRef == null)
            {
                return HttpNotFound();
            }
            return View(officeRef);
        }

        // POST: OfficeRef/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeRef officeRef = db.OfficeRefs.Find(id);
            db.OfficeRefs.Remove(officeRef);
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
