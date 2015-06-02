namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookformchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficeRef", "BookingForm_BookingFormID", "dbo.BookingForm");
            DropIndex("dbo.OfficeRef", new[] { "BookingForm_BookingFormID" });
            AddColumn("dbo.BookingForm", "OfficeRef", c => c.Int(nullable: false));
            DropColumn("dbo.OfficeRef", "BookingForm_BookingFormID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OfficeRef", "BookingForm_BookingFormID", c => c.Int());
            DropColumn("dbo.BookingForm", "OfficeRef");
            CreateIndex("dbo.OfficeRef", "BookingForm_BookingFormID");
            AddForeignKey("dbo.OfficeRef", "BookingForm_BookingFormID", "dbo.BookingForm", "BookingFormID");
        }
    }
}
