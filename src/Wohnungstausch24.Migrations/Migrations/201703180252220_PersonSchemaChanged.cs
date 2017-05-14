namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonSchemaChanged : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Person", newSchema: "searchProfile");
        }
        
        public override void Down()
        {
            MoveTable(name: "searchProfile.Person", newSchema: "dbo");
        }
    }
}
