namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WantEnergyCertificateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "WantEnergyCertificate", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listing", "WantEnergyCertificate");
        }
    }
}
