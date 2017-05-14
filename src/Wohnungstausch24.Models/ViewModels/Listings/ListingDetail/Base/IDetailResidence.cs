using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base
{
    public interface IDetailResidence:IDetailListing
    {
        decimal? ColdRent { get; set; }
        decimal? AdditionalCosts { get; set; }
        decimal LivingArea { get; set; }
        FeatureCategory? FeatureCategory { get; set; }
        ConditionArtType? ConditionArtType { get; set; }
        DateTime? LastRenovationDate { get; set; }
        DesignType? DesignType { get; set; }        
        List<BalconyViewModel> Balconies { get; set; }
        List<HeatingViewModel> Heatings { get; set; }
        List<BeaconingViewModel> Beaconings { get; set; }
        List<ParkSpaceViewModel> ParkSpaces { get; set; }
        List<BathroomViewModel> Bathrooms { get; set; }
        List<FloorViewModel> Floors { get; set; }

        bool? HasWinterGarden { get; set; }
        bool? HasStorageRoom { get; set; }
        bool? HasBicycleRoom { get; set; }
        bool? HasWashDryingRoom { get; set; }
        bool? HasElevator { get; set; }
        bool? HasChimney { get; set; }
        bool? HasRollerBlind { get; set; }
        bool? HasCableSatTv { get; set; }
        bool? HasGermanTvByAntenna { get; set; }
        bool? HasInternet { get; set; }
        bool? HasCableDucts { get; set; }
        bool? IsSeniorFocused { get; set; }
        bool? IsWheelchairAccessible { get; set; }
        bool? IsBarrierFree { get; set; }
        bool? HasLibrary { get; set; }
        bool? HasAttic { get; set; }
        bool? HasAirCondition { get; set; }
        bool? HasSauna { get; set; }
        bool? HasSwimmingPool { get; set; }
        bool? HasAlarmSystem { get; set; }
        bool? HasCamera { get; set; }
        bool? HasPoliceCall { get; set; }

        decimal? Clearance { get; set; }
        string ClearanceText { get; set; }
        bool IsHeatingCostsIncluded { get; set; }
        decimal? HeatingCosts { get; set; }
        bool? IsKitchenFitted { get; set; }
        bool? IsKitchenOpen { get; set; }
        bool? IsKitchenPantry { get; set; }
        int NumberOfRooms { get; set; }
        int NumberOfBedrooms { get; set; }
        int NumberOfLevels { get; set; }
        bool IsShared { get; set; }
        bool IsFurnished { get; set; }
        decimal BasementArea { get; set; }
        decimal UsefulArea { get; set; }
        decimal AtticSpace { get; set; }
        int NumberOfLivingBedrooms { get; set; }
        BeaconingType? PrimaryEnergySource { get; set; }
        EnergyCertificateType? EnergyCertificateType { get; set; }
        int? ConstructionYear { get; set; }
        AgeGroup? AgeGroup { get; set; }
        DateTime? ValidUntil { get; set; }
        decimal? EnergyConsumptionParameter { get; set; }
        bool? IncludedHotWater { get; set; }
        decimal? UltimateEnergyDemand { get; set; }
        decimal? ElectricityValue { get; set; }
        decimal? WarmnessValue { get; set; }
        int? ValueRating { get; set; }
    }
}
