using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public interface IResidence :IListing
    {
        decimal? LivingArea { get; set; }
        decimal? UsefulArea { get; set; }
        decimal? BasementArea { get; set; }
        decimal? GardenArea { get; set; }
        decimal? OtherArea { get; set; }
        int? ConstructionYear { get; set; }
        int? NumberOfRooms { get; set; }
        int? NumberOfBedrooms { get; set; }
        int? NumberOfBathrooms { get; set; }
        int? NumberOfSeperateToilet { get; set; }
        int? NumberOfLivingBedrooms { get; set; }
        bool? IsFurnished { get; set; }
        bool? IsShared{ get; set; }
        bool? HasGuestToilet { get; set; }
        decimal? CurrentColdRent { get; set; }
        decimal? AdditionalCosts { get; set; }
        decimal? SpeedOfInternet { get; set; }
        DateTime? LastRenovationDate { get; set; }

        bool? HasWinterGarden { get; set; }
        bool? HasStorageRoom { get; set; }
        bool? HasBicycleRoom { get; set; }
        bool? HasWashDryingRoom{ get; set; }
        bool? HasElevator{ get; set; }
        bool? HasChimney { get; set; }
        bool? HasRollerBlind { get; set; }
        bool? HasCableSatTv { get; set; }
        bool? HasGermanTvByAntenna {get;set;}
        bool? HasInternet {get;set;}
        bool? HasCableDucts {get;set;}
        bool? IsSeniorFocused {get;set;}
        bool? IsWheelchairAccessible{get;set;}
        bool? IsBarrierFree {get;set;}
        bool? HasLibrary { get; set; }
        bool? HasAttic { get; set; }
        decimal? AtticSpace { get; set; }
        bool? HasAirCondition { get; set; }
        bool? HasSauna { get; set; }
        bool? HasSwimmingPool { get; set; }
        bool? HasAlarmSystem { get; set; }
        bool? HasCamera { get; set; }
        bool? HasPoliceCall { get; set; }
        bool? IsConstructionYearProjected { get; set; }
        decimal? Clearance { get; set; }
        string ClearanceText { get; set; }
        bool? IsHeatingCostsIncluded { get; set; }
        decimal? HeatingCosts { get; set; }
        DateTime? DateOfIssue { get; set; }
        DateTime? ValidUntil { get; set; }
        decimal? EnergyConsumptionParameter { get; set; }
        bool? IncludedHotWater { get; set; }
        decimal? UltimateEnergyDemand {get;set;}
        decimal? ElectricityValue      {get;set;}
        decimal? WarmnessValue         {get;set;}
        bool? IsApartmentTower { get; set; }
        bool? HasGrannyPart { get; set; }
        /// <summary>
        /// Should be an integer between 0 and 500
        /// </summary>
        int? ValueRating { get; set; }
        bool? HasSeparateToilet { get; set; }
        bool? IsKitchenFitted { get; set; }
        bool? IsKitchenOpen { get; set; }
        bool? IsKitchenPantry { get; set; }
        bool? LandMarked { get; set; }
        bool? WantEnergyCertificate { get; set; }

        FurnishType? FurnishType { get; set; }
        FeatureCategory? FeatureCategory { get; set; }
        DesignType? DesignType { get; set; }
        UnderGroundType? UnderGroundType { get; set; }
        ConditionArtType? ConditionArtType { get; set; }
        EnergyCertificateType? EnergyCertificateType { get; set; }
        AgeGroup? AgeGroup { get; set; }
        Epart? Epart { get; set; }
        BeaconingType? PrimaryEnegySource { get; set; }
        InternetType? InternetType { get; set; }
        EnergyType? EnergyType { get; set; }
        RollerBlindType? RollerBlindType { get; set; }



        ICollection<ParkingSpace> ParkingSpaces { get; set; }
        ICollection<Balcony> Balconies { get; set; }
        ICollection<Floor> Floors { get; set; }
        ICollection<Heating> Heatings { get; set; }
        ICollection<Beaconing> Beaconings { get; set; }
        ICollection<Bathroom> Bathrooms { get; set; }
        ICollection<EmployeeStatusObject> EmployeeStatuses { get; set; }
    }
}