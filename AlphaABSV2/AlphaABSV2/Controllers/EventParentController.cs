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
    public class EventParentController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: EventParent
        public ActionResult Index()
        {
            return View(db.EventParents.ToList());
        }

        // GET: EventParent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventParent eventParent = db.EventParents.Find(id);
            if (eventParent == null)
            {
                return HttpNotFound();
            }
            return View(eventParent);
        }

        // GET: EventParent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventParent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventParentID,EventName")] EventParent eventParent)
        {
            if (ModelState.IsValid)
            {
                db.EventParents.Add(eventParent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventParent);
        }

        // GET: EventParent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventParent eventParent = db.EventParents.Find(id);
            if (eventParent == null)
            {
                return HttpNotFound();
            }
            return View(eventParent);
        }

        // POST: EventParent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventParentID,EventName")] EventParent eventParent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventParent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventParent);
        }

        // GET: EventParent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventParent eventParent = db.EventParents.Find(id);
            if (eventParent == null)
            {
                return HttpNotFound();
            }
            return View(eventParent);
        }

        // POST: EventParent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventParent eventParent = db.EventParents.Find(id);
            db.EventParents.Remove(eventParent);
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
