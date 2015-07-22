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
    public class MarketingDatabaseController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: MarketingDatabase
        public ActionResult Index()
        {
            return View(db.MarketingDB.ToList());
        }

        // GET: MarketingDatabase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketingDatabase marketingDatabase = db.MarketingDB.Find(id);
            if (marketingDatabase == null)
            {
                return HttpNotFound();
            }
            return View(marketingDatabase);
        }

        // GET: MarketingDatabase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarketingDatabase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketingDatabaseID,FirstName,LastName,MobileNum,Email,MailChimpSubscribed, Created")] MarketingDatabase marketingDatabase)
        {
            if (ModelState.IsValid)
            {
                db.MarketingDB.Add(marketingDatabase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marketingDatabase);
        }

        // GET: MarketingDatabase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketingDatabase marketingDatabase = db.MarketingDB.Find(id);
            if (marketingDatabase == null)
            {
                return HttpNotFound();
            }
            return View(marketingDatabase);
        }

        // POST: MarketingDatabase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketingDatabaseID,FirstName,LastName,MobileNum,Email,MailChimpSubscribed, Created")] MarketingDatabase marketingDatabase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketingDatabase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marketingDatabase);
        }

        // GET: MarketingDatabase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketingDatabase marketingDatabase = db.MarketingDB.Find(id);
            if (marketingDatabase == null)
            {
                return HttpNotFound();
            }
            return View(marketingDatabase);
        }

        // POST: MarketingDatabase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarketingDatabase marketingDatabase = db.MarketingDB.Find(id);
            db.MarketingDB.Remove(marketingDatabase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PlayerDatabase()
        {
            return View(db.MarketingDB);
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
