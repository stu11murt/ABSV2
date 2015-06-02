using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class GroupBooking
    {
        public int GroupBookingID { get; set; }

        [Display(Name = "Group Organiser")]
        public string GroupOrganiser { get; set; }

        [Display(Name = "Party Name")]
        public string PartyName { get; set; }

        [Display(Name = "Group Reference")]
        public string GroupRef { get; set; }

        [Display(Name = "Your Email Address")]
        public string PlayerEmail { get; set; }

        [Display(Name = "Your Mobile Number")]
        public string PlayerMobile { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Amount To Pay")]
        public decimal PlayerAmountToPay { get; set; }

        public int BookingFormID { get; set; }
        public BookingForm BookingForm { get; set; }
    }
}