using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public class Residence :Listing, IResidence
    {
        public decimal? LivingArea { get; set; }
        public decimal? UsefulArea { get; set; }
        public decimal? BasementArea { get; set; }
        public decimal? GardenArea { get; set; }
        public decimal? OtherArea { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? NumberOfBedrooms { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public int? NumberOfSeperateToilet { get; set; }
        public int? NumberOfLivingBedrooms { get; set; }
        public bool? IsFurnished { get; set; }
        public bool? IsShared { get; set; }
        public bool? IsApartmentTower { get; set; }
        public bool? HasGuestToilet { get; set; }
        public int? ValueRating { get; set; }
        public int? ConstructionYear { get; set; }
        public decimal? CurrentColdRent { get; set; }
        public decimal? AdditionalCosts { get; set; }
        public DateTime? LastRenovationDate { get; set; }
        public bool? HasWinterGarden { get; set; }
        public bool? HasStorageRoom { get; set; }
        public bool? HasBicycleRoom { get; set; }
        public bool? HasWashDryingRoom { get; set; }
        public bool? HasElevator { get; set; }
        public bool? HasChimney { get; set; }
        public bool? HasRollerBlind { get; set; }
        public bool? HasCableSatTv { get; set; }
        public bool? HasGermanTvByAntenna { get; set; }
        public bool? HasInternet { get; set; }
        public bool? HasCableDucts { get; set; }
        public bool? IsSeniorFocused { get; set; }
        public bool? IsWheelchairAccessible { get; set; }
        public bool? IsBarrierFree { get; set; }
        public bool? HasLibrary { get; set; }
        public bool? HasAttic { get; set; }
        public decimal? AtticSpace { get; set; }
        public bool? HasAirCondition { get; set; }
        public bool? HasSauna { get; set; }
        public bool? HasSwimmingPool { get; set; }
        public bool? HasAlarmSystem { get; set; }
        public bool? HasCamera { get; set; }
        public bool? HasPoliceCall { get; set; }
        public bool? IsConstructionYearProjected { get; set; }
        public decimal? Clearance { get; set; }
        public string ClearanceText { get; set; }
        public bool? IsHeatingCostsIncluded { get; set; }
        public decimal? HeatingCosts { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public DateTime? ValidUntil { get; set; }
        public decimal? EnergyConsumptionParameter { get; set; }
        public bool? IncludedHotWater { get; set; }
        public decimal? UltimateEnergyDemand { get; set; }
        public decimal? ElectricityValue { get; set; }
        public decimal? WarmnessValue { get; set; }
        public decimal? SpeedOfInternet { get; set; }
        public bool? IsKitchenFitted { get; set; }
        public bool? IsKitchenOpen { get; set; }
        public bool? IsKitchenPantry { get; set; }
        public bool? HasSeparateToilet { get; set; }
        public bool? LandMarked { get; set; }
        public bool? HasGrannyPart { get; set; }
        public bool? WantEnergyCertificate { get; set; }

        public FurnishType? FurnishType { get; set; }
        public Epart? Epart { get; set; }
        public FeatureCategory? FeatureCategory { get; set; }
        public DesignType? DesignType { get; set; }
        public UnderGroundType? UnderGroundType { get; set; }
        public ConditionArtType? ConditionArtType { get; set; }
        public EnergyCertificateType? EnergyCertificateType { get; set; }
        public AgeGroup? AgeGroup { get; set; }
        public InternetType? InternetType { get; set; }
        public BeaconingType? PrimaryEnegySource { get; set; }
        public EnergyType? EnergyType { get; set; }
        public RollerBlindType? RollerBlindType { get; set; }

        public virtual ICollection<ParkingSpace> ParkingSpaces { get; set; }
        public virtual ICollection<Balcony> Balconies { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
        public virtual ICollection<Heating> Heatings { get; set; }
        public virtual ICollection<Beaconing> Beaconings { get; set; }
        public virtual ICollection<Bathroom> Bathrooms { get; set; }
        public virtual ICollection<EmployeeStatusObject> EmployeeStatuses { get; set; }
    }
}