namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailManagerCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailCategories",
                c => new
                    {
                        EmailCategoriesID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.EmailCategoriesID);
            
            AddColumn("dbo.EmailTemplates", "EmailCategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.EmailTemplates", "MailChimp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailTemplates", "MailChimp");
            DropColumn("dbo.EmailTemplates", "EmailCategoryID");
            DropTable("dbo.EmailCategories");
        }
    }
}
