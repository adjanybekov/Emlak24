namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class IsWillingToPayAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "IsWillingToPay", c => c.Boolean());
        }

        public override void Down()
        {
            DropColumn("dbo.Listing", "IsWillingToPay");
        }
    }
}
