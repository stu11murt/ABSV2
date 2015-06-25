using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class Financial
    {
        public int FinancialID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Deposit Due")]
        public DateTime DepositDueOnDate { get; set; }

        [Display(Name="Event Cost Per Person")]
        public decimal EventCostPerPerson { get; set; }

        [Display(Name = "Deposit Per Person")]
        public decimal? DepositPerPerson { get; set; }

        [Display(Name = "Balance Remaining")]
        public decimal? BalanceRemaining { get; set; }

        [Display(Name = "Balance Remaining Per Person")]
        public decimal? BalanceRemainingPP { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Deposit Total Taken")]
        public decimal? DepositTotalTaken { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Amount Taken")]
        public decimal AmountTaken { get; set; }

        [Display(Name = "Group Spend on Day")]
        public decimal? GroupSpendOnDay { get; set; }

        [Display(Name = "Discount - Per Person")]
        public decimal DiscountPerPerson { get; set; }

        [Display(Name = "Discount - Total")]
        public decimal DiscountTotal { get; set; }




        //Nav fields
        public int BookingFormID { get; set; }
        public virtual BookingForm BookingForm { get; set; }
    }
}