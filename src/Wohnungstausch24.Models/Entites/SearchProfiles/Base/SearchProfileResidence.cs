using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Base
{
    public class SearchProfileResidence : SearchProfileListing, ISearchProfileResidence
    {
        public SearchProfileResidence()
        {
            YearOfConstruction = new RangedIntEntityNullable();
            NumberOfLivingRooms = new RangedIntEntityNullable();
            ResidentialArea = new RangedDecimalEntityNullable();
            NumberOfBathRooms = new RangedIntEntityNullable();
            NumberOfParkingLots = new RangedIntEntityNullable();
            BalconyTerraceArea = new RangedDecimalEntityNullable();
            GardenArea = new RangedDecimalEntityNullable();
            SelectedFeatureCategories = new HashSet<SpFeatureCategory>();
            SelectedFloors = new HashSet<SpFloor>();
            SelectedHeatings = new HashSet<SpHeating>();
            SelectedBeaconings = new HashSet<SpBeaconing>();
            SelectedParkSpaces = new HashSet<SpParkSpace>();
            GeoDirection = new HashSet<SpGeoDirection>();
            SelectedSights = new HashSet<SpSight>();
            SelectedEnergies = new HashSet<SpEnergy>();
            SelectedRollerBlinds = new HashSet<SpRollerBlind>();
        }
        public bool? HasSauna { get; set; }
        public bool? HasSwimmingPool { get; set; }
        public bool? HasWashDryingRoom { get; set; }
        public bool? HasWinterGarden { get; set; }
        public bool? IsSharePossible { get; set; }
        public bool? HasChimney { get; set; }
        public bool? HasAirCondition { get; set; }
        public bool? HasElevator { get; set; }
        public bool? HasGardenUtilization { get; set; }
        public bool? IsWheelchairAccessible { get; set; }
        public bool? HasCableSatTv { get; set; }
        public bool? HasGermanTvByAntenna { get; set; }
        public bool? HasBarrierFree { get; set; }
        public bool? HasStorageRoom { get; set; }
        public bool? HasBicycleRoom { get; set; }
        public bool? HasRollerBlind { get; set; }
        public bool? HasGuestToilet { get; set; }
        public bool? HasCableDucts { get; set; }
        public bool? IsSeniorFocused { get; set; }
        public bool? HasApprovalOfAddress { get; set; }
        public bool? IsFurnished { get; set; }
        public bool? HasShower { get; set; }
        public bool? HasBidet { get; set; }
        public bool? HasTub { get; set; }
        public bool? HasWindow { get; set; }
        public bool? HasUrinal { get; set; }
        public bool? HasBalcony { get; set; }
        public bool? IsKitchenFitted { get; set; }
        public bool? IsKitchenOpen { get; set; }
        public bool? IsKitchenPantry { get; set; }
        public virtual RangedIntEntityNullable YearOfConstruction { get; set; }
        public virtual RangedIntEntityNullable NumberOfLivingRooms { get; set; }
        public virtual RangedDecimalEntityNullable ResidentialArea { get; set; }
        public virtual RangedIntEntityNullable NumberOfBathRooms { get; set; }
        public virtual RangedIntEntityNullable NumberOfParkingLots { get; set; }
        public virtual RangedDecimalEntityNullable BalconyTerraceArea { get; set; }
        public virtual RangedDecimalEntityNullable GardenArea { get; set; }
        public virtual ICollection<SpFeatureCategory> SelectedFeatureCategories { get; set; }
        public virtual ICollection<SpFloor> SelectedFloors { get; set; }
        public virtual ICollection<SpHeating> SelectedHeatings { get; set; }
        public virtual ICollection<SpBeaconing> SelectedBeaconings { get; set; }
        public virtual ICollection<SpParkSpace> SelectedParkSpaces { get; set; }
        public virtual ICollection<SpGeoDirection> GeoDirection { get; set; }
        public virtual ICollection<SpSight> SelectedSights { get; set; }
        public virtual ICollection<SpEnergy> SelectedEnergies { get; set; }
        public virtual ICollection<SpRollerBlind> SelectedRollerBlinds { get; set; }
    }

    public class SpRollerBlind : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public RollerBlindType RollerBlindType{ get; set; }
    }
    public class SpEnergy : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public EnergyType EnergyType { get; set; }
    }
    public class SpSight : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public SightType SightType { get; set; }
    }
    public class SpGeoDirection : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public GeoDirection GeoDirection { get; set; }
    }
    public class SpParkSpace : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public ParkSpaceType ParkSpaceType { get; set; }
    }
    public class SpBeaconing : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public BeaconingType BeaconingType{ get; set; }
    }
    public class SpHeating : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public HeatingType HeatingType { get; set; }
    }
    public class SpFeatureCategory:Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public FeatureCategory FeatureCategory { get; set; }
    }
    public class SpFloor : Entity<int>
    {
        public int SpResidenceId { get; set; }
        public SearchProfileResidence SpResidence { get; set; }
        public FloorType FloorType { get; set; }
    }
}