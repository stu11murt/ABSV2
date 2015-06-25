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
    public class AddOnParentController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: AddOnParent
        public ActionResult Index()
        {
            return View(db.AddOnParent.ToList());
        }

        // GET: AddOnParent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddOnParent addOnParent = db.AddOnParent.Find(id);
            if (addOnParent == null)
            {
                return HttpNotFound();
            }
            return View(addOnParent);
        }

        // GET: AddOnParent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddOnParent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddOnParentID,AddOnCategory")] AddOnParent addOnParent)
        {
            if (ModelState.IsValid)
            {
                db.AddOnParent.Add(addOnParent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addOnParent);
        }

        // GET: AddOnParent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddOnParent addOnParent = db.AddOnParent.Find(id);
            if (addOnParent == null)
            {
                return HttpNotFound();
            }
            return View(addOnParent);
        }

        // POST: AddOnParent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddOnParentID,AddOnCategory")] AddOnParent addOnParent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addOnParent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addOnParent);
        }

        // GET: AddOnParent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddOnParent addOnParent = db.AddOnParent.Find(id);
            if (addOnParent == null)
            {
                return HttpNotFound();
            }
            return View(addOnParent);
        }

        // POST: AddOnParent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddOnParent addOnParent = db.AddOnParent.Find(id);
            db.AddOnParent.Remove(addOnParent);
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
