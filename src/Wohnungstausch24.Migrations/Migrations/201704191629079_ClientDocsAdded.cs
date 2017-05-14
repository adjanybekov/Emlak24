namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientDocsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "searchProfile.ClientDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        DocumentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Wt24File", t => t.FileId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("searchProfile.ClientDocument", "FileId", "dbo.Wt24File");
            DropForeignKey("searchProfile.ClientDocument", "ClientId", "searchProfile.Client");
            DropIndex("searchProfile.ClientDocument", new[] { "FileId" });
            DropIndex("searchProfile.ClientDocument", new[] { "ClientId" });
            DropTable("searchProfile.ClientDocument");
        }
    }
}
