namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newRegistrationFieldsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "RollerBlindType", c => c.Int());
            AddColumn("dbo.Listing", "HasHousingPermission", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listing", "HasHousingPermission");
            DropColumn("dbo.Listing", "RollerBlindType");
        }
    }
}
