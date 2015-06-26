namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelTweak2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "HotelTotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "HotelDateDepositDue", c => c.DateTime());
            AddColumn("dbo.BookingForm", "HotelFinalBalance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "HotelDateToPay", c => c.DateTime());
            DropColumn("dbo.BookingForm", "TotalCost");
            DropColumn("dbo.BookingForm", "DateHotelDepositDue");
            DropColumn("dbo.BookingForm", "FinalHotelBalance");
            DropColumn("dbo.BookingForm", "DateToPayHotel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingForm", "DateToPayHotel", c => c.DateTime());
            AddColumn("dbo.BookingForm", "FinalHotelBalance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DateHotelDepositDue", c => c.DateTime());
            AddColumn("dbo.BookingForm", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BookingForm", "HotelDateToPay");
            DropColumn("dbo.BookingForm", "HotelFinalBalance");
            DropColumn("dbo.BookingForm", "HotelDateDepositDue");
            DropColumn("dbo.BookingForm", "HotelTotalCost");
        }
    }
}
