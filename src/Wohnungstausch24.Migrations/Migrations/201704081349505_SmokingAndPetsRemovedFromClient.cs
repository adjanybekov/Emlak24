namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmokingAndPetsRemovedFromClient : DbMigration
    {
        public override void Up()
        {
            DropColumn("searchProfile.Client", "HasPets");
            DropColumn("searchProfile.Client", "IsSmoker");
            DropColumn("searchProfile.Client", "PetSpecies");
        }
        
        public override void Down()
        {
            AddColumn("searchProfile.Client", "PetSpecies", c => c.String());
            AddColumn("searchProfile.Client", "IsSmoker", c => c.Boolean(nullable: false));
            AddColumn("searchProfile.Client", "HasPets", c => c.Boolean(nullable: false));
        }
    }
}
