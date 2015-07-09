namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staffrotas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffEventRota",
                c => new
                    {
                        StaffEventRotaID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        EventRecordID = c.Int(nullable: false),
                        StaffNotes = c.String(),
                    })
                .PrimaryKey(t => t.StaffEventRotaID)
                .ForeignKey("dbo.EventRecord", t => t.EventRecordID, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.StaffID)
                .Index(t => t.EventRecordID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffEventRota", "StaffID", "dbo.Staff");
            DropForeignKey("dbo.StaffEventRota", "EventRecordID", "dbo.EventRecord");
            DropIndex("dbo.StaffEventRota", new[] { "EventRecordID" });
            DropIndex("dbo.StaffEventRota", new[] { "StaffID" });
            DropTable("dbo.StaffEventRota");
        }
    }
}
