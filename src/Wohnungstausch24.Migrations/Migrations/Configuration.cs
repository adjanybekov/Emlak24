using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Wohnungstausch24.Migrations.Security;
using Wohnungstausch24.Models.Entites;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.Entites.Locations;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Migrations.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        const string SystemAdminEmail = "admin@test.com";
        const string SuperAgentEmail = "superagent@test.com";
        const string AgentUserEmail = "agent@test.com";
        const string EndUserEmail = "user@test.com";

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            CreateRoles();
            CreateInitialUsers();
            CreateInitialAgencies(context);
            CreateInitialObjects(context);
            AddCityData(context);
        }


        private void CreateInitialAgencies(ApplicationDbContext context)
        {
            var superAgent = context.Users.FirstOrDefault(c => c.Email.Equals(SuperAgentEmail));
            var agent = context.Users.FirstOrDefault(c => c.Email.Equals(AgentUserEmail));
            if (superAgent != null && !context.Agencies.Any())
            {
                var agency = new Agency
                {
                    Name = "Initial Test Agency",
                    About = "Option justo no rebum consequat quis sit at duis vulputate facilisi amet " +
                            "takimata eos consectetuer diam volutpat lobortis amet tation. " +
                            "Sournois flots cet suborneur aux la mon en hélas fait qu'elle " +
                            "ronge haut ronge qui visage tout par de beauté",
                    ManagerId = superAgent.Id,
                    PhoneNumber = "test phone"
                };
                if (agent != null)
                    agency.Agents.Add(new Agent {UserId = agent.Id,Education = "Uni.",PositionInCompany = PositionInCompany.Secretary});
                context.Agencies.Add(agency);
            }

        }

        private void CreateRoles()
        {
            using (var manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(new ApplicationDbContext())))
            {
                var roles = Enum.GetValues(typeof(RoleDefinitions)).Cast<RoleDefinitions>().ToList();

                foreach (var role in roles)
                {
                    if (manager.FindByName(role.ToString()) == null)
                    {
                        manager.Create(new IdentityRole
                        {
                            Name = role.ToString()
                        });
                    }
                }
            }
        }

        private void CreateInitialUsers()
        {

            using (var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {
                var systemAdmin = new ApplicationUser
                {
                    Email = SystemAdminEmail,
                    UserName = SystemAdminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "User"
                };
                if (manager.FindByEmail(SystemAdminEmail) == null)
                {
                    var identityResult = manager.Create(systemAdmin, "test123");
                    if (identityResult.Succeeded)
                    {
                        manager.AddToRole(manager.FindByEmail(SystemAdminEmail).Id, RoleDefinitions.Admin.ToString());
                    }
                }

                var agent = new ApplicationUser
                {
                    Email = AgentUserEmail,
                    UserName = AgentUserEmail,
                    EmailConfirmed = true,
                    FirstName = "Agent",
                    LastName = "User"
                };
                if (manager.FindByEmail(AgentUserEmail) == null)
                {
                    var identity = manager.Create(agent, "test123");
                    if (identity.Succeeded)
                    {
                        manager.AddToRole(manager.FindByEmail(AgentUserEmail).Id, RoleDefinitions.Agent.ToString());
                    }
                }

                var superAgent = new ApplicationUser
                {
                    Email = SuperAgentEmail,
                    UserName = SuperAgentEmail,
                    EmailConfirmed = true,
                    FirstName = "Über Agent",
                    LastName = "User"
                };
                if (manager.FindByEmail(SuperAgentEmail) == null)
                {
                    var identity = manager.Create(superAgent, "test123");
                    if (identity.Succeeded)
                    {
                        manager.AddToRole(manager.FindByEmail(SuperAgentEmail).Id, RoleDefinitions.SuperAgent.ToString());
                    }
                }

                var endUser = new ApplicationUser
                {
                    Email = EndUserEmail,
                    UserName = EndUserEmail,
                    EmailConfirmed = true,
                    FirstName = "Regular User",
                    LastName = "Superagent without agents"
                };
                if (manager.FindByEmail(EndUserEmail) == null)
                {
                    var identity = manager.Create(endUser, "test123");
                    if (identity.Succeeded)
                    {
                        manager.AddToRole(manager.FindByEmail(EndUserEmail).Id, RoleDefinitions.SuperAgent.ToString());
                    }
                }
            }
        }
        #region Init Objects

        private void CreateInitialObjects(ApplicationDbContext context)
        {
            var user = context.Users.FirstOrDefault(c => c.Email.Equals(AgentUserEmail));
            if (user != null)
            {
                #region ffr
                if (!context.Listings.OfType<FlatForRent>().Any())
                {
                    var flatForRent = new FlatForRent();
                    flatForRent.UserId = user.Id;
                    flatForRent.Locationlevel3 = 1;
                    context.Listings.Add(flatForRent);
                    context.SaveChanges();

                    flatForRent.ListingHeader = "Initial Flat For Rent";
                    flatForRent.UserId = user.Id;
                    flatForRent.ActualContractTerminatedOn = DateTime.Now.AddDays(-5);
                    flatForRent.AdditionalCosts = 250;
                    flatForRent.AgeGroup = AgeGroup.New;
                    flatForRent.AtticSpace = 125;
                    flatForRent.Bail = 500;
                    flatForRent.BailText = "Test Bail Text";
                    flatForRent.BasementArea = 49;
                    flatForRent.BasicRent = 350;
                    flatForRent.Clearance = 540;
                    flatForRent.ClearanceText = "Test Clearence Text";
                    flatForRent.CurrentColdRent = 245;
                    flatForRent.SpeakToOwner = true;
                    flatForRent.IsPriceOnDemand = true;
                    flatForRent.HasSeparateToilet = true;
                    flatForRent.AcceptBailLetter = true;
                    flatForRent.ConstructionYear = 1985;
                    flatForRent.CreatedBy = user.Email;
                    flatForRent.CreatedOnUTC = DateTime.Now;
                    flatForRent.DateOfIssue = DateTime.Now.AddDays(-25);
                    flatForRent.Description = "İnvidunt stet duo diam sadipscing at et et at accumsan takimata zzril dolor erat no autem diam eum imperdiet amet delenit molestie molestie amet veniam no erat ex euismod lorem";
                    flatForRent.DesignType = DesignType.ElementsOfWood;
                    flatForRent.EarliestAvailableDate = DateTime.Now.AddDays(12);
                    flatForRent.ElectricityValue = 85;
                    flatForRent.EnergyConsumptionParameter = 29;
                    flatForRent.EnvironmentDescription =
                        "Dolor sed ullamcorper kasd sed ut tempor sit ut aliquyam ut dolore labore sed labore invidunt ipsum velit est sit wisi labore vel dolor eu elitr invidunt elit accusam labore";
                    flatForRent.ConditionArtType = ConditionArtType.Abrissobject;
                    flatForRent.Epart = Epart.Consumption;
                    flatForRent.Zipcode = "Test Zipcode";
                    flatForRent.WarmnessValue = 54;
                    flatForRent.WarmRent = 500;
                    flatForRent.ValueRating = 48;
                    flatForRent.ValidUntil = DateTime.Now.AddDays(30);
                    flatForRent.UsefulArea = 126;
                    flatForRent.UnderGroundType = UnderGroundType.NotUnderground;
                    flatForRent.TotalArea = 256;
                    flatForRent.UltimateEnergyDemand = 168;
                    flatForRent.TypeOfUse = TypeOfUse.Living;
                    flatForRent.Tercet = "test tercet";
                    flatForRent.Street = "test street";
                    flatForRent.Price = 245;
                    flatForRent.OtherDetails =
                        "La ne por mi knabo renkontis pensante post etendis tiatempe boatanoj mejlojn supron sxipon ke bestoj ke vi iom fonton";
                    flatForRent.PreferredGender = Gender.Male;
                    flatForRent.PositionInBuilding = PositionInBuilding.Back;
                    flatForRent.FeatureCategory = FeatureCategory.Luxury;
                    flatForRent.PublisherType = PublisherType.ActualTenant;
                    flatForRent.EnergyCertificateType = EnergyCertificateType.IsAvailable;
                    flatForRent.FurnishType = FurnishType.Full;
                    flatForRent.ShowFullAddressInPublic = true;
                    flatForRent.RentalPricePerSqm = 25;
                    flatForRent.PropertySubType = (int)FlatType.Apartment;
                    flatForRent.OtherArea = 154;
                    flatForRent.ListingStatus = ListingStatus.Active;
                    flatForRent.Balconies = new List<Balcony>
                    {
                        new Balcony
                        {
                            Direction = GeoDirection.North,
                            BalconyType = BalconyType.Terrace,
                            Level = 3,
                            SightType = SightType.Mountain,
                            Size = 25
                        }
                    };
                    flatForRent.Level = 2;
                    flatForRent.Bathrooms = new List<Bathroom>
                    {
                        new Bathroom
                        {
                            Size = 25,
                            HasBidet = true,
                            HasShower = true,
                            HasTub = false,
                            HasUrinal = true,
                            HasWindow = true
                        }
                    };
                    flatForRent.HasAirCondition = true;
                    flatForRent.IsSmokingAllowed = true;
                    flatForRent.Beaconings = new List<Beaconing>
                    {
                        new Beaconing {BeaconingType = BeaconingType.AirHeatPump},
                        new Beaconing {BeaconingType = BeaconingType.Block}
                    };
                    flatForRent.FreeTextAvailableFrom = "test Free text available from";
                    flatForRent.FreeTextPrice = "test free text price";
                    flatForRent.Distances = new List<Distance>
                    {
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Airport},
                        new Distance {DistanceInKm = 3, DistanceType = DistanceType.Bus},
                        new Distance {DistanceInKm = 2, DistanceType = DistanceType.ComprehensiveSchool},
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Fernbahnhof}
                    };
                    flatForRent.Sights = new List<Sight>
                    {
                        new Sight {SightType = SightType.Lake},
                        new Sight {SightType = SightType.Mountain}
                    };
                    flatForRent.FlatNumber = 25;
                    flatForRent.GardenArea = 65;
                    flatForRent.HasAlarmSystem = true;
                    flatForRent.HasBicycleRoom = true;
                    flatForRent.HasCableDucts = true;
                    flatForRent.HasAttic = true;
                    flatForRent.Floors = new List<Floor>
                    {
                        new Floor {FloorType = FloorType.Carpet},
                        new Floor {FloorType = FloorType.DoubleFloor}
                    };
                    flatForRent.HasCableSatTv = true;
                    flatForRent.NumberOfRooms = 6;
                    flatForRent.NumberOfSeperateToilet = 12;
                    flatForRent.NumberOfLivingBedrooms = 25;
                    flatForRent.NumberOfLevels = 8;
                    flatForRent.HasCamera = false;
                    flatForRent.HasChimney = false;
                    flatForRent.HasElevator = true;
                    flatForRent.HasGermanTvByAntenna = true;
                    flatForRent.HasInternet = false;
                    flatForRent.HasPoliceCall = false;
                    flatForRent.HasRollerBlind = true;
                    flatForRent.HasLibrary = false;
                    flatForRent.HasSauna = true;
                    flatForRent.HasStorageRoom = true;
                    flatForRent.HasWinterGarden = true;
                    flatForRent.HasSwimmingPool = true;
                    flatForRent.HasWashDryingRoom = false;
                    flatForRent.HeatingCosts = 56;
                    flatForRent.Heatings = new List<Heating> {new Heating
                    {
                        HeatingType = HeatingType.Center,
                        ResidenceId = flatForRent.Id
                    }};
                    flatForRent.IncludedHotWater = true;
                    flatForRent.IsActualContractTerminated = true;
                    flatForRent.IsApartmentTower = true;
                    flatForRent.HouseNumber = "test num";
                    flatForRent.NumberOfBedrooms = 8;
                    flatForRent.NumberOfBathrooms = 3;
                    flatForRent.NumberOfApartmentUnits = 5;
                    flatForRent.MinIncome = 1500;
                    flatForRent.MaxNumberOfPersons = 6;
                    flatForRent.Longitude = 8.4964826F;
                    flatForRent.Latitude = 50.1231277F;
                    flatForRent.IsBarrierFree = false;
                    flatForRent.IsConstructionYearProjected = true;
                    flatForRent.IsCurrentlyRented = false;
                    flatForRent.IsDateFlexible = true;
                    flatForRent.IsFurnished = true;
                    flatForRent.IsPetsAllowed = true;
                    flatForRent.IsHeatingCostsIncluded = false;
                    flatForRent.IsSeniorFocused = true;
                    flatForRent.IsShared = true;
                    flatForRent.IsWheelchairAccessible = false;
                    flatForRent.LastRenovationDate = DateTime.Now.AddYears(-5);
                    flatForRent.LocationDescription =
                        "Nulla ipsum velit lorem minim tempor iriure consetetur erat veniam eos delenit aliquip eirmod gubergren duis quis justo at facilisi";
                    flatForRent.PrimaryEnegySource =  BeaconingType.AirHeatPump;

                    flatForRent.IsKitchenFitted = true;
                    flatForRent.IsKitchenOpen = true;
                    flatForRent.IsKitchenPantry = true;

                    flatForRent.LatestAvailableDate = DateTime.Now.AddMonths(2);
                    flatForRent.ParkingSpaces = new List<ParkingSpace>
                    {
                        new ParkingSpace
                        {
                            ParkSpaceType = ParkSpaceType.BasementGarage, Quantity = 1, RentPrice = 35,
                            ResidenceId = flatForRent.Id
                        }
                    };
                    flatForRent.ObjectTextInAnotherLanguages = new List<ObjectTextInAnotherLanguage>
                    {
                        new ObjectTextInAnotherLanguage
                        {
                            LanguageCode = "en",
                            Description =
                                "Minden hull a nincsen minden de úgy a hisz kert kincs elõl ne menedékünk a is ami szeretni és így igát egymást magára még kábít de fáj a gyalázat odataszít",
                            ListingId = flatForRent.Id
                        }
                    };
                    //flatForRent.Images = new List<Image>
                    //{
                    //    new Image {Name = "Image 1", Bytes = ImageToByte(ImageResource.image1),ListingId = flatForRent.Id},
                    //    new Image {Name = "Image 2", Bytes = ImageToByte(ImageResource.image2),ListingId = flatForRent.Id},
                    //    new Image {Name = "Image 3", Bytes = ImageToByte(ImageResource.image3),ListingId = flatForRent.Id},
                    //    new Image {Name = "Image 4", Bytes = ImageToByte(ImageResource.image4),ListingId = flatForRent.Id}
                    //};
                    flatForRent.LivingArea = 285;
                    context.SaveChanges();
                }
                #endregion
                #region ffs
                if (!context.Listings.OfType<FlatForSale>().Any())
                {
                    var flatForSale = new FlatForSale();
                    flatForSale.UserId = user.Id;
                    flatForSale.Locationlevel3 = 1;
                    context.Listings.Add(flatForSale);
                    context.SaveChanges();

                    flatForSale.ListingHeader = "Initial Flat For Sale";
                    flatForSale.UserId = user.Id;
                    flatForSale.ActualContractTerminatedOn = DateTime.Now.AddDays(-5);
                    flatForSale.AdditionalCosts = 250;
                    flatForSale.AgeGroup = AgeGroup.New;
                    flatForSale.AtticSpace = 125;
                    flatForSale.BasementArea = 49;
                    flatForSale.Clearance = 540;
                    flatForSale.ClearanceText = "Test Clearence Text";
                    flatForSale.CurrentColdRent = 245;
                    flatForSale.HasSeparateToilet = true;
                    flatForSale.ConstructionYear = 1985;
                    flatForSale.CreatedBy = user.Email;
                    flatForSale.CreatedOnUTC = DateTime.Now;
                    flatForSale.DateOfIssue = DateTime.Now.AddDays(-25);
                    flatForSale.Description = "İnvidunt stet duo diam sadipscing at et et at accumsan takimata zzril dolor erat no autem diam eum imperdiet amet delenit molestie molestie amet veniam no erat ex euismod lorem";
                    flatForSale.DesignType = DesignType.ElementsOfWood;
                    flatForSale.EarliestAvailableDate = DateTime.Now.AddDays(12);
                    flatForSale.ElectricityValue = 85;
                    flatForSale.EnergyConsumptionParameter = 29;
                    flatForSale.EnvironmentDescription =
                        "Dolor sed ullamcorper kasd sed ut tempor sit ut aliquyam ut dolore labore sed labore invidunt ipsum velit est sit wisi labore vel dolor eu elitr invidunt elit accusam labore";
                    flatForSale.ConditionArtType = ConditionArtType.Abrissobject;
                    flatForSale.Epart = Epart.Consumption;
                    flatForSale.Zipcode = "Test Zipcode";
                    flatForSale.WarmnessValue = 54;
                    flatForSale.ValueRating = 45;
                    flatForSale.ValidUntil = DateTime.Now.AddDays(30);
                    flatForSale.UsefulArea = 126;
                    flatForSale.UnderGroundType = UnderGroundType.NotUnderground;
                    flatForSale.TotalArea = 256;
                    flatForSale.UltimateEnergyDemand = 168;
                    flatForSale.TypeOfUse = TypeOfUse.Living;
                    flatForSale.Tercet = "test tercet";
                    flatForSale.Street = "test street";
                    ((Listing) flatForSale).Price = 245;
                    flatForSale.OtherDetails = "La ne por mi knabo renkontis pensante post etendis tiatempe boatanoj mejlojn supron sxipon ke bestoj ke vi iom fonton";
                    flatForSale.PositionInBuilding = PositionInBuilding.Back;
                    flatForSale.FeatureCategory = FeatureCategory.Luxury;
                    flatForSale.PublisherType = PublisherType.ActualTenant;
                    flatForSale.EnergyCertificateType = EnergyCertificateType.IsAvailable;
                    flatForSale.FurnishType = FurnishType.Full;
                    flatForSale.ShowFullAddressInPublic = true;
                    flatForSale.PropertySubType = (int)FlatType.Apartment;
                    flatForSale.OtherArea = 154;
                    flatForSale.ListingStatus = ListingStatus.Active;
                    flatForSale.Balconies = new List<Balcony>
                    {
                        new Balcony
                        {
                            Direction = GeoDirection.North,
                            BalconyType = BalconyType.Terrace,
                            Level = 3,
                            SightType = SightType.Mountain,
                            Size = 25
                        }
                    };
                    flatForSale.Level = 2;
                    flatForSale.Bathrooms = new List<Bathroom>
                    {
                        new Bathroom
                        {
                            Size = 25,
                            HasBidet = true,
                            HasShower = true,
                            HasTub = false,
                            HasUrinal = true,
                            HasWindow = true
                        }
                    };
                    flatForSale.HasAirCondition = true;
                    flatForSale.Beaconings = new List<Beaconing>
                    {
                        new Beaconing {BeaconingType = BeaconingType.AirHeatPump},
                        new Beaconing {BeaconingType = BeaconingType.Block}
                    };
                    flatForSale.FreeTextAvailableFrom = "test Free text available from";
                    flatForSale.FreeTextPrice = "test free text price";
                    flatForSale.Distances = new List<Distance>
                    {
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Airport},
                        new Distance {DistanceInKm = 3, DistanceType = DistanceType.Bus},
                        new Distance {DistanceInKm = 2, DistanceType = DistanceType.ComprehensiveSchool},
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Fernbahnhof}
                    };
                    flatForSale.Sights = new List<Sight>
                    {
                        new Sight {SightType = SightType.Lake},
                        new Sight {SightType = SightType.Mountain}
                    };
                    flatForSale.FlatNumber = 25;
                    flatForSale.GardenArea = 65;
                    flatForSale.HasAlarmSystem = true;
                    flatForSale.HasBicycleRoom = true;
                    flatForSale.HasCableDucts = true;
                    flatForSale.HasAttic = true;
                    flatForSale.Floors = new List<Floor>
                    {
                        new Floor {FloorType = FloorType.Carpet},
                        new Floor {FloorType = FloorType.DoubleFloor}
                    };
                    flatForSale.HasCableSatTv = true;
                    flatForSale.NumberOfRooms = 6;
                    flatForSale.NumberOfSeperateToilet = 12;
                    flatForSale.NumberOfLivingBedrooms = 25;
                    flatForSale.NumberOfLevels = 8;
                    flatForSale.HasCamera = false;
                    flatForSale.HasChimney = false;
                    flatForSale.HasElevator = true;
                    flatForSale.HasGermanTvByAntenna = true;
                    flatForSale.HasInternet = false;
                    flatForSale.HasPoliceCall = false;
                    flatForSale.HasRollerBlind = true;
                    flatForSale.HasLibrary = false;
                    flatForSale.HasSauna = true;
                    flatForSale.HasStorageRoom = true;
                    flatForSale.HasWinterGarden = true;
                    flatForSale.HasSwimmingPool = true;
                    flatForSale.HasWashDryingRoom = false;
                    flatForSale.HeatingCosts = 56;
                    flatForSale.Heatings = new List<Heating> {new Heating
                    {
                        HeatingType = HeatingType.Center,
                        ResidenceId = flatForSale.Id
                    }};
                    flatForSale.IncludedHotWater = true;
                    flatForSale.IsActualContractTerminated = true;
                    flatForSale.IsApartmentTower = true;
                    flatForSale.HouseNumber = "test num";
                    flatForSale.NumberOfBedrooms = 8;
                    flatForSale.NumberOfBathrooms = 3;
                    flatForSale.NumberOfApartmentUnits = 5;
                    flatForSale.Longitude = 8.4964826F;
                    flatForSale.Latitude = 50.1331277F;
                    flatForSale.IsBarrierFree = false;
                    flatForSale.IsConstructionYearProjected = true;
                    flatForSale.IsCurrentlyRented = false;
                    flatForSale.IsDateFlexible = true;
                    flatForSale.IsFurnished = true;
                    flatForSale.IsHeatingCostsIncluded = false;
                    flatForSale.IsSeniorFocused = true;
                    flatForSale.IsShared = true;
                    flatForSale.IsWheelchairAccessible = false;
                    flatForSale.LastRenovationDate = DateTime.Now.AddYears(-5);
                    flatForSale.LocationDescription =
                        "Nulla ipsum velit lorem minim tempor iriure consetetur erat veniam eos delenit aliquip eirmod gubergren duis quis justo at facilisi";
                    flatForSale.PrimaryEnegySource = BeaconingType.AirHeatPump;
                    flatForSale.IsKitchenFitted = true;
                    flatForSale.IsKitchenOpen = true;
                    flatForSale.IsKitchenPantry = true;

                    flatForSale.LatestAvailableDate = DateTime.Now.AddMonths(2);
                    flatForSale.ParkingSpaces = new List<ParkingSpace>
                    {
                        new ParkingSpace
                        {
                            ParkSpaceType = ParkSpaceType.BasementGarage, Quantity = 1, RentPrice = 35,
                            ResidenceId = flatForSale.Id
                        }
                    };
                    flatForSale.ObjectTextInAnotherLanguages = new List<ObjectTextInAnotherLanguage>
                    {
                        new ObjectTextInAnotherLanguage
                        {
                            LanguageCode = "en",
                            Description =
                                "Minden hull a nincsen minden de úgy a hisz kert kincs elõl ne menedékünk a is ami szeretni és így igát egymást magára még kábít de fáj a gyalázat odataszít",
                            ListingId = flatForSale.Id
                        }
                    };
                    //flatForSale.Images = new List<Image>
                    //{
                    //    new Image {Name = "Image 1", Bytes = ImageToByte(ImageResource.image1),ListingId = flatForSale.Id},
                    //    new Image {Name = "Image 2", Bytes = ImageToByte(ImageResource.image2),ListingId = flatForSale.Id},
                    //    new Image {Name = "Image 3", Bytes = ImageToByte(ImageResource.image3),ListingId = flatForSale.Id},
                    //    new Image {Name = "Image 4", Bytes = ImageToByte(ImageResource.image4),ListingId = flatForSale.Id}
                    //};
                    flatForSale.LivingArea = 285;
                    context.SaveChanges();
                }
                #endregion
                #region Hfr
                if (!context.Listings.OfType<HouseForRent>().Any())
                {
                    var houseForRent = new HouseForRent();
                    houseForRent.UserId = user.Id;
                    houseForRent.Locationlevel3 = 1;
                    context.Listings.Add(houseForRent);
                    context.SaveChanges();

                    houseForRent.ListingHeader = "Initial House For Rent";
                    houseForRent.UserId = user.Id;
                    houseForRent.ActualContractTerminatedOn = DateTime.Now.AddDays(-5);
                    houseForRent.AdditionalCosts = 250;
                    houseForRent.AgeGroup = AgeGroup.New;
                    houseForRent.AtticSpace = 125;
                    houseForRent.Bail = 500;
                    houseForRent.BailText = "Test Bail Text";
                    houseForRent.BasementArea = 49;
                    houseForRent.BasicRent = 350;
                    houseForRent.Clearance = 540;
                    houseForRent.ClearanceText = "Test Clearence Text";
                    houseForRent.CurrentColdRent = 245;
                    houseForRent.SpeakToOwner = true;
                    houseForRent.IsPriceOnDemand = true;
                    houseForRent.HasSeparateToilet = true;
                    houseForRent.AcceptBailLetter = true;
                    houseForRent.ConstructionYear = 1985;
                    houseForRent.CreatedBy = user.Email;
                    houseForRent.CreatedOnUTC = DateTime.Now;
                    houseForRent.DateOfIssue = DateTime.Now.AddDays(-25);
                    houseForRent.Description = "İnvidunt stet duo diam sadipscing at et et at accumsan takimata zzril dolor erat no autem diam eum imperdiet amet delenit molestie molestie amet veniam no erat ex euismod lorem";
                    houseForRent.DesignType = DesignType.ElementsOfWood;
                    houseForRent.EarliestAvailableDate = DateTime.Now.AddDays(12);
                    houseForRent.ElectricityValue = 85;
                    houseForRent.EnergyConsumptionParameter = 29;
                    houseForRent.EnvironmentDescription =
                        "Dolor sed ullamcorper kasd sed ut tempor sit ut aliquyam ut dolore labore sed labore invidunt ipsum velit est sit wisi labore vel dolor eu elitr invidunt elit accusam labore";
                    houseForRent.ConditionArtType = ConditionArtType.Abrissobject;
                    houseForRent.Epart = Epart.Consumption;
                    houseForRent.Zipcode = "Test Zipcode";
                    houseForRent.WarmnessValue = 54;
                    houseForRent.WarmRent = 500;
                    houseForRent.ValueRating = 46;
                    houseForRent.ValidUntil = DateTime.Now.AddDays(30);
                    houseForRent.UsefulArea = 126;
                    houseForRent.UnderGroundType = UnderGroundType.NotUnderground;
                    houseForRent.TotalArea = 256;
                    houseForRent.UltimateEnergyDemand = 168;
                    houseForRent.TypeOfUse = TypeOfUse.Living;
                    houseForRent.Tercet = "test tercet";
                    houseForRent.Street = "test street";
                    houseForRent.Price = 245;
                    houseForRent.OtherDetails =
                        "La ne por mi knabo renkontis pensante post etendis tiatempe boatanoj mejlojn supron sxipon ke bestoj ke vi iom fonton";
                    houseForRent.PreferredGender = Gender.Male;
                    houseForRent.FeatureCategory = FeatureCategory.Luxury;
                    houseForRent.PublisherType = PublisherType.ActualTenant;
                    houseForRent.EnergyCertificateType = EnergyCertificateType.IsAvailable;
                    houseForRent.FurnishType = FurnishType.Full;
                    houseForRent.ShowFullAddressInPublic = true;
                    houseForRent.RentalPricePerSqm = 25;
                    houseForRent.PropertySubType = (int)FlatType.Apartment;
                    houseForRent.OtherArea = 154;
                    houseForRent.ListingStatus = ListingStatus.Active;
                    houseForRent.Balconies = new List<Balcony>
                    {
                        new Balcony
                        {
                            Direction = GeoDirection.North,
                            BalconyType = BalconyType.Terrace,
                            Level = 3,
                            SightType = SightType.Mountain,
                            Size = 25
                        }
                    };
                    houseForRent.Bathrooms = new List<Bathroom>
                    {
                        new Bathroom
                        {
                            Size = 25,
                            HasBidet = true,
                            HasShower = true,
                            HasTub = false,
                            HasUrinal = true,
                            HasWindow = true
                        }
                    };
                    houseForRent.HasAirCondition = true;
                    houseForRent.IsSmokingAllowed = true;
                    houseForRent.Beaconings = new List<Beaconing>
                    {
                        new Beaconing {BeaconingType = BeaconingType.AirHeatPump},
                        new Beaconing {BeaconingType = BeaconingType.Block}
                    };
                    houseForRent.FreeTextAvailableFrom = "test Free text available from";
                    houseForRent.FreeTextPrice = "test free text price";
                    houseForRent.Distances = new List<Distance>
                    {
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Airport},
                        new Distance {DistanceInKm = 3, DistanceType = DistanceType.Bus},
                        new Distance {DistanceInKm = 2, DistanceType = DistanceType.ComprehensiveSchool},
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Fernbahnhof}
                    };
                    houseForRent.Sights = new List<Sight>
                    {
                        new Sight {SightType = SightType.Lake},
                        new Sight {SightType = SightType.Mountain}
                    };
                    houseForRent.GardenArea = 65;
                    houseForRent.HasAlarmSystem = true;
                    houseForRent.HasBicycleRoom = true;
                    houseForRent.HasCableDucts = true;
                    houseForRent.HasAttic = true;
                    houseForRent.Floors = new List<Floor>
                    {
                        new Floor {FloorType = FloorType.Carpet},
                        new Floor {FloorType = FloorType.DoubleFloor}
                    };
                    houseForRent.HasCableSatTv = true;
                    houseForRent.NumberOfRooms = 6;
                    houseForRent.NumberOfSeperateToilet = 12;
                    houseForRent.NumberOfLivingBedrooms = 25;
                    houseForRent.NumberOfLevels = 8;
                    houseForRent.HasCamera = false;
                    houseForRent.HasChimney = false;
                    houseForRent.HasElevator = true;
                    houseForRent.HasGermanTvByAntenna = true;
                    houseForRent.HasInternet = false;
                    houseForRent.HasPoliceCall = false;
                    houseForRent.HasRollerBlind = true;
                    houseForRent.HasLibrary = false;
                    houseForRent.HasSauna = true;
                    houseForRent.HasStorageRoom = true;
                    houseForRent.HasWinterGarden = true;
                    houseForRent.HasSwimmingPool = true;
                    houseForRent.HasWashDryingRoom = false;
                    houseForRent.HeatingCosts = 56;
                    houseForRent.Heatings = new List<Heating> {new Heating
                    {
                        HeatingType = HeatingType.Center,
                        ResidenceId = houseForRent.Id
                    }};
                    houseForRent.IncludedHotWater = true;
                    houseForRent.IsActualContractTerminated = true;
                    houseForRent.IsApartmentTower = true;
                    houseForRent.HouseNumber = "test num";
                    houseForRent.NumberOfBedrooms = 8;
                    houseForRent.NumberOfBathrooms = 3;
                    houseForRent.MinIncome = 1500;
                    houseForRent.MaxNumberOfPersons = 6;
                    houseForRent.Longitude = 8.5064826F;
                    houseForRent.Latitude = 50.1431277F;
                    houseForRent.IsBarrierFree = false;
                    houseForRent.IsConstructionYearProjected = true;
                    houseForRent.IsCurrentlyRented = false;
                    houseForRent.IsDateFlexible = true;
                    houseForRent.IsFurnished = true;
                    houseForRent.IsPetsAllowed = true;
                    houseForRent.IsHeatingCostsIncluded = false;
                    houseForRent.IsSeniorFocused = true;
                    houseForRent.IsShared = true;
                    houseForRent.IsWheelchairAccessible = false;
                    houseForRent.LastRenovationDate = DateTime.Now.AddYears(-5);
                    houseForRent.LocationDescription =
                        "Nulla ipsum velit lorem minim tempor iriure consetetur erat veniam eos delenit aliquip eirmod gubergren duis quis justo at facilisi";
                    houseForRent.PrimaryEnegySource = BeaconingType.AirHeatPump;
                    houseForRent.IsKitchenFitted = true;
                    houseForRent.IsKitchenOpen = true;
                    houseForRent.IsKitchenPantry = true;

                    houseForRent.LatestAvailableDate = DateTime.Now.AddMonths(2);
                    houseForRent.ParkingSpaces = new List<ParkingSpace>
                    {
                        new ParkingSpace
                        {
                            ParkSpaceType = ParkSpaceType.BasementGarage, Quantity = 1, RentPrice = 35,
                            ResidenceId = houseForRent.Id
                        }
                    };
                    houseForRent.ObjectTextInAnotherLanguages = new List<ObjectTextInAnotherLanguage>
                    {
                        new ObjectTextInAnotherLanguage
                        {
                            LanguageCode = "en",
                            Description =
                                "Minden hull a nincsen minden de úgy a hisz kert kincs elõl ne menedékünk a is ami szeretni és így igát egymást magára még kábít de fáj a gyalázat odataszít",
                            ListingId = houseForRent.Id
                        }
                    };
                    //houseForRent.Images = new List<Image>
                    //{
                    //    new Image {Name = "Image 1", Bytes = ImageToByte(ImageResource.image1),ListingId = houseForRent.Id},
                    //    new Image {Name = "Image 2", Bytes = ImageToByte(ImageResource.image2),ListingId = houseForRent.Id},
                    //    new Image {Name = "Image 3", Bytes = ImageToByte(ImageResource.image3),ListingId = houseForRent.Id},
                    //    new Image {Name = "Image 4", Bytes = ImageToByte(ImageResource.image4),ListingId = houseForRent.Id}
                    //};
                    houseForRent.LivingArea = 285;
                    context.SaveChanges();
                }
                #endregion
                #region Hfs
                if (!context.Listings.OfType<HouseForSale>().Any())
                {
                    var houseForSale = new HouseForSale();
                    houseForSale.UserId = user.Id;
                    houseForSale.Locationlevel3 = 1;
                    context.Listings.Add(houseForSale);
                    context.SaveChanges();

                    houseForSale.ListingHeader = "Initial House For Sale";
                    houseForSale.UserId = user.Id;
                    houseForSale.ActualContractTerminatedOn = DateTime.Now.AddDays(-5);
                    houseForSale.AdditionalCosts = 250;
                    houseForSale.AgeGroup = AgeGroup.New;
                    houseForSale.AtticSpace = 125;
                    houseForSale.BasementArea = 49;
                    houseForSale.Clearance = 540;
                    houseForSale.ClearanceText = "Test Clearence Text";
                    houseForSale.CurrentColdRent = 245;
                    houseForSale.HasSeparateToilet = true;
                    houseForSale.ConstructionYear = 1985;
                    houseForSale.CreatedBy = user.Email;
                    houseForSale.CreatedOnUTC = DateTime.Now;
                    houseForSale.DateOfIssue = DateTime.Now.AddDays(-25);
                    houseForSale.Description = "İnvidunt stet duo diam sadipscing at et et at accumsan takimata zzril dolor erat no autem diam eum imperdiet amet delenit molestie molestie amet veniam no erat ex euismod lorem";
                    houseForSale.DesignType = DesignType.ElementsOfWood;
                    houseForSale.EarliestAvailableDate = DateTime.Now.AddDays(12);
                    houseForSale.ElectricityValue = 85;
                    houseForSale.EnergyConsumptionParameter = 29;
                    houseForSale.EnvironmentDescription =
                        "Dolor sed ullamcorper kasd sed ut tempor sit ut aliquyam ut dolore labore sed labore invidunt ipsum velit est sit wisi labore vel dolor eu elitr invidunt elit accusam labore";
                    houseForSale.ConditionArtType = ConditionArtType.Abrissobject;
                    houseForSale.Epart = Epart.Consumption;
                    houseForSale.Zipcode = "Test Zipcode";
                    houseForSale.WarmnessValue = 54;
                    houseForSale.ValueRating = 47;
                    houseForSale.ValidUntil = DateTime.Now.AddDays(30);
                    houseForSale.UsefulArea = 126;
                    houseForSale.UnderGroundType = UnderGroundType.NotUnderground;
                    houseForSale.TotalArea = 256;
                    houseForSale.UltimateEnergyDemand = 168;
                    houseForSale.TypeOfUse = TypeOfUse.Living;
                    houseForSale.Tercet = "test tercet";
                    houseForSale.Street = "test street";
                    ((Listing) houseForSale).Price = 245;
                    houseForSale.OtherDetails =
                        "La ne por mi knabo renkontis pensante post etendis tiatempe boatanoj mejlojn supron sxipon ke bestoj ke vi iom fonton";
                    houseForSale.FeatureCategory = FeatureCategory.Luxury;
                    houseForSale.PublisherType = PublisherType.ActualTenant;
                    houseForSale.EnergyCertificateType = EnergyCertificateType.IsAvailable;
                    houseForSale.FurnishType = FurnishType.Full;
                    houseForSale.ShowFullAddressInPublic = true;
                    houseForSale.PropertySubType = (int)FlatType.Apartment;
                    houseForSale.OtherArea = 154;
                    houseForSale.ListingStatus = ListingStatus.Active;
                    houseForSale.Balconies = new List<Balcony>
                    {
                        new Balcony
                        {
                            Direction = GeoDirection.North,
                            BalconyType = BalconyType.Terrace,
                            Level = 3,
                            SightType = SightType.Mountain,
                            Size = 25
                        }
                    };
                    houseForSale.Bathrooms = new List<Bathroom>
                    {
                        new Bathroom
                        {
                            Size = 25,
                            HasBidet = true,
                            HasShower = true,
                            HasTub = false,
                            HasUrinal = true,
                            HasWindow = true
                        }
                    };
                    houseForSale.HasAirCondition = true;
                    houseForSale.Beaconings = new List<Beaconing>
                    {
                        new Beaconing {BeaconingType = BeaconingType.AirHeatPump},
                        new Beaconing {BeaconingType = BeaconingType.Block}
                    };
                    houseForSale.FreeTextAvailableFrom = "test Free text available from";
                    houseForSale.FreeTextPrice = "test free text price";
                    houseForSale.Distances = new List<Distance>
                    {
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Airport},
                        new Distance {DistanceInKm = 3, DistanceType = DistanceType.Bus},
                        new Distance {DistanceInKm = 2, DistanceType = DistanceType.ComprehensiveSchool},
                        new Distance {DistanceInKm = 25, DistanceType = DistanceType.Fernbahnhof}
                    };
                    houseForSale.Sights = new List<Sight>
                    {
                        new Sight {SightType = SightType.Lake},
                        new Sight {SightType = SightType.Mountain}
                    };
                    houseForSale.GardenArea = 65;
                    houseForSale.HasAlarmSystem = true;
                    houseForSale.HasBicycleRoom = true;
                    houseForSale.HasCableDucts = true;
                    houseForSale.HasAttic = true;
                    houseForSale.Floors = new List<Floor>
                    {
                        new Floor {FloorType = FloorType.Carpet},
                        new Floor {FloorType = FloorType.DoubleFloor}
                    };
                    houseForSale.HasCableSatTv = true;
                    houseForSale.NumberOfRooms = 6;
                    houseForSale.NumberOfSeperateToilet = 12;
                    houseForSale.NumberOfLivingBedrooms = 25;
                    houseForSale.NumberOfLevels = 8;
                    houseForSale.HasCamera = false;
                    houseForSale.HasChimney = false;
                    houseForSale.HasElevator = true;
                    houseForSale.HasGermanTvByAntenna = true;
                    houseForSale.HasInternet = false;
                    houseForSale.HasPoliceCall = false;
                    houseForSale.HasRollerBlind = true;
                    houseForSale.HasLibrary = false;
                    houseForSale.HasSauna = true;
                    houseForSale.HasStorageRoom = true;
                    houseForSale.HasWinterGarden = true;
                    houseForSale.HasSwimmingPool = true;
                    houseForSale.HasWashDryingRoom = false;
                    houseForSale.HeatingCosts = 56;
                    houseForSale.Heatings = new List<Heating> {new Heating
                    {
                        HeatingType = HeatingType.Center,
                        ResidenceId = houseForSale.Id
                    }};
                    houseForSale.IncludedHotWater = true;
                    houseForSale.IsActualContractTerminated = true;
                    houseForSale.IsApartmentTower = true;
                    houseForSale.HouseNumber = "test num";
                    houseForSale.NumberOfBedrooms = 8;
                    houseForSale.NumberOfBathrooms = 3;
                    houseForSale.Longitude = 8.4864826F;
                    houseForSale.Latitude = 50.1131277F;
                    houseForSale.IsBarrierFree = false;
                    houseForSale.IsConstructionYearProjected = true;
                    houseForSale.IsCurrentlyRented = false;
                    houseForSale.IsDateFlexible = true;
                    houseForSale.IsFurnished = true;
                    houseForSale.IsHeatingCostsIncluded = false;
                    houseForSale.IsSeniorFocused = true;
                    houseForSale.IsShared = true;
                    houseForSale.IsWheelchairAccessible = false;
                    houseForSale.LastRenovationDate = DateTime.Now.AddYears(-5);
                    houseForSale.LocationDescription =
                        "Nulla ipsum velit lorem minim tempor iriure consetetur erat veniam eos delenit aliquip eirmod gubergren duis quis justo at facilisi";
                    houseForSale.PrimaryEnegySource = BeaconingType.AirHeatPump;
                    houseForSale.IsKitchenFitted = true;
                    houseForSale.IsKitchenOpen = true;
                    houseForSale.IsKitchenPantry = true;

                    houseForSale.LatestAvailableDate = DateTime.Now.AddMonths(2);
                    houseForSale.ParkingSpaces = new List<ParkingSpace>
                    {
                        new ParkingSpace
                        {
                            ParkSpaceType = ParkSpaceType.BasementGarage, Quantity = 1, RentPrice = 35,
                            ResidenceId = houseForSale.Id
                        }
                    };
                    houseForSale.ObjectTextInAnotherLanguages = new List<ObjectTextInAnotherLanguage>
                    {
                        new ObjectTextInAnotherLanguage
                        {
                            LanguageCode = "en",
                            Description =
                                "Minden hull a nincsen minden de úgy a hisz kert kincs elõl ne menedékünk a is ami szeretni és így igát egymást magára még kábít de fáj a gyalázat odataszít",
                            ListingId = houseForSale.Id
                        }
                    };
                    //houseForSale.Images = new List<Image>
                    //{
                    //    new Image {Name = "Image 1", Bytes = ImageToByte(ImageResource.image1),ListingId = houseForSale.Id},
                    //    new Image {Name = "Image 2", Bytes = ImageToByte(ImageResource.image2),ListingId = houseForSale.Id},
                    //    new Image {Name = "Image 3", Bytes = ImageToByte(ImageResource.image3),ListingId = houseForSale.Id},
                    //    new Image {Name = "Image 4", Bytes = ImageToByte(ImageResource.image4),ListingId = houseForSale.Id}
                    //};
                    houseForSale.LivingArea = 285;
                    context.SaveChanges();
                }
                #endregion

                if (!context.SearchProfiles.OfType<SearchProfileFlatForRent>().Any())
                {
                    context.SearchProfiles.Add(new SearchProfileFlatForRent
                    {
                        Title = "Flat For Rent",
                        UserId = user.Id,
                        AvailableFrom = DateTime.Now.AddMonths(-1),
                        AvailableTo = DateTime.Now.AddMonths(1),
                        PriceRange = new RangedDecimalEntityNullable {From = 1250,To = 2000,Min = 0,Max = 5000},
                        ResidentialArea = new RangedDecimalEntityNullable { From = 250, To = 500, Min = 0, Max = 5000 },
                        Clients = new List<Client>
                        {
                            new Client
                            {
                                Name = "test",
                                About = "about",
                                Age = 25,
                                EmploymentStatus = EmploymentStatus.Employee,
                                Gender = Gender.Male,
                                Profession = "test profession",
                                 Headline = "headline" ,
                                 Income = 1250,
                                 Persons = new List<Person>
                                 {
                                     new Person
                                     {
                                         Gender = Gender.Female,
                                         Income = 1256,
                                         Profession = "test profession",
                                         Age = 25,
                                         EmploymentStatus = EmploymentStatus.Employee
                                     }
                                 }
                            }
                        }
                    });
                }
                if (!context.SearchProfiles.OfType<SearchProfileFlatForSale>().Any())
                {
                    context.SearchProfiles.Add(new SearchProfileFlatForSale
                    {
                        Title = "Flat For Sale",
                        UserId = user.Id,
                        AvailableFrom = DateTime.Now.AddMonths(-1),
                        AvailableTo = DateTime.Now.AddMonths(1),
                        PriceRange = new RangedDecimalEntityNullable {From = 100000,To = 200000,Min = 0,Max = 5000000},
                        Clients = new List<Client>
                        {
                            new Client
                            {
                                Name = "test",
                                About = "about",
                                Age = 25,
                                EmploymentStatus = EmploymentStatus.Employee,
                                Gender = Gender.Male,
                                Profession = "test profession",
                                 Headline = "headline" ,
                                 Income = 1250,
                                 Persons = new List<Person>
                                 {
                                     new Person
                                     {
                                         Gender = Gender.Female,
                                         Income = 1256,
                                         Profession = "test profession",
                                         Age = 25,
                                         EmploymentStatus = EmploymentStatus.Employee
                                     }
                                 }
                            }
                        }
                    });
                }
                if (!context.SearchProfiles.OfType<SearchProfileHouseForRent>().Any())
                {
                    context.SearchProfiles.Add(new SearchProfileHouseForRent
                    {
                        Title = "House For Rent",
                        UserId = user.Id,
                        AvailableFrom = DateTime.Now.AddMonths(-2),
                        AvailableTo = DateTime.Now.AddMonths(2),
                        PriceRange = new RangedDecimalEntityNullable { From = 3250, To = 10000, Min = 0, Max = 50000 },
                        PlotArea = new RangedDecimal(),
                        Clients = new List<Client>
                        {
                            new Client
                            {
                                Name = "test",
                                About = "about",
                                Age = 35,
                                EmploymentStatus = EmploymentStatus.Retired,
                                Gender = Gender.Female,
                                Profession = "test profession",
                                 Headline = "headline" ,
                                 Income = 3500,
                                 Persons = new List<Person>
                                 {
                                     new Person
                                     {
                                         Gender = Gender.Male,
                                         Income = 5000,
                                         Profession = "test profession",
                                         Age = 35,
                                         EmploymentStatus = EmploymentStatus.Employee
                                     },
                                     new Person
                                     {
                                         Gender = Gender.Male,
                                         Income = 0,
                                         Profession = "test profession",
                                         Age = 6,
                                         EmploymentStatus = EmploymentStatus.Unemployed
                                     },
                                 }
                            }
                        }
                    });
                }
                if (!context.SearchProfiles.OfType<SearchProfileHouseForSale>().Any())
                {
                    context.SearchProfiles.Add(new SearchProfileHouseForSale
                    {
                        Title = "House For Sale",
                        UserId = user.Id,
                        AvailableFrom = DateTime.Now.AddMonths(-2),
                        AvailableTo = DateTime.Now.AddMonths(2),
                        PriceRange = new RangedDecimalEntityNullable { From = 325000, To = 1000000, Min = 0, Max = 5000000 },
                        PlotArea = new RangedDecimal(),
                        Clients = new List<Client>
                        {
                            new Client
                            {
                                Name = "test",
                                About = "about",
                                Age = 35,
                                EmploymentStatus = EmploymentStatus.Retired,
                                Gender = Gender.Female,
                                Profession = "test profession",
                                 Headline = "headline" ,
                                 Income = 3500,
                                 Persons = new List<Person>
                                 {
                                     new Person
                                     {
                                         Gender = Gender.Male,
                                         Income = 5000,
                                         Profession = "test profession",
                                         Age = 35,
                                         EmploymentStatus = EmploymentStatus.Employee
                                     },
                                     new Person
                                     {
                                         Gender = Gender.Male,
                                         Income = 0,
                                         Profession = "test profession",
                                         Age = 6,
                                         EmploymentStatus = EmploymentStatus.Unemployed
                                     },
                                 }
                            }
                        }
                    });
                }
            }
        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        #endregion

        #region Add City Data

        private void AddCityData(ApplicationDbContext context)
        {
            var deustschland = context.Countries.FirstOrDefault(c=>c.Name.Equals("Deutschland"));
            if (deustschland == null) throw new ArgumentNullException(nameof(deustschland));
            var countriesList = GetAdditionalLocations();

            foreach (var item in countriesList)
            {
                var loc1 = item.State.Trim();
                var loc2 = item.Region.Trim();
                var loc3 = item.District.Trim();

                var loc1E = context.LocationLevel1.FirstOrDefault(c => c.Name.Equals(loc1) && c.ParentId == deustschland.Id);
                if (loc1E == null)
                {
                    loc1E = new LocationLevel1 { Name = loc1, ParentId = deustschland.Id };
                    context.LocationLevel1.Add(loc1E);
                    context.SaveChanges();
                }

                var loc2E = context.LocationLevel2.FirstOrDefault(c => c.Name.Equals(loc2) && c.ParentId == loc1E.Id);
                if (loc2E == null)
                {
                    loc2E = new LocationLevel2 { Name = loc2, ParentId = loc1E.Id };
                    context.LocationLevel2.Add(loc2E);
                    context.SaveChanges();
                }

                var loc3E = context.LocationLevel3.FirstOrDefault(c => c.Name.Equals(loc3) && c.ParentId == loc2E.Id);
                if (loc3E == null)
                {
                    loc3E = new LocationLevel3 { Name = loc3, ParentId = loc2E.Id };
                    context.LocationLevel3.Add(loc3E);
                    context.SaveChanges();
                }
            }
            #region Clean old cities
            var duplicates = (from l1 in context.LocationLevel1
                              join l2 in context.LocationLevel2 on l1.Id equals l2.ParentId
                              join l3 in context.LocationLevel3 on l2.Id equals l3.ParentId
                              where l1.Name == l2.Name && l2.Name == l3.Name
                              select new { l1, l2, l3 }).ToList();

            foreach (var duplicate in duplicates)
            {
                context.LocationLevel2.Remove(duplicate.l2);
                context.LocationLevel3.Remove(duplicate.l3);
            }
            #endregion
        }

        private List<AdditionalLocations> GetAdditionalLocations()
        {
            var list = new List<AdditionalLocations>();
            #region Berlin
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Berlin-Mitte", District = "Gesundbrunnen" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Berlin-Mitte", District = "Hansaviertel" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Berlin-Mitte", District = "Mitte" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Berlin-Mitte", District = "Moabit" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Berlin-Mitte", District = "Tiergarten" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Berlin-Mitte", District = "Wedding" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Charlottenburg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Charlottenburg-Nord" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Grunewald" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Halensee" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Schmargendorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Westend" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Charlottenburg - Wilmersdorf", District = "Wilmersdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Friedrichshain - Kreuzberg", District = "Friedrichshain" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Friedrichshain - Kreuzberg", District = "Kreuzberg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Alt-Hohenschönhausen" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Falkenberg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Fennpfuhl" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Friedrichsfelde" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Karlshorst" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Lichtenberg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Malchow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Neu-Hohenschönhausen" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Rummelsburg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Lichtenberg", District = "Wartenberg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Marzahn - Hellersdorf", District = "Biesdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Marzahn - Hellersdorf", District = "Hellersdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Marzahn - Hellersdorf", District = "Kaulsdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Marzahn - Hellersdorf", District = "Mahlsdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Marzahn - Hellersdorf", District = "Marzahn" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Neukölln", District = "Britz" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Neukölln", District = "Buckow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Neukölln", District = "Gropiusstadt" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Neukölln", District = "Neukölln" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Neukölln", District = "Rudow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Blankenburg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Blankenfelde" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Buch" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Französisch Buchholz" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Heinersdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Karow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Niederschönhausen" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Pankow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Prenzlauer Berg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Rosenthal" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Stadtrandsiedlung Malchow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Weißensee" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Pankow", District = "Wilhelmsruh" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Borsigwalde (← Wittenau)" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Frohnau" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Heiligensee" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Hermsdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Konradshöhe" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Lübars" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Märkisches Viertel" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Reinickendorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Tegel" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Waidmannslust" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Reinickendorf", District = "Wittenau" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Falkenhagener Feld" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Gatow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Hakenfelde" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Haselhorst" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Kladow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Siemensstadt" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Spandau" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Staaken" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Spandau", District = "Wilhelmstadt" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Dahlem" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Lankwitz" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Lichterfelde" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Nikolassee" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Steglitz" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Wannsee" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Steglitz - Zehlendorf", District = "Zehlendorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Tempelhof - Schöneberg", District = "Friedenau" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Tempelhof - Schöneberg", District = "Lichtenrade" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Tempelhof - Schöneberg", District = "Mariendorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Tempelhof - Schöneberg", District = "Marienfelde" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Tempelhof - Schöneberg", District = "Schöneberg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Tempelhof - Schöneberg", District = "Tempelhof" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Adlershof" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Altglienicke" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Alt-Treptow" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Baumschulenweg" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Bohnsdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Friedrichshagen" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Grünau" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Johannisthal" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Köpenick" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Müggelheim" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Niederschöneweide" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Oberschöneweide" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Plänterwald" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Rahnsdorf" });
            list.Add(new AdditionalLocations { State = "Berlin ", Region = "Treptow - Köpenick", District = "Schmöckwitz" });
            #endregion
            #region Bremen
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Blockland", District = "Blockland" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Blumenthal", District = "Blumenthal " });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Blumenthal", District = "Rönnebeck " });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Blumenthal", District = "Lüssum-Bockhorn" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Blumenthal", District = "Farge" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Blumenthal", District = "Rekum" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Borgfeld", District = "Katrepel" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Borgfeld", District = "Timmersloh" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Borgfeld", District = "Warf" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Borgfeld", District = "Varenmoor" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Burglesum", District = "Burg-Grambke " });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Burglesum", District = "Werderland" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Burglesum", District = "Burgdamm" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Burglesum", District = "Lesum" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Burglesum", District = "St. Magnus" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Findorff", District = "Regensburger Straße" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Findorff", District = "Findorff-Bürgerweide" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Findorff", District = "Weidedamm" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Findorff", District = "In den Hufen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Gröpelingen", District = "Gröpelingen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Gröpelingen", District = "Lindenhof" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Gröpelingen", District = "Ohlenhof" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Gröpelingen", District = "In den Wischen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Gröpelingen", District = "Oslebshausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Häfen", District = "Industriehäfen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Häfen", District = "Stadtbremisches Überseehafengebiet Bremerhaven" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Häfen", District = "Neustädter Hafen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Häfen", District = "Hohentorshafen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Hemelingen", District = "Arbergen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Hemelingen", District = "Hastedt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Hemelingen", District = "Hemelinen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Hemelingen", District = "Mahndorf" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Hemelingen", District = "Sebaldsbrück" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Horn-Lehe", District = "Horn" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Horn-Lehe", District = "Lehe" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Horn-Lehe", District = "Lehesterdeich" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Huchting", District = "Mittelshuchting" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Huchting", District = "Sodenmatt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Huchting", District = "Kirchhuchting" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Huchting", District = "Grolland" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Mitte", District = "Altstadt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Mitte", District = "Bahnhofsvorstadt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Mitte", District = "Ostertor" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Alte Neustadt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Buntentor" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Gartenstadt Süd" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Hohentor" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Huckelriede" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Neustadt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Neuenland/Flughafen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Neustadt", District = "Südervorstadt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Oberneuland", District = "Oberneuland" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Obervieland", District = "Habenhausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Obervieland", District = "Arsten" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Obervieland", District = "Kattenturm" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Obervieland", District = "Kattenesch" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Osterholz", District = "Ellener Feld " });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Osterholz", District = "Ellenerbrok-Schevemoor" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Osterholz", District = "Tenever" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Osterholz", District = "Osterholz" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Osterholz", District = "Blockdiek" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Östliche Vorstadt", District = "Steintor" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Östliche Vorstadt", District = "Fesenfeld" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Östliche Vorstadt", District = "Peterswerder" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Östliche Vorstadt", District = "Hulsberg" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Neu-Schwachhausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Bürgerpark" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Barkhof" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Riensberg" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Radio Bremen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Schwachhausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Schwachhausen", District = "Gete" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Seehausen", District = "Seehausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Strom", District = "Strom" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vahr", District = "Gartenstadt Vahr" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vahr", District = "Neue Vahr Nord" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vahr", District = "Neue Vahr Südost" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vahr", District = "Neue Vahr Südwest" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vegesack", District = "Vegesack " });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vegesack", District = "Grohn" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vegesack", District = "Schönebeck" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vegesack", District = "Aumund-Hammersbeck" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Vegesack", District = "Fähr-Lobbendorf" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Utbremen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Steffensweg" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Westend" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Walle" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Osterfeuerberg" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Hohweg" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Walle", District = "Überseestadt" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Woltmershausen", District = "Woltmershausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Woltmershausen", District = "Rablinghausen" });
            list.Add(new AdditionalLocations { State = "Bremen", Region = "Woltmershausen", District = "Seehausen" });
            #endregion
            #region darmstadt
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Mitte" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Stadtzentrum" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Rheintor/Grafenstraße" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Hochschulviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Kapellplatzviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "St. Ludwig mit Eichbergviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Nord" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Johannesviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Martinsviertel-West" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Martinsviertel-Ost" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Waldkolonie" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Mornewegviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Pallaswiesenviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Am Ziegelbusch" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Ost" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Am Oberfeld" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Mathildenhöhe" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Woogsviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "An den Lichtwiesen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Bessungen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Paulusviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Alt-Bessungen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "An der Ludwigshöhe" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-West" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Am Südbahnhof" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Heimstättensiedlung" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Verlegerviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Am Kavalleriesand" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Arheilgen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Alt-Arheilgen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Arheilgen-Süd" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Arheilgen-West" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Arheilgen-Ost" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Eberstadt" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Alt-Eberstadt" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Am Lämmchesberg" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Villenkolonie" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Am Frankenstein" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Kirchtannensiedlung" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Wixhausen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Wixhausen-West" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Wixhausen-Ost" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Kranichstein" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Kranichstein-Süd" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Kranichstein-Nord" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Darmstadt", District = "Darmstadt-Außenbezirke" });

            #endregion
            #region Dortmund
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "City" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Westfalenhalle" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Dorstfelder Brücke" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Dorstfeld" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Hafen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Nordmarkt" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Borsigplatz" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Kaiserbrunnen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Westfalendamm" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Ruhrallee" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Brechten" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Eving" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Holthausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Lindenhorst" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Derne" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Hostedde" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Kirchderne" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Kurl-Husen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Lanstrop" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Alt-Scharnhorst" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Scharnhorst-Ost" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Asseln" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Brackel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Wambel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Wickede" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Aplerbeck" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Berghofen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Schüren" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Sölde" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Sölderholz" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Benninghofen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Hacheney" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Hörde" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Holzen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Syburg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Wellinghofen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Wichlinghofen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Barop" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Bittermark" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Brünninghausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Eichlinghofen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Hombruch" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Persebeck-Kruckel-Schnee" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Kirchhörde-Löttringhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Rombergpark-Lücklemberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Menglinghausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Bövinghausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Kley" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Lütgendortmund" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Marten" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Oespel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Westrich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Deusen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Huckarde" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Jungferntal-Rahm" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Kirchlinde" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Bodelschwingh" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Mengede" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Nette" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Oestrich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Schwieringhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Dortmund", District = "Westerfilde" });

            #endregion
            #region düsseldorf
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Altstadt" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Carlstadt" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Stadtmitte" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Pempelfort" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Derendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Golzheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Flingern Süd" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Flingern Nord" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Düsseltal" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Friedrichstadt" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Unterbilk" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Hafen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Hamm" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Volmerswerth" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Bilk" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Oberbilk" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Flehe" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Oberkassel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Heerdt" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Lörick" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Niederkassel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Stockum" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Lohausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Kaiserswerth" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Wittlaer" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Angermund" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Kalkum" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Lichtenbroich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Unterrath" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Rath" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Mörsenbroich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Gerresheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Grafenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Ludenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Hubbelrath" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Knittkuhl" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Lierenfeld" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Eller" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Vennhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Unterbach" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Wersten" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Himmelgeist" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Holthausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Reisholz" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Benrath" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Urdenbach" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Itter" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Hassels" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Garath" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Düsseldorf", District = "Hellerhof" });

            #endregion
            #region Essen
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Stadtkern" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Ostviertel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Nordviertel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Westviertel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Südviertel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Südostviertel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Huttrop" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Frillendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Rüttenscheid" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Rellinghausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Bergerhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Stadtwald" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Altendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Frohnhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Holsterhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Fulerum" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Haarzopf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Margarethenhöhe" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Schönebeck" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Bedingrade" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Frintrop" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Dellwig" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Gerschede" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Borbeck-Mitte" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Bochold" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Bergeborbeck" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Altenessen-Nord" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Altenessen-Süd" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Karnap" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Vogelheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Schonnebeck" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Stoppenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Katernberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Steele" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Kray" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Freisenbruch" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Horst" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Leithe" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Heisingen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Kupferdreh" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Byfang" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Überruhr-Hinsel & Überruhr-Holthausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Burgaltendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Bredeney" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Schuir" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Werden" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Heidhausen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Fischlaken" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Essen", District = "Kettwig" });

            #endregion
            #region Frankfurt Am main
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Altstadt" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Bahnhofsviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Bergen-Enkheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Berkersheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Bockenheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Bonames" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Bornheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Dornbusch" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Eckenheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Eschersheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Fechenheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Flughafen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Frankfurter Berg" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Gallus" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Ginnheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Griesheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Gutleutviertel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Harheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Hausen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Heddernheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Höchst" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Innenstadt" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Kalbach-Riedberg" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Nied" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Nieder-Erlenbach" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Nieder-Eschbach" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Niederrad" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Niederursel" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Nordend-Ost" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Nordend-West" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Oberrad" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Ostend" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Praunheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Preungesheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Riederwald" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Rödelheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Sachsenhausen-Nord" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Sachsenhausen-Süd" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Schwanheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Seckbach" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Sindlingen" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Sossenheim" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Unterliederbach" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Westend-Nord" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Westend-Süd" });
            list.Add(new AdditionalLocations { State = "Hessen", Region = "Frankfurt am Main", District = "Zeilsheim" });

            #endregion
            #region hamburg
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Altona-Altstadt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Altona-Nord" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Bahrenfeld" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Blankenese" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Groß Flottbek" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Iserbrook" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Lurup" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Nienstedten (mit Klein Flottbek)" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Osdorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Othmarschen" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Ottensen" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Rissen" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Sternschanze" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Altona", District = "Sülldorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Allermöhe" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Altengamme" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Bergedorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Billwerder" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Curslack" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Kirchwerder" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Lohbrügge" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Moorfleet" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Neuallermöhe" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Neuengamme" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Ochsenwerder" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Reitbrook" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Spadenland" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Bergedorf", District = "Tatenberg" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Eidelstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Eimsbüttel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Harvestehude" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Hoheluft-West" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Lokstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Niendorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Rotherbaum" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Schnelsen" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Eimsbüttel", District = "Stellingen" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Billbrook" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Billstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Borgfelde" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Finkenwerder" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "HafenCity" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Hamburg-Altstadt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Hamm" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Hammerbrook" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Horn" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Kleiner Grasbrook" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Neustadt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Neuwerk (Insel)" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Rothenburgsort" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Steinwerder" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "St. Georg" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "St. Pauli" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Veddel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Waltershof " });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Mitte", District = "Wilhelmsburg " });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Alsterdorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Barmbek-Nord" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Barmbek-Süd" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "City Nord" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Dulsberg" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Eppendorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Fuhlsbüttel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Groß Borstel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Hoheluft-Ost" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Hohenfelde" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Langenhorn" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Ohlsdorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Uhlenhorst" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Hamburg-Nord", District = "Winterhude" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Altenwerder" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Cranz" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Eißendorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Francop" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Gut Moor" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Harburg" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Hausbruch" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Heimfeld" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Langenbek " });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Marmstorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Moorburg" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Neuenfelde" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Neugraben-Fischbek" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Neuland" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Rönneburg" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Sinstorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Harburg", District = "Wilstorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Bergstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Bramfeld" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Duvenstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Eilbek" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Farmsen-Berne" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Hummelsbüttel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Jenfeld" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Lemsahl-Mellingstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Marienthal" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Poppenbüttel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Rahlstedt" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Sasel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Steilshoop" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Tonndorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Volksdorf" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Wandsbek" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Wellingsbüttel" });
            list.Add(new AdditionalLocations { State = "Hamburg", Region = "Wandsbek", District = "Wohldorf-Ohlstedt" });

            #endregion
            #region Köln
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Altstadt-Süd" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Neustadt-Süd" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Altstadt-Nord" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Neustadt-Nord" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Deutz" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Bayenthal" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Marienburg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Raderberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Raderthal" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Zollstock" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Rondorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Hahnwald" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Rodenkirchen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Weiß" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Sürth" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Godorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Immendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Meschenich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Klettenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Sülz" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Lindenthal" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Braunsfeld" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Junkersdorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Müngersdorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Weiden" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Lövenich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Widdersdorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Ehrenfeld" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Neuehrenfeld" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Bickendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Vogelsang" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Bocklemünd/Mengenich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Ossendorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Nippes" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Mauenheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Riehl" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Weidenpesch" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Longerich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Niehl" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Bilderstöckchen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Merkenich" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Fühlingen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Seeberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Heimersdorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Lindweiler" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Pesch" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Esch/Auweiler" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Volkhoven/Weiler" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Chorweiler" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Blumenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Roggendorf/Thenhoven" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Worringen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Poll" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Westhoven" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Ensen" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Gremberghoven" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Eil" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Porz" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Urbach" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Elsdorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Grengel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Wahnheide" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Wahn" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Lind" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Libur" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Zündorf" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Langel" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Finkenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Humboldt/Gremberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Kalk" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Vingst" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Höhenberg" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Ostheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Merheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Brück" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Rath/Heumar" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Neubrück" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Mülheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Buchforst" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Buchheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Holweide" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Dellbrück" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Höhenhaus" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Dünnwald" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Stammheim" });
            list.Add(new AdditionalLocations { State = "Nordrhein-Westfalen", Region = "Köln", District = "Flittard" });

            #endregion
            #region Stuttgart
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Oberer Schlossgarten" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rathaus" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Neue Vorstadt" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Universität" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Europaviertel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hauptbahnhof" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Kernerviertel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Diemershalde" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Dobel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Heusteigviertel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Relenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Lenzhalde" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Am Bismarckturm" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Killesberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Weißenhof" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Nordbahnhof" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Am Pragfriedhof" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Am Rosensteinpark" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Auf der Prag" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Mönchhalde" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Heilbronner Straße" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Gänsheide" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Uhlandshöhe" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Stöckach" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Berg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Ostheim" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Gaisburg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Gablenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Frauenkopf" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Bopser" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Lehen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Weinsteige" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Karlshöhe" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Heslach" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Südheim" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Kaltental" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Kräherwald" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hölderlinplatz" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rosenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Feuersee" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rotebühl" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Vogelsang" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hasenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Wildpark" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Solitude" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Muckensturm" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Schmidener Vorstadt" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Espan" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Kurpark" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Cannstatt-Mitte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Seelberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Winterhalde" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Wasen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Veielbrunnen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Im Geiger" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Neckarvorstadt" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Pragstraße" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Altenburg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hallschlag" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Birkenäcker" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Burgholzhof" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Sommerrain" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Steinhaldenfeld" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Birkach-Nord" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Birkach-Süd" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Schönberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Botnang-Nord" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Botnang-Ost" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Botnang-Süd" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Botnang-West" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Degerloch" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Waldau" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Tränke" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Haigst" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hoffeld" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Feuerbach-Ost" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Siegelberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Bahnhof Feuerbach" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Feuerbach-Mitte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Lemberg/Föhrich" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hohe Warte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Feuerbacher Tal" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "An der Burg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hedelfingen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hafen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Lederberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rohracker" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Möhringen-Nord" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Möhringen-Mitte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Wallgraben-Ost" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Möhringen-Süd" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Möhringen-Ost" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Sternhäule" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Fasanenhof-Ost" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Fasanenhof" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Sonnenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Mühlhausen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Freiberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Mönchfeld" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hofen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Neugereut" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = " Münster" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Obertürkheim" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Uhlbach" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Plieningen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Chausseefeld" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Steckfeld" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Asemwald" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hohenheim" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Sillenbuch" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Heumaden" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Riedenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Stammheim-Süd" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Stammheim-Mitte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Gehrenwald" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Flohberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Untertürkheim" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Benzviertel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Lindenschulviertel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Bruckwiesen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Luginsland" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rotenberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Vaihingen-Mitte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Österfeld" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Höhenrand" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Wallgraben-West" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rosental" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Heerstraße" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Lauchäcker" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Dachswald" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Pfaffenwald" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Büsnau" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rohr" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Dürrlewang" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Wangen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Weilimdorf" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Weilimdorf-Nord" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Bergheim" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Giebel" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Hausen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Wolfbusch" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Am Stadtpark" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Schützenbühl" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Elbelen" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Frauensteg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Mitte" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Hohenstein" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Mönchsberg" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zuffenhausen-Im Raiser" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Neuwirtshaus" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Rot" });
            list.Add(new AdditionalLocations { State = "Baden-Württemberg", Region = "Stuttgart", District = "Zazenhausen" });

            #endregion
            return list;
        }

        #endregion
    }

    public class AdditionalLocations
    {
        public string State { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
    }
}
