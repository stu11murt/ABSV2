namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namesplit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "GroupOrganiserFName", c => c.String());
            AddColumn("dbo.BookingForm", "GroupOrganiserLName", c => c.String());
            AddColumn("dbo.GroupBooking", "FirstName", c => c.String());
            AddColumn("dbo.GroupBooking", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupBooking", "LastName");
            DropColumn("dbo.GroupBooking", "FirstName");
            DropColumn("dbo.BookingForm", "GroupOrganiserLName");
            DropColumn("dbo.BookingForm", "GroupOrganiserFName");
        }
    }
}
