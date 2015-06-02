using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class VersionManager
    {
        public int VersionManagerID { get; set; }

        [Display(Name="Business Name")]
        public string BusinessName { get; set; }

        [Display(Name="Building Number/Name")]
        public string BuildingNumberName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string VatNum { get; set; }
        public string Bank { get; set; }
    }
}