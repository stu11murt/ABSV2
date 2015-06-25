using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlphaABSV2.Models;


namespace AlphaABSV2.Models
{
    public class AddOnRecord
    {
        public int AddOnRecordID { get; set; }
        public int AddOnsID { get; set; }
        public int BookingFormID { get; set; }

        [Display(Name="Number")]
        public int AddOnNumber { get; set; }

        public virtual AddOns AddOns { get; set; }
    }
}