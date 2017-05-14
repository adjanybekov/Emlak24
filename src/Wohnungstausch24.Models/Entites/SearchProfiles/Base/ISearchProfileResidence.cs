using System.Collections.Generic;
using Wohnungstausch24.Core.Models;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Base
{
    public interface ISearchProfileResidence : ISearchProfileListing
    {
        bool? HasSauna { get; set; }
        bool? HasSwimmingPool { get; set; }
        bool? HasWashDryingRoom { get; set; }
        bool? HasWinterGarden { get; set; }
        bool? IsSharePossible { get; set; }
        bool? HasChimney { get; set; }
        bool? HasAirCondition { get; set; }
        bool? HasElevator { get; set; }
        bool? HasGardenUtilization { get; set; }
        bool? IsWheelchairAccessible { get; set; }
        bool? HasCableSatTv { get; set; }
        bool? HasGermanTvByAntenna { get; set; }
        bool? HasBarrierFree { get; set; }
        bool? HasStorageRoom { get; set; }
        bool? HasBicycleRoom { get; set; }
        bool? HasRollerBlind { get; set; }
        bool? HasGuestToilet { get; set; }
        bool? HasCableDucts { get; set; }
        bool? IsSeniorFocused { get; set; }
        bool? HasApprovalOfAddress { get; set; }
        bool? IsFurnished { get; set; }
        bool? HasShower { get; set; }
        bool? HasBidet { get; set; }
        bool? HasTub { get; set; }
        bool? HasWindow { get; set; }
        bool? HasUrinal { get; set; }
        bool? HasBalcony { get; set; }
        bool? IsKitchenFitted { get; set; }
        bool? IsKitchenOpen { get; set; }
        bool? IsKitchenPantry { get; set; }

        RangedIntEntityNullable YearOfConstruction { get; set; }
        RangedIntEntityNullable NumberOfLivingRooms { get; set; }
        RangedDecimalEntityNullable ResidentialArea { get; set; }
        RangedIntEntityNullable NumberOfBathRooms { get; set; }
        RangedIntEntityNullable NumberOfParkingLots { get; set; }
        RangedDecimalEntityNullable BalconyTerraceArea { get; set; }
        RangedDecimalEntityNullable GardenArea { get; set; }

        ICollection<SpFeatureCategory> SelectedFeatureCategories { get; set; }
        ICollection<SpFloor> SelectedFloors { get; set; }
        ICollection<SpHeating> SelectedHeatings { get; set; }
        ICollection<SpBeaconing> SelectedBeaconings { get; set; }
        ICollection<SpParkSpace> SelectedParkSpaces { get; set; }
        ICollection<SpGeoDirection> GeoDirection { get; set; }
        ICollection<SpSight> SelectedSights { get; set; }
        ICollection<SpEnergy> SelectedEnergies { get; set; }
        ICollection<SpRollerBlind> SelectedRollerBlinds { get; set; }
    }
}
