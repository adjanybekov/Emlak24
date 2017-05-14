using System.Collections.Generic;
using System.Linq;
using System;
using Wohnungstausch24.Core.Files;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.Images;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.House;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.House;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Common;
using Wohnungstausch24.Models.ViewModels.Listings;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Room;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Room;
using Wohnungstausch24.Models.ViewModels.Search.BasicSearch;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Land;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class ListingService : IListingService
    {
        private readonly ApplicationDbContext _dbContext;
        private IListingSecurityService _listingSecurityService;
        private readonly IAutoMapper _autoMapper;

        public ListingService(ApplicationDbContext dbContext, IAutoMapper autoMapper, IListingSecurityService listingSecurityService)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
            _listingSecurityService = listingSecurityService;
        }

        public ListingsDisplayViewModel GetMyListingsByUserId(string userId, int? page, int? itemsPerPage)
        {
            var userIds = new List<string> {userId};

            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId.Equals(userId));
            if (agency != null)
            {
                userIds.AddRange(agency.Agents.Select(c=>c.UserId).ToList());
            }

            var listings = from listing in _dbContext.Listings where userIds.Any(c=>c.Equals(listing.UserId)) select listing;

            ListingsDisplayViewModel model = new ListingsDisplayViewModel();
            model.Pager = new Pager(listings.Count(), page, itemsPerPage);

            ICollection<SummaryViewModel> curlistings = ((from listing in listings
                    join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                    join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                    join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                    join country in _dbContext.Countries on loc1.ParentId equals country.Id
                    orderby listing.Id
                    select new SummaryViewModel
                    {
                        Id = listing.Id,
                        LocationLevel1 = loc1.Name,
                        LocationLevel2 = loc2.Name,
                        LocationLevel3 = loc3.Name,
                        Country = country.Name,
                        TypeOfMerchandising =(listing is FlatForRent || listing is HouseForRent || listing is RoomForRent) ? TypeOfMerchandising.Rent: TypeOfMerchandising.Sale,
                        TypeOfUse = listing.TypeOfUse,
                        ListingHeader = listing.ListingHeader,
                        Price = listing.Price,
                        Description = listing.Description,
                        TotalArea = listing.TotalArea,
                        Street = listing.Street,
                        Latitude = listing.Latitude,
                        Longitude = listing.Longitude,
                        CreatedOnUtc = listing.CreatedOnUTC,
                        ListingStatus = listing.ListingStatus,
                        Files = listing.Files.Select(c => new FileDto
                        {
                            Id = c.Id,
                            Name = c.File.Name,
                            FileUrl = c.File.RelativePath,
                            ThumbnailUrl = c.File.ThumbnailPath,
                            Filetype = c.File.Filetype,
                            Mime = c.File.Mime,
                            Extension = c.File.Extension
                        }).ToList(),
                        PropertyType = (listing is Room)? PropertyType.WazRoom:(listing is Flat)? PropertyType.Flat: (listing is Land) ? PropertyType.Land : PropertyType.House,
                        Owner = userIds.Count>1?listing.User.Email:""
                    })).Skip((model.Pager.CurrentPage - 1) * model.Pager.ItemsPerPage).Take(model.Pager.ItemsPerPage)
                .ToList();

            model.Items = curlistings.ToList();
            return model;
        }

        public ICollection<SummaryViewModel> GetAll()
        {
            return (from listing in _dbContext.Listings
                join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                join country in _dbContext.Countries on loc1.ParentId equals country.Id
                select new SummaryViewModel
                {
                    Id = listing.Id,
                    LocationLevel1 = loc1.Name,
                    LocationLevel2 = loc2.Name,
                    LocationLevel3 = loc3.Name,
                    Country = country.Name,
                    TypeOfMerchandising =
                        (listing is FlatForRent || listing is HouseForRent || listing is RoomForRent)
                            ? TypeOfMerchandising.Rent
                            : TypeOfMerchandising.Sale,
                    TypeOfUse = listing.TypeOfUse,
                    ListingHeader = listing.ListingHeader,
                    Price = listing.Price,
                    Description = listing.Description,
                    TotalArea = listing.TotalArea,
                    Street = listing.Street,
                    Latitude = listing.Latitude,
                    Longitude = listing.Longitude,
                    CreatedOnUtc = listing.CreatedOnUTC,
                    ListingStatus = listing.ListingStatus,
                    Files = listing.Files.Select(c => new FileDto
                    {
                        Id = c.Id,
                        Name = c.File.Name,
                        FileUrl = c.File.RelativePath,
                        ThumbnailUrl = c.File.ThumbnailPath,
                        Filetype = c.File.Filetype,
                        Mime = c.File.Mime,
                        Extension = c.File.Extension
                    }).ToList(),
                    PropertyType =
                        (listing is Room)
                            ? PropertyType.WazRoom:(listing is Flat)
                            ? PropertyType.Flat
                            : (listing is Land) ? PropertyType.Land : PropertyType.House
                }).ToList();
        }

        public ICollection<ObjectData> GetAllForHomePage()
        {
            return (from listing in _dbContext.Listings where listing.ShowFullAddressInPublic == true
                join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                join country in _dbContext.Countries on loc1.ParentId equals country.Id
                select new ObjectData
                {
                    address = listing.HouseNumber + listing.Street + loc3.Name + loc2.Name + loc1.Name,
                    image = listing.Files.Select(c => c.Id).FirstOrDefault().ToString(),
                    type =
                        (listing is FlatForRent || listing is HouseForRent)
                            ? TypeOfMerchandising.Rent.ToString()
                            : TypeOfMerchandising.Sale.ToString(),
                    area = listing.TotalArea.ToString(),
                    bedrooms = listing.ListingHeader,
                    price = listing.Price.ToString(),
                    lat = listing.Latitude.ToString(),
                    lng = listing.Longitude.ToString(),
                    id = listing.Id
                }).ToList();
        }

        public BasicSearchViewModel Search(BasicSearchViewModel model)
        {
            var selectedLocationIds = (from loc2 in model.Locations
                               let children = loc2.Children
                               from loc3 in children where loc3.Selected select loc3.Id).ToList();
            IQueryable<Listing> query = (from listing in _dbContext.Listings.Where(c=> !selectedLocationIds.Any() ||  selectedLocationIds.Any(l=>l == c.Locationlevel3))
                join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                where
                (listing.Price >= model.PriceFrom || model.PriceFrom == 0)
                && (listing.Price <= model.PriceTo || model.PriceTo == 0)
                select listing);

            IQueryable<Residence> residenceResultSet = null;
            TypeOfMerchandising? typeOfMerchandising = null;

            if (model.SelectedPropertyType == PropertyType.Flat || model.SelectedPropertyType == PropertyType.House)
            {
                if (model.SelectedPropertyType == PropertyType.Flat && model.SelectedTypeOfMerchandising == TypeOfMerchandising.Rent)
                {
                    residenceResultSet = query.OfType<FlatForRent>();
                    typeOfMerchandising = TypeOfMerchandising.Rent;
                }
                if (model.SelectedPropertyType == PropertyType.Flat && model.SelectedTypeOfMerchandising == TypeOfMerchandising.Sale)
                {
                    residenceResultSet = query.OfType<FlatForSale>();
                    typeOfMerchandising = TypeOfMerchandising.Sale;
                }
                if (model.SelectedPropertyType == PropertyType.House && model.SelectedTypeOfMerchandising == TypeOfMerchandising.Rent)
                {
                    residenceResultSet = query.OfType<HouseForRent>();
                    typeOfMerchandising = TypeOfMerchandising.Rent;
                }
                if (model.SelectedPropertyType == PropertyType.House && model.SelectedTypeOfMerchandising == TypeOfMerchandising.Sale)
                {
                    residenceResultSet = query.OfType<HouseForSale>();
                    typeOfMerchandising = TypeOfMerchandising.Sale;
                }

                model.SummaryViewModels =
                (from listing in residenceResultSet
                 join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                 join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                 join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                 join country in _dbContext.Countries on loc1.ParentId equals country.Id
                 where (listing.LivingArea >= model.AreaFrom || model.AreaFrom == 0) && (listing.LivingArea <= model.AreaTo || model.AreaTo == 0)
                 select new SummaryViewModel
                 {
                     LocationLevel1 = loc1.Name,
                     LocationLevel2 = loc2.Name,
                     LocationLevel3 = loc3.Name,
                     Country = country.Name,
                     TypeOfUse = listing.TypeOfUse,
                     ListingHeader = listing.ListingHeader,
                     Price = listing.Price,
                     Description = listing.Description,
                     TotalArea = listing.TotalArea,
                     Street = listing.Street,
                     Latitude = listing.Latitude,
                     Longitude = listing.Longitude,
                     CreatedOnUtc = listing.CreatedOnUTC,
                     ListingStatus = listing.ListingStatus,
                     Files = listing.Files.Select(c => new FileDto
                     {
                         Id = c.Id,
                         Name = c.File.Name,
                         FileUrl = c.File.RelativePath,
                         ThumbnailUrl = c.File.ThumbnailPath,
                         Filetype = c.File.Filetype,
                         Mime = c.File.Mime,
                         Extension = c.File.Extension
                     }).ToList(),
                     Id = listing.Id,
                     TypeOfMerchandising = typeOfMerchandising
                 }).ToList();

            }
            else
            {
                IQueryable<Land> landResultSet = null;
                if (model.SelectedTypeOfMerchandising == TypeOfMerchandising.Sale)
                {
                    landResultSet = query.OfType<LandForSale>();
                    typeOfMerchandising = TypeOfMerchandising.Sale;
                }
                model.SummaryViewModels = (from listing in landResultSet
                    join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                    join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                    join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                    join country in _dbContext.Countries on loc1.ParentId equals country.Id
                    where
                    (listing.TotalArea >= model.AreaFrom || model.AreaFrom == 0) &&
                    (listing.TotalArea <= model.AreaTo || model.AreaTo == 0)
                    select new SummaryViewModel
                    {
                        LocationLevel1 = loc1.Name,
                        LocationLevel2 = loc2.Name,
                        LocationLevel3 = loc3.Name,
                        Country = country.Name,
                        TypeOfUse = listing.TypeOfUse,
                        ListingHeader = listing.ListingHeader,
                        Price = listing.Price,
                        Description = listing.Description,
                        TotalArea = listing.TotalArea,
                        Street = listing.Street,
                        Latitude = listing.Latitude,
                        Longitude = listing.Longitude,
                        CreatedOnUtc = listing.CreatedOnUTC,
                        ListingStatus = listing.ListingStatus,
                        Files = listing.Files.Where(c => c.File.Filetype == Wt24FileType.Image).Select(c => new FileDto
                        {
                            Id = c.Id,
                            Name = c.File.Name,
                            FileUrl = c.File.RelativePath,
                            ThumbnailUrl = c.File.ThumbnailPath,
                            Filetype = c.File.Filetype,
                            Mime = c.File.Mime,
                            Extension = c.File.Extension
                        }).ToList(),
                        Id = listing.Id,
                        TypeOfMerchandising =  typeOfMerchandising
                    }).ToList();
            }
            return model;
        }

        public List<SummaryViewModel> DetailedSearch(DetailedSearchResultsModel model)
        {
            DetailedSearchListing detailedSearchListing = new DetailedSearchFlatForRent();
            TypeOfMerchandising? typeOfMerchandising = null;

            var result = new List<SummaryViewModel>();

            var selectedLocationIds = (from loc2 in model.Locations
                                       let children = loc2.Children
                                       from loc3 in children
                                       where loc3.Selected
                                       select loc3.Id).ToList();

            IQueryable<Listing> query = (from listing in _dbContext.Listings.Where(c => !selectedLocationIds.Any() || selectedLocationIds.Any(l => l == c.Locationlevel3))
                                         join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                                         select listing);

            if (model.DetailedSearchFlatForRent != null)
            {
                detailedSearchListing = model.DetailedSearchFlatForRent;
                typeOfMerchandising = TypeOfMerchandising.Rent;
                query = query.Where(c => c is FlatForRent);
            }
            if (model.DetailedSearchFlatForSale != null)
            {
                detailedSearchListing = model.DetailedSearchFlatForSale;
                typeOfMerchandising = TypeOfMerchandising.Sale;
                query = query.Where(c => c is FlatForSale);
            }
            if (model.DetailedSearchHouseForRent != null)
            {
                detailedSearchListing = model.DetailedSearchHouseForRent;
                typeOfMerchandising = TypeOfMerchandising.Rent;
                query = query.Where(c => c is HouseForRent); ;
            }
            if (model.DetailedSearchHouseForSale != null)
            {
                detailedSearchListing = model.DetailedSearchHouseForSale;
                typeOfMerchandising = TypeOfMerchandising.Sale;
                query = query.Where(c => c is HouseForSale);
            }
            if (model.DetailedSearchLandForSale != null)
            {
                detailedSearchListing = model.DetailedSearchLandForSale;
                typeOfMerchandising = TypeOfMerchandising.Sale;
                query = query.Where(c => c is LandForSale);
            }
            query = from listing in query
                where
                (detailedSearchListing.PriceRange.IsMinSelected || listing.Price >= detailedSearchListing.PriceRange.Min) &&
                (detailedSearchListing.PriceRange.IsMaxSelected || listing.Price <= detailedSearchListing.PriceRange.Max)
                select listing;

            if (detailedSearchListing is DetailedSearchResidence)
            {
                var detailedSearchResidence = detailedSearchListing as DetailedSearchResidence;
                var selectedFeatureCategories = detailedSearchResidence.FeatureCategoryViewModels.Where(c => c.Selected).Select(c => c.FeatureCategory).ToList();
                var selectedFloors = detailedSearchResidence.FloorViewModels.Where(c => c.Selected).Select(c => c.FloorType).ToList();
                var selectedBeaconings = detailedSearchResidence.BeaconingTypeViewModels.Where(c => c.Selected).Select(c => c.BeaconingType).ToList();
                var selectedHeatings = detailedSearchResidence.HeatingTypeViewModels.Where(c => c.Selected).Select(c => c.HeatingType).ToList();
                var selectedParkings = detailedSearchResidence.ParkSpaceTypeViewModels.Where(c => c.Selected).Select(c => c.ParkSpaceType).ToList();
                var selectedBalconyDirections = detailedSearchResidence.AdjustmentBalconyTerrace.Where(c => c.Selected).Select(c => c.GeoDirection).ToList();
                var selectedSightTypes = detailedSearchResidence.SightTypeViewModels.Where(c => c.Selected).Select(c => c.SightType).ToList();

                query = from residence in query.OfType<Residence>()
                        let balconyTerraceArea = residence.Balconies.Sum(c => c.Size)
                        let parkingLots = residence.ParkingSpaces.Sum(c => c.Quantity)
                        where
                        #region Residence Booleans
                        (!detailedSearchResidence.IsSharePossible || (residence.IsShared ?? false)) &&
                        (!detailedSearchResidence.HasChimney || (residence.HasChimney ?? false)) &&
                        (!detailedSearchResidence.HasAirCondition || (residence.HasAirCondition ?? false)) &&
                        (!detailedSearchResidence.HasElevator || (residence.HasElevator ?? false)) &&
                        (!detailedSearchResidence.HasGardenUtilization || residence.GardenArea > 0) &&
                        (!detailedSearchResidence.IsWheelchairAccessible || (residence.IsWheelchairAccessible ?? false)) &&
                        (!detailedSearchResidence.HasCableSatTv || (residence.HasCableSatTv ?? false)) &&
                        (!detailedSearchResidence.HasGermanTvByAntenna || (residence.HasGermanTvByAntenna ?? false)) &&
                        (!detailedSearchResidence.HasBarrierFree || (residence.IsBarrierFree ?? false)) &&
                        (!detailedSearchResidence.HasSauna || (residence.HasSauna ?? false)) &&
                        (!detailedSearchResidence.HasSwimmingPool || (residence.HasSwimmingPool ?? false)) &&
                        (!detailedSearchResidence.HasWashDryingRoom || (residence.HasWashDryingRoom ?? false)) &&
                        (!detailedSearchResidence.HasWinterGarden || (residence.HasWinterGarden ?? false)) &&
                        (!detailedSearchResidence.HasStorageRoom || (residence.HasStorageRoom ?? false)) &&
                        (!detailedSearchResidence.HasBicycleRoom || (residence.HasBicycleRoom ?? false)) &&
                        (!detailedSearchResidence.HasRollerBlind || (residence.HasRollerBlind ?? false)) &&
                        (!detailedSearchResidence.HasGuestToilet || (residence.HasGuestToilet ?? false)) &&
                        (!detailedSearchResidence.HasCableDucts || (residence.HasCableDucts ?? false)) &&
                        (!detailedSearchResidence.IsSeniorFocused || (residence.IsSeniorFocused ?? false)) &&
                        (!detailedSearchResidence.HasApprovalOfAddress || (residence.ShowFullAddressInPublic ?? false)) &&
                        (!detailedSearchResidence.HasBalcony || residence.Balconies.Count > 0) &&
                        #endregion
                        #region Others
                        //Bathroom
                        (!detailedSearchResidence.HasBidet  || residence.Bathrooms.Any(c=> c.HasBidet??false)) &&
                        (!detailedSearchResidence.HasShower || residence.Bathrooms.Any(c=> c.HasShower??false)) &&
                        (!detailedSearchResidence.HasTub    || residence.Bathrooms.Any(c=> c.HasTub??false)) &&
                        (!detailedSearchResidence.HasUrinal || residence.Bathrooms.Any(c=> c.HasUrinal??false)) &&
                        (!detailedSearchResidence.HasWindow || residence.Bathrooms.Any(c=> c.HasWindow??false)) &&
                        //Kitchen
                        (!detailedSearchResidence.IsKitchenFitted || (residence.IsKitchenFitted ?? false)) &&
                        (!detailedSearchResidence.IsKitchenOpen   || (residence.IsKitchenOpen ?? false)) &&
                        (!detailedSearchResidence.IsKitchenPantry || (residence.IsKitchenPantry ?? false)) &&
                        #endregion

                        #region Multi select lists
                        (selectedFeatureCategories.Count == 0 || selectedFeatureCategories.Any(c => c == residence.FeatureCategory)) &&
                        (selectedFloors.Count == 0 || !selectedFloors.Except(residence.Floors.Select(f => f.FloorType)).Any()) &&
                        (selectedBeaconings.Count == 0 || !selectedBeaconings.Except(residence.Beaconings.Select(f => f.BeaconingType ?? 0)).Any()) &&
                        (selectedHeatings.Count == 0 || !selectedHeatings.Except(residence.Heatings.Select(f => f.HeatingType ?? 0)).Any()) &&
                        (selectedParkings.Count == 0 || !selectedParkings.Except(residence.ParkingSpaces.Select(f => f.ParkSpaceType ?? 0)).Any()) &&
                        (selectedParkings.Count == 0 || !selectedParkings.Except(residence.ParkingSpaces.Select(f => f.ParkSpaceType ?? 0)).Any()) &&
                        (selectedSightTypes.Count == 0 || !selectedSightTypes.Except(residence.Sights.Select(f => f.SightType ?? 0)).Any()) &&
                        //todo: check direction
                        (selectedBalconyDirections.Count == 0 || !selectedBalconyDirections.Except(residence.Balconies.Select(f => f.Direction ?? 0)).Any()) &&
                        (selectedSightTypes.Count == 0 || !selectedSightTypes.Except(residence.Sights.Select(f => f.SightType ?? 0)).Any()) &&
                        #endregion
                        ((detailedSearchResidence.YearOfConstruction.IsMinSelected || detailedSearchResidence.YearOfConstruction.From <= residence.ConstructionYear) && (detailedSearchResidence.YearOfConstruction.IsMaxSelected || detailedSearchResidence.YearOfConstruction.To >= residence.ConstructionYear)) &&
                        ((detailedSearchResidence.ResidentialArea.IsMinSelected  || detailedSearchResidence.ResidentialArea.From <= residence.LivingArea) && (detailedSearchResidence.ResidentialArea.IsMaxSelected || detailedSearchResidence.ResidentialArea.To >= residence.LivingArea)) &&
                        ((detailedSearchResidence.BalconyTerraceArea.IsMinSelected || detailedSearchResidence.BalconyTerraceArea.From <= balconyTerraceArea) && (detailedSearchResidence.BalconyTerraceArea.IsMaxSelected || detailedSearchResidence.BalconyTerraceArea.To >= balconyTerraceArea))&&
                        ((detailedSearchResidence.GardenArea.IsMinSelected || detailedSearchResidence.GardenArea.From <= residence.GardenArea) && (detailedSearchResidence.GardenArea.IsMaxSelected || detailedSearchResidence.GardenArea.To >= residence.GardenArea))&&
                        ((detailedSearchResidence.NumberOfLivingRooms.IsMinSelected || detailedSearchResidence.NumberOfLivingRooms.From <= residence.NumberOfLivingBedrooms) && (detailedSearchResidence.NumberOfLivingRooms.IsMaxSelected || detailedSearchResidence.NumberOfLivingRooms.To >= residence.NumberOfRooms))&&
                        ((detailedSearchResidence.NumberOfBathRooms.IsMinSelected || detailedSearchResidence.NumberOfBathRooms.From <= residence.NumberOfBathrooms) && (detailedSearchResidence.NumberOfBathRooms.IsMaxSelected || detailedSearchResidence.NumberOfBathRooms.To >= residence.NumberOfBathrooms))&&
                        ((detailedSearchResidence.NumberOfParkingLots.IsMinSelected || detailedSearchResidence.NumberOfParkingLots.From <= parkingLots) && (detailedSearchResidence.NumberOfParkingLots.IsMaxSelected || detailedSearchResidence.NumberOfParkingLots.To >= parkingLots))&&
                        (detailedSearchResidence.IsDateFlexible || (detailedSearchResidence.AvailableFrom==null || detailedSearchResidence.AvailableFrom >= residence.EarliestAvailableDate) && (detailedSearchResidence.AvailableTo == null || detailedSearchResidence.AvailableTo <= residence.LatestAvailableDate))
                        select residence;

                if (detailedSearchResidence is DetailedSearchFlat)
                {
                    var detailedSearchFlat = detailedSearchResidence as DetailedSearchFlat;
                    query = from flat in query.OfType<Flat>()
                            where
                            ((detailedSearchFlat.Level.From <= flat.Level || detailedSearchFlat.Level.IsMinSelected) && (detailedSearchFlat.Level.To >= flat.CurrentColdRent || detailedSearchFlat.Level.IsMaxSelected)) &&
                            ((detailedSearchFlat.NumberOfLevels.From <= flat.NumberOfLevels || detailedSearchFlat.NumberOfLevels.IsMinSelected) && (detailedSearchFlat.NumberOfLevels.To >= flat.CurrentColdRent || detailedSearchFlat.NumberOfLevels.IsMaxSelected))
                            select flat;

                    if (detailedSearchFlat is DetailedSearchFlatForRent)
                    {
                        var detailedSearchFFr = detailedSearchFlat as DetailedSearchFlatForRent;
                        query = from flatForRent in query.OfType<FlatForRent>()
                                where
                                (!detailedSearchFFr.IsSmokingAllowed || (flatForRent.IsSmokingAllowed ?? false)) &&
                                (!detailedSearchFFr.IsPetsAllowed || (flatForRent.IsPetsAllowed ?? false))
                                select flatForRent;
                    }
                }



                result = (from listing in query.OfType<Residence>()
                join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                join country in _dbContext.Countries on loc1.ParentId equals country.Id

                select new SummaryViewModel
                {
                    LocationLevel1 = loc1.Name,
                    LocationLevel2 = loc2.Name,
                    LocationLevel3 = loc3.Name,
                    Country = country.Name,
                    TypeOfUse = listing.TypeOfUse,
                    ListingHeader = listing.ListingHeader,
                    Price = listing.Price,
                    Description = listing.Description,
                    TotalArea = listing.TotalArea,
                    Street = listing.Street,
                    Latitude = listing.Latitude,
                    Longitude = listing.Longitude,
                    CreatedOnUtc = listing.CreatedOnUTC,
                    ListingStatus = listing.ListingStatus,
                    Files = listing.Files.Select(c => new FileDto
                    {
                        Id = c.Id,
                        Name = c.File.Name,
                        FileUrl = c.File.RelativePath,
                        ThumbnailUrl = c.File.ThumbnailPath,
                        Filetype = c.File.Filetype,
                        Mime = c.File.Mime,
                        Extension = c.File.Extension
                    }).ToList(),
                    Id = listing.Id,
                    TypeOfMerchandising = typeOfMerchandising
                }).ToList();
            }
            else
            {
                result = (from listing in query.OfType<Land>()
                          join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                          join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                          join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                          join country in _dbContext.Countries on loc1.ParentId equals country.Id
                          select new SummaryViewModel
                          {
                              LocationLevel1 = loc1.Name,
                              LocationLevel2 = loc2.Name,
                              LocationLevel3 = loc3.Name,
                              Country = country.Name,
                              TypeOfUse = listing.TypeOfUse,
                              ListingHeader = listing.ListingHeader,
                              Price = listing.Price,
                              Description = listing.Description,
                              TotalArea = listing.TotalArea,
                              Street = listing.Street,
                              Latitude = listing.Latitude,
                              Longitude = listing.Longitude,
                              CreatedOnUtc = listing.CreatedOnUTC,
                              ListingStatus = listing.ListingStatus,
                              Files = listing.Files.Where(c => c.File.Filetype == Wt24FileType.Image).Select(c => new FileDto
                              {
                                  Id = c.Id,
                                  Name = c.File.Name,
                                  FileUrl = c.File.RelativePath,
                                  ThumbnailUrl = c.File.ThumbnailPath,
                                  Filetype = c.File.Filetype,
                                  Mime = c.File.Mime,
                                  Extension = c.File.Extension
                              }).ToList(),
                              Id = listing.Id,
                              TypeOfMerchandising = typeOfMerchandising
                          }).ToList();
            }
            return result;
        }

        public DetailListing GetById(int id)
        {
            var genericListing = _dbContext.Listings.Find(id);

            #region Get base properties for listing
            var detailListing = (from listing in _dbContext.Listings
                                 where listing.Id == id
                                 join loc3 in _dbContext.LocationLevel3 on listing.Locationlevel3 equals loc3.Id
                                 join loc2 in _dbContext.LocationLevel2 on loc3.ParentId equals loc2.Id
                                 join loc1 in _dbContext.LocationLevel1 on loc2.ParentId equals loc1.Id
                                 join country in _dbContext.Countries on loc1.ParentId equals country.Id
                                 join user in _dbContext.Users on listing.UserId equals user.Id
                                 join a in _dbContext.Agents on user.Id equals a.UserId into agents
                                 from agent in agents.DefaultIfEmpty()
                                 select new DetailListing
                                 {
                                     Id = listing.Id,
                                     LocationLevel1 = loc1.Name,
                                     LocationLevel2 = loc2.Name,
                                     LocationLevel3 = loc3.Name,
                                     Country = country.Name,
                                     TypeOfUse = listing.TypeOfUse,
                                     ListingHeader = listing.ListingHeader,
                                     Price = listing.Price,
                                     Description = listing.Description,
                                     TotalArea = listing.TotalArea,
                                     PlotArea = listing.PlotArea,
                                     Street = listing.Street,
                                     HouseNo = listing.HouseNumber,
                                     Latitude = listing.Latitude,
                                     Longitude = listing.Longitude,
                                     CreatedOnUtc = listing.CreatedOnUTC,
                                     FreeTextPrice = listing.FreeTextPrice,
                                     ListingStatus = listing.ListingStatus,
                                     Files = listing.Files.Select(c => new FileDto
                                     {
                                         Id = c.Id,
                                         Name = c.File.Name,
                                         FileUrl = c.File.RelativePath,
                                         ThumbnailUrl = c.File.ThumbnailPath,
                                         Filetype = c.File.Filetype,
                                         Mime = c.File.Mime,
                                         Extension = c.File.Extension
                                     }).ToList(),
                                     LocationDescription = listing.LocationDescription,
                                     EnvironmentDescription = listing.EnvironmentDescription,
                                     AgentViewModel = new ListingAgentViewModel
                                     {
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Facebook = user.Facebook,
                                         GooglePlus = user.GooglePlus,
                                         Linkedin = user.Linkedin,
                                         Twitter = user.Twitter,
                                         Email = user.Email,
                                         Skype = user.Skype,
                                         Phone = user.PhoneNumber,
                                         Phone2 = user.PhoneNumber2,
                                         ApprovalOfAddress = user.ApprovalOfAddress,
                                         ListingsCount = user.Listings.Count,
                                         UserId = user.Id,
                                         AgencyName = agent.Agency.Name,
                                         Avatar = user.Avatar.ThumbnailPath,
                                         CompanyLogo = agent.Agency.Logo.ThumbnailPath
                                     },
                                     Distances = listing.Distances.Select(c => new DistanceToViewModel { DistanceInKm = c.DistanceInKm, DistanceType = c.DistanceType }).ToList(),
                                     PropertySubType = listing.PropertySubType,
                                     ObjectTextInAnotherLanguages = listing.ObjectTextInAnotherLanguages.Select(c => new TextInAnotherLanguageViewModel{Description = c.Description,LanguageCode = c.LanguageCode}).ToList(),
                                     OtherDetails = listing.OtherDetails,
                                     IsAddressPublic = listing.ShowFullAddressInPublic ?? false
                                 }).FirstOrDefault();

            if (genericListing is IListingForRent)
            {
                if (detailListing != null) detailListing.TypeOfMerchandising = TypeOfMerchandising.Rent;
            }
            if (genericListing is IListingForSale)
            {
                if (detailListing != null) detailListing.TypeOfMerchandising = TypeOfMerchandising.Sale;
            }
            #endregion

            if (genericListing is Residence)
            {
                var residence = genericListing as Residence;
                var detailResidence = _autoMapper.Map<DetailResidence>(detailListing);
                detailResidence.ActualContractTerminatedOn = residence.ActualContractTerminatedOn;
                detailResidence.AdditionalCosts = residence.AdditionalCosts;
                detailResidence.AtticSpace = residence.AtticSpace.GetValueOrDefault();
                detailResidence.Balconies = _autoMapper.Map(residence.Balconies,detailResidence.Balconies);
                detailResidence.BasementArea = residence.BasementArea.GetValueOrDefault();
                detailResidence.Bathrooms = _autoMapper.Map(residence.Bathrooms,detailResidence.Bathrooms);
                detailResidence.Beaconings = residence.Beaconings.Select(c=>new BeaconingViewModel{BeaconingType= c.BeaconingType.GetValueOrDefault()}).ToList();
                detailResidence.Clearance = residence.Clearance;
                detailResidence.ClearanceText = residence.ClearanceText;
                detailResidence.ColdRent = residence.CurrentColdRent;
                detailResidence.ConditionArtType = residence.ConditionArtType;
                detailResidence.DesignType = residence.DesignType;
                detailResidence.Distances = residence.Distances.Select(c => new DistanceToViewModel {  DistanceType = c.DistanceType, DistanceInKm = c.DistanceInKm }).ToList();
                detailResidence.EarliestAvailableDate = residence.EarliestAvailableDate;
                detailResidence.FeatureCategory = residence.FeatureCategory;
                detailResidence.Floors = residence.Floors.Select(c=>new FloorViewModel {FloorType = c.FloorType}).ToList();
                detailResidence.FreeTextPrice = residence.FreeTextPrice;
                detailResidence.HasAirCondition = residence.HasAirCondition;
                detailResidence.HasAlarmSystem = residence.HasAlarmSystem;
                detailResidence.HasAttic = residence.HasAttic;
                detailResidence.HasBicycleRoom = residence.HasBicycleRoom;
                detailResidence.HasCableDucts = residence.HasCableDucts;
                detailResidence.HasCableSatTv = residence.HasCableSatTv;
                detailResidence.HasCamera = residence.HasCamera;
                detailResidence.HasChimney = residence.HasChimney;
                detailResidence.HasElevator = residence.HasElevator;
                detailResidence.HasGermanTvByAntenna = residence.HasGermanTvByAntenna;
                detailResidence.HasInternet = residence.HasInternet;
                detailResidence.HasLibrary = residence.HasLibrary;
                detailResidence.HasPoliceCall = residence.HasPoliceCall;
                detailResidence.HasRollerBlind = residence.HasRollerBlind;
                detailResidence.HasSauna = residence.HasSauna;
                detailResidence.HasStorageRoom = residence.HasStorageRoom;
                detailResidence.HasSwimmingPool = residence.HasSwimmingPool;
                detailResidence.HasWashDryingRoom = residence.HasWashDryingRoom;
                detailResidence.HasWinterGarden = residence.HasWinterGarden;
                detailResidence.HeatingCosts = residence.HeatingCosts;
                detailResidence.Heatings = residence.Heatings.Select(c=>new HeatingViewModel{HeatingType= c.HeatingType}).ToList();
                detailResidence.IsActualContractTerminated = residence.IsActualContractTerminated;
                detailResidence.IsBarrierFree = residence.IsBarrierFree;
                detailResidence.IsFurnished= residence.IsFurnished.GetValueOrDefault();
                detailResidence.IsHeatingCostsIncluded = residence.IsHeatingCostsIncluded.GetValueOrDefault() ;
                detailResidence.IsKitchenFitted = residence.IsKitchenFitted;
                detailResidence.IsKitchenOpen = residence.IsKitchenOpen;
                detailResidence.IsKitchenPantry = residence.IsKitchenPantry;
                detailResidence.IsSeniorFocused = residence.IsSeniorFocused;
                detailResidence.IsShared= residence.IsShared.GetValueOrDefault();
                detailResidence.IsWheelchairAccessible = residence.IsWheelchairAccessible;
                detailResidence.LastRenovationDate = residence.LastRenovationDate;
                detailResidence.LatestAvailableDate = residence.LatestAvailableDate;
                detailResidence.LivingArea = residence.LivingArea.GetValueOrDefault();
                detailResidence.NumberOfBedrooms= residence.NumberOfBedrooms.GetValueOrDefault();
                detailResidence.NumberOfLevels= residence.NumberOfLevels.GetValueOrDefault();
                detailResidence.NumberOfLivingBedrooms= residence.NumberOfLivingBedrooms.GetValueOrDefault();
                detailResidence.NumberOfRooms= residence.NumberOfRooms.GetValueOrDefault();
                detailResidence.ParkSpaces = _autoMapper.Map(residence.ParkingSpaces,detailResidence.ParkSpaces);
                detailResidence.PrimaryEnergySource = residence.PrimaryEnegySource;


                detailResidence.EnergyCertificateType = residence.EnergyCertificateType;
                detailResidence.PropertySubType = residence.PropertySubType;
                detailResidence.ConstructionYear = residence.ConstructionYear;
                detailResidence.AgeGroup = residence.AgeGroup;
                detailResidence.ValidUntil = residence.ValidUntil;

                detailResidence.EnergyConsumptionParameter = residence.EnergyConsumptionParameter;
                detailResidence.IncludedHotWater = residence.IncludedHotWater;
                detailResidence.UltimateEnergyDemand = residence.UltimateEnergyDemand;
                detailResidence.ElectricityValue = residence.ElectricityValue;
                detailResidence.WarmnessValue = residence.WarmnessValue;
                detailResidence.ValueRating = residence.ValueRating;


                detailResidence.UsefulArea = residence.UsefulArea.GetValueOrDefault();
                if (residence is RoomForRent)
                {
                    var roomForRentEntity = residence as RoomForRent;
                    var detailRoomForRent = _autoMapper.Map<DetailRoomForRent>(detailResidence);

                    detailRoomForRent.Bail = roomForRentEntity.Bail;
                    detailRoomForRent.BailText = roomForRentEntity.BailText;
                    detailRoomForRent.BasicRent = roomForRentEntity.BasicRent;
                    detailRoomForRent.Level = roomForRentEntity.Level.GetValueOrDefault();
                    detailRoomForRent.NumberOfApartmentUnits =
                        roomForRentEntity.NumberOfApartmentUnits.GetValueOrDefault();
                    detailRoomForRent.PropertyType = PropertyType.WazRoom;
                    detailRoomForRent.RentalPricePerSqm = roomForRentEntity.RentalPricePerSqm;
                    detailRoomForRent.WarmRent = roomForRentEntity.WarmRent;
                    detailRoomForRent.ForHolidayUse = roomForRentEntity.ForHolidayUse.GetValueOrDefault();
                    detailRoomForRent.ForIndustrialUse = roomForRentEntity.ForIndustrialUse.GetValueOrDefault();
                    detailRoomForRent.RentSubsidy = roomForRentEntity.RentSubsidy.GetValueOrDefault();
                    return detailRoomForRent;
                }

                if (residence is FlatForRent)
                {
                        var flatForRentEntity = residence as FlatForRent;
                        var detailFlatForRent = _autoMapper.Map<DetailFlatForRent>(detailResidence);

                        detailFlatForRent.Bail = flatForRentEntity.Bail;
                        detailFlatForRent.BailText = flatForRentEntity.BailText;
                        detailFlatForRent.BasicRent = flatForRentEntity.BasicRent;
                        detailFlatForRent.Level = flatForRentEntity.Level.GetValueOrDefault();
                        detailFlatForRent.NumberOfApartmentUnits = flatForRentEntity.NumberOfApartmentUnits.GetValueOrDefault();
                        detailFlatForRent.PropertyType = PropertyType.Flat;
                        detailFlatForRent.RentalPricePerSqm = flatForRentEntity.RentalPricePerSqm;
                        detailFlatForRent.WarmRent = flatForRentEntity.WarmRent;
                        detailFlatForRent.ForHolidayUse = flatForRentEntity.ForHolidayUse.GetValueOrDefault();
                        detailFlatForRent.ForIndustrialUse = flatForRentEntity.ForIndustrialUse.GetValueOrDefault();
                        detailFlatForRent.RentSubsidy = flatForRentEntity.RentSubsidy.GetValueOrDefault();
                        return detailFlatForRent;
                }


                if (residence is FlatForSale)
                {
                    var flatForSale = residence as FlatForSale;
                    var detailFlatForSale = _autoMapper.Map<DetailFlatForSale>(detailResidence);
                    detailFlatForSale.PropertyType = PropertyType.Flat;
                    detailFlatForSale.Level = flatForSale.Level.GetValueOrDefault();
                    detailFlatForSale.NumberOfApartmentUnits = flatForSale.NumberOfApartmentUnits.GetValueOrDefault();
                    return detailFlatForSale;
                }
                if (residence is HouseForRent)
                {
                    var detailHouseForRent = _autoMapper.Map<DetailHouseForRent>(detailResidence);
                    var houseForRent = residence as HouseForRent;
                    if (houseForRent != null)
                    {
                        detailHouseForRent.ForHolidayUse = houseForRent.ForHolidayUse.GetValueOrDefault();
                        detailHouseForRent.ForIndustrialUse = houseForRent.ForIndustrialUse.GetValueOrDefault();
                        detailHouseForRent.RentSubsidy = houseForRent.RentSubsidy.GetValueOrDefault();
                        detailHouseForRent.HouseType = (HouseType)houseForRent.PropertySubType.GetValueOrDefault(0);
                        detailHouseForRent.PropertyType = PropertyType.House;
                    }
                    return detailHouseForRent;
                }
                if (residence is HouseForSale)
                {
                    var detailHouseForSale = _autoMapper.Map<DetailHouseForSale>(detailResidence);
                    detailHouseForSale.PropertyType = PropertyType.House;
                    var houseForSale = residence as HouseForSale;
                    if (houseForSale != null)
                    {
                        detailHouseForSale.HouseType = (HouseType)houseForSale.PropertySubType;
                    }
                    return detailHouseForSale;
                }
            }
            if (genericListing is LandForSale)
            {
                var detailLandForSale = _autoMapper.Map<DetailLandForSale>(detailListing);
                detailLandForSale.PropertyType = PropertyType.House;
                return detailLandForSale;
            }
            throw new Exception("Entity not found");
        }

        public Step1ViewModel GetStep1ById(int? id)
        {
            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));
            if (genericListing is FlatForRent)
            {
                var listingFlat = genericListing as FlatForRent;
                var flatForRent = _autoMapper.Map<Step1FlatForRent>(listingFlat);
                var model = new Step1ViewModel {Id = id, Step1FlatForRent = flatForRent};
                return model;
            }
            if (genericListing is FlatForSale)
            {
                var listingFlat = genericListing as FlatForSale;
                var flatForSale = _autoMapper.Map<Step1FlatForSale>(listingFlat);
                var model = new Step1ViewModel {Id = id, Step1FlatForSale = flatForSale};
                return model;
            }
            if (genericListing is HouseForRent)
            {
                var listingHouse = genericListing as HouseForRent;
                var houseForRent = _autoMapper.Map<Step1HouseForRent>(listingHouse);
                var model = new Step1ViewModel {Id = id, Step1HouseForRent = houseForRent};
                return model;
            }
            if (genericListing is HouseForSale)
            {
                var listingHouse = genericListing as HouseForSale;
                var houseForSale = _autoMapper.Map<Step1HouseForSale>(listingHouse);
                var model = new Step1ViewModel {Id = id, Step1HouseForSale = houseForSale};
                return model;
            }
            if (genericListing is LandForSale)
            {
                var listingLand = genericListing as LandForSale;
                var landForSale = _autoMapper.Map<Step1LandForSale>(listingLand);
                var model = new Step1ViewModel {Id = id, Step1LandForSale = landForSale};
                return model;
            }
            if (genericListing is RoomForRent)
            {
                var listingWazRoom = genericListing as RoomForRent;
                var WazRoom = _autoMapper.Map<Step1RoomForRent>(listingWazRoom);
                var model = new Step1ViewModel {Id = id, Step1RoomForRent = WazRoom };
                return model;
            }
            return null;
        }

        public Step2ViewModel GetStep2ById(int id)
        {
            var step2ViewModel = new Step2ViewModel(id);
            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));

            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                step2ViewModel.Step2FlatForRent = _autoMapper.Map<Step2FlatForRent>(flatForRent);
            }
            else if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                step2ViewModel.Step2FlatForSale = _autoMapper.Map<Step2FlatForSale>(flatForSale);
            }
            else if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                step2ViewModel.Step2HouseForRent = _autoMapper.Map<Step2HouseForRent>(houseForRent);
            }
            else if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                step2ViewModel.Step2HouseForSale = _autoMapper.Map<Step2HouseForSale>(houseForSale);
            }
            else if (genericListing is LandForSale)
            {
                var landForSale = genericListing as LandForSale;
                step2ViewModel.Step2LandForSale = _autoMapper.Map<Step2LandForSale>(landForSale); ;
            }
            else if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                step2ViewModel.Step2RoomForRent = _autoMapper.Map<Step2RoomForRent>(roomForRent); ;
            }
            return step2ViewModel;
        }

        public Step3ViewModel GetStep3ById(int? id)
        {
            var step3Model = new Step3ViewModel {Id = id};

            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));

            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                step3Model.Step3FlatForRent = _autoMapper.Map<Step3FlatForRent>(flatForRent); ;
            }
            else if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                step3Model.Step3FlatForSale = _autoMapper.Map<Step3FlatForSale>(flatForSale);
            }
            else if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                step3Model.Step3HouseForRent = _autoMapper.Map<Step3HouseForRent>(houseForRent);
            }
            else if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                step3Model.Step3HouseForSale = _autoMapper.Map<Step3HouseForSale>(houseForSale);
            }
            else if (genericListing is LandForSale)
            {
                var landForSale = genericListing as LandForSale;
                step3Model.Step3LandForSale = _autoMapper.Map<Step3LandForSale>(landForSale);
            }
            else if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                step3Model.Step3RoomForRent = _autoMapper.Map<Step3RoomForRent>(roomForRent);
            }
            return step3Model;
        }

        public Step4ViewModel GetStep4ById(int id)
        {
            var model = new Step4ViewModel(id);
            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));
            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                model.Step4FlatForRent = _autoMapper.Map<Step4FlatForRent>(flatForRent);
            }
            if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                model.Step4FlatForSale = _autoMapper.Map<Step4FlatForSale>(flatForSale);
            }
            if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                model.Step4HouseForRent = _autoMapper.Map<Step4HouseForRent>(houseForRent);
            }
            if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                model.Step4HouseForSale = _autoMapper.Map<Step4HouseForSale>(houseForSale);
            }
            if (genericListing is LandForSale)
            {
                var landForSale = genericListing as LandForSale;
                model.Step4LandForSale = _autoMapper.Map<Step4LandForSale>(landForSale);
            }
            if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                model.Step4RoomForRent = _autoMapper.Map<Step4RoomForRent>(roomForRent);
            }
            return model;
        }

        public Step5ViewModel GetStep5ById(int id)
        {
            var listing = _dbContext.Listings.Find(id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            var images = listing.Files.Select(c => new FileDto {Id = c.Id, Name = c.File.Name}).ToList();
            var model = new Step5ViewModel(id);

            if (listing is FlatForRent)
            {
                model.Step5FlatForRent = new Step5FlatForRent{Images = images};
            }
            if (listing is FlatForSale)
            {
                model.Step5FlatForSale = new Step5FlatForSale{Images = images};
            }
            if (listing is HouseForRent)
            {
                model.Step5HouseForRent = new Step5HouseForRent{Images = images};
            }
            if (listing is HouseForSale)
            {
                model.Step5HouseForSale = new Step5HouseForSale{Images = images};
            }
            if (listing is LandForSale)
            {
                model.Step5LandForSale = new Step5LandForSale{Images = images};
            }
            if (listing is RoomForRent)
            {
                model.Step5RoomForRent = new Step5RoomForRent { Images = images};
            }
            return model;
        }

        public Step6ViewModel GetStep6ById(int id)
        {
            var model = new Step6ViewModel(id);
            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));

            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                model.Step6FlatForRent = _autoMapper.Map<Step6FlatForRent>(flatForRent);
            }
            if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                model.Step6FlatForSale = _autoMapper.Map<Step6FlatForSale>(flatForSale);
            }
            if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                model.Step6HouseForRent = _autoMapper.Map<Step6HouseForRent>(houseForRent);
            }
            if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                model.Step6HouseForSale = _autoMapper.Map<Step6HouseForSale>(houseForSale);
            }
            if (genericListing is LandForSale)
            {
                var landForSale = genericListing as LandForSale;
                model.Step6LandForSale = _autoMapper.Map<Step6LandForSale>(landForSale);
            }
            if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                model.Step6RoomForRent = _autoMapper.Map<Step6RoomForRent>(roomForRent);
            }

            return model;
        }

        public Step7ViewModel GetStep7ById(int id)
        {
            var model = new Step7ViewModel(id);
            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));

            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                model.Step7FlatForRent = _autoMapper.Map<Step7FlatForRent>(flatForRent);
            }
            if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                model.Step7FlatForSale = _autoMapper.Map<Step7FlatForSale>(flatForSale);
            }
            if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                model.Step7HouseForRent = _autoMapper.Map<Step7HouseForRent>(houseForRent);
            }
            if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                model.Step7HouseForSale = _autoMapper.Map<Step7HouseForSale>(houseForSale);
            }
            if (genericListing is LandForSale)
            {
                var landForSale = genericListing as LandForSale;
                model.Step7LandForSale = _autoMapper.Map<Step7LandForSale>(landForSale);
            }
            if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                model.Step7RoomForRent= _autoMapper.Map<Step7RoomForRent>(roomForRent);
            }
            return model;
        }

        public Step8ViewModel GetStep8ById(int id)
        {
            var model = new Step8ViewModel(id);

            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));

            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                model.Step8FlatForRent = _autoMapper.Map<Step8FlatForRent>(flatForRent);
            }
            if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                model.Step8FlatForSale = _autoMapper.Map<Step8FlatForSale>(flatForSale);
            }
            if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                model.Step8HouseForRent = _autoMapper.Map<Step8HouseForRent>(houseForRent);
            }
            if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                model.Step8HouseForSale = _autoMapper.Map<Step8HouseForSale>(houseForSale);
            }
            if (genericListing is LandForSale)
            {
                var landForSale = genericListing as LandForSale;
                model.Step8LandForSale = _autoMapper.Map<Step8LandForSale>(landForSale);
            }
            if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                model.Step8RoomForRent = _autoMapper.Map<Step8RoomForRent>(roomForRent);
            }
            return model;
        }

        public Step9ViewModel GetStep9ById(int id)
        {
            var model = new Step9ViewModel(id);

            var genericListing = _dbContext.Listings.Find(id);
            if (genericListing == null) throw new ArgumentNullException(nameof(genericListing));

            if (genericListing is FlatForRent)
            {
                var flatForRent = genericListing as FlatForRent;
                model.Step9FlatForRent = _autoMapper.Map<Step9FlatForRent>(flatForRent);
            }
            if (genericListing is FlatForSale)
            {
                var flatForSale = genericListing as FlatForSale;
                model.Step9FlatForSale = _autoMapper.Map<Step9FlatForSale>(flatForSale);
            }
            if (genericListing is HouseForRent)
            {
                var houseForRent = genericListing as HouseForRent;
                model.Step9HouseForRent = _autoMapper.Map<Step9HouseForRent>(houseForRent);
            }
            if (genericListing is HouseForSale)
            {
                var houseForSale = genericListing as HouseForSale;
                model.Step9HouseForSale = _autoMapper.Map<Step9HouseForSale>(houseForSale);
            }
            if (genericListing is RoomForRent)
            {
                var roomForRent = genericListing as RoomForRent;
                model.Step9RoomForRent = _autoMapper.Map<Step9RoomForRent>(roomForRent);
            }
            return model;
        }

        public void SaveListingStep1(Step1ViewModel model, string userId)
        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step1FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step1FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step1HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step1HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step1LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var wazRoomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step1RoomForRent, wazRoomForRent);
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveListingStep2(Step2ViewModel model, string userId)
        {
            Listing listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step2FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step2FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step2HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step2HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step2LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var roomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step2RoomForRent, roomForRent);
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveListingStep3(Step3ViewModel model, string userId)
        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step3FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step3FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step3HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step3HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step3LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var roomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step3RoomForRent, roomForRent);
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveListingStep4(Step4ViewModel model, string userId)
        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step4FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step4FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step4HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step4HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step4LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var roomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step4RoomForRent, roomForRent);
                }
                _dbContext.SaveChanges();
            }
            _dbContext.SaveChanges();
        }

        public void SaveListingStep5(Step5ViewModel model, string userId)

        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step5FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step5FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step5HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step5HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step5LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var roomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step5RoomForRent, roomForRent);
                }
                _dbContext.SaveChanges();
            }
            _dbContext.SaveChanges();
        }

        public void SaveListingStep6(Step6ViewModel model, string userId)
        {
            Listing listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step6FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step6FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step6HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step6HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step6LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var roomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step6RoomForRent, roomForRent);
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveListingStep7(Step7ViewModel model, string userId)
        {
            Listing listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    Step7FlatForRent ffrViewModel = model.Step7FlatForRent;
                    var flatForRent = listing as FlatForRent;

                    if (ffrViewModel != null)
                        foreach (var statusViewModel in ffrViewModel.EmploymentStatuses)
                        {
                            if (statusViewModel.Selected && flatForRent.EmployeeStatuses.All(c => c.EmploymentStatus != statusViewModel.EmploymentStatus))
                            {
                                flatForRent.EmployeeStatuses.Add(new EmployeeStatusObject { EmploymentStatus = statusViewModel.EmploymentStatus });
                            }
                            else if (!statusViewModel.Selected && flatForRent.EmployeeStatuses.Any(c => c.EmploymentStatus == statusViewModel.EmploymentStatus))
                            {
                                var item = flatForRent.EmployeeStatuses.FirstOrDefault(c => c.EmploymentStatus == statusViewModel.EmploymentStatus);
                                if (item != null) _dbContext.EmployeeStatuses.Remove(item);
                            }
                        }

                    _autoMapper.Map(model.Step7FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step7FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    Step7HouseForRent hfrViewModel = model.Step7HouseForRent;
                    var flatForRent = listing as HouseForRent;

                    if (hfrViewModel != null)
                        foreach (var statusViewModel in hfrViewModel.EmploymentStatuses)
                        {
                            if (statusViewModel.Selected && flatForRent.EmployeeStatuses.All(c => c.EmploymentStatus != statusViewModel.EmploymentStatus))
                            {
                                flatForRent.EmployeeStatuses.Add(new EmployeeStatusObject { EmploymentStatus = statusViewModel.EmploymentStatus });
                            }
                            else if (!statusViewModel.Selected && flatForRent.EmployeeStatuses.Any(c => c.EmploymentStatus == statusViewModel.EmploymentStatus))
                            {
                                var item = flatForRent.EmployeeStatuses.FirstOrDefault(c => c.EmploymentStatus == statusViewModel.EmploymentStatus);
                                if (item != null) _dbContext.EmployeeStatuses.Remove(item);
                            }
                        }
                    _autoMapper.Map(model.Step7HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step7HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step7LandForSale, landForSale);
                }

                if (listing is RoomForRent)
                {
                    Step7RoomForRent rfrViewModel = model.Step7RoomForRent;
                    var roomForRent = listing as RoomForRent;

                    if (rfrViewModel != null)
                        foreach (var statusViewModel in rfrViewModel.EmploymentStatuses)
                        {
                            if (statusViewModel.Selected && roomForRent.EmployeeStatuses.All(c => c.EmploymentStatus != statusViewModel.EmploymentStatus))
                            {
                                roomForRent.EmployeeStatuses.Add(new EmployeeStatusObject { EmploymentStatus = statusViewModel.EmploymentStatus });
                            }
                            else if (!statusViewModel.Selected && roomForRent.EmployeeStatuses.Any(c => c.EmploymentStatus == statusViewModel.EmploymentStatus))
                            {
                                var item = roomForRent.EmployeeStatuses.FirstOrDefault(c => c.EmploymentStatus == statusViewModel.EmploymentStatus);
                                if (item != null) _dbContext.EmployeeStatuses.Remove(item);
                            }
                        }

                    _autoMapper.Map(model.Step7RoomForRent, roomForRent);
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveListingStep8(Step8ViewModel model, string userId)
        {
            Listing listing = _dbContext.Listings.Find(model.Id);

            Step9Residence residenceViewModel = null;

            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is FlatForRent)
                {
                    var flatForRent = listing as FlatForRent;
                    _autoMapper.Map(model.Step8FlatForRent, flatForRent);
                }
                if (listing is FlatForSale)
                {
                    residenceViewModel = model.Step8FlatForSale;
                    var flatForSale = listing as FlatForSale;
                    _autoMapper.Map(model.Step8FlatForSale, flatForSale);
                }
                if (listing is HouseForRent)
                {
                    var houseForRent = listing as HouseForRent;
                    _autoMapper.Map(model.Step8HouseForRent, houseForRent);
                }
                if (listing is HouseForSale)
                {
                    residenceViewModel = model.Step8HouseForSale;
                    var houseForSale = listing as HouseForSale;
                    _autoMapper.Map(model.Step8HouseForSale, houseForSale);
                }
                if (listing is LandForSale)
                {
                    var landForSale = listing as LandForSale;
                    _autoMapper.Map(model.Step8LandForSale, landForSale);
                }
                if (listing is RoomForRent)
                {
                    var roomForRent = listing as RoomForRent;
                    _autoMapper.Map(model.Step8RoomForRent, roomForRent);
                }

                var residence = listing as Residence;

                if (residenceViewModel != null)
                {
                    foreach (var floorViewModel in residenceViewModel.FloorTypes)
                    {
                        if (floorViewModel.Selected && residence.Floors.All(c => c.FloorType != floorViewModel.FloorType))
                        {
                            residence.Floors.Add(new Floor { FloorType = floorViewModel.FloorType });
                        }
                        else if (!floorViewModel.Selected && residence.Floors.Any(c => c.FloorType == floorViewModel.FloorType))
                        {
                            var item = residence.Floors.FirstOrDefault(c => c.FloorType == floorViewModel.FloorType);
                            if (item != null) _dbContext.Floors.Remove(item);
                        }
                    }
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveListingStep9(Step9ViewModel model, string userId)
        {
            Listing listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            Step9Residence residenceViewModel = null;

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                if (listing is Residence)
                {
                    if (listing is FlatForRent)
                    {
                        var flatForRent = listing as FlatForRent;
                        residenceViewModel = model.Step9FlatForRent;
                        _autoMapper.Map(model.Step9FlatForRent, flatForRent);
                    }
                    if (listing is FlatForSale)
                    {
                        residenceViewModel = model.Step9FlatForSale;
                        var flatForSale = listing as FlatForSale;
                        _autoMapper.Map(model.Step9FlatForSale, flatForSale);
                    }
                    if (listing is HouseForRent)
                    {
                        residenceViewModel = model.Step9HouseForRent;
                        var houseForRent = listing as HouseForRent;
                        _autoMapper.Map(model.Step9HouseForRent, houseForRent);
                    }
                    if (listing is HouseForSale)
                    {

                        residenceViewModel = model.Step9HouseForSale;
                        var houseForSale = listing as HouseForSale;
                        _autoMapper.Map(model.Step9HouseForSale, houseForSale);
                    }
                    if (listing is RoomForRent)
                    {
                        var roomForRent = listing as RoomForRent;
                        residenceViewModel = model.Step9RoomForRent;
                        _autoMapper.Map(model.Step9RoomForRent, roomForRent);
                    }
                    var residence = listing as Residence;

                    if (residenceViewModel != null)
                        foreach (var floorViewModel in residenceViewModel.FloorTypes)
                        {
                            if (floorViewModel.Selected && residence.Floors.All(c => c.FloorType != floorViewModel.FloorType))
                            {
                                residence.Floors.Add(new Floor {FloorType = floorViewModel.FloorType });
                            }
                            else if (!floorViewModel.Selected && residence.Floors.Any(c => c.FloorType == floorViewModel.FloorType))
                            {
                                var item = residence.Floors.FirstOrDefault(c => c.FloorType == floorViewModel.FloorType);
                                if (item != null) _dbContext.Floors.Remove(item);
                            }
                        }
                    _dbContext.SaveChanges();
                }
                else throw new NotSupportedException("Cant Add features to residence");

            }
        }

        public List<ParkSpaceViewModel> AddParkingSpace(AddparkingSpaceViewModel model,int Id)
        {
            var listing = _dbContext.Listings.Find(Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (listing is Residence)
            {
                ParkSpaceType? parkSpaceType = model.ParkType;
                int? quantity = model.Quantity;
                decimal? rentPrice = model.Price;

                var residenceListing = listing as Residence;

                residenceListing.ParkingSpaces.Add(new ParkingSpace
                {
                    ParkSpaceType = parkSpaceType,
                    Quantity = quantity,
                    RentPrice = rentPrice
                });

                _dbContext.SaveChanges();
                return
                    residenceListing.ParkingSpaces.ToList().Select(c => _autoMapper.Map<ParkSpaceViewModel>(c)).ToList();
            }

            throw new Exception("Property is not a residence, cant add parking space.");
        }

        public List<BalconyViewModel> AddBalcony(AddBalconyViewModel model,int Id)
        {
            var listing = _dbContext.Listings.Find(Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (listing is Residence)
            {
                GeoDirection? direction = model.Direction;
                BalconyType? balconyType = model.BalconyType;
                SightType? sightType = model.SightType;
                int level = model.Level;
                int size = model.Size;



                var residenceListing = listing as Residence;
                if (sightType == null)
                {
                    sightType = SightType.NotDefined;
                }
                residenceListing.Balconies.Add(new Balcony
                {
                    Direction = direction,
                    BalconyType = balconyType,
                    SightType = sightType,
                    Level = level,
                    Size = size
                });

                _dbContext.SaveChanges();
                return residenceListing.Balconies.ToList().Select(c => _autoMapper.Map<BalconyViewModel>(c)).ToList();
            }

            throw new Exception("Property is not a residence, cant add parking space.");
        }

        public List<BalconyViewModel> DeleteBalcony(int id, string userId)
        {
            var balcony = _dbContext.Balconies.Find(id);
            if (balcony == null) throw new ArgumentNullException(nameof(balcony));
            var listing = _dbContext.Listings.Find(balcony.ResidenceId) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                _dbContext.Balconies.Remove(balcony);
                _dbContext.SaveChanges();
                return listing.Balconies.ToList().Select(c => _autoMapper.Map<BalconyViewModel>(c)).ToList();
            }
            return new List<BalconyViewModel>();
        }

        public List<ParkSpaceViewModel> DeleteParkSpace(int id, string userId)
        {
            var parkingSpace = _dbContext.ParkingSpaces.Find(id);
            if (parkingSpace == null) throw new ArgumentNullException(nameof(parkingSpace));
            var listing = _dbContext.Listings.Find(parkingSpace.ResidenceId) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                _dbContext.ParkingSpaces.Remove(parkingSpace);
                _dbContext.SaveChanges();
                return listing.ParkingSpaces.ToList().Select(c => _autoMapper.Map<ParkSpaceViewModel>(c)).ToList();
            }
            return new List<ParkSpaceViewModel>();
        }

        public List<BalconyViewModel> GetBalconies(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.Balconies.ToList().Select(c => _autoMapper.Map<BalconyViewModel>(c)).ToList();
        }

        //todo: ibrahim delete user ıds

        public List<ParkSpaceViewModel> GetParkSpaces(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.ParkingSpaces.ToList().Select(c => _autoMapper.Map<ParkSpaceViewModel>(c)).ToList();
        }

        public int InitNewListing(InitListingViewModel model, string userId)
        {
            Listing listing;


            if (model.PropertyType == PropertyType.Flat)
            {
                if (model.TypeOfMerchandising == TypeOfMerchandising.Rent)
                {
                    listing = new FlatForRent
                    {
                        UserId = userId,
                        ListingStatus = ListingStatus.Draft,
                        TypeOfUse = model.TypeOfUse
                    };
                    _dbContext.Listings.Add(listing);
                    _dbContext.SaveChanges();
                    return listing.Id;
                }
                if (model.TypeOfMerchandising == TypeOfMerchandising.Sale)
                {
                    listing = new FlatForSale
                    {
                        UserId = userId,
                        ListingStatus = ListingStatus.Draft,
                        TypeOfUse = model.TypeOfUse
                    };
                    _dbContext.Listings.Add(listing);
                    _dbContext.SaveChanges();
                    return listing.Id;
                }
            }
            else if (model.PropertyType == PropertyType.House)
            {
                if (model.TypeOfMerchandising == TypeOfMerchandising.Rent)
                {
                    listing = new HouseForRent
                    {
                        UserId = userId,
                        ListingStatus = ListingStatus.Draft,
                        TypeOfUse = model.TypeOfUse
                    };
                    _dbContext.Listings.Add(listing);
                    _dbContext.SaveChanges();
                    return listing.Id;
                }
                if (model.TypeOfMerchandising == TypeOfMerchandising.Sale)
                {
                    listing = new HouseForSale
                    {
                        UserId = userId,
                        ListingStatus = ListingStatus.Draft,
                        TypeOfUse = model.TypeOfUse
                    };
                    _dbContext.Listings.Add(listing);
                    _dbContext.SaveChanges();
                    return listing.Id;
                }
            }
            else if (model.PropertyType == PropertyType.Land)
            {
                if (model.TypeOfMerchandising == TypeOfMerchandising.Sale)
                {
                    listing = new LandForSale
                    {
                        UserId = userId,
                        ListingStatus = ListingStatus.Draft,
                        TypeOfUse = model.TypeOfUse,
                    };
                    _dbContext.Listings.Add(listing);
                    _dbContext.SaveChanges();
                    return listing.Id;
                }
            }
            else if (model.PropertyType == PropertyType.WazRoom)
            {
                if (model.TypeOfMerchandising == TypeOfMerchandising.Rent)
                {
                    listing = new RoomForRent
                    {
                        UserId = userId,
                        ListingStatus = ListingStatus.Draft,
                        TypeOfUse = model.TypeOfUse
                    };
                    _dbContext.Listings.Add(listing);
                    _dbContext.SaveChanges();
                    return listing.Id;
                }
            }
                return 0;
        }

        public List<ViewSightViewModel> AddViewSight(Step2ViewModel model)
        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (listing!=null)
            {
                SightType? sightViewEnum = null;

                if (model.Step2FlatForRent != null)
                {
                    sightViewEnum = model.Step2FlatForRent.AddViewSightViewModel.SightType;
                }
                if (model.Step2FlatForSale != null)
                {
                    sightViewEnum = model.Step2FlatForSale.AddViewSightViewModel.SightType;
                }
                if (model.Step2HouseForRent != null)
                {
                    sightViewEnum = model.Step2HouseForRent.AddViewSightViewModel.SightType;
                }
                if (model.Step2HouseForSale != null)
                {
                    sightViewEnum = model.Step2HouseForSale.AddViewSightViewModel.SightType;
                }
                if (model.Step2LandForSale != null)
                {
                    sightViewEnum = model.Step2LandForSale.AddViewSightViewModel.SightType;
                }
                if (model.Step2RoomForRent != null)
                {
                    sightViewEnum = model.Step2RoomForRent.AddViewSightViewModel.SightType;
                }

                var Listing = listing;
                Listing.Sights.Add(new Sight {SightType = sightViewEnum});
                _dbContext.SaveChanges();
                return Listing.Sights.ToList().Select(c => _autoMapper.Map<ViewSightViewModel>(c)).ToList();
            }
            throw new Exception("Property is not a residence, cant add parking space.");
        }

        public List<ViewSightViewModel> GetViewSights(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.Sights.ToList().Select(c => _autoMapper.Map<ViewSightViewModel>(c)).ToList();
        }

        public List<ViewSightViewModel> DeleteViewSight(int id, string userId)
        {
            var viewSight = _dbContext.Sights.Find(id);
            if (viewSight == null) throw new ArgumentNullException(nameof(viewSight));
            var listing = _dbContext.Listings.Find(viewSight.ListingId) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                _dbContext.Sights.Remove(viewSight);
                _dbContext.SaveChanges();
                return listing.Sights.ToList().Select(c => _autoMapper.Map<ViewSightViewModel>(c)).ToList();
            }
            return new List<ViewSightViewModel>();
        }

        //todo send userId

        public List<DistanceToViewModel> AddDistanceTo(AddDistanceToViewModel model, int id, string userId)
        {
            var listing = _dbContext.Listings.Find(id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                DistanceType? distanceType = null;
                decimal? distance = null;

                if (model != null)
                {
                    distanceType = model.DistanceType;
                    distance = model.Distance;
                }

                listing.Distances.Add(new Distance
                {
                    DistanceType = distanceType,
                    DistanceInKm = distance
                });

                _dbContext.SaveChanges();
            }
            return listing.Distances.ToList().Select(c => _autoMapper.Map<DistanceToViewModel>(c)).ToList();
        }

        public List<DistanceToViewModel> DeleteDistanceTo(int id, string userId)
        {
            var distanceTo = _dbContext.Distances.Find(id);
            if (distanceTo == null) throw new ArgumentNullException(nameof(distanceTo));
            var listing = _dbContext.Listings.Find(distanceTo.ListingId) ;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (_listingSecurityService.CanEditListing(userId, listing))
            {
                _dbContext.Distances.Remove(distanceTo);
                _dbContext.SaveChanges();
                return listing.Distances.ToList().Select(c => _autoMapper.Map<DistanceToViewModel>(c)).ToList();
            }
            return new List<DistanceToViewModel>();
        }

        public List<DistanceToViewModel> GetDistanceTos(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.Distances.ToList().Select(c => _autoMapper.Map<DistanceToViewModel>(c)).ToList();
        }

        public List<HeatingViewModel> AddHeating(AddHeatingViewModel heating, int Id, string userId)
        {
            var listing = _dbContext.Listings.Find(Id);
            if (listing == null)
                throw new ArgumentNullException(nameof(listing));
            if (!listing.UserId.Equals(userId))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");


            if (listing is Residence)
            {
                HeatingType? heatingtype = HeatingType.None;

                heatingtype = heating.HeatingType;
                //if (listingObject.PropertyType == PropertyType.Flat && listingObject.TypeOfMerchandising == TypeOfMerchandising.Rent)
                //{
               //     heatingtype = model.Step8FlatForRent.AddHeatingViewModel.HeatingType;
                //}
                //if (model.Step8FlatForSale != null)
                //{
                //    heatingtype = model.Step8FlatForSale.AddHeatingViewModel.HeatingType;
                //}
                //if (model.Step8HouseForRent != null)
                //{
                //    heatingtype = model.Step8HouseForRent.AddHeatingViewModel.HeatingType;
                //}
                //if (model.Step8HouseForSale != null)
                //{
                //    heatingtype = model.Step8HouseForSale.AddHeatingViewModel.HeatingType;
                //}

                var residenceListing = listing as Residence;
                residenceListing.Heatings.Add(new Heating { HeatingType = heatingtype });
                _dbContext.SaveChanges();
                return residenceListing.Heatings.ToList().Select(c => _autoMapper.Map<HeatingViewModel>(c)).ToList();
            }
            throw new Exception("Property is not a residence, cant add heating.");
        }

        public List<HeatingViewModel> DeleteHeating(int id, string userId)
        {
            var heating = _dbContext.Heatings.Find(id);
            if (heating == null) throw new ArgumentNullException(nameof(heating));
            var listing = _dbContext.Listings.Find(heating.ResidenceId) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (!listing.UserId.Equals(userId))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            _dbContext.Heatings.Remove(heating);
            _dbContext.SaveChanges();
            return listing.Heatings.ToList().Select(c => _autoMapper.Map<HeatingViewModel>(c)).ToList();
        }

        public List<HeatingViewModel> GetHeatings(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.Heatings.ToList().Select(c => _autoMapper.Map<HeatingViewModel>(c)).ToList();
        }

        public List<BathroomViewModel> AddBathroom(AddBathroomViewModel model,int Id, string userId)
        {
            var listing = _dbContext.Listings.Find(Id);
            if (listing == null)
                throw new ArgumentNullException(nameof(listing));
            if (!listing.UserId.Equals(userId))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            if (listing is Residence)
            {
                int?  size = model.Size;
                bool? hasShower = model.HasShower;
                bool? hasTub = model.HasTub;
                bool? hasWindow = model.HasWindow;
                bool? hasUrinal = model.HasUrinal;
                bool? hasBidet = model.HasBidet;

                var residenceListing = listing as Residence;
                residenceListing.Bathrooms.Add(new Bathroom { HasShower = hasShower,HasWindow = hasWindow,HasTub = hasTub,HasUrinal = hasUrinal,HasBidet = hasBidet,Size = size});
                _dbContext.SaveChanges();
                return residenceListing.Bathrooms.ToList().Select(c => _autoMapper.Map<BathroomViewModel>(c)).ToList();
            }
            throw new Exception("Property is not a residence, cant add heating.");
        }

        public List<BathroomViewModel> DeleteBathroom(int id, string userId)
        {
            var bathroom = _dbContext.Bathrooms.Find(id);
            if (bathroom == null) throw new ArgumentNullException(nameof(bathroom));
            var listing = _dbContext.Listings.Find(bathroom.ResidenceId) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (!listing.UserId.Equals(userId))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            _dbContext.Bathrooms.Remove(bathroom);
            _dbContext.SaveChanges();
            return listing.Bathrooms.ToList().Select(c => _autoMapper.Map<BathroomViewModel>(c)).ToList();
        }

        public List<BathroomViewModel> GetBathrooms(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.Bathrooms.ToList().Select(c => _autoMapper.Map<BathroomViewModel>(c)).ToList();
        }

        public List<BeaconingViewModel> AddBeaconing(AddBeaconingViewModel model,int Id, string userId)
        {
            var listing = _dbContext.Listings.Find(Id);
            if (listing == null)
                throw new ArgumentNullException(nameof(listing));
            if (!_listingSecurityService.CanEditListing(userId, listing))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            if (listing is Residence)
            {
                BeaconingType? beaconingType= null;
                beaconingType = model.BeaconingType;

                var residenceListing = listing as Residence;
                residenceListing.Beaconings.Add(new Beaconing { BeaconingType = beaconingType});
                _dbContext.SaveChanges();
                return residenceListing.Beaconings.ToList().Select(c => _autoMapper.Map<BeaconingViewModel>(c)).ToList();
            }
            throw new Exception("Property is not a residence, cant add beaconing.");
        }

        public List<BeaconingViewModel> DeleteBeaconing(int id, string userId)
        {
            var beaconing = _dbContext.Beaconings.Find(id);
            if (beaconing == null) throw new ArgumentNullException(nameof(beaconing));
            var listing = _dbContext.Listings.Find(beaconing.ResidenceId) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (!_listingSecurityService.CanEditListing(userId, listing))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            _dbContext.Beaconings.Remove(beaconing);
            _dbContext.SaveChanges();
            return listing.Beaconings.ToList().Select(c => _autoMapper.Map<BeaconingViewModel>(c)).ToList();
        }

        public List<BeaconingViewModel> GetBeaconings(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id) as Residence;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.Beaconings.ToList().Select(c => _autoMapper.Map<BeaconingViewModel>(c)).ToList();
        }

        public List<TextInAnotherLanguageViewModel> AddTextInAnotherLanguage(Step6ViewModel model, string userId)
        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing==null)
                throw new ArgumentNullException(nameof(listing));
            if (!_listingSecurityService.CanEditListing(userId, listing))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            string languageCode = null;
            string description = null;


            if (model.Step6FlatForRent != null)
            {
                languageCode = model.Step6FlatForRent.AddTextInAnotherLanguageViewModel.LanguageCode;
                description = model.Step6FlatForRent.AddTextInAnotherLanguageViewModel.Description;
            }
            if (model.Step6FlatForSale != null)
            {
                languageCode = model.Step6FlatForSale.AddTextInAnotherLanguageViewModel.LanguageCode;
                description = model.Step6FlatForSale.AddTextInAnotherLanguageViewModel.Description;
            }
            if (model.Step6HouseForRent != null)
            {
                languageCode = model.Step6HouseForRent.AddTextInAnotherLanguageViewModel.LanguageCode;
                description = model.Step6HouseForRent.AddTextInAnotherLanguageViewModel.Description;
            }
            if (model.Step6HouseForSale != null)
            {
                languageCode = model.Step6HouseForSale.AddTextInAnotherLanguageViewModel.LanguageCode;
                description = model.Step6HouseForSale.AddTextInAnotherLanguageViewModel.Description;
            }
            if (model.Step6LandForSale != null)
            {
                languageCode = model.Step6LandForSale.AddTextInAnotherLanguageViewModel.LanguageCode;
                description = model.Step6LandForSale.AddTextInAnotherLanguageViewModel.Description;
            }
            if (model.Step6RoomForRent != null)
            {
                languageCode = model.Step6RoomForRent.AddTextInAnotherLanguageViewModel.LanguageCode;
                description = model.Step6RoomForRent.AddTextInAnotherLanguageViewModel.Description;
            }

            listing.ObjectTextInAnotherLanguages.Add(new ObjectTextInAnotherLanguage { LanguageCode = languageCode,Description = description});
            _dbContext.SaveChanges();
            return listing.ObjectTextInAnotherLanguages.ToList().Select(c => _autoMapper.Map<TextInAnotherLanguageViewModel>(c)).ToList();
        }

        public List<TextInAnotherLanguageViewModel> DeleteTextInAnotherLanguage(int id, string userId)
        {
            var textDescription = _dbContext.ObjectTextInAnotherLanguages.Find(id);
            if (textDescription == null) throw new ArgumentNullException(nameof(textDescription));
            var listing = _dbContext.Listings.Find(textDescription.ListingId);
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (!_listingSecurityService.CanEditListing(userId, listing))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            _dbContext.ObjectTextInAnotherLanguages.Remove(textDescription);
            _dbContext.SaveChanges();
            return listing.ObjectTextInAnotherLanguages.ToList().Select(c => _autoMapper.Map<TextInAnotherLanguageViewModel>(c)).ToList();
        }

        public List<TextInAnotherLanguageViewModel> GetTextsInAnotherLanguage(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id);
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.ObjectTextInAnotherLanguages.ToList().Select(c => _autoMapper.Map<TextInAnotherLanguageViewModel>(c)).ToList();
        }

        public List<MixedLandViewModel> AddMixedLand(Step4ViewModel model, string userId)
        {
            var listing = _dbContext.Listings.Find(model.Id);
            if (listing == null)
                throw new ArgumentNullException(nameof(listing));
            if (!_listingSecurityService.CanEditListing(userId, listing))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

          TypeOfUse? typeOfUse = null;
            decimal? totalArea = null;
            decimal? plotArea = null;
            decimal? separableFrom = null;

            if (model.Step4LandForSale != null)
            {
                typeOfUse = model.Step4LandForSale.AddMixedLandViewModel.TypeOfUse;
                totalArea = model.Step4LandForSale.AddMixedLandViewModel.TotalArea;
                plotArea = model.Step4LandForSale.AddMixedLandViewModel.PlotArea;
                separableFrom = model.Step4LandForSale.AddMixedLandViewModel.SeparableFrom;
            }
            var land = listing as LandForSale;
            land.MixedLands.Add(new MixedLand { TypeOfUse = typeOfUse,
                TotalArea = totalArea, PlotArea = plotArea,SeparableFrom = separableFrom
            });

            _dbContext.SaveChanges();
            return land.MixedLands.ToList().Select(c => _autoMapper.Map<MixedLandViewModel>(c)).ToList();


        }

        public List<MixedLandViewModel> DeleteMixedLand(int id, string userId)
        {
            var landForSale = _dbContext.MixedLands.Find(id);
            if (landForSale == null) throw new ArgumentNullException(nameof(landForSale));
            var listing = _dbContext.Listings.Find(landForSale.LandId) as LandForSale;

            if (listing == null) throw new ArgumentNullException(nameof(listing));
            if (!_listingSecurityService.CanEditListing(userId, listing))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");

            _dbContext.MixedLands.Remove(landForSale);
            _dbContext.SaveChanges();
            return listing.MixedLands.ToList().Select(c => _autoMapper.Map<MixedLandViewModel>(c)).ToList();
        }

        public List<MixedLandViewModel> GetMixedLands(int? id, string userId)
        {
            var listing = _dbContext.Listings.Find(id) as LandForSale;
            if (listing == null) throw new ArgumentNullException(nameof(listing));
            return listing.MixedLands.ToList().Select(c => _autoMapper.Map<MixedLandViewModel>(c)).ToList();
        }

        public DetailedSearchResultsModel GetDetailedSearchViewModel(TypeOfMerchandising? mt, PropertyType? pt)
        {
            var model = new DetailedSearchResultsModel { SelectedPropertyType = pt, SelectedTypeOfMerchandising = mt};

            if (mt == TypeOfMerchandising.Rent && pt == PropertyType.Flat)
            {
                model.DetailedSearchFlatForRent = new DetailedSearchFlatForRent();
            }
            else if (mt == TypeOfMerchandising.Sale && pt == PropertyType.Flat)
            {
                model.DetailedSearchFlatForSale= new DetailedSearchFlatForSale();
            }
            else if (mt == TypeOfMerchandising.Rent && pt == PropertyType.House)
            {
                model.DetailedSearchHouseForRent = new DetailedSearchHouseForRent();
            }
            else if (mt == TypeOfMerchandising.Sale && pt == PropertyType.House)
            {
                model.DetailedSearchHouseForSale = new DetailedSearchHouseForSale();
            }
            else if (mt == TypeOfMerchandising.Sale && pt == PropertyType.Land)
            {
                model.DetailedSearchLandForSale = new DetailedSearchLandForSale();
            }
            else if(mt==null && pt==null)
            {
                model.DetailedSearchFlatForRent = new DetailedSearchFlatForRent();
            }

            return model;
        }

        public List<string> GetContactEmailsByListingId(int id)
        {
            var list = new List<string>();
            list.Add(_dbContext.Listings.Find(id)?.User.Email);
            list.Add("riehl@riehlestate.de");
            return list;
        }
    }
}