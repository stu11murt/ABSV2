namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelfieldsnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingForm", "HotelID", c => c.Int());
            AlterColumn("dbo.BookingForm", "CheckInDate", c => c.DateTime());
            AlterColumn("dbo.BookingForm", "CheckOutDate", c => c.DateTime());
            AlterColumn("dbo.BookingForm", "HotelTotalCost", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookingForm", "HotelTotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BookingForm", "CheckOutDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingForm", "CheckInDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookingForm", "HotelID", c => c.Int(nullable: false));
        }
    }
}
