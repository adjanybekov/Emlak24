namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class BalconyTerraceAreaDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Listing", "BalconyTerraceArea");
        }

        public override void Down()
        {
            AddColumn("dbo.Listing", "BalconyTerraceArea", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
