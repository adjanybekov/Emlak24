namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyNameRemovedFromAppUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
        }
    }
}
