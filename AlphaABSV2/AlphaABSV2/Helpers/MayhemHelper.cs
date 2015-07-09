using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.Models;
using AlphaABSV2.DAL;

namespace AlphaABSV2.Helpers
{
    public enum QueryTypeMayhem { Paintball = 1, Laser = 2, Walkon = 3, BigTicket = 4, PrePay = 98, AllEvents = 99 }

    public static class MayhemHelper
    {
        public static List<EventRecord> FindQueryType(DateTime selectDate, int id)
        {
            ABSContext db = new ABSContext();
            
            switch (id)
            {
                case (int)QueryTypeMayhem.Paintball:
                    List<EventRecord> evs = db.EventRecords.Where(e => e.Event.EventParentID == (int)QueryTypeMayhem.Paintball && e.BookingForm.DateOfEvent == selectDate).ToList();
                    return db.EventRecords.Where(e => e.Event.EventParentID == (int)QueryTypeMayhem.Paintball && e.BookingForm.DateOfEvent == selectDate).ToList();
                case (int)QueryTypeMayhem.PrePay:
                    return db.EventRecords.Where(e => e.BookingForm.BalanceRemaining == 0 && e.BookingForm.DateOfEvent == selectDate).ToList();
                case (int)QueryTypeMayhem.Laser:
                    return db.EventRecords.Where(e => e.Event.EventParent.EventParentID == (int)QueryTypeMayhem.Laser && e.BookingForm.DateOfEvent == selectDate).ToList();
                case (int)QueryTypeMayhem.Walkon:
                    return db.EventRecords.Where(e => e.Event.EventParent.EventParentID == (int)QueryTypeMayhem.Walkon && e.BookingForm.DateOfEvent == selectDate).ToList();
                case (int)QueryTypeMayhem.BigTicket:
                    return db.EventRecords.Where(e => e.Event.EventParent.EventParentID == (int)QueryTypeMayhem.BigTicket && e.BookingForm.DateOfEvent == selectDate).ToList();
                default:
                    return db.EventRecords.ToList();
            }
        }
    }
}