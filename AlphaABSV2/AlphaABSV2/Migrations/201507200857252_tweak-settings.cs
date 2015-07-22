namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweaksettings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ABSSettings", "CompanyRef", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ABSSettings", "CompanyRef", c => c.Int(nullable: false));
        }
    }
}