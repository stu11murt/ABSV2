namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingForm",
                c => new
                    {
                        BookingFormID = c.Int(nullable: false, identity: true),
                        BookingRef = c.String(),
                        DateOfBooking = c.DateTime(nullable: false),
                        Source = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                        Purpose = c.Int(nullable: false),
                        GroupOrganiser = c.String(),
                        PartyName = c.String(),
                        GroupSize = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        BookingStatus = c.Int(nullable: false),
                        BookingSummary = c.String(),
                        DaySheetNotes = c.String(),
                        InternalNotes = c.String(),
                        SendEmail = c.Boolean(nullable: false),
                        SendText = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingFormID);
            
            CreateTable(
                "dbo.EventParent",
                c => new
                    {
                        EventParentID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        BookingForm_BookingFormID = c.Int(),
                    })
                .PrimaryKey(t => t.EventParentID)
                .ForeignKey("dbo.BookingForm", t => t.BookingForm_BookingFormID)
                .Index(t => t.BookingForm_BookingFormID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventType = c.String(),
                        Duration = c.Time(precision: 7),
                        MultiSession = c.Boolean(),
                        SessionNumber = c.Int(),
                        MinNumber = c.Int(nullable: false),
                        MaxNumber = c.Int(nullable: false),
                        EventParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.EventParent", t => t.EventParentID, cascadeDelete: true)
                .Index(t => t.EventParentID);
            
            CreateTable(
                "dbo.EventRecord",
                c => new
                    {
                        EventRecordID = c.Int(nullable: false, identity: true),
                        EventNumber = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EventTypeID = c.Int(nullable: false),
                        BookingFormID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventRecordID)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .Index(t => t.BookingFormID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.GroupBooking",
                c => new
                    {
                        GroupBookingID = c.Int(nullable: false, identity: true),
                        GroupOrganiser = c.String(),
                        PartyName = c.String(),
                        GroupRef = c.String(),
                        PlayerEmail = c.String(),
                        PlayerMobile = c.String(),
                        PlayerAmountToPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingFormID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupBookingID)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .Index(t => t.BookingFormID);
            
            CreateTable(
                "dbo.OfficeRef",
                c => new
                    {
                        OfficeRefID = c.Int(nullable: false, identity: true),
                        OfficeRefPeople = c.String(),
                        BookingForm_BookingFormID = c.Int(),
                    })
                .PrimaryKey(t => t.OfficeRefID)
                .ForeignKey("dbo.BookingForm", t => t.BookingForm_BookingFormID)
                .Index(t => t.BookingForm_BookingFormID);
            
            CreateTable(
                "dbo.BookingStatus",
                c => new
                    {
                        BookingStatusID = c.Int(nullable: false, identity: true),
                        BookingStatusText = c.String(),
                    })
                .PrimaryKey(t => t.BookingStatusID);
            
            CreateTable(
                "dbo.Purpose",
                c => new
                    {
                        PurposeID = c.Int(nullable: false, identity: true),
                        PurposeOfEvent = c.String(),
                    })
                .PrimaryKey(t => t.PurposeID);
            
            CreateTable(
                "dbo.Source",
                c => new
                    {
                        SourceID = c.Int(nullable: false, identity: true),
                        SourceName = c.String(),
                    })
                .PrimaryKey(t => t.SourceID);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                    })
                .PrimaryKey(t => t.VenueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeRef", "BookingForm_BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.GroupBooking", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.EventParent", "BookingForm_BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.EventRecord", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventRecord", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.Event", "EventParentID", "dbo.EventParent");
            DropIndex("dbo.OfficeRef", new[] { "BookingForm_BookingFormID" });
            DropIndex("dbo.GroupBooking", new[] { "BookingFormID" });
            DropIndex("dbo.EventRecord", new[] { "EventID" });
            DropIndex("dbo.EventRecord", new[] { "BookingFormID" });
            DropIndex("dbo.Event", new[] { "EventParentID" });
            DropIndex("dbo.EventParent", new[] { "BookingForm_BookingFormID" });
            DropTable("dbo.Venue");
            DropTable("dbo.Source");
            DropTable("dbo.Purpose");
            DropTable("dbo.BookingStatus");
            DropTable("dbo.OfficeRef");
            DropTable("dbo.GroupBooking");
            DropTable("dbo.EventRecord");
            DropTable("dbo.Event");
            DropTable("dbo.EventParent");
            DropTable("dbo.BookingForm");
        }
    }
}
