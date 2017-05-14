using System;
using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base
{
    public interface IDetailedSearchResidence : IDetailedSearchListing
    {
        bool HasSauna { get; set; }
        bool HasSwimmingPool { get; set; }
        bool HasWashDryingRoom { get; set; }
        bool HasWinterGarden { get; set; }
        bool IsSharePossible { get; set; }
        bool HasChimney { get; set; }
        bool HasAirCondition { get; set; }
        bool HasElevator { get; set; }
        bool HasGardenUtilization { get; set; }
        bool IsWheelchairAccessible { get; set; }
        bool HasCableSatTv { get; set; }
        bool HasGermanTvByAntenna { get; set; }
        bool HasBarrierFree { get; set; }
        bool HasStorageRoom { get; set; }
        bool HasBicycleRoom { get; set; }
        bool HasRollerBlind { get; set; }
        bool HasGuestToilet { get; set; }
        bool HasCableDucts { get; set; }
        bool IsSeniorFocused { get; set; }
        bool HasApprovalOfAddress { get; set; }
        bool IsFurnished { get; set; }
        bool HasShower { get; set; }
        bool HasBidet { get; set; }
        bool HasTub { get; set; }
        bool HasWindow { get; set; }
        bool HasUrinal { get; set; }
        bool HasBalcony { get; set; }
        bool IsKitchenFitted { get; set; }
        bool IsKitchenOpen { get; set; }
        bool IsKitchenPantry { get; set; }
        List<FeatureCategoryViewModel> FeatureCategoryViewModels { get; set; }
        List<FloorViewModel> FloorViewModels { get; set; }
        List<HeatingTypeViewModel> HeatingTypeViewModels { get; set; }
        List<BeaconingTypeViewModel> BeaconingTypeViewModels { get; set; }
        List<ParkSpaceTypeViewModel> ParkSpaceTypeViewModels { get; set; }
        List<GeoDirectionViewModel> AdjustmentBalconyTerrace { get; set; }
        List<SightTypeViewModel> SightTypeViewModels { get; set; }
        List<EnergyTypeViewModel> EnergyTypeViewModels { get; set; }
        List<RollerBlindTypeViewModel> RollerBlindTypeViewModels { get; set; }
        RangedInt YearOfConstruction { get; set; }
        RangedInt NumberOfLivingRooms { get; set; }
        RangedDecimal ResidentialArea { get; set; }
        RangedInt NumberOfBathRooms { get; set; }
        RangedInt NumberOfParkingLots { get; set; }
        RangedDecimal BalconyTerraceArea { get; set; }
        RangedDecimal GardenArea { get; set; }
    }
}
