namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onlinepaymentAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OnlinePayment", "AmountToPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OnlinePayment", "AmountToPay");
        }
    }
}
