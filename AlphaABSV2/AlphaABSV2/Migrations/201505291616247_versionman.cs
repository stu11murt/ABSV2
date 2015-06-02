namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionman : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VersionManager",
                c => new
                    {
                        VersionManagerID = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(),
                        BuildingNumberName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Town = c.String(),
                        Country = c.String(),
                        PostCode = c.String(),
                        VatNum = c.String(),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.VersionManagerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VersionManager");
        }
    }
}
