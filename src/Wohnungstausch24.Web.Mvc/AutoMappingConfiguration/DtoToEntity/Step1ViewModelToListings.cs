using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step1ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Step1FlatForRent, FlatForRent>()
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.Zipcode, o => o.MapFrom(c => c.ZipCode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.PositionInBuilding, o => o.MapFrom(c => c.PositionInBuilding))
                .ForMember(c => c.NumberOfApartmentUnits, o => o.MapFrom(c => c.NumberOfApartmentUnits))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.ForIndustrialUse, o => o.MapFrom(c => c.ForIndustrialUse))
                .ForMember(c => c.ForHolidayUse, o => o.MapFrom(c => c.ForHolidayUse))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step1RoomForRent, RoomForRent>()
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.Zipcode, o => o.MapFrom(c => c.ZipCode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.PositionInBuilding, o => o.MapFrom(c => c.PositionInBuilding))
                .ForMember(c => c.NumberOfApartmentUnits, o => o.MapFrom(c => c.NumberOfApartmentUnits))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.ForIndustrialUse, o => o.MapFrom(c => c.ForIndustrialUse))
                .ForMember(c => c.ForHolidayUse, o => o.MapFrom(c => c.ForHolidayUse))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step1FlatForSale, FlatForSale>()
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.Zipcode, o => o.MapFrom(c => c.ZipCode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.PositionInBuilding, o => o.MapFrom(c => c.PositionInBuilding))
                .ForMember(c => c.NumberOfApartmentUnits, o => o.MapFrom(c => c.NumberOfApartmentUnits))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step1HouseForRent, HouseForRent>()
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.Zipcode, o => o.MapFrom(c => c.ZipCode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.ForIndustrialUse, o => o.MapFrom(c => c.ForIndustrialUse))
                .ForMember(c => c.ForHolidayUse, o => o.MapFrom(c => c.ForHolidayUse))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step1HouseForSale, HouseForSale>()
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.Zipcode, o => o.MapFrom(c => c.ZipCode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step1LandForSale, LandForSale>()
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.Zipcode, o => o.MapFrom(c => c.ZipCode))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                 .ForMember(c => c.FloorTypeNumerator, o => o.MapFrom(c => c.FloorTypeNumerator))
                .ForMember(c => c.FloorTypeDenumerator, o => o.MapFrom(c => c.FloorTypeDenumerator))
                .ForMember(c => c.Boundary, o => o.MapFrom(c => c.Boundary))
                .ForMember(c => c.Floor, o => o.MapFrom(c => c.Floor))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}