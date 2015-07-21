using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class OnlinePayment
    {
        public int OnlinePaymentID { get; set; }

        [Display(Name="Credit Card Number")]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }

        [Display(Name="Name on Card")]
        public string NameOnCard { get; set; }

        [Display(Name = "Valid From")]
        public string ValidFrom { get; set; }

        [Display(Name="Expiry Date")]
        public string ExpiryDate { get; set; }

        [Display(Name="CCV2 Number")]
        public string CCV2 { get; set;}

        [Display(Name = "Amount To Pay")]
        [DataType(DataType.Currency)]
        public decimal AmountToPay { get; set; }

        public DateTime Created { get; set; }

        [Display(Name="Payee Email")]
        public string PayeeEmail { get; set; }

        //NAV FIELDS
        public int BookingFormID { get; set; }
        public BookingForm BookingForm { get; set; }
    }
}