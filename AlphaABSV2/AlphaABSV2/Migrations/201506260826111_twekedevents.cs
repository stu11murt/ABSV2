namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twekedevents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventRecord", "EventNumber", c => c.Int());
            AlterColumn("dbo.EventRecord", "StartTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventRecord", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EventRecord", "EventNumber", c => c.Int(nullable: false));
        }
    }
}
