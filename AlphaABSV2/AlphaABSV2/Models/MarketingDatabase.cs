using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class MarketingDatabase
    {
        public int MarketingDatabaseID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Num")]
        public string MobileNum { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        public bool MailChimpSubscribed { get; set; }
    }
}