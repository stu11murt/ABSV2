using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.Models;
using AlphaABSV2.ViewModels;
using AlphaABSV2.DAL;
using System.Web.Mvc;

namespace AlphaABSV2.ViewModels
{
    public class BookingViewModel
    {
        private ABSContext db = new ABSContext();

        public BookingForm booking { get; set; }
        public List<EventRecord> EventData { get; set; }
        public List<Event> DynamicEvents
        {
            get
            {

                return db.Events.ToList();

            }
            set
            {


            }
        }

        public List<AddOnRecord> AddOnData { get; set; }
        public List<AddOns> DynamicAddOns
        {
            get { return db.AddOns.ToList();  }
            set { }
        }

        public OnlinePayment OnlinePay { get; set; }

        

        
    }
}