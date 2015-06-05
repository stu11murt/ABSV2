namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailTel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "Email", c => c.String());
            AddColumn("dbo.BookingForm", "TelNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingForm", "TelNo");
            DropColumn("dbo.BookingForm", "Email");
        }
    }
}
