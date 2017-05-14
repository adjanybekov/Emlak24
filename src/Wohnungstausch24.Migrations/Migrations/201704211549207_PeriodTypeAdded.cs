namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PeriodTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "PeriodType", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Listing", "PeriodType");
        }
    }
}
