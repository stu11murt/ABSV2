using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlphaABSV2.Models;

namespace AlphaABSV2.Models
{
    public class StaffEventRota
    {
        public int StaffEventRotaID { get; set; }

        public int StaffID { get; set; }
        public int EventRecordID { get; set; }

        [Display(Name="Staff Notes")]
        public string StaffNotes { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual EventRecord EventRecord { get; set; }
    }
}