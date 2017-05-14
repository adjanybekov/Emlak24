namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClientName : DbMigration
    {
        public override void Up()
        {
            AddColumn("searchProfile.Client", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("searchProfile.Client", "FirstName");
            DropColumn("searchProfile.Client", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("searchProfile.Client", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("searchProfile.Client", "FirstName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("searchProfile.Client", "Name");
        }
    }
}
