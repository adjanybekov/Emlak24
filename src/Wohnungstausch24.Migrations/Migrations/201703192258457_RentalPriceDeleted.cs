namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalPriceDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From");
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To");
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max");
            DropColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min");
        }
        
        public override void Down()
        {
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
