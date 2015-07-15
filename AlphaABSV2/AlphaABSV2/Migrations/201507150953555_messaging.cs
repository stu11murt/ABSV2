namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messaging : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messaging",
                c => new
                    {
                        MessagingID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        Message = c.String(),
                        Read = c.Boolean(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessagingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messaging");
        }
    }
}
