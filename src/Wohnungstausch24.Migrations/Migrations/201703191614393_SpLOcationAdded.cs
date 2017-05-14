namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpLOcationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "searchProfile.SpLocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpListingId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpListingId)
                .Index(t => t.SpListingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("searchProfile.SpLocation", "SpListingId", "searchProfile.SearchProfileListing");
            DropIndex("searchProfile.SpLocation", new[] { "SpListingId" });
            DropTable("searchProfile.SpLocation");
        }
    }
}
