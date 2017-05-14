namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyOptionalFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agency", "About", c => c.String(maxLength: 3000));
            AlterColumn("dbo.Agency", "YearOfEstablishment", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agency", "YearOfEstablishment", c => c.Int(nullable: false));
            AlterColumn("dbo.Agency", "About", c => c.String(nullable: false, maxLength: 3000));
        }
    }
}
