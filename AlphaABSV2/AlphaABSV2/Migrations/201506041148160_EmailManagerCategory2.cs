namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailManagerCategory2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketingDatabase", "MailChimpSubscribed", c => c.Boolean(nullable: false));
            DropColumn("dbo.MarketingDatabase", "MailChimp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MarketingDatabase", "MailChimp", c => c.Boolean(nullable: false));
            DropColumn("dbo.MarketingDatabase", "MailChimpSubscribed");
        }
    }
}
