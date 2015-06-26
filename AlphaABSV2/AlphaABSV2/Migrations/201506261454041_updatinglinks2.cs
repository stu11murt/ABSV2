namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatinglinks2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.AccommRecordID)
                .ForeignKey("dbo.AccommParent", t => t.AccommParentID, cascadeDelete: true)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .Index(t => t.AccommParentID)
                .Index(t => t.BookingFormID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccommRecord", "BookingFormID", "dbo.BookingForm");
            DropForeignKey("dbo.AccommRecord", "AccommParentID", "dbo.AccommParent");
            DropIndex("dbo.AccommRecord", new[] { "BookingFormID" });
            DropIndex("dbo.AccommRecord", new[] { "AccommParentID" });
            DropTable("dbo.AccommParent");
            DropTable("dbo.AccommRecord");
        }
    }
}
