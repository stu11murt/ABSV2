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
    public class AddOnsController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: AddOns
        public ActionResult Index()
        {
            var addOns = db.AddOns;
            return View(addOns.ToList());
        }

        // GET: AddOns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddOns addOns = db.AddOns.Find(id);
            if (addOns == null)
            {
                return HttpNotFound();
            }
            return View(addOns);
        }

        // GET: AddOns/Create
        public ActionResult Create()
        {
            ViewBag.AddOnParentID = new SelectList(db.AddOnParent, "AddOnParentID", "AddOnCategory");
            ViewBag.BookingFormID = new SelectList(db.Bookings, "BookingFormID", "BookingRef");
            return View();
        }

        // POST: AddOns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookingFormID,AddOnParentID,AddOnName,AddOnType,AddOnCost,FreeWith,AddOnNumber")] AddOns addOns)
        {
            if (ModelState.IsValid)
            {
                db.AddOns.Add(addOns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddOnParentID = new SelectList(db.AddOnParent, "AddOnParentID", "AddOnCategory", addOns.AddOnParentID);
            return View(addOns);
        }

        // GET: AddOns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddOns addOns = db.AddOns.Find(id);
            if (addOns == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddOnParentID = new SelectList(db.AddOnParent, "AddOnParentID", "AddOnCategory", addOns.AddOnParentID);
            return View(addOns);
        }

        // POST: AddOns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookingFormID,AddOnParentID,AddOnName,AddOnType,AddOnCost,FreeWith,AddOnNumber")] AddOns addOns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addOns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddOnParentID = new SelectList(db.AddOnParent, "AddOnParentID", "AddOnCategory", addOns.AddOnParentID);
            return View(addOns);
        }

        // GET: AddOns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddOns addOns = db.AddOns.Find(id);
            if (addOns == null)
            {
                return HttpNotFound();
            }
            return View(addOns);
        }

        // POST: AddOns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddOns addOns = db.AddOns.Find(id);
            db.AddOns.Remove(addOns);
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
