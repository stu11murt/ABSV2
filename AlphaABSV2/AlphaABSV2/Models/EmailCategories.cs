using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class EmailCategories
    {
        public int EmailCategoriesID { get; set; }

        [Display(Name="Email Category")]
        public string CategoryName { get; set; }

    }
}