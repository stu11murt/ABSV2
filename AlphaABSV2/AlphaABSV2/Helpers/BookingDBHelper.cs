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
                BookingForm newBooking = new BookingForm();
                newBooking.BookingRef = bookingViewModel.booking.BookingRef;
                newBooking.VenueID = bookingViewModel.booking.VenueID;
                newBooking.Source = bookingViewModel.booking.Source;
                newBooking.DateOfBooking = bookingViewModel.booking.DateOfBooking;
                newBooking.GroupOrganiserFName = bookingViewModel.booking.GroupOrganiserFName;
                newBooking.GroupOrganiserLName = bookingViewModel.booking.GroupOrganiserLName;
                newBooking.GroupOrganiser =  bookingViewModel.booking.GroupOrganiserFName + " " + bookingViewModel.booking.GroupOrganiserLName;
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

                //TODO
                SubscribeToMailChimp(bookingViewModel);

                MarketingDatabase markDB = new MarketingDatabase();
                markDB.FirstName = bookingViewModel.booking.GroupOrganiserFName;
                markDB.LastName = bookingViewModel.booking.GroupOrganiserLName;
                markDB.MobileNum = bookingViewModel.booking.TelNo;
                markDB.Email = bookingViewModel.booking.Email;
                markDB.MailChimpSubscribed = true;
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
    }
}