﻿using System.Linq;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.Entites.Locations;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Models.ViewModels.Location;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class SearchProfileToEntity:IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DetailedSearchFlatForRent, SearchProfileFlatForRent>()
                .ForMember(c => c.AvailableFrom, o => o.MapFrom(c => c.AvailableFrom))
                .ForMember(c => c.AvailableTo, o => o.MapFrom(c => c.AvailableTo))
                .ForMember(c => c.PriceRange, o => o.MapFrom(c => c.PriceRange))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.IsApartmentTower, o => o.MapFrom(c => c.IsApartmentTower))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.HasHousingPermission, o => o.MapFrom(c => c.HasHousingPermission))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.IsPetsAllowed, o => o.MapFrom(c => c.IsPetsAllowed))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsSharePossible, o => o.MapFrom(c => c.IsSharePossible))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGardenUtilization, o => o.MapFrom(c => c.HasGardenUtilization))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasBarrierFree, o => o.MapFrom(c => c.HasBarrierFree))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.HasApprovalOfAddress, o => o.MapFrom(c => c.HasApprovalOfAddress))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.HasShower, o => o.MapFrom(c => c.HasShower))
                .ForMember(c => c.HasBidet, o => o.MapFrom(c => c.HasBidet))
                .ForMember(c => c.HasTub, o => o.MapFrom(c => c.HasTub))
                .ForMember(c => c.HasWindow, o => o.MapFrom(c => c.HasWindow))
                .ForMember(c => c.HasUrinal, o => o.MapFrom(c => c.HasUrinal))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.HasBalcony))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.YearOfConstruction, o => o.MapFrom(c => c.YearOfConstruction))
                .ForMember(c => c.NumberOfLivingRooms, o => o.MapFrom(c => c.NumberOfLivingRooms))
                .ForMember(c => c.ResidentialArea, o => o.MapFrom(c => c.ResidentialArea))
                .ForMember(c => c.NumberOfBathRooms, o => o.MapFrom(c => c.NumberOfBathRooms))
                .ForMember(c => c.NumberOfParkingLots, o => o.MapFrom(c => c.NumberOfParkingLots))
                .ForMember(c => c.BalconyTerraceArea, o => o.MapFrom(c => c.BalconyTerraceArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.SelectedFeatureCategories, o => o.MapFrom(c => c.FeatureCategoryViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedFloors, o => o.MapFrom(c => c.FloorViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedHeatings, o => o.MapFrom(c => c.HeatingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedBeaconings, o => o.MapFrom(c => c.BeaconingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedParkSpaces, o => o.MapFrom(c => c.ParkSpaceTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.GeoDirection, o => o.MapFrom(c => c.AdjustmentBalconyTerrace.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedSights, o => o.MapFrom(c => c.SightTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedEnergies, o => o.MapFrom(c => c.EnergyTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedRollerBlinds, o => o.MapFrom(c => c.RollerBlindTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedFlatTypes, o => o.MapFrom(c => c.FlatTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<DetailedSearchFlatForSale, SearchProfileFlatForSale>()
                .ForMember(c => c.AvailableFrom, o => o.MapFrom(c => c.AvailableFrom))
                .ForMember(c => c.AvailableTo, o => o.MapFrom(c => c.AvailableTo))
                .ForMember(c => c.PriceRange, o => o.MapFrom(c => c.PriceRange))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.IsApartmentTower, o => o.MapFrom(c => c.IsApartmentTower))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsSharePossible, o => o.MapFrom(c => c.IsSharePossible))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGardenUtilization, o => o.MapFrom(c => c.HasGardenUtilization))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasBarrierFree, o => o.MapFrom(c => c.HasBarrierFree))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.HasApprovalOfAddress, o => o.MapFrom(c => c.HasApprovalOfAddress))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.HasShower, o => o.MapFrom(c => c.HasShower))
                .ForMember(c => c.HasBidet, o => o.MapFrom(c => c.HasBidet))
                .ForMember(c => c.HasTub, o => o.MapFrom(c => c.HasTub))
                .ForMember(c => c.HasWindow, o => o.MapFrom(c => c.HasWindow))
                .ForMember(c => c.HasUrinal, o => o.MapFrom(c => c.HasUrinal))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.HasBalcony))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.YearOfConstruction, o => o.MapFrom(c => c.YearOfConstruction))
                .ForMember(c => c.NumberOfLivingRooms, o => o.MapFrom(c => c.NumberOfLivingRooms))
                .ForMember(c => c.ResidentialArea, o => o.MapFrom(c => c.ResidentialArea))
                .ForMember(c => c.NumberOfBathRooms, o => o.MapFrom(c => c.NumberOfBathRooms))
                .ForMember(c => c.NumberOfParkingLots, o => o.MapFrom(c => c.NumberOfParkingLots))
                .ForMember(c => c.BalconyTerraceArea, o => o.MapFrom(c => c.BalconyTerraceArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.SelectedFeatureCategories, o => o.MapFrom(c => c.FeatureCategoryViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedFloors, o => o.MapFrom(c => c.FloorViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedHeatings, o => o.MapFrom(c => c.HeatingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedBeaconings, o => o.MapFrom(c => c.BeaconingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedParkSpaces, o => o.MapFrom(c => c.ParkSpaceTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.GeoDirection, o => o.MapFrom(c => c.AdjustmentBalconyTerrace.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedSights, o => o.MapFrom(c => c.SightTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedEnergies, o => o.MapFrom(c => c.EnergyTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedRollerBlinds, o => o.MapFrom(c => c.RollerBlindTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedFlatTypes, o => o.MapFrom(c => c.FlatTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<DetailedSearchHouseForRent, SearchProfileHouseForRent>()
                .ForMember(c => c.AvailableFrom, o => o.MapFrom(c => c.AvailableFrom))
                .ForMember(c => c.AvailableTo, o => o.MapFrom(c => c.AvailableTo))
                .ForMember(c => c.PriceRange, o => o.MapFrom(c => c.PriceRange))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.HasHousingPermission, o => o.MapFrom(c => c.HasHousingPermission))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.IsPetsAllowed, o => o.MapFrom(c => c.IsPetsAllowed))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsSharePossible, o => o.MapFrom(c => c.IsSharePossible))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGardenUtilization, o => o.MapFrom(c => c.HasGardenUtilization))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasBarrierFree, o => o.MapFrom(c => c.HasBarrierFree))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.HasApprovalOfAddress, o => o.MapFrom(c => c.HasApprovalOfAddress))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.HasShower, o => o.MapFrom(c => c.HasShower))
                .ForMember(c => c.HasBidet, o => o.MapFrom(c => c.HasBidet))
                .ForMember(c => c.HasTub, o => o.MapFrom(c => c.HasTub))
                .ForMember(c => c.HasWindow, o => o.MapFrom(c => c.HasWindow))
                .ForMember(c => c.HasUrinal, o => o.MapFrom(c => c.HasUrinal))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.HasBalcony))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.YearOfConstruction, o => o.MapFrom(c => c.YearOfConstruction))
                .ForMember(c => c.NumberOfLivingRooms, o => o.MapFrom(c => c.NumberOfLivingRooms))
                .ForMember(c => c.ResidentialArea, o => o.MapFrom(c => c.ResidentialArea))
                .ForMember(c => c.NumberOfBathRooms, o => o.MapFrom(c => c.NumberOfBathRooms))
                .ForMember(c => c.NumberOfParkingLots, o => o.MapFrom(c => c.NumberOfParkingLots))
                .ForMember(c => c.BalconyTerraceArea, o => o.MapFrom(c => c.BalconyTerraceArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.SelectedFeatureCategories, o => o.MapFrom(c => c.FeatureCategoryViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedFloors, o => o.MapFrom(c => c.FloorViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedHeatings, o => o.MapFrom(c => c.HeatingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedBeaconings, o => o.MapFrom(c => c.BeaconingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedParkSpaces, o => o.MapFrom(c => c.ParkSpaceTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.GeoDirection, o => o.MapFrom(c => c.AdjustmentBalconyTerrace.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedSights, o => o.MapFrom(c => c.SightTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedEnergies, o => o.MapFrom(c => c.EnergyTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedRollerBlinds, o => o.MapFrom(c => c.RollerBlindTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedHouseTypes, o => o.MapFrom(c => c.HouseTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<DetailedSearchHouseForSale, SearchProfileHouseForSale>()
                .ForMember(c => c.AvailableFrom, o => o.MapFrom(c => c.AvailableFrom))
                .ForMember(c => c.AvailableTo, o => o.MapFrom(c => c.AvailableTo))
                .ForMember(c => c.PriceRange, o => o.MapFrom(c => c.PriceRange))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsSharePossible, o => o.MapFrom(c => c.IsSharePossible))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGardenUtilization, o => o.MapFrom(c => c.HasGardenUtilization))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasBarrierFree, o => o.MapFrom(c => c.HasBarrierFree))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.HasApprovalOfAddress, o => o.MapFrom(c => c.HasApprovalOfAddress))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.HasShower, o => o.MapFrom(c => c.HasShower))
                .ForMember(c => c.HasBidet, o => o.MapFrom(c => c.HasBidet))
                .ForMember(c => c.HasTub, o => o.MapFrom(c => c.HasTub))
                .ForMember(c => c.HasWindow, o => o.MapFrom(c => c.HasWindow))
                .ForMember(c => c.HasUrinal, o => o.MapFrom(c => c.HasUrinal))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.HasBalcony))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.YearOfConstruction, o => o.MapFrom(c => c.YearOfConstruction))
                .ForMember(c => c.NumberOfLivingRooms, o => o.MapFrom(c => c.NumberOfLivingRooms))
                .ForMember(c => c.ResidentialArea, o => o.MapFrom(c => c.ResidentialArea))
                .ForMember(c => c.NumberOfBathRooms, o => o.MapFrom(c => c.NumberOfBathRooms))
                .ForMember(c => c.NumberOfParkingLots, o => o.MapFrom(c => c.NumberOfParkingLots))
                .ForMember(c => c.BalconyTerraceArea, o => o.MapFrom(c => c.BalconyTerraceArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.SelectedFeatureCategories, o => o.MapFrom(c => c.FeatureCategoryViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedFloors, o => o.MapFrom(c => c.FloorViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedHeatings, o => o.MapFrom(c => c.HeatingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedBeaconings, o => o.MapFrom(c => c.BeaconingTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedParkSpaces, o => o.MapFrom(c => c.ParkSpaceTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.GeoDirection, o => o.MapFrom(c => c.AdjustmentBalconyTerrace.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedSights, o => o.MapFrom(c => c.SightTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedEnergies, o => o.MapFrom(c => c.EnergyTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedRollerBlinds, o => o.MapFrom(c => c.RollerBlindTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.SelectedHouseTypes, o => o.MapFrom(c => c.HouseTypeViewModels.Where(ce => ce.Selected).ToList()))
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatTypeViewModel, SpFlatType>()
                .ForMember(c => c.FlatType, o => o.MapFrom(c => c.FlatType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<RollerBlindTypeViewModel, SpRollerBlind>()
                .ForMember(c => c.RollerBlindType, o => o.MapFrom(c => c.RollerBlindType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<EnergyTypeViewModel, SpEnergy>()
                .ForMember(c => c.EnergyType, o => o.MapFrom(c => c.EnergyType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<SightTypeViewModel, SpSight>()
                .ForMember(c => c.SightType, o => o.MapFrom(c => c.SightType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<GeoDirectionViewModel, SpGeoDirection>()
                .ForMember(c => c.GeoDirection, o => o.MapFrom(c => c.GeoDirection))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<ParkSpaceTypeViewModel, SpParkSpace>()
                .ForMember(c => c.ParkSpaceType, o => o.MapFrom(c => c.ParkSpaceType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<FeatureCategoryViewModel, SpFeatureCategory>()
                .ForMember(c => c.FeatureCategory, o => o.MapFrom(c => c.FeatureCategory))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<FloorViewModel, SpFloor>()
                .ForMember(c => c.FloorType, o => o.MapFrom(c => c.FloorType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<HeatingTypeViewModel, SpHeating>()
                .ForMember(c => c.HeatingType, o => o.MapFrom(c => c.HeatingType))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<BeaconingTypeViewModel, SpBeaconing>()
                .ForMember(c => c.BeaconingType, o => o.MapFrom(c => c.BeaconingType))
                .ForAllOtherMembers(c=>c.Ignore());
            cfg.CreateMap<HouseTypeViewModel,SpHouseType>()
                .ForMember(c => c.HouseType, o => o.MapFrom(c => c.HouseType))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}