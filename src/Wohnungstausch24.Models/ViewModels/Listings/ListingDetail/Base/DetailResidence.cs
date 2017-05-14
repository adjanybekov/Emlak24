using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base
{
    public class DetailResidence :DetailListing, IDetailResidence
    {
        [Display(Name = "FeatureCategory", ResourceType = typeof(Resource))]
        public FeatureCategory? FeatureCategory { get; set; }
        [Display(Name = "ConditionArtType", ResourceType = typeof(Resource))]
        public ConditionArtType? ConditionArtType { get; set; }
        [Display(Name = "LastRenovationDate", ResourceType = typeof(Resource))]
        public DateTime? LastRenovationDate { get; set; }
        [Display(Name = "DesignType", ResourceType = typeof(Resource))]
        public DesignType? DesignType { get; set; }
        public List<BalconyViewModel> Balconies { get; set; }
        public List<HeatingViewModel> Heatings { get; set; }
        public List<ParkSpaceViewModel> ParkSpaces { get; set; }
        public List<BathroomViewModel> Bathrooms { get; set; }
        public List<FloorViewModel> Floors { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Detail_HasWinterGarden")]
        public bool? HasWinterGarden { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasStorageRoom")]
        public bool? HasStorageRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasBicycleRoom")]
        public bool? HasBicycleRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasWashDryingRoom")]
        public bool? HasWashDryingRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasElevator")]
        public bool? HasElevator { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasChimney")]
        public bool? HasChimney { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasRollerBlind")]
        public bool? HasRollerBlind { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasCableSatTv")]
        public bool? HasCableSatTv { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasGermanTvByAntenna")]
        public bool? HasGermanTvByAntenna { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasInternet")]
        public bool? HasInternet { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasCableDucts")]
        public bool? HasCableDucts { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_IsSeniorFocused")]
        public bool? IsSeniorFocused { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_IsWheelchairAccessible")]
        public bool? IsWheelchairAccessible { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_IsBarrierFree")]
        public bool? IsBarrierFree { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasLibrary")]
        public bool? HasLibrary { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasAttic")]
        public bool? HasAttic { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_AtticSpace")]
        public decimal AtticSpace { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasAirCondition")]
        public bool? HasAirCondition { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasSauna_de")]
        public bool? HasSauna { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasSwimmingPool")]
        public bool? HasSwimmingPool { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasAlarmSystem")]
        public bool? HasAlarmSystem { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasCamera")]
        public bool? HasCamera { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasPoliceCall")]
        public bool? HasPoliceCall { get; set; }
        [Display(Name = "Property_Add_Clearence", ResourceType = typeof(Resource))]
        public decimal? Clearance { get; set; }
        [Display(Name = "Property_Add_ClearenceText", ResourceType = typeof(Resource))]
        public string ClearanceText { get; set; }
        [Display(Name = "Property_Add_IsHeatingCostsIncluded", ResourceType = typeof(Resource))]
        public bool IsHeatingCostsIncluded { get; set; }
        [Display(Name = "Property_Add_HeatingCosts", ResourceType = typeof(Resource))]
        public decimal? HeatingCosts { get; set; }
        [Display(Name = "Property_Step3_Cold_Rent", ResourceType = typeof(Resource))]
        public decimal? ColdRent { get; set; }
        [Display(Name = "Property_Add_AdditionalCosts", ResourceType = typeof(Resource))]
        public decimal? AdditionalCosts { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "DetailResidence_IsKitchenFitted")]
        public bool? IsKitchenFitted { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "DetailResidence_IsKitchenOpen")]
        public bool? IsKitchenOpen { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "DetailResidence_IsKitchenPantry")]
        public bool? IsKitchenPantry { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_LivingArea")]
        public decimal LivingArea { get; set; }
        [Display(Name = "Number_Of_Rooms", ResourceType = typeof(Resource))]
        public int NumberOfRooms { get; set; }
        [Display(Name = "Number_Of_Living_Bedrooms", ResourceType = typeof(Resource))]
        public int NumberOfBedrooms { get; set; }
        [Display(Name = "Property_Add_NumberOfLevels", ResourceType = typeof(Resource))]
        public int NumberOfLevels { get; set; }
        [Display(Name = "Property_Add_IsFlatSharePossible", ResourceType = typeof(Resource))]
        public bool IsShared { get; set; }
        [Display(Name = "Property_Add_IsFurnished", ResourceType = typeof(Resource))]
        public bool IsFurnished { get; set; }
        [Display(Name = "Basement_area", ResourceType = typeof(Resource))]
        public decimal BasementArea { get; set; }
        [Display(Name = "Property_Add_UsefulArea", ResourceType = typeof(Resource))]
        public decimal UsefulArea { get; set; }
        [Display(Name = "Number_Of_Living_Bedrooms", ResourceType = typeof(Resource))]
        public int NumberOfLivingBedrooms { get; set; }
        public List<BeaconingViewModel> Beaconings { get; set; }
        [Display(Name = "PrimaryEnegySource", ResourceType = typeof(Resource))]
        public BeaconingType? PrimaryEnergySource { get; set; }
        [Display(Name = "EnergyCertificateType", ResourceType = typeof(Resource))]
        public EnergyCertificateType? EnergyCertificateType { get; set; }
        [Display(Name = "Property_Step8_ConstructionYear", ResourceType = typeof(Resource))]
        public int? ConstructionYear { get; set; }
        [Display(Name = "Property_Step8_AgeGroup", ResourceType = typeof(Resource))]
        public AgeGroup? AgeGroup { get; set; }
        [Display(Name = "ValidUntil", ResourceType = typeof(Resource))]
        public DateTime? ValidUntil { get; set; }
        [Display(Name = "EnergyConsumptionParameter", ResourceType = typeof(Resource))]
        public decimal? EnergyConsumptionParameter { get; set; }
        [Display(Name = "IncludedHotWater", ResourceType = typeof(Resource))]
        public bool? IncludedHotWater { get; set; }
        [Display(Name = "UltimateEnergyDemand", ResourceType = typeof(Resource))]
        public decimal? UltimateEnergyDemand { get; set; }
        [Display(Name = "ElectricityValue", ResourceType = typeof(Resource))]
        public decimal? ElectricityValue { get; set; }
        [Display(Name = "WarmnessValue", ResourceType = typeof(Resource))]
        public decimal? WarmnessValue { get; set; }
        [Display(Name = "ValueRating", ResourceType = typeof(Resource))]
        public int? ValueRating { get; set; }
    }
}