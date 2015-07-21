namespace AlphaABSV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onlinepayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OnlinePayment",
                c => new
                    {
                        OnlinePaymentID = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.String(),
                        NameOnCard = c.String(),
                        ValidFrom = c.String(),
                        ExpiryDate = c.String(),
                        CCV2 = c.String(),
                        Created = c.DateTime(nullable: false),
                        PayeeEmail = c.String(),
                        BookingFormID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OnlinePaymentID)
                .ForeignKey("dbo.BookingForm", t => t.BookingFormID, cascadeDelete: true)
                .Index(t => t.BookingFormID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnlinePayment", "BookingFormID", "dbo.BookingForm");
            DropIndex("dbo.OnlinePayment", new[] { "BookingFormID" });
            DropTable("dbo.OnlinePayment");
        }
    }
}
