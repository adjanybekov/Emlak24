namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenantFieldsAddedToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EmploymentStatus", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Income", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "Profession", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Profession");
            DropColumn("dbo.AspNetUsers", "Income");
            DropColumn("dbo.AspNetUsers", "EmploymentStatus");
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
