namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailManagerContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailManager", "EmailTemplateContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailManager", "EmailTemplateContent");
        }
    }
}
