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
                Financial finance = FinanceHelper.CalculateCosts(db, bookingViewModel);


                BookingForm newBooking = new BookingForm();
                newBooking = bookingViewModel.booking;

                newBooking.BookingRef = "temp" + DateTime.Now.ToShortDateString();
                newBooking.EndTime = bookingViewModel.booking.StartTime.AddHours(2);
                newBooking.Created = DateTime.Now;
                db.Bookings.Add(newBooking);
                db.SaveChanges();

                //TODO
                UpdateBookingRef(db,newBooking);

                foreach (EventRecord record in bookingViewModel.EventData)
                {

                    EventRecord eventRecord = new EventRecord();
                    eventRecord.BookingFormID = newBooking.BookingFormID;
                    eventRecord.EventNumber = record.EventNumber;
                    eventRecord.EventID = record.EventID;
                    eventRecord.StartTime = record.StartTime;
                    db.EventRecords.Add(eventRecord);
                    db.SaveChanges();

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

                //Financials
                finance.BookingFormID = newBooking.BookingFormID;
                db.Financials.Add(finance);
                db.SaveChanges();


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

   }
}