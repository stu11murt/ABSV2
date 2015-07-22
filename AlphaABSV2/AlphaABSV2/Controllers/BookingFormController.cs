﻿using System;
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
    public enum BookingStatusEnum {  Provisional = 1, Confirmed = 2, Cancelled = 3, Postponed = 4 }
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
               Helpers.BookingDBHelper.AddBooking(db, bookingViewModel);

                return RedirectToAction("Index");
            }

            InitiateDropDowns(bookingViewModel.booking.VenueID, bookingViewModel.booking.Source, bookingViewModel.booking.OfficeRef, bookingViewModel.booking.Purpose, bookingViewModel.booking.BookingStatus, bookingViewModel.booking.HotelID, bookingViewModel.booking.Agent);
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
            InitiateDropDowns(bookingForm.VenueID, bookingForm.Source, bookingForm.OfficeRef, bookingForm.Purpose, bookingForm.BookingStatus, bookingForm.HotelID, bookingForm.Agent);
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

        //$.post("/BookingForm/SubmitPayment/", { NameOnCard: NoC, CCNumber: templateNam, ValidFrom: VFrom, ExpiryDate:ExDate, CCVNumber: CCv, PayeeEmail: PayEmail });

        //ONLINE PAYMENT SUBMISSION
        public ActionResult SubmitOnlinePayment(string NameOnCard, string CCNumber, string ValidFrom, string ExpiryDate, string CCVNumber, string PayeeEmail)
        {
            //do a payment check in here
            if (CCVNumber == "123")
                return Content("Passed");
            else
                return Content("Failed");
        }

        //Display All Provisional Bookings
        public ActionResult DisplayProvBookings()
        {
            return View(db.Bookings.Where(b => b.BookingStatus == (int)BookingStatusEnum.Provisional).ToList());
        }

        public ActionResult ConfirmedBookings()
        {
            return View(db.Bookings.Where(b => b.BookingStatus == (int)BookingStatusEnum.Confirmed).ToList());
        }

        public ActionResult PostponedBookings()
        {
            return View(db.Bookings.Where(b => b.BookingStatus == (int)BookingStatusEnum.Postponed).ToList());
        }

        public ActionResult CancelledBookings()
        {
            return View(db.Bookings.Where(b => b.BookingStatus == (int)BookingStatusEnum.Cancelled).ToList());
        }

        public ActionResult AccomodationBookings()
        {
            return View(db.Bookings);
        }

        public ActionResult EventsCalendar()
        {
            return View();
        }

        public ActionResult GroupBookings()
        {
            var groupBookings = db.GroupBookings.ToList();
            return View(groupBookings);
        }

        public ActionResult OverduePayments()
        {
           return View(db.Bookings);
        }

        public ActionResult FinanceReports()
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

        private void PopulateHotelDropDownList(object selectedHotel= null)
        {
            var hotelQuery = from h in db.AccommParents
                               orderby h.AccommName
                               select h;
            ViewBag.Hotel = new SelectList(hotelQuery, "AccommParentID", "AccommName", selectedHotel);
        }

        private void PopulateAgentsDropDownList(object selectAgent = null)
        {
            var agentQuery = from a in db.Agents
                             orderby a.AgentName
                             select a;
            ViewBag.Agents = new SelectList(agentQuery, "AgentID", "AgentName", selectAgent);

        }

        private void InitiateDropDowns(int? venueID = 0, int? sourcesID = 0, int? officeRefID = 0, int? purposeID = 0, int? bookingStatusID = 0, int? hotelID = 0, int? agentID = 0)
        {
            PopulateVenueDropDownList(venueID);
            PopulateSourcesDropDownList(sourcesID);
            PopulateOfficeRefDropDownList(officeRefID);
            PopulatePurposeDropDownList(purposeID);
            PopulateBookingstatusDropDownList(bookingStatusID);
            PopulateHotelDropDownList(hotelID);
            PopulateAgentsDropDownList(agentID);

        }

        public ActionResult QuickView(string eventDate)
        {
           if(eventDate != null)
           {
               DateTime eDate = Convert.ToDateTime(eventDate);
               return View(db.EventRecords.Where(e => e.BookingForm.DateOfEvent == eDate).ToList());
           }
           else
           {
               return View(db.EventRecords.Where(e => e.BookingForm.DateOfEvent > DateTime.Today).ToList());
           }
            
        }

        public ActionResult PaintballQuickView(int? eventID)
        {

            return View(db.EventRecords.Where(e => e.Event.EventParentID == 1).ToList());
        }

        public ActionResult LaserQuickView()
        {
           
            return View(db.EventRecords.Where(e => e.Event.EventParentID == 2).ToList());
        }

        public ActionResult EventQuickView()
        {
            return View(db.EventRecords);
        }


        public JsonResult GetEvents(string start, string end)
        {
            ABSContext db = new ABSContext();

            DateTime fromDate = Convert.ToDateTime(start);
            DateTime toDate = Convert.ToDateTime(end);

            //var rep = Resolver.Resolve<IEventRepository>();
            var events = db.EventRecords.Where(e => e.BookingForm.DateOfEvent >= fromDate && e.BookingForm.DateOfEvent <= toDate);

            var eventList = from e in events
                            select new
                            {
                                id = e.EventID,
                                title = e.BookingForm.GroupOrganiser + " " + e.BookingForm.GroupSize + " " + e.BookingForm.TelNo + " " + e.BookingForm.BookingStatus,
                                start = e.StartTime,
                                end = e.EndTime,
                                allDay = false,
                                url = "/BookingForm/Details/"+ e.BookingFormID
                            };

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        
    }
}
