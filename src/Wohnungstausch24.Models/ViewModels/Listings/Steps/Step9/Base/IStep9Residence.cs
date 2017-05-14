using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base
{
    public interface IStep9Residence:IStep9Listing
    {
        FeatureCategory? FeatureCategory { get; set; }
        DateTime? LastRenovationDate { get; set; }
        DesignType? DesignType { get; set; }
        AddKitchenViewModel AddKitchenViewModel { get; set; }
        AddBathroomViewModel AddBathroomViewModel{ get; set; }
        List<FloorViewModel> FloorTypes { get; set; }
        bool HasWinterGarden { get; set; }
        bool HasStorageRoom { get; set; }
        bool HasBicycleRoom { get; set; }
        bool HasWashDryingRoom { get; set; }
        bool HasElevator { get; set; }
        bool HasChimney { get; set; }
        bool HasRollerBlind { get; set; }
        bool HasCableSatTv { get; set; }
        bool HasGermanTvByAntenna { get; set; }
        bool HasInternet { get; set; }
        bool HasCableDucts { get; set; }
        bool IsSeniorFocused { get; set; }
        bool IsWheelchairAccessible { get; set; }
        bool IsBarrierFree { get; set; }
        bool IsApartmentTower { get; set; }
        bool HasLibrary { get; set; }
        bool HasAttic { get; set; }
        bool HasAirCondition { get; set; }
        bool HasSauna { get; set; }
        bool HasSwimmingPool { get; set; }
        bool HasAlarmSystem { get; set; }
        bool HasCamera { get; set; }
        bool HasPoliceCall { get; set; }
        bool IsKitchenFitted { get; set; }
        bool IsKitchenOpen { get; set; }
        bool IsKitchenPantry { get; set; }
        int? ConstructionYear { get; set; }
        bool IsConstructionYearProjected { get; set; }
        bool LandMarked { get; set; }
        InternetType? InternetType { get; set; }
        RollerBlindType? RollerBlindType { get; set; }
        decimal? SpeedOfInternet { get; set; }
        ConditionArtType? ConditionArtType { get; set; }
    }
}
