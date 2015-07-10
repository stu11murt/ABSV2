using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Display(Name = "Package")]
        public string EventType { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "0:hh:mm tt", ApplyFormatInEditMode = true)]
        public ICollection<DateTime?> StartTimeSlots { get; set; }

        public TimeSpan? Duration { get; set; }

        public bool? MultiSession { get; set; }

        public int? SessionNumber { get; set; }

        [Display(Name = "Min Number")]
        public int MinNumber { get; set; }

        [Display(Name = "Max Number")]
        public int MaxNumber { get; set; }

        [Display(Name = "Event Deposit")]
        [DataType(DataType.Currency)]
        public decimal EventDeposit { get; set; }

        [Display(Name = "Event Cost")]
        [DataType(DataType.Currency)]
        public decimal EventCost { get; set; }

        //Navigation properties
        public int EventParentID { get; set; }
        public virtual EventParent EventParent { get; set; }

        public virtual ICollection<EventRecord> EventRecord { get; set; }
    }
}