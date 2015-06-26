using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlphaABSV2.Models;

namespace AlphaABSV2.Models
{
    public class EventRecord
    {
        public int EventRecordID { get; set; }
        
        public int EventID { get; set; }
        public int BookingFormID { get; set; }

        [Display(Name = "Event Number")]
        public int? EventNumber { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Start Time")]
        //[DisplayFormat(DataFormatString = "0:hh:mm tt", ApplyFormatInEditMode = true)]
        public DateTime? StartTime { get; set; }

        
        public virtual Event Event { get; set; }
        public virtual BookingForm BookingForm { get; set; }
    }
}