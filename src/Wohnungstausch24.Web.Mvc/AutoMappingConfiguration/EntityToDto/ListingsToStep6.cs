using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep6 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            #region flat
            cfg.CreateMap<FlatForRent, Step6FlatForRent>()
                .ForMember(c => c.ObjectDescription, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Tercet, o => o.MapFrom(c => c.Tercet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent, Step6RoomForRent>()
                .ForMember(c => c.ObjectDescription, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Tercet, o => o.MapFrom(c => c.Tercet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale, Step6FlatForSale>()
                .ForMember(c => c.ObjectDescription, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Tercet, o => o.MapFrom(c => c.Tercet))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region house


            cfg.CreateMap<HouseForRent, Step6HouseForRent>()
                .ForMember(c => c.ObjectDescription, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step6HouseForSale>()
                .ForMember(c => c.ObjectDescription, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region Land

            cfg.CreateMap<LandForSale, Step6LandForSale>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.ObjectDescription, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}