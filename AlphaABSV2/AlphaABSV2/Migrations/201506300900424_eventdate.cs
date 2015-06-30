namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "DateOfEvent", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingForm", "DateOfEvent");
        }
    }
}
