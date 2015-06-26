namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelTweak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "HotelID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingForm", "HotelID");
        }
    }
}
