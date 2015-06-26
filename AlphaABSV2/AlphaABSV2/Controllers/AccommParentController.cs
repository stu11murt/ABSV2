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
    public class AccommParentController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: AccommParent
        public ActionResult Index()
        {
            return View(db.AccommParents.ToList());
        }

        // GET: AccommParent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccommParent accommParent = db.AccommParents.Find(id);
            if (accommParent == null)
            {
                return HttpNotFound();
            }
            return View(accommParent);
        }

        // GET: AccommParent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccommParent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccommParentID,AccommName,StreetNumber,SteetName,TownCity,PostCode,CheckInTime,CheckOutTime")] AccommParent accommParent)
        {
            if (ModelState.IsValid)
            {
                db.AccommParents.Add(accommParent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accommParent);
        }

        // GET: AccommParent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccommParent accommParent = db.AccommParents.Find(id);
            if (accommParent == null)
            {
                return HttpNotFound();
            }
            return View(accommParent);
        }

        // POST: AccommParent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccommParentID,AccommName,StreetNumber,SteetName,TownCity,PostCode,CheckInTime,CheckOutTime")] AccommParent accommParent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accommParent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accommParent);
        }

        // GET: AccommParent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccommParent accommParent = db.AccommParents.Find(id);
            if (accommParent == null)
            {
                return HttpNotFound();
            }
            return View(accommParent);
        }

        // POST: AccommParent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccommParent accommParent = db.AccommParents.Find(id);
            db.AccommParents.Remove(accommParent);
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
