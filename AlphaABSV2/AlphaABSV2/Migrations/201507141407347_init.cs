namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccommParent",
                c => new
                    {
                        AccommParentID = c.Int(nullable: false, identity: true),
                        AccommName = c.String(),
                        StreetNumber = c.String(),
                        SteetName = c.String(),
                        TownCity = c.String(),
                        PostCode = c.String(),
                        CheckInTime = c.DateTime(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccommParentID);
            
            CreateTable(
                "dbo.AddOnParent",
                c => new
                    {
                        AddOnParentID = c.Int(nullable: false, identity: true),
                        AddOnCategory = c.String(),
                        BookingForm_BookingFormID = c.Int(),
                    })
                .PrimaryKey(t => t.AddOnParentID)
                .ForeignKey("dbo.BookingForm", t => t.BookingForm_BookingFormID)
                .Index(t => t.BookingForm_BookingFormID);
            
            CreateTable(
                "dbo.AddOns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddOnParentID = c.Int(nullable: false),
                        AddOnName = c.String(),
                        AddOnType = c.Int(),
                        AddOnCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FreeWith = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddOnParent", t => t.AddOnParentID, cascadeDelete: true)
                .Index(t => t.AddOnParentID);
            
            CreateTable(
                "dbo.AddOnRecord",
                c => new
                    {
                        AddOnRecordID = c.Int(nullable: false, identity: true),
                        AddOnsID = c.Int(nullable: false),
                        BookingFormID = c.Int(nullable: false),
                        AddOnNumber = c.Int(),
                    })
                .PrimaryKey(t => t.AddOnRecordID)
                .ForeignKey("dbo.AddOns", t => t.AddOnsID, cascadeDelete: true)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .Index(t => t.AddOnsID)
                .Index(t => t.BookingFormID);
            
            CreateTable(
                "dbo.BookingForm",
                c => new
                    {
                        BookingFormID = c.Int(nullable: false, identity: true),
                        BookingRef = c.String(),
                        OfficeRef = c.Int(nullable: false),
                        DateOfEvent = c.DateTime(nullable: false),
                        Email = c.String(),
                        TelNo = c.String(),
                        Source = c.Int(nullable: false),
                        Agent = c.Int(nullable: false),
                        VenueID = c.Int(nullable: false),
                        Purpose = c.Int(nullable: false),
                        GroupOrganiserFName = c.String(),
                        GroupOrganiserLName = c.String(),
                        GroupOrganiser = c.String(),
                        HouseNumber = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
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
                        Created = c.DateTime(nullable: false),
                        HotelID = c.Int(),
                        CheckInDate = c.DateTime(),
                        CheckOutDate = c.DateTime(),
                        HotelBookingInfo = c.String(),
                        HotelTotalCost = c.Decimal(precision: 18, scale: 2),
                        HotelDateDepositDue = c.DateTime(),
                        HotelFinalBalance = c.Decimal(precision: 18, scale: 2),
                        HotelDateToPay = c.DateTime(),
                        HotelContact = c.String(),
                        DepositDueOnDate = c.DateTime(nullable: false),
                        EventCostPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepositPerPerson = c.Decimal(precision: 18, scale: 2),
                        BalanceRemaining = c.Decimal(precision: 18, scale: 2),
                        BalanceRemainingPP = c.Decimal(precision: 18, scale: 2),
                        DepositTotalTaken = c.Decimal(precision: 18, scale: 2),
                        AmountTaken = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupSpendOnDay = c.Decimal(precision: 18, scale: 2),
                        DiscountPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        EventDeposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventCost = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        EventID = c.Int(nullable: false),
                        BookingFormID = c.Int(nullable: false),
                        EventNumber = c.Int(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.EventRecordID)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.BookingFormID);
            
            CreateTable(
                "dbo.StaffEventRota",
                c => new
                    {
                        StaffEventRotaID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        EventRecordID = c.Int(nullable: false),
                        StaffNotes = c.String(),
                    })
                .PrimaryKey(t => t.StaffEventRotaID)
                .ForeignKey("dbo.EventRecord", t => t.EventRecordID, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.StaffID)
                .Index(t => t.EventRecordID);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNum = c.String(),
                        Email = c.String(),
                        NINumber = c.String(),
                        DateEmployed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID);
            
            CreateTable(
                "dbo.StaffSkills",
                c => new
                    {
                        StaffSkillsID = c.Int(nullable: false, identity: true),
                        EventParent_EventParentID = c.Int(),
                        Staff_StaffID = c.Int(),
                    })
                .PrimaryKey(t => t.StaffSkillsID)
                .ForeignKey("dbo.EventParent", t => t.EventParent_EventParentID)
                .ForeignKey("dbo.Staff", t => t.Staff_StaffID)
                .Index(t => t.EventParent_EventParentID)
                .Index(t => t.Staff_StaffID);
            
            CreateTable(
                "dbo.GroupBooking",
                c => new
                    {
                        GroupBookingID = c.Int(nullable: false, identity: true),
                        GroupOrganiser = c.String(),
                        PartyName = c.String(),
                        GroupRef = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PlayerEmail = c.String(),
                        PlayerMobile = c.String(),
                        PlayerAmountToPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingFormID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupBookingID)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .Index(t => t.BookingFormID);
            
            CreateTable(
                "dbo.Agent",
                c => new
                    {
                        AgentID = c.Int(nullable: false, identity: true),
                        AgentName = c.String(),
                        AgentCode = c.String(),
                        MainContactNumber = c.String(),
                        Email = c.String(),
                        HouseNumber = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        Active = c.Boolean(nullable: false),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondContactNumber = c.String(),
                        Notes = c.String(),
                        PaymentNotes = c.String(),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.AgentID);
            
            CreateTable(
                "dbo.BookingStatus",
                c => new
                    {
                        BookingStatusID = c.Int(nullable: false, identity: true),
                        BookingStatusText = c.String(),
                    })
                .PrimaryKey(t => t.BookingStatusID);
            
            CreateTable(
                "dbo.EmailCategories",
                c => new
                    {
                        EmailCategoriesID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.EmailCategoriesID);
            
            CreateTable(
                "dbo.EmailManager",
                c => new
                    {
                        EmailManagerID = c.Int(nullable: false, identity: true),
                        EmailTemplateContent = c.String(),
                    })
                .PrimaryKey(t => t.EmailManagerID);
            
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        EmailTemplatesID = c.Int(nullable: false, identity: true),
                        TemplateTitle = c.String(),
                        TemplateContent = c.String(),
                        EmailCategoryID = c.Int(nullable: false),
                        MailChimp = c.Boolean(nullable: false),
                        EmailManager_EmailManagerID = c.Int(),
                    })
                .PrimaryKey(t => t.EmailTemplatesID)
                .ForeignKey("dbo.EmailManager", t => t.EmailManager_EmailManagerID)
                .Index(t => t.EmailManager_EmailManagerID);
            
            CreateTable(
                "dbo.Financial",
                c => new
                    {
                        FinancialID = c.Int(nullable: false, identity: true),
                        DepositDueOnDate = c.DateTime(nullable: false),
                        EventCostPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepositPerPerson = c.Decimal(precision: 18, scale: 2),
                        BalanceRemaining = c.Decimal(precision: 18, scale: 2),
                        BalanceRemainingPP = c.Decimal(precision: 18, scale: 2),
                        DepositTotalTaken = c.Decimal(precision: 18, scale: 2),
                        AmountTaken = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupSpendOnDay = c.Decimal(precision: 18, scale: 2),
                        DiscountPerPerson = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingFormID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinancialID)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .Index(t => t.BookingFormID);
            
            CreateTable(
                "dbo.MarketingDatabase",
                c => new
                    {
                        MarketingDatabaseID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNum = c.String(),
                        Email = c.String(),
                        Created = c.DateTime(nullable: false),
                        MailChimpSubscribed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MarketingDatabaseID);
            
            CreateTable(
                "dbo.OfficeRef",
                c => new
                    {
                        OfficeRefID = c.Int(nullable: false, identity: true),
                        OfficeRefPeople = c.String(),
                    })
                .PrimaryKey(t => t.OfficeRefID);
            
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
            
            CreateTable(
                "dbo.VersionManager",
                c => new
                    {
                        VersionManagerID = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(),
                        BuildingNumberName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Town = c.String(),
                        Country = c.String(),
                        PostCode = c.String(),
                        VatNum = c.String(),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.VersionManagerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Financial", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.EmailTemplates", "EmailManager_EmailManagerID", "dbo.EmailManager");
            DropForeignKey("dbo.GroupBooking", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.EventParent", "BookingForm_BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.StaffSkills", "Staff_StaffID", "dbo.Staff");
            DropForeignKey("dbo.StaffSkills", "EventParent_EventParentID", "dbo.EventParent");
            DropForeignKey("dbo.StaffEventRota", "StaffID", "dbo.Staff");
            DropForeignKey("dbo.StaffEventRota", "EventRecordID", "dbo.EventRecord");
            DropForeignKey("dbo.EventRecord", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventRecord", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.Event", "EventParentID", "dbo.EventParent");
            DropForeignKey("dbo.AddOnRecord", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.AddOnParent", "BookingForm_BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.AddOnRecord", "AddOnsID", "dbo.AddOns");
            DropForeignKey("dbo.AddOns", "AddOnParentID", "dbo.AddOnParent");
            DropIndex("dbo.Financial", new[] { "BookingFormID" });
            DropIndex("dbo.EmailTemplates", new[] { "EmailManager_EmailManagerID" });
            DropIndex("dbo.GroupBooking", new[] { "BookingFormID" });
            DropIndex("dbo.StaffSkills", new[] { "Staff_StaffID" });
            DropIndex("dbo.StaffSkills", new[] { "EventParent_EventParentID" });
            DropIndex("dbo.StaffEventRota", new[] { "EventRecordID" });
            DropIndex("dbo.StaffEventRota", new[] { "StaffID" });
            DropIndex("dbo.EventRecord", new[] { "BookingFormID" });
            DropIndex("dbo.EventRecord", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "EventParentID" });
            DropIndex("dbo.EventParent", new[] { "BookingForm_BookingFormID" });
            DropIndex("dbo.AddOnRecord", new[] { "BookingFormID" });
            DropIndex("dbo.AddOnRecord", new[] { "AddOnsID" });
            DropIndex("dbo.AddOns", new[] { "AddOnParentID" });
            DropIndex("dbo.AddOnParent", new[] { "BookingForm_BookingFormID" });
            DropTable("dbo.VersionManager");
            DropTable("dbo.Venue");
            DropTable("dbo.Source");
            DropTable("dbo.Purpose");
            DropTable("dbo.OfficeRef");
            DropTable("dbo.MarketingDatabase");
            DropTable("dbo.Financial");
            DropTable("dbo.EmailTemplates");
            DropTable("dbo.EmailManager");
            DropTable("dbo.EmailCategories");
            DropTable("dbo.BookingStatus");
            DropTable("dbo.Agent");
            DropTable("dbo.GroupBooking");
            DropTable("dbo.StaffSkills");
            DropTable("dbo.Staff");
            DropTable("dbo.StaffEventRota");
            DropTable("dbo.EventRecord");
            DropTable("dbo.Event");
            DropTable("dbo.EventParent");
            DropTable("dbo.BookingForm");
            DropTable("dbo.AddOnRecord");
            DropTable("dbo.AddOns");
            DropTable("dbo.AddOnParent");
            DropTable("dbo.AccommParent");
        }
    }
}
