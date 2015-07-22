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
    public class MessagingController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: Messaging
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        // GET: Messaging/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messaging messaging = db.Messages.Find(id);
            if (messaging == null)
            {
                return HttpNotFound();
            }
            return View(messaging);
        }

        // GET: Messaging/Create
        public ActionResult Create()
        {
            PopulateUsersDropDownList();
            return View();
        }

        // POST: Messaging/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Message,Read,Archived,Deleted,Created")] Messaging messaging, string userID = "NA")
        {
            if (ModelState.IsValid)
            {
                messaging.Created = DateTime.Now;
                db.Messages.Add(messaging);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messaging);
        }

        // GET: Messaging/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messaging messaging = db.Messages.Find(id);
            if (messaging == null)
            {
                return HttpNotFound();
            }
            return View(messaging);
        }

        // POST: Messaging/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Message,Read,Archived,Deleted,Created")] Messaging messaging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messaging).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messaging);
        }

        // GET: Messaging/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messaging messaging = db.Messages.Find(id);
            if (messaging == null)
            {
                return HttpNotFound();
            }
            return View(messaging);
        }

        // POST: Messaging/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messaging messaging = db.Messages.Find(id);
            db.Messages.Remove(messaging);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateUsersDropDownList(object userStatus = null)
        {
            AccountController acc = new AccountController();
           
            var userQuery = from a in acc.GetUserIDs()
                              orderby a.UserName
                              select a;
            ViewBag.Users = new SelectList(userQuery, "Id", "UserName", userStatus);
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
