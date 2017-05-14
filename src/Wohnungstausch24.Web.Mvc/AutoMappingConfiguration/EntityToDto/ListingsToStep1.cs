using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep1 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            #region Flat

            cfg.CreateMap<FlatForRent, Step1FlatForRent>()
                .ForMember(c => c.TypeOfMerchandising, o => o.MapFrom(c => TypeOfMerchandising.Rent))
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.ZipCode, o => o.MapFrom(c => c.Zipcode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.PropertyTpe, o => o.MapFrom(c => PropertyType.Flat))
                .ForMember(c => c.NumberOfApartmentUnits, o => o.MapFrom(c => c.NumberOfApartmentUnits))
                .ForMember(c => c.PositionInBuilding, o => o.MapFrom(c => c.PositionInBuilding))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.ForIndustrialUse, o => o.MapFrom(c => c.ForIndustrialUse))
                .ForMember(c => c.ForHolidayUse, o => o.MapFrom(c => c.ForHolidayUse))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent, Step1RoomForRent>()
                .ForMember(c => c.TypeOfMerchandising, o => o.MapFrom(c => TypeOfMerchandising.Rent))
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.ZipCode, o => o.MapFrom(c => c.Zipcode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.PropertyTpe, o => o.MapFrom(c => PropertyType.WazRoom))
                .ForMember(c => c.NumberOfApartmentUnits, o => o.MapFrom(c => c.NumberOfApartmentUnits))
                .ForMember(c => c.PositionInBuilding, o => o.MapFrom(c => c.PositionInBuilding))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.ForIndustrialUse, o => o.MapFrom(c => c.ForIndustrialUse))
                .ForMember(c => c.ForHolidayUse, o => o.MapFrom(c => c.ForHolidayUse))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale, Step1FlatForSale>()
                .ForMember(c => c.TypeOfMerchandising, o => o.MapFrom(c => TypeOfMerchandising.Sale))
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.ZipCode, o => o.MapFrom(c => c.Zipcode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.PropertyTpe, o => o.MapFrom(c => PropertyType.Flat))
                .ForMember(c => c.NumberOfApartmentUnits, o => o.MapFrom(c => c.NumberOfApartmentUnits))
                .ForMember(c => c.PositionInBuilding, o => o.MapFrom(c => c.PositionInBuilding))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region house

            cfg.CreateMap<HouseForRent, Step1HouseForRent>()
                .ForMember(c => c.TypeOfMerchandising, o => o.MapFrom(c => TypeOfMerchandising.Rent))
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.ZipCode, o => o.MapFrom(c => c.Zipcode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.PropertyTpe, o => o.MapFrom(c => PropertyType.House))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.ForIndustrialUse, o => o.MapFrom(c => c.ForIndustrialUse))
                .ForMember(c => c.ForHolidayUse, o => o.MapFrom(c => c.ForHolidayUse))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step1HouseForSale>()
                .ForMember(c => c.TypeOfMerchandising, o => o.MapFrom(c => TypeOfMerchandising.Sale))
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.PropertySubType, o => o.MapFrom(c => c.PropertySubType))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.HouseNumber, o => o.MapFrom(c => c.HouseNumber))
                .ForMember(c => c.ZipCode, o => o.MapFrom(c => c.Zipcode))
                .ForMember(c => c.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(c => c.IsFurnished, o => o.MapFrom(c => c.IsFurnished))
                .ForMember(c => c.IsShared, o => o.MapFrom(c => c.IsShared))
                .ForMember(c => c.FurnishType, o => o.MapFrom(c => c.FurnishType))
                .ForMember(c => c.PropertyTpe, o => o.MapFrom(c => PropertyType.House))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region Land


            cfg.CreateMap<LandForSale, Step1LandForSale>()
                .ForMember(c => c.TypeOfMerchandising, o => o.MapFrom(c => TypeOfMerchandising.Sale))
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.ShowFullAddressInPublic, o => o.MapFrom(c => c.ShowFullAddressInPublic))
                .ForMember(c => c.Locationlevel3, o => o.MapFrom(c => c.Locationlevel3))
                .ForMember(c => c.Street, o => o.MapFrom(c => c.Street))
                .ForMember(c => c.ZipCode, o => o.MapFrom(c => c.Zipcode))
                .ForMember(c => c.PropertyTpe, o => o.MapFrom(c => PropertyType.Land))
                .ForMember(c => c.SubUrbLeft, o => o.MapFrom(c => c.SubUrbLeft))
                .ForMember(c => c.FloorTypeNumerator, o => o.MapFrom(c => c.FloorTypeNumerator))
                .ForMember(c => c.FloorTypeDenumerator, o => o.MapFrom(c => c.FloorTypeDenumerator))
                .ForMember(c => c.Boundary, o => o.MapFrom(c => c.Boundary))
                .ForMember(c => c.Floor, o => o.MapFrom(c => c.Floor))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}