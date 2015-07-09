namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class endtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventRecord", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventRecord", "EndTime");
        }
    }
}
