using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlphaABSV2.Models;


namespace AlphaABSV2.Models
{
    public class AddOns
    {
        public int ID { get; set; }
        
        public int AddOnParentID { get; set; }
        

        [Display(Name="Name")]
        public string AddOnName { get; set; }

        public int? AddOnType { get; set; }
        
        public decimal AddOnCost { get; set; }

        public bool? FreeWith { get; set; }

        
        //Navigation fields
        public virtual AddOnParent AddOnParent { get; set; }
       
        public virtual ICollection<AddOnRecord> AddOnRecords { get; set; }

        

    }
}