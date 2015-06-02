namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staffmanager2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNum = c.String(),
                        Email = c.String(),
                        NINumber = c.String(),
                    })
                .PrimaryKey(t => t.StaffID);
            
            CreateTable(
                "dbo.StaffSkills",
                c => new
                    {
                        StaffSkillsID = c.Int(nullable: false, identity: true),
                        EventParent_EventParentID = c.Int(),
                        Staff_StaffID = c.Int(),
                    })
                .PrimaryKey(t => t.StaffSkillsID)
                .ForeignKey("dbo.EventParent", t => t.EventParent_EventParentID)
                .ForeignKey("dbo.Staff", t => t.Staff_StaffID)
                .Index(t => t.EventParent_EventParentID)
                .Index(t => t.Staff_StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffSkills", "Staff_StaffID", "dbo.Staff");
            DropForeignKey("dbo.StaffSkills", "EventParent_EventParentID", "dbo.EventParent");
            DropIndex("dbo.StaffSkills", new[] { "Staff_StaffID" });
            DropIndex("dbo.StaffSkills", new[] { "EventParent_EventParentID" });
            DropTable("dbo.StaffSkills");
            DropTable("dbo.Staff");
        }
    }
}
