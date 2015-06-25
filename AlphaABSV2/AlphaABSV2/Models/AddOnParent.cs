using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlphaABSV2.Models;

namespace AlphaABSV2.Models
{
    public class AddOnParent
    {
        public int AddOnParentID { get; set; }

        public string AddOnCategory { get; set; }

        //NAv Fields
        public virtual ICollection<AddOns> AddOns { get; set; }
    }
}