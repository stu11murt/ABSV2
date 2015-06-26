namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccommRecord", "AccommParentID", "dbo.AccommParent");
            DropForeignKey("dbo.AccommRecord", "BookingFormID", "dbo.BookingForm");
            DropIndex("dbo.AccommRecord", new[] { "AccommParentID" });
            DropIndex("dbo.AccommRecord", new[] { "BookingFormID" });
            AddColumn("dbo.BookingForm", "CheckInDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingForm", "CheckOutDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingForm", "HotelBookingInfo", c => c.String());
            AddColumn("dbo.BookingForm", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DateHotelDepositDue", c => c.DateTime());
            AddColumn("dbo.BookingForm", "FinalHotelBalance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DateToPayHotel", c => c.DateTime());
            AddColumn("dbo.BookingForm", "HotelContact", c => c.String());
            DropTable("dbo.AccommRecord");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccommRecord",
                c => new
                    {
                        AccommRecordID = c.Int(nullable: false, identity: true),
                        AccommParentID = c.Int(nullable: false),
                        BookingFormID = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        HotelBookingInfo = c.String(),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateHotelDepositDue = c.DateTime(),
                        FinalHotelBalance = c.Decimal(precision: 18, scale: 2),
                        DateToPayHotel = c.DateTime(),
                        HotelContact = c.String(),
                    })
                .PrimaryKey(t => t.AccommRecordID);
            
            DropColumn("dbo.BookingForm", "HotelContact");
            DropColumn("dbo.BookingForm", "DateToPayHotel");
            DropColumn("dbo.BookingForm", "FinalHotelBalance");
            DropColumn("dbo.BookingForm", "DateHotelDepositDue");
            DropColumn("dbo.BookingForm", "TotalCost");
            DropColumn("dbo.BookingForm", "HotelBookingInfo");
            DropColumn("dbo.BookingForm", "CheckOutDate");
            DropColumn("dbo.BookingForm", "CheckInDate");
            CreateIndex("dbo.AccommRecord", "BookingFormID");
            CreateIndex("dbo.AccommRecord", "AccommParentID");
            AddForeignKey("dbo.AccommRecord", "BookingFormID", "dbo.BookingForm", "BookingFormID", cascadeDelete: true);
            AddForeignKey("dbo.AccommRecord", "AccommParentID", "dbo.AccommParent", "AccommParentID", cascadeDelete: true);
        }
    }
}
