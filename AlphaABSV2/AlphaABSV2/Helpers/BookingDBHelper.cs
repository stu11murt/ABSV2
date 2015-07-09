using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.Models;
using AlphaABSV2.DAL;
using AlphaABSV2.ViewModels;
using System.Web.Mvc;

namespace AlphaABSV2.Helpers
{
    public static class BookingDBHelper
    {
        public static void AddBooking(ABSContext db, BookingViewModel bookingViewModel)
        {

            try
            {
                //TODO update financials
                //Financial finance = FinanceHelper.CalculateCosts(db, bookingViewModel);


                BookingForm newBooking = new BookingForm();
                newBooking = FinanceHelper.CalculateCosts(db, bookingViewModel);

                newBooking.BookingRef = "temp" + DateTime.Now.ToShortDateString();
                newBooking.EndTime = bookingViewModel.booking.StartTime.AddHours(2);
                newBooking.GroupOrganiser = bookingViewModel.booking.GroupOrganiserFName + " " + bookingViewModel.booking.GroupOrganiserLName;
                newBooking.Created = DateTime.Now;
                db.Bookings.Add(newBooking);
                db.SaveChanges();

                //TODO
                UpdateBookingRef(db,newBooking);

                foreach (EventRecord record in bookingViewModel.EventData)
                {
                    if (record.EventNumber != null && record.StartTime != null)
                    { 
                        DateTime evDate = Convert.ToDateTime(bookingViewModel.booking.DateOfEvent);
                        DateTime st = Convert.ToDateTime(record.StartTime);

                        DateTime ActStartTime = new DateTime(evDate.Year, evDate.Month, evDate.Day, st.Hour, st.Minute, st.Second);

                        Event ev = db.Events.Find(record.EventID);
                        EventRecord eventRecord = new EventRecord();
                        eventRecord.BookingFormID = newBooking.BookingFormID;
                        eventRecord.EventNumber = record.EventNumber;
                        eventRecord.EventID = record.EventID;
                        eventRecord.StartTime = ActStartTime;
                        
                        if(ev != null)
                            eventRecord.EndTime = ActStartTime.Add((TimeSpan)ev.Duration); 
                        
                        db.EventRecords.Add(eventRecord);
                        db.SaveChanges();
                    }

                }

                foreach(AddOnRecord addRecord in bookingViewModel.AddOnData)
                {
                    AddOnRecord aRecord = new AddOnRecord();
                    aRecord.AddOnNumber = addRecord.AddOnNumber;
                    aRecord.BookingFormID = newBooking.BookingFormID;
                    aRecord.AddOnsID = addRecord.AddOnsID;
                    db.AddOnRecords.Add(aRecord);
                    db.SaveChanges();
                }

                ////Financials
                //finance.BookingFormID = newBooking.BookingFormID;
                //db.Financials.Add(finance);
                //db.SaveChanges();


                //TODO
                SubscribeToMailChimp(bookingViewModel);

                MarketingDatabase markDB = new MarketingDatabase();
                markDB.FirstName = bookingViewModel.booking.GroupOrganiserFName;
                markDB.LastName = bookingViewModel.booking.GroupOrganiserLName;
                markDB.MobileNum = bookingViewModel.booking.TelNo;
                markDB.Email = bookingViewModel.booking.Email;
                markDB.MailChimpSubscribed = true;
                markDB.Created = DateTime.Now;
                db.MarketingDB.Add(markDB);
                db.SaveChanges();


               

                
            }
            catch (Exception)
            {
                
                throw;
            }
		      
        }

        private static void SubscribeToMailChimp(BookingViewModel bookMod)
        {
            //TODO
            //stuff 
        }

        private static void UpdateBookingRef(ABSContext db, BookingForm booking)
        {
            //TODO
            booking.BookingRef = "NewUniqueRef";
            db.SaveChanges();
        }

        public static int GetTotalGroups(DateTime? eventDate, int eventParentID = 0, string eventType = "NA")
        {
            ABSContext db = new ABSContext();
            if(eventDate != null && eventParentID > 0)
            {
                return db.EventRecords.Where(e => e.Event.EventParentID == eventParentID && e.BookingForm.DateOfEvent == eventDate).Select(b => b.BookingForm).ToList().Count;
            }
            else if (eventDate != null && eventType != "NA")
            {
                return db.EventRecords.Where(b => b.Event.EventType == eventType && b.BookingForm.DateOfEvent == eventDate).Select(x => x.BookingForm).ToList().Count;
            }
            else
            {
                return 0;
            }
            
        }

        public static int GetTotalPlayers(DateTime? eventDate, int eventParentID = 0, int eventType = 0)
        {
            ABSContext db = new ABSContext();
            if (eventDate != null && eventParentID > 0)
            {
                return db.EventRecords.Where(e => e.Event.EventParentID == eventParentID && e.BookingForm.DateOfEvent == eventDate).Select(n => (int)n.EventNumber).Sum();
            }
            else if (eventDate != null && eventType > 0)
            {
                return db.EventRecords.Where(e => e.Event.EventID == eventType && e.BookingForm.DateOfEvent == eventDate).Select(n => (int)n.EventNumber).Sum();
            }
            else
            {
                return 0;
            }
                
            
        }

   }
}