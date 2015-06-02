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
        public DbSet<EventRecord> EventRecord { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<VersionManager> VersionManagers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffSkills> StaffSkills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<AlphaABSV2.Models.GroupBooking> GroupBookings { get; set; }
    }
}