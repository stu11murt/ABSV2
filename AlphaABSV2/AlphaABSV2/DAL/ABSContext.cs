using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlphaABSV2.DAL
{
    public class ABSContext : DbContext
    {
        public ABSContext()
            : base("ABSContext")
        { }

        public DbSet<BookingForm> Bookings { get; set; }
        public DbSet<OfficeRef> OfficeRefs { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<EventParent> EventParents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRecord> EventRecords { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<VersionManager> VersionManagers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffSkills> StaffSkills { get; set; }
        public DbSet<MarketingDatabase> MarketingDB { get; set; }
        public DbSet<EmailManager> EmailManager { get; set; }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }
        public DbSet<EmailCategories> EmailCategories { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<AddOnParent> AddOnParents { get; set; }
        public DbSet<AddOns> AddOns { get; set; }
        public DbSet<AddOnRecord> AddOnRecords { get; set; }
        public DbSet<AccommParent> AccommParents { get; set; }
        public DbSet<StaffEventRota> StaffEventRotas { get; set; }
       
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<AlphaABSV2.Models.GroupBooking> GroupBookings { get; set; }
    }
}