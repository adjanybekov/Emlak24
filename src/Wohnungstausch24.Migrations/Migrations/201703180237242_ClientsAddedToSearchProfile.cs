namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsAddedToSearchProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Person", "ParentId", "dbo.AspNetUsers");
            DropIndex("dbo.Person", new[] { "ParentId" });
            CreateTable(
                "searchProfile.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchProfileId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        About = c.String(nullable: false, maxLength: 1000),
                        HasPets = c.Boolean(nullable: false),
                        IsSmoker = c.Boolean(nullable: false),
                        Headline = c.String(nullable: false),
                        PetSpecies = c.String(),
                        Age = c.Int(),
                        Income = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Profession = c.String(maxLength: 100),
                        Gender = c.Int(),
                        EmploymentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SearchProfileId)
                .Index(t => t.SearchProfileId);
            
            AddColumn("dbo.Person", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "ClientId");
            AddForeignKey("dbo.Person", "ClientId", "searchProfile.Client", "Id");
            DropColumn("dbo.AspNetUsers", "HasPets");
            DropColumn("dbo.AspNetUsers", "IsSmoker");
            DropColumn("dbo.AspNetUsers", "AboutMe");
            DropColumn("dbo.AspNetUsers", "Headline");
            DropColumn("dbo.AspNetUsers", "PetSpecies");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "EmploymentStatus");
            DropColumn("dbo.AspNetUsers", "Income");
            DropColumn("dbo.AspNetUsers", "Profession");
            DropColumn("dbo.Person", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "ParentId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Profession", c => c.String());
            AddColumn("dbo.AspNetUsers", "Income", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "EmploymentStatus", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PetSpecies", c => c.String());
            AddColumn("dbo.AspNetUsers", "Headline", c => c.String());
            AddColumn("dbo.AspNetUsers", "AboutMe", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsSmoker", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "HasPets", c => c.Boolean(nullable: false));
            DropForeignKey("searchProfile.Client", "SearchProfileId", "searchProfile.SearchProfileListing");
            DropForeignKey("dbo.Person", "ClientId", "searchProfile.Client");
            DropIndex("dbo.Person", new[] { "ClientId" });
            DropIndex("searchProfile.Client", new[] { "SearchProfileId" });
            DropColumn("dbo.Person", "ClientId");
            DropTable("searchProfile.Client");
            CreateIndex("dbo.Person", "ParentId");
            AddForeignKey("dbo.Person", "ParentId", "dbo.AspNetUsers", "Id");
        }
    }
}
