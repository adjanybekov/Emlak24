namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFamilyMembersAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentStatus = c.Int(),
                        Profession = c.String(),
                        Income = c.Decimal(precision: 18, scale: 2),
                        Gender = c.Int(),
                        Age = c.Int(),
                        ParentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.UserFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        FileId = c.Int(),
                        TenantFileType = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wt24File", t => t.FileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FileId);
            
            AddColumn("dbo.AspNetUsers", "HasPets", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsSmoker", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AboutMe", c => c.String());
            AddColumn("dbo.AspNetUsers", "Headline", c => c.String());
            AddColumn("dbo.AspNetUsers", "PetSpecies", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFile", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFile", "FileId", "dbo.Wt24File");
            DropForeignKey("dbo.Person", "ParentId", "dbo.AspNetUsers");
            DropIndex("dbo.UserFile", new[] { "FileId" });
            DropIndex("dbo.UserFile", new[] { "UserId" });
            DropIndex("dbo.Person", new[] { "ParentId" });
            DropColumn("dbo.AspNetUsers", "PetSpecies");
            DropColumn("dbo.AspNetUsers", "Headline");
            DropColumn("dbo.AspNetUsers", "AboutMe");
            DropColumn("dbo.AspNetUsers", "IsSmoker");
            DropColumn("dbo.AspNetUsers", "HasPets");
            DropTable("dbo.UserFile");
            DropTable("dbo.Person");
        }
    }
}
