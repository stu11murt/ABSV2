namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailLinker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailLinker",
                c => new
                    {
                        EmailLinkerID = c.Int(nullable: false, identity: true),
                        EmailTemplatesID = c.Int(nullable: false),
                        EmailCategoriesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmailLinkerID)
                .ForeignKey("dbo.EmailCategories", t => t.EmailCategoriesID, cascadeDelete: true)
                .ForeignKey("dbo.EmailTemplates", t => t.EmailTemplatesID, cascadeDelete: true)
                .Index(t => t.EmailTemplatesID)
                .Index(t => t.EmailCategoriesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailLinker", "EmailTemplatesID", "dbo.EmailTemplates");
            DropForeignKey("dbo.EmailLinker", "EmailCategoriesID", "dbo.EmailCategories");
            DropIndex("dbo.EmailLinker", new[] { "EmailCategoriesID" });
            DropIndex("dbo.EmailLinker", new[] { "EmailTemplatesID" });
            DropTable("dbo.EmailLinker");
        }
    }
}
