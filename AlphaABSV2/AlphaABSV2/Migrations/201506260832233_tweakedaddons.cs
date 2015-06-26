namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweakedaddons : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddOnRecord", "AddOnNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddOnRecord", "AddOnNumber", c => c.Int(nullable: false));
        }
    }
}
