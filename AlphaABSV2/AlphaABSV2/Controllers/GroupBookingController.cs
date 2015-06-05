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
    public class GroupBookingController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: GroupBooking
        public ActionResult Index(string bookingRef = "")
        {
            if(!string.IsNullOrEmpty(bookingRef))
            {
                return View();
            }
            else
            {

                return View("Index", db.Bookings.Where(b => b.BookingRef.Contains(bookingRef)));
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return View("Index", db.Bookings.Where(b => b.BookingRef.Contains(searchString)));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Thankyou()
        {
            return View();
        }

        // GET: GroupBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupBooking groupBooking = db.GroupBookings.Find(id);
            if (groupBooking == null)
            {
                return HttpNotFound();
            }
            return View(groupBooking);
        }

        // GET: GroupBooking/Create
        public ActionResult Create(int id)
        {
            GroupBooking group = new GroupBooking();
            BookingForm bkForm = db.Bookings.Find(id);

            if (bkForm != null)
            {
                group.BookingFormID = bkForm.BookingFormID;
                group.GroupRef = bkForm.BookingRef;
                group.GroupOrganiser = bkForm.GroupOrganiser;
                group.PartyName = bkForm.PartyName;
            }
            return View(group);
        }

        // POST: GroupBooking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupOrganiser,PartyName,GroupRef,PlayerEmail,PlayerMobile,PlayerAmountToPay,BookingFormID")] GroupBooking groupBooking)
        {
            if (ModelState.IsValid)
            {
                db.GroupBookings.Add(groupBooking);
                db.SaveChanges();

                //TODO add this to BookingDBHelper
                MarketingDatabase markDB = new MarketingDatabase();
                markDB.FirstName = groupBooking.FirstName;
                markDB.LastName = groupBooking.LastName;
                markDB.MobileNum = groupBooking.PlayerMobile;
                markDB.Email = groupBooking.PlayerEmail;
                markDB.MailChimpSubscribed = true;
                db.MarketingDB.Add(markDB);
                db.SaveChanges();


                return RedirectToAction("Thankyou");
            }

            ViewBag.BookingFormID = new SelectList(db.Bookings, "BookingFormID", "BookingRef", groupBooking.BookingFormID);
            return View(groupBooking);
        }

        // GET: GroupBooking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupBooking groupBooking = db.GroupBookings.Find(id);
            if (groupBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingFormID = new SelectList(db.Bookings, "BookingFormID", "BookingRef", groupBooking.BookingFormID);
            return View(groupBooking);
        }

        // POST: GroupBooking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupBookingID,GroupOrganiser,PartyName,GroupRef,PlayerEmail,PlayerMobile,PlayerAmountToPay,BookingFormID")] GroupBooking groupBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingFormID = new SelectList(db.Bookings, "BookingFormID", "BookingRef", groupBooking.BookingFormID);
            return View(groupBooking);
        }

        // GET: GroupBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupBooking groupBooking = db.GroupBookings.Find(id);
            if (groupBooking == null)
            {
                return HttpNotFound();
            }
            return View(groupBooking);
        }

        // POST: GroupBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupBooking groupBooking = db.GroupBookings.Find(id);
            db.GroupBookings.Remove(groupBooking);
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
