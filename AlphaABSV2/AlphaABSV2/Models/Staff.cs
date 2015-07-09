using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class Staff
    {
        public int StaffID { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Num")]
        public string MobileNum { get; set; }

        public string Email { get; set; }

        [Display(Name="National Ins Number")]
        public string NINumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Employed")]
        public DateTime DateEmployed { get; set; }


        public virtual ICollection<StaffSkills> StaffSkills { get; set; }
        public virtual ICollection<StaffEventRota> StaffEventRotas { get; set; }

    }
}