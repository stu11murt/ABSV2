namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailManager1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        EmailTemplatesID = c.Int(nullable: false, identity: true),
                        TemplateTitle = c.String(),
                        TemplateContent = c.String(),
                        EmailManager_EmailManagerID = c.Int(),
                    })
                .PrimaryKey(t => t.EmailTemplatesID)
                .ForeignKey("dbo.EmailManager", t => t.EmailManager_EmailManagerID)
                .Index(t => t.EmailManager_EmailManagerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailTemplates", "EmailManager_EmailManagerID", "dbo.EmailManager");
            DropIndex("dbo.EmailTemplates", new[] { "EmailManager_EmailManagerID" });
            DropTable("dbo.EmailTemplates");
        }
    }
}
