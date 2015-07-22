namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailcounter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailManager", "EmailCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailManager", "EmailCount");
        }
    }
}
