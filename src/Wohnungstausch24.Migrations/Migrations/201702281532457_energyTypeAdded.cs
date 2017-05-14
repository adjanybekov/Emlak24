namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class energyTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "EnergyType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listing", "EnergyType");
        }
    }
}
