namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RefactoringSomeFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "HasGuestToilet", c => c.Boolean());
            AddColumn("dbo.Listing", "CurrentColdRent", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Listing", "RentPrice");
            DropColumn("dbo.Listing", "RentOnDemand");
            DropColumn("dbo.Listing", "PurchasePrice");
            DropColumn("dbo.Listing", "ColdRent");
            DropColumn("dbo.Listing", "ActualRent");
        }

        public override void Down()
        {
            AddColumn("dbo.Listing", "ActualRent", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Listing", "ColdRent", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Listing", "PurchasePrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Listing", "RentOnDemand", c => c.Boolean());
            AddColumn("dbo.Listing", "RentPrice", c => c.Int());
            DropColumn("dbo.Listing", "CurrentColdRent");
            DropColumn("dbo.Listing", "HasGuestToilet");
        }
    }
}
