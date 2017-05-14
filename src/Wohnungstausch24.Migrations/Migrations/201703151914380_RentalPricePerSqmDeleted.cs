namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalPricePerSqmDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From");
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To");
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max");
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_From1", newName: "RentalPricePerSqm_From");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_To1", newName: "RentalPricePerSqm_To");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_Max1", newName: "RentalPricePerSqm_Max");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_Min1", newName: "RentalPricePerSqm_Min");
        }
        
        public override void Down()
        {
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_Min", newName: "RentalPricePerSqm_Min1");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_Max", newName: "RentalPricePerSqm_Max1");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_To", newName: "RentalPricePerSqm_To1");
            RenameColumn(table: "searchProfile.SearchProfileListing", name: "RentalPricePerSqm_From", newName: "RentalPricePerSqm_From1");
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
