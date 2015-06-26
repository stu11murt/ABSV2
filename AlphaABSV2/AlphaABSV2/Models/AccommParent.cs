using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class AccommParent
    {
        public int AccommParentID { get; set; }

        [Display(Name="Hotel Name")]
        public string AccommName { get; set; }

        public string StreetNumber { get; set; }

        public string SteetName { get; set; }

        public string TownCity { get; set; }

        public string PostCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Check In Time")]
        public DateTime CheckInTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Check Out Time")]
        public DateTime CheckOutTime { get; set; }

       
        
    }
}