namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class combinefinancewithbooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingForm", "DepositDueOnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookingForm", "EventCostPerPerson", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DepositPerPerson", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "BalanceRemaining", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "BalanceRemainingPP", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DepositTotalTaken", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "AmountTaken", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "GroupSpendOnDay", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DiscountPerPerson", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BookingForm", "DiscountTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookingForm", "DiscountTotal");
            DropColumn("dbo.BookingForm", "DiscountPerPerson");
            DropColumn("dbo.BookingForm", "GroupSpendOnDay");
            DropColumn("dbo.BookingForm", "AmountTaken");
            DropColumn("dbo.BookingForm", "DepositTotalTaken");
            DropColumn("dbo.BookingForm", "BalanceRemainingPP");
            DropColumn("dbo.BookingForm", "BalanceRemaining");
            DropColumn("dbo.BookingForm", "DepositPerPerson");
            DropColumn("dbo.BookingForm", "EventCostPerPerson");
            DropColumn("dbo.BookingForm", "DepositDueOnDate");
        }
    }
}
