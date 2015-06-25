using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class BookingForm
    {
        public int BookingFormID { get; set; }

        public string BookingRef { get; set; }

        [Display(Name = "Office Ref")]
        public int OfficeRef { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Booking")]
        public DateTime DateOfBooking { get; set; }

        public string Email { get; set; }

        [Display(Name="Tel/Mob Num")]
        public string TelNo { get; set; }

        public int Source { get; set; }
        //[Display(Name = "Source of Booking")]
        //public virtual ICollection<Source> Sources { get; set; }

        [Display(Name="Venue")]
        public int VenueID { get; set; }
        //public virtual ICollection<Venue> Venues {  get; set; }

        public int Purpose { get; set; }
        //[Display(Name = "Purpose of Event")]
        //public virtual ICollection<Purpose> Purposes { get; set; }

        [Display(Name = "Group Organiser First Name")]
        public string GroupOrganiserFName { get; set; }

        [Display(Name = "GroupOrgansiser Last Name")]
        public string GroupOrganiserLName { get; set; }

        [Display(Name = "Group Organiser")]
        public string GroupOrganiser { get; set; }

        [Display(Name = "Party Name")]
        public string PartyName { get; set; }

        [Display(Name = "Group Size")]
        public int GroupSize { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        public int BookingStatus { get; set; }
        //[Display(Name = "Booking Status")]
        //public virtual ICollection<BookingStatus> BookingStatuses { get; set; }

        [Display(Name = "Booking Summary")]
        public string BookingSummary { get; set; }

        [Display(Name = "Day Sheet Notes")]
        public string DaySheetNotes { get; set; }

        [Display(Name = "Internal Notes")]
        public string InternalNotes { get; set; }

        [Display(Name = "Send Email")]
        public bool SendEmail { get; set; }

        [Display(Name = "Send Text")]
        public bool SendText { get; set; }

        public DateTime Created { get; set; }

        //Events
        public virtual ICollection<EventParent> EventParents { get; set; }

        public virtual ICollection<EventRecord> EventRecords { get; set; }

        public virtual ICollection<AddOnParent> AddOnParents { get; set; }

        public virtual ICollection<AddOnRecord> AddOnRecords { get; set; }

        public virtual ICollection<GroupBooking> GroupBookings { get; set; }

        public virtual ICollection<Financial> Financials { get; set; }
    }
}