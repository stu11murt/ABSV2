namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventdate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookingForm", "DateOfBooking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingForm", "DateOfBooking", c => c.DateTime(nullable: false));
        }
    }
}
