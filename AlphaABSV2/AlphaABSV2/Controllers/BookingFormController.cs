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
using AlphaABSV2.ViewModels;

namespace AlphaABSV2.Controllers
{
    public class BookingFormController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: BookingForm
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: BookingForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingForm bookingForm = db.Bookings.Find(id);
            if (bookingForm == null)
            {
                return HttpNotFound();
            }
            return View(bookingForm);
        }

               
        public ActionResult Create()
        {

            InitiateDropDowns();
            var viewModel = new BookingViewModel();
            return View(viewModel);
        }

        // POST: BookingForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingViewModel bookingViewModel)
        {

            if (ModelState.IsValid)
            {
                BookingForm newBooking = new BookingForm();
                newBooking.BookingRef = bookingViewModel.booking.BookingRef;
                newBooking.VenueID = bookingViewModel.booking.VenueID;
                newBooking.Source = bookingViewModel.booking.Source;
                newBooking.DateOfBooking = bookingViewModel.booking.DateOfBooking;
                newBooking.GroupOrganiser = bookingViewModel.booking.GroupOrganiser;
                newBooking.PartyName = bookingViewModel.booking.PartyName;
                newBooking.GroupSize = bookingViewModel.booking.GroupSize;
                newBooking.StartTime = bookingViewModel.booking.StartTime;
                newBooking.EndTime = bookingViewModel.booking.EndTime;
                newBooking.BookingSummary = bookingViewModel.booking.BookingSummary;
                newBooking.DaySheetNotes = bookingViewModel.booking.DaySheetNotes;
                newBooking.InternalNotes = bookingViewModel.booking.InternalNotes;
                newBooking.SendEmail = bookingViewModel.booking.SendEmail;
                newBooking.SendText = bookingViewModel.booking.SendText;


                db.Bookings.Add(newBooking);
                db.SaveChanges();

                foreach (EventRecord record in bookingViewModel.EventData)
                {

                    EventRecord eventRecord = new EventRecord();
                    eventRecord.BookingFormID = newBooking.BookingFormID;
                    eventRecord.EventNumber = record.EventNumber;
                    eventRecord.EventID = record.EventTypeID;
                    eventRecord.StartTime = record.StartTime;
                    db.EventRecord.Add(eventRecord);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }

            InitiateDropDowns(bookingViewModel.booking.VenueID, bookingViewModel.booking.Source, bookingViewModel.booking.OfficeRef, bookingViewModel.booking.Purpose, bookingViewModel.booking.BookingStatus);
            return View(bookingViewModel);
        }


        // GET: BookingForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingForm bookingForm = db.Bookings.Find(id);
            if (bookingForm == null)
            {
                return HttpNotFound();
            }
            
            PopulateVenueDropDownList(bookingForm.VenueID);
            InitiateDropDowns(bookingForm.VenueID, bookingForm.Source, bookingForm.OfficeRef, bookingForm.Purpose, bookingForm.BookingStatus);
            return View(bookingForm);
        }

        // POST: BookingForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingFormID,BookingRef,DateOfBooking,GroupOrganiser,PartyName,GroupSize,StartTime,EndTime,BookingSummary,DaySheetNotes,InternalNotes,SendEmail,SendText")] BookingForm bookingForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingForm);
        }

        // GET: BookingForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingForm bookingForm = db.Bookings.Find(id);
            if (bookingForm == null)
            {
                return HttpNotFound();
            }
            return View(bookingForm);
        }

        // POST: BookingForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingForm bookingForm = db.Bookings.Find(id);
            db.Bookings.Remove(bookingForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Display All Provisional Bookings
        public ActionResult DisplayProvBookings()
        {
            return View(db.Bookings.ToList());
        }

        public ActionResult EventsCalendar()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateVenueDropDownList(object selectedVenue = null)
        {
            var venuesQuery = from v in db.Venues
                              orderby v.VenueName
                              select v;
            ViewBag.Venue = new SelectList(venuesQuery, "VenueID", "VenueName", selectedVenue);
        }

        private void PopulateSourcesDropDownList(object selectedSource = null)
        {
            var sourcesQuery = from s in db.Sources
                               orderby s.SourceName
                               select s;
            ViewBag.Source = new SelectList(sourcesQuery, "SourceID", "SourceName", selectedSource);
        }

        private void PopulateBookingstatusDropDownList(object selectedStatus = null)
        {
            var statusQuery = from b in db.BookingStatuses
                              orderby b.BookingStatusID
                              select b;
            ViewBag.BookingStatus = new SelectList(statusQuery, "BookingStatusID", "BookingStatusText", selectedStatus);
        }

        private void PopulateOfficeRefDropDownList(object selectedref = null)
        {
            var officeRefQuery = from o in db.OfficeRefs
                              orderby o.OfficeRefPeople
                              select o;
            ViewBag.OfficeRef = new SelectList(officeRefQuery, "OfficeRefID", "OfficeRefPeople", selectedref);
        }

        private void PopulatePurposeDropDownList(object selectedPurpose = null)
        {
            var purposeQuery = from p in db.Purposes
                              orderby p.PurposeOfEvent
                              select p;
            ViewBag.Purpose = new SelectList(purposeQuery, "PurposeID", "PurposeOfEvent", selectedPurpose);
        }

        private void InitiateDropDowns(int? venueID = 0, int? sourcesID = 0, int? officeRefID = 0, int? purposeID = 0, int? bookingStatusID = 0)
        {
            PopulateVenueDropDownList(venueID);
            PopulateSourcesDropDownList(sourcesID);
            PopulateOfficeRefDropDownList(officeRefID);
            PopulatePurposeDropDownList(purposeID);
            PopulateBookingstatusDropDownList(bookingStatusID);

        }

        
    }
}
