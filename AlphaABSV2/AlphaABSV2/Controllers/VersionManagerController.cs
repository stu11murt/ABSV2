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
    public class VersionManagerController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: VersionManager
        public ActionResult Index()
        {
            return View(db.VersionManagers.ToList());
        }

        // GET: VersionManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VersionManager versionManager = db.VersionManagers.Find(id);
            if (versionManager == null)
            {
                return HttpNotFound();
            }
            return View(versionManager);
        }

        // GET: VersionManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VersionManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VersionManagerID,BusinessName,BuildingNumberName,Address1,Address2,Town,Country,PostCode,VatNum,Bank")] VersionManager versionManager)
        {
            if (ModelState.IsValid)
            {
                db.VersionManagers.Add(versionManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(versionManager);
        }

        // GET: VersionManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VersionManager versionManager = db.VersionManagers.Find(id);
            if (versionManager == null)
            {
                return HttpNotFound();
            }
            return View(versionManager);
        }

        // POST: VersionManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VersionManagerID,BusinessName,BuildingNumberName,Address1,Address2,Town,Country,PostCode,VatNum,Bank")] VersionManager versionManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(versionManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(versionManager);
        }

        // GET: VersionManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VersionManager versionManager = db.VersionManagers.Find(id);
            if (versionManager == null)
            {
                return HttpNotFound();
            }
            return View(versionManager);
        }

        // POST: VersionManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VersionManager versionManager = db.VersionManagers.Find(id);
            db.VersionManagers.Remove(versionManager);
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
