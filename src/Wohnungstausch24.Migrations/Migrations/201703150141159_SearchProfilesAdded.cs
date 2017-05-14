namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SearchProfilesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "searchProfile.SearchProfileListing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        AvailableFrom = c.DateTime(),
                        AvailableTo = c.DateTime(),
                        PriceRange_From = c.Int(),
                        PriceRange_To = c.Int(),
                        PriceRange_Max = c.Int(),
                        PriceRange_Min = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        HasSauna = c.Boolean(),
                        HasSwimmingPool = c.Boolean(),
                        HasWashDryingRoom = c.Boolean(),
                        HasWinterGarden = c.Boolean(),
                        IsSharePossible = c.Boolean(),
                        HasChimney = c.Boolean(),
                        HasAirCondition = c.Boolean(),
                        HasElevator = c.Boolean(),
                        HasGardenUtilization = c.Boolean(),
                        IsWheelchairAccessible = c.Boolean(),
                        HasCableSatTv = c.Boolean(),
                        HasGermanTvByAntenna = c.Boolean(),
                        HasBarrierFree = c.Boolean(),
                        HasStorageRoom = c.Boolean(),
                        HasBicycleRoom = c.Boolean(),
                        HasRollerBlind = c.Boolean(),
                        HasGuestToilet = c.Boolean(),
                        HasCableDucts = c.Boolean(),
                        IsSeniorFocused = c.Boolean(),
                        HasApprovalOfAddress = c.Boolean(),
                        IsFurnished = c.Boolean(),
                        HasShower = c.Boolean(),
                        HasBidet = c.Boolean(),
                        HasTub = c.Boolean(),
                        HasWindow = c.Boolean(),
                        HasUrinal = c.Boolean(),
                        HasBalcony = c.Boolean(),
                        IsKitchenFitted = c.Boolean(),
                        IsKitchenOpen = c.Boolean(),
                        IsKitchenPantry = c.Boolean(),
                        BalconyTerraceArea_From = c.Int(),
                        BalconyTerraceArea_To = c.Int(),
                        BalconyTerraceArea_Max = c.Int(),
                        BalconyTerraceArea_Min = c.Int(),
                        GardenArea_From = c.Int(),
                        GardenArea_To = c.Int(),
                        GardenArea_Max = c.Int(),
                        GardenArea_Min = c.Int(),
                        ResidentialArea_From = c.Int(),
                        ResidentialArea_To = c.Int(),
                        ResidentialArea_Max = c.Int(),
                        ResidentialArea_Min = c.Int(),
                        NumberOfBathRooms_From = c.Int(),
                        NumberOfBathRooms_To = c.Int(),
                        NumberOfBathRooms_Max = c.Int(),
                        NumberOfBathRooms_Min = c.Int(),
                        NumberOfLivingRooms_From = c.Int(),
                        NumberOfLivingRooms_To = c.Int(),
                        NumberOfLivingRooms_Max = c.Int(),
                        NumberOfLivingRooms_Min = c.Int(),
                        NumberOfParkingLots_From = c.Int(),
                        NumberOfParkingLots_To = c.Int(),
                        NumberOfParkingLots_Max = c.Int(),
                        NumberOfParkingLots_Min = c.Int(),
                        YearOfConstruction_From = c.Int(),
                        YearOfConstruction_To = c.Int(),
                        YearOfConstruction_Max = c.Int(),
                        YearOfConstruction_Min = c.Int(),
                        IsApartmentTower = c.Boolean(),
                        Level_From = c.Int(),
                        Level_To = c.Int(),
                        Level_Max = c.Int(),
                        Level_Min = c.Int(),
                        NumberOfLevels_From = c.Int(),
                        NumberOfLevels_To = c.Int(),
                        NumberOfLevels_Max = c.Int(),
                        NumberOfLevels_Min = c.Int(),
                        HasHousingPermission = c.Boolean(),
                        IsSmokingAllowed = c.Boolean(),
                        IsPetsAllowed = c.Boolean(),
                        RentalPricePerSqm_From = c.Int(),
                        RentalPricePerSqm_To = c.Int(),
                        RentalPricePerSqm_Max = c.Int(),
                        RentalPricePerSqm_Min = c.Int(),
                        PlotArea_From = c.Decimal(precision: 18, scale: 2),
                        PlotArea_To = c.Decimal(precision: 18, scale: 2),
                        PlotArea_Max = c.Decimal(precision: 18, scale: 2),
                        PlotArea_Min = c.Decimal(precision: 18, scale: 2),
                        PlotArea_Range = c.String(),
                        RentalPricePerSqm_From1 = c.Int(),
                        RentalPricePerSqm_To1 = c.Int(),
                        RentalPricePerSqm_Max1 = c.Int(),
                        RentalPricePerSqm_Min1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "searchProfile.SpGeoDirection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        GeoDirection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpBeaconing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        BeaconingType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpEnergy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        EnergyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpFeatureCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        FeatureCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpFloor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        FloorType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpHeating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        HeatingType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpParkSpace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        ParkSpaceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpRollerBlind",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        RollerBlindType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpSight",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpResidenceId = c.Int(nullable: false),
                        SightType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpResidenceId)
                .Index(t => t.SpResidenceId);
            
            CreateTable(
                "searchProfile.SpFlatType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpFlatId = c.Int(nullable: false),
                        FlatType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpFlatId)
                .Index(t => t.SpFlatId);
            
            CreateTable(
                "searchProfile.SpHouseType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpHouseId = c.Int(nullable: false),
                        HouseType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("searchProfile.SearchProfileListing", t => t.SpHouseId)
                .Index(t => t.SpHouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("searchProfile.SpHouseType", "SpHouseId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpFlatType", "SpFlatId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpSight", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpRollerBlind", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpParkSpace", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpHeating", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpFloor", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpFeatureCategory", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpEnergy", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpBeaconing", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SpGeoDirection", "SpResidenceId", "searchProfile.SearchProfileListing");
            DropForeignKey("searchProfile.SearchProfileListing", "UserId", "dbo.AspNetUsers");
            DropIndex("searchProfile.SpHouseType", new[] { "SpHouseId" });
            DropIndex("searchProfile.SpFlatType", new[] { "SpFlatId" });
            DropIndex("searchProfile.SpSight", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpRollerBlind", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpParkSpace", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpHeating", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpFloor", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpFeatureCategory", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpEnergy", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpBeaconing", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SpGeoDirection", new[] { "SpResidenceId" });
            DropIndex("searchProfile.SearchProfileListing", new[] { "UserId" });
            DropTable("searchProfile.SpHouseType");
            DropTable("searchProfile.SpFlatType");
            DropTable("searchProfile.SpSight");
            DropTable("searchProfile.SpRollerBlind");
            DropTable("searchProfile.SpParkSpace");
            DropTable("searchProfile.SpHeating");
            DropTable("searchProfile.SpFloor");
            DropTable("searchProfile.SpFeatureCategory");
            DropTable("searchProfile.SpEnergy");
            DropTable("searchProfile.SpBeaconing");
            DropTable("searchProfile.SpGeoDirection");
            DropTable("searchProfile.SearchProfileListing");
        }
    }
}
