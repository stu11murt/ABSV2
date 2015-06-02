using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class EventRecord
    {
        public int EventRecordID { get; set; }

        public int EventNumber { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "0:hh:mm tt", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        public int EventTypeID { get; set; }

        //Navigation properties
        public int BookingFormID { get; set; }
        public virtual BookingForm BookingForm { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }
    }
}