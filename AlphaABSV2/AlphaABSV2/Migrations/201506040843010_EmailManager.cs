namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailManager : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailManager",
                c => new
                    {
                        EmailManagerID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.EmailManagerID);
            
            CreateTable(
                "dbo.MarketingDatabase",
                c => new
                    {
                        MarketingDatabaseID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNum = c.String(),
                        Email = c.String(),
                        MailChimp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MarketingDatabaseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MarketingDatabase");
            DropTable("dbo.EmailManager");
        }
    }
}
