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
                newBooking.BookingRef = "temp" + DateTime.Now.ToShortDateString();
                newBooking.VenueID = bookingViewModel.booking.VenueID;
                newBooking.Source = bookingViewModel.booking.Source;
                newBooking.Purpose = bookingViewModel.booking.Purpose;
                newBooking.DateOfBooking = bookingViewModel.booking.DateOfBooking;
                newBooking.GroupOrganiserFName = bookingViewModel.booking.GroupOrganiserFName;
                newBooking.GroupOrganiserLName = bookingViewModel.booking.GroupOrganiserLName;
                newBooking.GroupOrganiser =  bookingViewModel.booking.GroupOrganiserFName + " " + bookingViewModel.booking.GroupOrganiserLName;
                newBooking.PartyName = bookingViewModel.booking.PartyName;
                newBooking.GroupSize = bookingViewModel.booking.GroupSize;
                newBooking.StartTime = bookingViewModel.booking.StartTime;
                newBooking.EndTime = bookingViewModel.booking.StartTime.AddHours(2);
                newBooking.BookingSummary = bookingViewModel.booking.BookingSummary;
                newBooking.DaySheetNotes = bookingViewModel.booking.DaySheetNotes;
                newBooking.InternalNotes = bookingViewModel.booking.InternalNotes;
                newBooking.SendEmail = bookingViewModel.booking.SendEmail;
                newBooking.SendText = bookingViewModel.booking.SendText;
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
                    db.AddOnRecord.Add(aRecord);
                    db.SaveChanges();
                }

                //Financials
                finance.BookingFormID = newBooking.BookingFormID;
                db.Financial.Add(finance);
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