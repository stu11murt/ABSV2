namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ABSSettings",
                c => new
                    {
                        ABSSettingsID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyRef = c.Int(nullable: false),
                        Test = c.String(),
                    })
                .PrimaryKey(t => t.ABSSettingsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ABSSettings");
        }
    }
}
