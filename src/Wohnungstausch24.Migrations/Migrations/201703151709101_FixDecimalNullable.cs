namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FixDecimalNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_From", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_To", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_Max", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_Min", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_From", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_To", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_Max", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_Min", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_From", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_To", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_Max", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_Min", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_From", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_To", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_Max", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_Min", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max1", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min1", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min1", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max1", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To1", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From1", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Min", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_Max", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_To", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "RentalPricePerSqm_From", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_Min", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_Max", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_To", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "ResidentialArea_From", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_Min", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_Max", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_To", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "GardenArea_From", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_Min", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_Max", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_To", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "BalconyTerraceArea_From", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_Min", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_Max", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_To", c => c.Int());
            AlterColumn("searchProfile.SearchProfileListing", "PriceRange_From", c => c.Int());
        }
    }
}
