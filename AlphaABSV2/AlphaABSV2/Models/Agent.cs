using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentID { get; set; }

        [Display(Name="Agent Name")]
        public string AgentName { get; set; }

        [Display(Name="Agent Code")]
        public string AgentCode { get; set; }

        [Display(Name = "Main Tel Number")]
        public string MainContactNumber { get; set; }

        public string Email { get; set; }

        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public bool Active { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Discount £")]
        public decimal DiscountAmount { get; set; }

        [Display(Name = "Discount %")]
        public decimal DiscountPercent { get; set; }

        [Display(Name = "2nd Tel Num")]
        public string SecondContactNumber { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Payment Notes")]
        public string PaymentNotes { get; set; }
        

        public DateTime? Created { get; set; }

    }
}