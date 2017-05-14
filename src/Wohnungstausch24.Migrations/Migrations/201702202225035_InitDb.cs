namespace Wohnungstausch24.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        About = c.String(nullable: false, maxLength: 3000),
                        PhoneNumber = c.String(nullable: false, maxLength: 200),
                        PhoneNumber2 = c.String(maxLength: 200),
                        FaxNumber = c.String(maxLength: 200),
                        Facebook = c.String(maxLength: 200),
                        Twitter = c.String(maxLength: 200),
                        Linkedin = c.String(maxLength: 200),
                        ManagerId = c.String(nullable: false, maxLength: 128),
                        GooglePlus = c.String(),
                        Email = c.String(),
                        YearOfEstablishment = c.Int(nullable: false),
                        BusinessType = c.Int(nullable: false),
                        OrganizationOther = c.String(),
                        Locationlevel3Id = c.Int(),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        LogoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wt24File", t => t.LogoId)
                .ForeignKey("dbo.AspNetUsers", t => t.ManagerId)
                .Index(t => t.ManagerId)
                .Index(t => t.LogoId);

            CreateTable(
                "dbo.AgencyBranch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Address = c.String(),
                        AgencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agency", t => t.AgencyId)
                .Index(t => t.AgencyId);

            CreateTable(
                "dbo.Agent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgencyId = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Education = c.String(),
                        PositionInCompany = c.Int(nullable: false),
                        FieldOfResponsibility = c.Int(nullable: false),
                        BranchId = c.Int(),
                        LogoOrAvatarId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgencyBranch", t => t.BranchId)
                .ForeignKey("dbo.Wt24File", t => t.LogoOrAvatarId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Agency", t => t.AgencyId)
                .Index(t => t.AgencyId)
                .Index(t => t.UserId)
                .Index(t => t.BranchId)
                .Index(t => t.LogoOrAvatarId);

            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        LanguageCulture = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agent", t => t.AgentId)
                .Index(t => t.AgentId);

            CreateTable(
                "dbo.Wt24File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelativePath = c.String(nullable: false, maxLength: 300),
                        Name = c.String(nullable: false, maxLength: 300),
                        Mime = c.String(nullable: false, maxLength: 100),
                        ContentLengthInBytes = c.Int(nullable: false),
                        ThumbnailPath = c.String(maxLength: 300),
                        Filetype = c.Int(nullable: false),
                        Extension = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Gender = c.Int(),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        About = c.String(maxLength: 1000),
                        Facebook = c.String(maxLength: 200),
                        Twitter = c.String(maxLength: 200),
                        Linkedin = c.String(maxLength: 200),
                        PhoneNumber2 = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 100),
                        GooglePlus = c.String(maxLength: 200),
                        ShowContactInformation = c.Boolean(nullable: false),
                        ListingLimit = c.Int(nullable: false),
                        AvatarId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wt24File", t => t.AvatarId)
                .Index(t => t.AvatarId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Listing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AcceptBailLetter = c.Boolean(),
                        ActualContractTerminatedOn = c.DateTime(),
                        ActualRent = c.Decimal(precision: 18, scale: 2),
                        AdditionalCosts = c.Decimal(precision: 18, scale: 2),
                        AgeGroup = c.Int(),
                        AllInRent = c.Boolean(),
                        AllInRentPrice = c.Decimal(precision: 18, scale: 2),
                        AllotmentType = c.Int(),
                        AtticSpace = c.Decimal(precision: 18, scale: 2),
                        Bail = c.Decimal(precision: 18, scale: 2),
                        BailText = c.String(),
                        BalconyTerraceArea = c.Decimal(precision: 18, scale: 2),
                        BasementArea = c.Decimal(precision: 18, scale: 2),
                        BasicRent = c.Decimal(precision: 18, scale: 2),
                        Boundary = c.String(),
                        BuildingType = c.Int(),
                        BuldingBank = c.Decimal(precision: 18, scale: 2),
                        Clearance = c.Decimal(precision: 18, scale: 2),
                        ClearanceText = c.String(maxLength: 3000),
                        ColdRent = c.Decimal(precision: 18, scale: 2),
                        ComissionFee = c.Decimal(precision: 18, scale: 2),
                        CommonCharge = c.Decimal(precision: 18, scale: 2),
                        ConditionArtType = c.Int(),
                        ConstructionYear = c.Int(),
                        ContaminatedSites = c.Boolean(),
                        CourtageAdvice = c.String(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedOnUTC = c.DateTime(nullable: false),
                        DateOfIssue = c.DateTime(),
                        DeletedBy = c.String(maxLength: 256),
                        DeletedOnUTC = c.DateTime(),
                        Description = c.String(maxLength: 3000),
                        DesignType = c.Int(),
                        Duration = c.Int(),
                        EarliestAvailableDate = c.DateTime(),
                        Electricity = c.Boolean(),
                        ElectricityValue = c.Decimal(precision: 18, scale: 2),
                        EmploymentStatus = c.Int(),
                        EnergyCertificateType = c.Int(),
                        EnergyConsumptionParameter = c.Decimal(precision: 18, scale: 2),
                        EnvironmentDescription = c.String(maxLength: 3000),
                        Epart = c.Int(),
                        ExploitationDenum = c.Int(),
                        ExploitationNum = c.Int(),
                        FeatureCategory = c.Int(),
                        FlatNumber = c.Int(),
                        Floor = c.Int(),
                        FloorTypeDenumerator = c.Int(),
                        FloorTypeNumerator = c.Int(),
                        ForHolidayUse = c.Boolean(),
                        ForIndustrialUse = c.Boolean(),
                        FreeTextAvailableFrom = c.String(maxLength: 3000),
                        FreeTextPrice = c.String(maxLength: 3000),
                        FurnishType = c.Int(),
                        GardenArea = c.Decimal(precision: 18, scale: 2),
                        Gaz = c.Boolean(),
                        GFZ = c.Decimal(precision: 18, scale: 2),
                        GRZ = c.Decimal(precision: 18, scale: 2),
                        HasAirCondition = c.Boolean(),
                        HasAlarmSystem = c.Boolean(),
                        HasAttic = c.Boolean(),
                        HasBicycleRoom = c.Boolean(),
                        HasCableDucts = c.Boolean(),
                        HasCableSatTv = c.Boolean(),
                        HasCamera = c.Boolean(),
                        HasChimney = c.Boolean(),
                        HasElevator = c.Boolean(),
                        HasGermanTvByAntenna = c.Boolean(),
                        HasInternet = c.Boolean(),
                        HasLibrary = c.Boolean(),
                        HasPoliceCall = c.Boolean(),
                        HasPositiveRating = c.Boolean(),
                        HasRollerBlind = c.Boolean(),
                        HasSauna = c.Boolean(),
                        HasSeparateToilet = c.Boolean(),
                        HasStatementOfLord = c.Boolean(),
                        HasStorageRoom = c.Boolean(),
                        HasSwimmingPool = c.Boolean(),
                        HasWashDryingRoom = c.Boolean(),
                        HasWinterGarden = c.Boolean(),
                        HeatingCosts = c.Decimal(precision: 18, scale: 2),
                        HouseNumber = c.String(),
                        IncludedHotWater = c.Boolean(),
                        Income = c.Int(),
                        InsideCourtage = c.Decimal(precision: 18, scale: 2),
                        InternetType = c.Int(),
                        IsActualContractTerminated = c.Boolean(),
                        IsAllowedToBeIntroducedByAgent = c.Boolean(),
                        IsApartmentTower = c.Boolean(),
                        IsBarrierFree = c.Boolean(),
                        IsConstructionYearProjected = c.Boolean(),
                        IsCurrentlyRented = c.Boolean(),
                        IsDateFlexible = c.Boolean(),
                        IsFurnished = c.Boolean(),
                        IsHeatingCostsIncluded = c.Boolean(),
                        IsKitchenFitted = c.Boolean(),
                        IsKitchenOpen = c.Boolean(),
                        IsKitchenPantry = c.Boolean(),
                        IsPetsAllowed = c.Boolean(),
                        IsPriceOnDemand = c.Boolean(),
                        IsRentedOut = c.Boolean(),
                        IsSeniorFocused = c.Boolean(),
                        IsShared = c.Boolean(),
                        IsSmokingAllowed = c.Boolean(),
                        IsSubjectToCommission = c.Boolean(),
                        IsWheelchairAccessible = c.Boolean(),
                        LandMarked = c.Boolean(),
                        LastRenovationDate = c.DateTime(),
                        LatestAvailableDate = c.DateTime(),
                        Latitude = c.Single(),
                        Level = c.Int(),
                        ListingHeader = c.String(maxLength: 300),
                        ListingStatus = c.Int(),
                        LivingArea = c.Decimal(precision: 18, scale: 2),
                        LocationDescription = c.String(maxLength: 3000),
                        Locationlevel3 = c.Int(),
                        Longitude = c.Single(),
                        MaintenanceSavings = c.Decimal(precision: 18, scale: 2),
                        MaxAgeOfPersons = c.Int(),
                        MaxNumberOfChildren = c.Int(),
                        MaxNumberOfPersons = c.Int(),
                        MinIncome = c.Int(),
                        NetYield = c.Decimal(precision: 18, scale: 2),
                        NetYieldActual = c.Decimal(precision: 18, scale: 2),
                        NetYieldDebit = c.Decimal(precision: 18, scale: 2),
                        NumberOfApartmentUnits = c.Int(),
                        NumberOfBathrooms = c.Int(),
                        NumberOfBedrooms = c.Int(),
                        NumberOfLevels = c.Int(),
                        NumberOfLivingBedrooms = c.Int(),
                        NumberOfRooms = c.Int(),
                        NumberOfSeperateToilet = c.Int(),
                        OrientationPrice = c.Decimal(precision: 18, scale: 2),
                        OtherArea = c.Decimal(precision: 18, scale: 2),
                        OtherComments = c.String(),
                        OtherDetails = c.String(maxLength: 3000),
                        OutsideCourtage = c.Decimal(precision: 18, scale: 2),
                        PlotArea = c.Decimal(precision: 18, scale: 2),
                        PositionInBuilding = c.Int(),
                        PreferredGender = c.Int(),
                        PrefferedAgeOfChildren = c.Int(),
                        Price = c.Int(),
                        PrimaryEnegySource = c.Int(),
                        PropertySubType = c.Int(),
                        PublisherType = c.Int(),
                        PurchasePrice = c.Decimal(precision: 18, scale: 2),
                        PurchasePricePerSqm = c.Decimal(precision: 18, scale: 2),
                        RentalIncomeActual = c.Decimal(precision: 18, scale: 2),
                        RentalIncomeDebit = c.Decimal(precision: 18, scale: 2),
                        RentalPricePerSqm = c.Decimal(precision: 18, scale: 2),
                        RentOnDemand = c.Boolean(),
                        RentPrice = c.Int(),
                        RentSubsidy = c.Decimal(precision: 18, scale: 2),
                        RoofType = c.Int(),
                        SeparableFrom = c.Decimal(precision: 18, scale: 2),
                        ShowFullAddressInPublic = c.Boolean(),
                        SpeakToOwner = c.Boolean(),
                        SpeedOfInternet = c.Decimal(precision: 18, scale: 2),
                        Street = c.String(maxLength: 500),
                        SubUrbLeft = c.String(),
                        Tercet = c.String(maxLength: 1000),
                        TK = c.Boolean(),
                        TotalArea = c.Int(),
                        TypeOfUse = c.Int(),
                        UltimateEnergyDemand = c.Decimal(precision: 18, scale: 2),
                        UnderGroundType = c.Int(),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedOnUTC = c.DateTime(),
                        UsefulArea = c.Decimal(precision: 18, scale: 2),
                        ValidUntil = c.DateTime(),
                        ValueRating = c.Int(),
                        WarmnessValue = c.Decimal(precision: 18, scale: 2),
                        WarmRent = c.Decimal(precision: 18, scale: 2),
                        Water = c.Boolean(),
                        XTimes = c.Decimal(precision: 18, scale: 2),
                        Zipcode = c.String(),
                        ZoneOfConstruction = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Distance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        DistanceType = c.Int(),
                        DistanceInKm = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ListingId)
                .Index(t => t.ListingId);

            CreateTable(
                "dbo.ListingFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wt24File", t => t.FileId)
                .ForeignKey("dbo.Listing", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId)
                .Index(t => t.FileId);

            CreateTable(
                "dbo.ObjectTextInAnotherLanguage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        LanguageCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ListingId)
                .Index(t => t.ListingId);

            CreateTable(
                "dbo.Sight",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListingId = c.Int(nullable: false),
                        SightType = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ListingId)
                .Index(t => t.ListingId);

            CreateTable(
                "dbo.MixedLand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandId = c.Int(nullable: false),
                        TypeOfUse = c.Int(nullable: false),
                        TotalArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PlotArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeparableFrom = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.LandId)
                .Index(t => t.LandId);

            CreateTable(
                "dbo.Balcony",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        Direction = c.Int(),
                        Size = c.Int(nullable: false),
                        BalconyType = c.Int(),
                        SightType = c.Int(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ResidenceId)
                .Index(t => t.ResidenceId);

            CreateTable(
                "dbo.Bathroom",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        Size = c.Int(),
                        HasShower = c.Boolean(),
                        HasTub = c.Boolean(),
                        HasWindow = c.Boolean(),
                        HasUrinal = c.Boolean(),
                        HasBidet = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ResidenceId)
                .Index(t => t.ResidenceId);

            CreateTable(
                "dbo.Beaconing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        BeaconingType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ResidenceId)
                .Index(t => t.ResidenceId);

            CreateTable(
                "dbo.EmployeeStatusObject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Selected = c.Boolean(nullable: false),
                        EmploymentStatus = c.Int(nullable: false),
                        Residence_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.Residence_Id)
                .Index(t => t.Residence_Id);

            CreateTable(
                "dbo.Floor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        FloorType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ResidenceId)
                .Index(t => t.ResidenceId);

            CreateTable(
                "dbo.Heating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        HeatingType = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ResidenceId)
                .Index(t => t.ResidenceId);

            CreateTable(
                "dbo.ParkingSpace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        ParkSpaceType = c.Int(),
                        Quantity = c.Int(),
                        RentPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listing", t => t.ResidenceId)
                .Index(t => t.ResidenceId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Emphasis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgencyId = c.Int(nullable: false),
                        EmphasisType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agency", t => t.AgencyId)
                .Index(t => t.AgencyId);

            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        AgencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agency", t => t.AgencyId)
                .Index(t => t.AgencyId);

            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.LocationLevel1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "dbo.LocationLevel2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocationLevel1", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "dbo.LocationLevel3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocationLevel2", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LocationLevel1", "ParentId", "dbo.Country");
            DropForeignKey("dbo.LocationLevel2", "ParentId", "dbo.LocationLevel1");
            DropForeignKey("dbo.LocationLevel3", "ParentId", "dbo.LocationLevel2");
            DropForeignKey("dbo.Organization", "AgencyId", "dbo.Agency");
            DropForeignKey("dbo.Agency", "ManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Agency", "LogoId", "dbo.Wt24File");
            DropForeignKey("dbo.Emphasis", "AgencyId", "dbo.Agency");
            DropForeignKey("dbo.Agent", "AgencyId", "dbo.Agency");
            DropForeignKey("dbo.Agent", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ParkingSpace", "ResidenceId", "dbo.Listing");
            DropForeignKey("dbo.Heating", "ResidenceId", "dbo.Listing");
            DropForeignKey("dbo.Floor", "ResidenceId", "dbo.Listing");
            DropForeignKey("dbo.EmployeeStatusObject", "Residence_Id", "dbo.Listing");
            DropForeignKey("dbo.Beaconing", "ResidenceId", "dbo.Listing");
            DropForeignKey("dbo.Bathroom", "ResidenceId", "dbo.Listing");
            DropForeignKey("dbo.Balcony", "ResidenceId", "dbo.Listing");
            DropForeignKey("dbo.MixedLand", "LandId", "dbo.Listing");
            DropForeignKey("dbo.Listing", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sight", "ListingId", "dbo.Listing");
            DropForeignKey("dbo.ObjectTextInAnotherLanguage", "ListingId", "dbo.Listing");
            DropForeignKey("dbo.ListingFile", "ListingId", "dbo.Listing");
            DropForeignKey("dbo.ListingFile", "FileId", "dbo.Wt24File");
            DropForeignKey("dbo.Distance", "ListingId", "dbo.Listing");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AvatarId", "dbo.Wt24File");
            DropForeignKey("dbo.Agent", "LogoOrAvatarId", "dbo.Wt24File");
            DropForeignKey("dbo.Language", "AgentId", "dbo.Agent");
            DropForeignKey("dbo.Agent", "BranchId", "dbo.AgencyBranch");
            DropForeignKey("dbo.AgencyBranch", "AgencyId", "dbo.Agency");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LocationLevel3", new[] { "ParentId" });
            DropIndex("dbo.LocationLevel2", new[] { "ParentId" });
            DropIndex("dbo.LocationLevel1", new[] { "ParentId" });
            DropIndex("dbo.Organization", new[] { "AgencyId" });
            DropIndex("dbo.Emphasis", new[] { "AgencyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.ParkingSpace", new[] { "ResidenceId" });
            DropIndex("dbo.Heating", new[] { "ResidenceId" });
            DropIndex("dbo.Floor", new[] { "ResidenceId" });
            DropIndex("dbo.EmployeeStatusObject", new[] { "Residence_Id" });
            DropIndex("dbo.Beaconing", new[] { "ResidenceId" });
            DropIndex("dbo.Bathroom", new[] { "ResidenceId" });
            DropIndex("dbo.Balcony", new[] { "ResidenceId" });
            DropIndex("dbo.MixedLand", new[] { "LandId" });
            DropIndex("dbo.Sight", new[] { "ListingId" });
            DropIndex("dbo.ObjectTextInAnotherLanguage", new[] { "ListingId" });
            DropIndex("dbo.ListingFile", new[] { "FileId" });
            DropIndex("dbo.ListingFile", new[] { "ListingId" });
            DropIndex("dbo.Distance", new[] { "ListingId" });
            DropIndex("dbo.Listing", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AvatarId" });
            DropIndex("dbo.Language", new[] { "AgentId" });
            DropIndex("dbo.Agent", new[] { "LogoOrAvatarId" });
            DropIndex("dbo.Agent", new[] { "BranchId" });
            DropIndex("dbo.Agent", new[] { "UserId" });
            DropIndex("dbo.Agent", new[] { "AgencyId" });
            DropIndex("dbo.AgencyBranch", new[] { "AgencyId" });
            DropIndex("dbo.Agency", new[] { "LogoId" });
            DropIndex("dbo.Agency", new[] { "ManagerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LocationLevel3");
            DropTable("dbo.LocationLevel2");
            DropTable("dbo.LocationLevel1");
            DropTable("dbo.Country");
            DropTable("dbo.Organization");
            DropTable("dbo.Emphasis");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.ParkingSpace");
            DropTable("dbo.Heating");
            DropTable("dbo.Floor");
            DropTable("dbo.EmployeeStatusObject");
            DropTable("dbo.Beaconing");
            DropTable("dbo.Bathroom");
            DropTable("dbo.Balcony");
            DropTable("dbo.MixedLand");
            DropTable("dbo.Sight");
            DropTable("dbo.ObjectTextInAnotherLanguage");
            DropTable("dbo.ListingFile");
            DropTable("dbo.Distance");
            DropTable("dbo.Listing");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Wt24File");
            DropTable("dbo.Language");
            DropTable("dbo.Agent");
            DropTable("dbo.AgencyBranch");
            DropTable("dbo.Agency");
        }
    }
}
