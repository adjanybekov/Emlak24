using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Room;
using Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto.CustomResolvers;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep9 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            #region flat

            cfg.CreateMap<FlatForRent, Step9FlatForRent>()
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasAlarmSystem, o => o.MapFrom(c => c.HasAlarmSystem))
                .ForMember(c => c.HasAttic, o => o.MapFrom(c => c.HasAttic))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasCamera, o => o.MapFrom(c => c.HasCamera))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasInternet, o => o.MapFrom(c => c.HasInternet))
                .ForMember(c => c.HasLibrary, o => o.MapFrom(c => c.HasLibrary))
                .ForMember(c => c.HasPoliceCall, o => o.MapFrom(c => c.HasPoliceCall))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsApartmentTower, o => o.MapFrom(c => c.IsApartmentTower))
                .ForMember(c => c.IsBarrierFree, o => o.MapFrom(c => c.IsBarrierFree))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.FeatureCategory, o => o.MapFrom(c => c.FeatureCategory))
                .ForMember(c => c.ConditionArtType, o => o.MapFrom(c => c.ConditionArtType))
                .ForMember(c => c.LastRenovationDate, o => o.MapFrom(c => c.LastRenovationDate))
                .ForMember(c => c.DesignType, o => o.MapFrom(c => c.DesignType))
                .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.FloorTypes, o => o.ResolveUsing<FloorTypesResolver>())
                .ForMember(c => c.ConstructionYear, o => o.MapFrom(c => c.ConstructionYear))
                .ForMember(c => c.IsConstructionYearProjected, o => o.MapFrom(c => c.IsConstructionYearProjected))
                .ForMember(c => c.FlatNumber, o => o.MapFrom(c => c.FlatNumber))
                 .ForMember(c => c.InternetType, o => o.MapFrom(c => c.InternetType))
                .ForMember(c => c.SpeedOfInternet, o => o.MapFrom(c => c.SpeedOfInternet))
                .ForMember(c => c.RollerBlindType, o => o.MapFrom(c => c.RollerBlindType))
                .ForMember(c => c.HasHousingPermission, o => o.MapFrom(c => c.HasHousingPermission))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent, Step9RoomForRent>()
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasAlarmSystem, o => o.MapFrom(c => c.HasAlarmSystem))
                .ForMember(c => c.HasAttic, o => o.MapFrom(c => c.HasAttic))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasCamera, o => o.MapFrom(c => c.HasCamera))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasInternet, o => o.MapFrom(c => c.HasInternet))
                .ForMember(c => c.HasLibrary, o => o.MapFrom(c => c.HasLibrary))
                .ForMember(c => c.HasPoliceCall, o => o.MapFrom(c => c.HasPoliceCall))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsApartmentTower, o => o.MapFrom(c => c.IsApartmentTower))
                .ForMember(c => c.IsBarrierFree, o => o.MapFrom(c => c.IsBarrierFree))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.FeatureCategory, o => o.MapFrom(c => c.FeatureCategory))
                .ForMember(c => c.ConditionArtType, o => o.MapFrom(c => c.ConditionArtType))
                .ForMember(c => c.LastRenovationDate, o => o.MapFrom(c => c.LastRenovationDate))
                .ForMember(c => c.DesignType, o => o.MapFrom(c => c.DesignType))
                .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.FloorTypes, o => o.ResolveUsing<FloorTypesResolver>())
                .ForMember(c => c.ConstructionYear, o => o.MapFrom(c => c.ConstructionYear))
                .ForMember(c => c.IsConstructionYearProjected, o => o.MapFrom(c => c.IsConstructionYearProjected))
                .ForMember(c => c.FlatNumber, o => o.MapFrom(c => c.FlatNumber))
                 .ForMember(c => c.InternetType, o => o.MapFrom(c => c.InternetType))
                .ForMember(c => c.SpeedOfInternet, o => o.MapFrom(c => c.SpeedOfInternet))
                .ForMember(c => c.RollerBlindType, o => o.MapFrom(c => c.RollerBlindType))
                .ForMember(c => c.HasHousingPermission, o => o.MapFrom(c => c.HasHousingPermission))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale, Step9FlatForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region house

            cfg.CreateMap<HouseForRent, Step9HouseForRent>()
                .ForMember(c => c.HasAirCondition, o => o.MapFrom(c => c.HasAirCondition))
                .ForMember(c => c.HasAlarmSystem, o => o.MapFrom(c => c.HasAlarmSystem))
                .ForMember(c => c.HasAttic, o => o.MapFrom(c => c.HasAttic))
                .ForMember(c => c.HasBicycleRoom, o => o.MapFrom(c => c.HasBicycleRoom))
                .ForMember(c => c.HasCableDucts, o => o.MapFrom(c => c.HasCableDucts))
                .ForMember(c => c.HasCableSatTv, o => o.MapFrom(c => c.HasCableSatTv))
                .ForMember(c => c.HasCamera, o => o.MapFrom(c => c.HasCamera))
                .ForMember(c => c.HasChimney, o => o.MapFrom(c => c.HasChimney))
                .ForMember(c => c.HasElevator, o => o.MapFrom(c => c.HasElevator))
                .ForMember(c => c.HasGermanTvByAntenna, o => o.MapFrom(c => c.HasGermanTvByAntenna))
                .ForMember(c => c.HasInternet, o => o.MapFrom(c => c.HasInternet))
                .ForMember(c => c.HasLibrary, o => o.MapFrom(c => c.HasLibrary))
                .ForMember(c => c.HasPoliceCall, o => o.MapFrom(c => c.HasPoliceCall))
                .ForMember(c => c.HasRollerBlind, o => o.MapFrom(c => c.HasRollerBlind))
                .ForMember(c => c.HasSauna, o => o.MapFrom(c => c.HasSauna))
                .ForMember(c => c.HasStorageRoom, o => o.MapFrom(c => c.HasStorageRoom))
                .ForMember(c => c.HasSwimmingPool, o => o.MapFrom(c => c.HasSwimmingPool))
                .ForMember(c => c.HasWashDryingRoom, o => o.MapFrom(c => c.HasWashDryingRoom))
                .ForMember(c => c.HasWinterGarden, o => o.MapFrom(c => c.HasWinterGarden))
                .ForMember(c => c.IsApartmentTower, o => o.MapFrom(c => c.IsApartmentTower))
                .ForMember(c => c.IsBarrierFree, o => o.MapFrom(c => c.IsBarrierFree))
                .ForMember(c => c.IsSeniorFocused, o => o.MapFrom(c => c.IsSeniorFocused))
                .ForMember(c => c.IsWheelchairAccessible, o => o.MapFrom(c => c.IsWheelchairAccessible))
                .ForMember(c => c.FeatureCategory, o => o.MapFrom(c => c.FeatureCategory))
                .ForMember(c => c.ConditionArtType, o => o.MapFrom(c => c.ConditionArtType))
                .ForMember(c => c.LastRenovationDate, o => o.MapFrom(c => c.LastRenovationDate))
                .ForMember(c => c.DesignType, o => o.MapFrom(c => c.DesignType))
                .ForMember(c => c.RoofType, o => o.MapFrom(c => c.RoofType))
                 .ForMember(c => c.IsKitchenOpen, o => o.MapFrom(c => c.IsKitchenOpen))
                .ForMember(c => c.IsKitchenFitted, o => o.MapFrom(c => c.IsKitchenFitted))
                .ForMember(c => c.IsKitchenPantry, o => o.MapFrom(c => c.IsKitchenPantry))
                .ForMember(c => c.FloorTypes, o => o.ResolveUsing<FloorTypesResolver>())
                .ForMember(c => c.ConstructionYear, o => o.MapFrom(c => c.ConstructionYear))
                .ForMember(c => c.IsConstructionYearProjected, o => o.MapFrom(c => c.IsConstructionYearProjected))
                .ForMember(c => c.LandMarked, o => o.MapFrom(c => c.LandMarked))
                 .ForMember(c => c.InternetType, o => o.MapFrom(c => c.InternetType))
                .ForMember(c => c.SpeedOfInternet, o => o.MapFrom(c => c.SpeedOfInternet))
                .ForMember(c => c.RollerBlindType, o => o.MapFrom(c => c.RollerBlindType))
                .ForMember(c => c.HasHousingPermission, o => o.MapFrom(c => c.HasHousingPermission))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step9HouseForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region Land

            cfg.CreateMap<LandForSale, Step9LandForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}