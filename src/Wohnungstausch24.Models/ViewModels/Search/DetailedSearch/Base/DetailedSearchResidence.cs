using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base
{
    public class DetailedSearchResidence : DetailedSearchListing, IDetailedSearchResidence
    {
        public DetailedSearchResidence()
        {
            this.FeatureCategoryViewModels =
                Enum.GetValues(typeof(FeatureCategory))
                    .Cast<FeatureCategory>()
                    .Select(c => new FeatureCategoryViewModel {FeatureCategory = c, Selected = false})
                    .ToList();
            this.FloorViewModels =
                Enum.GetValues(typeof(FloorType))
                    .Cast<FloorType>()
                    .Select(c => new FloorViewModel {FloorType = c, Selected = false})
                    .ToList();
            this.HeatingTypeViewModels =
                Enum.GetValues(typeof(HeatingType))
                    .Cast<HeatingType>()
                    .Select(c => new HeatingTypeViewModel {HeatingType = c, Selected = false})
                    .ToList();
            this.BeaconingTypeViewModels =
                Enum.GetValues(typeof(BeaconingType))
                    .Cast<BeaconingType>()
                    .Select(c => new BeaconingTypeViewModel {BeaconingType = c, Selected = false})
                    .ToList();
            this.ParkSpaceTypeViewModels =
                Enum.GetValues(typeof(ParkSpaceType))
                    .Cast<ParkSpaceType>()
                    .Select(c => new ParkSpaceTypeViewModel {ParkSpaceType = c, Selected = false})
                    .ToList();
            this.AdjustmentBalconyTerrace =
                Enum.GetValues(typeof(GeoDirection))
                    .Cast<GeoDirection>()
                    .Select(c => new GeoDirectionViewModel {GeoDirection = c, Selected = false})
                    .ToList();
            this.SightTypeViewModels =
                Enum.GetValues(typeof(SightType))
                    .Cast<SightType>()
                    .Select(c => new SightTypeViewModel {SightType = c, Selected = false})
                    .ToList();
            this.EnergyTypeViewModels =
                Enum.GetValues(typeof(EnergyType))
                    .Cast<EnergyType>()
                    .Select(c => new EnergyTypeViewModel {EnergyType = c, Selected = false})
                    .ToList();
            this.RollerBlindTypeViewModels =
                Enum.GetValues(typeof(RollerBlindType))
                    .Cast<RollerBlindType>()
                    .Select(c => new RollerBlindTypeViewModel {RollerBlindType = c, Selected = false})
                    .ToList();
        }
        [Display(ResourceType = typeof(Resource),Name = "Property_Add_IsFlatSharePossible")]
        public bool IsSharePossible { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasChimney")]
        public bool HasChimney { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasAirCondition")]
        public bool HasAirCondition { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasElevator")]
        public bool HasElevator { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsGardenUtilizationPossible")]
        public bool HasGardenUtilization { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsWheelchairAccessible")]
        public bool IsWheelchairAccessible { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasCableSatTv")]
        public bool HasCableSatTv { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasGermanTvByAntenna")]
        public bool HasGermanTvByAntenna { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsBarrierFree")]
        public bool HasBarrierFree { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasSauna")]
        public bool HasSauna { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasSwimmingPool")]
        public bool HasSwimmingPool { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasWashDryingRoom")]
        public bool HasWashDryingRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasWinterGarden")]
        public bool HasWinterGarden { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasBalcony")]
        public bool HasBalcony { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasStorageRoom")]
        public bool HasStorageRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasBicycleRoom")]
        public bool HasBicycleRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasRollerBlind")]
        public bool HasRollerBlind { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasGuestToilet")]
        public bool HasGuestToilet { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasCableDucts")]
        public bool HasCableDucts { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsSeniorFocused")]
        public bool IsSeniorFocused { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_ApprovalOfAddress")]
        public bool HasApprovalOfAddress { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_IsFurnished")]
        public bool IsFurnished { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasShower")]
        public bool HasShower { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasBidet")]
        public bool HasBidet { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasTub")]
        public bool HasTub { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasWindow")]
        public bool HasWindow { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_HasUrinal")]
        public bool HasUrinal { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_KitchenType_Fitted")]
        public bool IsKitchenFitted { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_KitchenType_Open")]
        public bool IsKitchenOpen { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Enum_KitchenType_Pantry")]
        public bool IsKitchenPantry { get; set; }

        public List<FeatureCategoryViewModel> FeatureCategoryViewModels { get; set; }
        public List<FloorViewModel> FloorViewModels { get; set; }
        public List<HeatingTypeViewModel> HeatingTypeViewModels { get; set; }
        public List<BeaconingTypeViewModel> BeaconingTypeViewModels { get; set; }
        public List<ParkSpaceTypeViewModel> ParkSpaceTypeViewModels { get; set; }
        public List<GeoDirectionViewModel> AdjustmentBalconyTerrace { get; set; }
        public List<SightTypeViewModel> SightTypeViewModels { get; set; }

        public List<EnergyTypeViewModel> EnergyTypeViewModels { get; set; }
        public List<RollerBlindTypeViewModel> RollerBlindTypeViewModels { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_YearOfConstruction")]
        public RangedInt YearOfConstruction { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_NumberOfLivingRooms")]
        public RangedInt NumberOfLivingRooms { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_ResidentialArea")]
        public RangedDecimal ResidentialArea { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_NumberOfBathRooms")]
        public RangedInt NumberOfBathRooms { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_NumberOfParkingLots")]
        public RangedInt NumberOfParkingLots { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_BalconyTerraceArea")]
        public RangedDecimal BalconyTerraceArea { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Ranged_GardenArea")]
        public RangedDecimal GardenArea { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "DetailedSearch_IsDateFlexible")]
        public bool IsDateFlexible { get; set; }
    }
}