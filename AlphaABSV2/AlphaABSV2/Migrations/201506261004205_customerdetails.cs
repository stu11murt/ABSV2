namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "HouseNumber", c => c.String());
            AddColumn("dbo.BookingForm", "Address", c => c.String());
            AddColumn("dbo.BookingForm", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingForm", "PostCode");
            DropColumn("dbo.BookingForm", "Address");
            DropColumn("dbo.BookingForm", "HouseNumber");
        }
    }
}
