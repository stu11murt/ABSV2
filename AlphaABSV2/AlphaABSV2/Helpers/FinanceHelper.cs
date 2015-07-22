using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.Models;
using AlphaABSV2.ViewModels;
using AlphaABSV2.DAL;

namespace AlphaABSV2.Helpers
{
    public static class FinanceHelper
    {
        public static BookingForm CalculateCosts(ABSContext db,  BookingViewModel booking)
        {
            decimal runningTotal = 0;
            decimal runningDeposit = 0;
            decimal totalBalance = 0;
            decimal balancePP = 0;
            decimal agentDiscount = 0;


            BookingForm newBooking = booking.booking;

           
            
            
            foreach(EventRecord ev in booking.EventData)
            {
                if(ev.EventNumber > 0)
                {
                    Event relEvent = db.Events.Find(ev.EventID);
                    if (relEvent != null)
                    {
                        
                        runningTotal += (decimal)ev.EventNumber * relEvent.EventCost;
                        runningDeposit += (decimal)ev.EventNumber * relEvent.EventDeposit;
                        
                    }


                }


            }


            foreach(AddOnRecord ad in booking.AddOnData)
            {
                if(ad.AddOnNumber > 0)
                {
                    AddOns addon = db.AddOns.Find(ad.AddOnsID);
                    if (addon != null)
                        runningTotal += (decimal)ad.AddOnNumber * addon.AddOnCost;
                }
            }


            //calculate agent discount
            if (IsAgentBooking(newBooking))
            {
                Agent calcAgent = GetAgent(newBooking);
                if (calcAgent != null)
                    if (calcAgent.DiscountAmount > 0)
                        agentDiscount = calcAgent.DiscountAmount;
                    else if (calcAgent.DiscountPercent > 0)
                        agentDiscount = calcAgent.DiscountPercent * runningTotal;
                    else
                        agentDiscount = 0;
                else
                    agentDiscount = 0;

            }

            
            //apply agent discount
            runningTotal = runningTotal - agentDiscount;

            totalBalance = runningTotal - booking.booking.AmountTaken;
            balancePP = totalBalance / booking.booking.GroupSize;
          
            


            newBooking.BalanceRemaining = totalBalance;
            newBooking.BalanceRemainingPP = balancePP;
            newBooking.DepositPerPerson = runningDeposit / booking.booking.GroupSize;


            return newBooking;
        }

        static bool IsAgentBooking(BookingForm booking)
        {
            if (booking.Agent > 0)
                return true;
            else
                return false;
        }

        static Agent GetAgent(BookingForm booking)
        {
            ABSContext db = new ABSContext();
            Agent agent = db.Agents.Find(booking.Agent);

            if (agent != null)
                return agent;
            else
                return null;
        }

        public static decimal TodaysTakings(DateTime day)
        {
            ABSContext db = new ABSContext();
            List<decimal> res = new List<decimal>();

            decimal total = Convert.ToDecimal(db.Bookings.Where(b => b.DateOfEvent == day).Sum(fi => (decimal?)fi.AmountTaken));

            return total;
        }

        //TODO if time
        public static decimal WeeksTakings(DateTime day)
        {
            ABSContext db = new ABSContext();
            List<decimal> res = new List<decimal>();

            decimal total = Convert.ToDecimal(db.Bookings.Where(b => b.DateOfEvent == day).Sum(fi => (decimal?)fi.AmountTaken));

            return total;
        }

        public static decimal EventTakings(DateTime day, int eventID)
        {
            ABSContext db = new ABSContext();
            List<decimal> res = new List<decimal>();

            decimal total = Convert.ToDecimal(db.Bookings.Where(b => b.DateOfEvent == day && b.EventRecords.Where(e => e.EventID == eventID).Count() > 0).Sum(fi => (decimal?)fi.AmountTaken));

            return total;
        }

       
    }
      
}