using AutoMapper;
using Wohnungstausch24.Core.Extensions;
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

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step6ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {

            cfg.CreateMap<Step6FlatForRent, FlatForRent>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.ObjectDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))                
                .ForMember(c => c.Tercet, o => o.MapFrom(c => c.Tercet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step6RoomForRent, RoomForRent>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.ObjectDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))                
                .ForMember(c => c.Tercet, o => o.MapFrom(c => c.Tercet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step6FlatForSale, FlatForSale>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.ObjectDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))                
                .ForMember(c => c.Tercet, o => o.MapFrom(c => c.Tercet))
                .ForAllOtherMembers(c => c.Ignore());
            
            cfg.CreateMap<Step6HouseForRent, HouseForRent>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.ObjectDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))                
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step6HouseForSale, HouseForSale>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.ObjectDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))                
                .ForAllOtherMembers(c => c.Ignore());                       

            cfg.CreateMap<Step6LandForSale, LandForSale>()
                .ForMember(c => c.ListingHeader, o => o.MapFrom(c => c.ListingHeader))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.ObjectDescription))
                .ForMember(c => c.LocationDescription, o => o.MapFrom(c => c.LocationDescription))
                .ForMember(c => c.EnvironmentDescription, o => o.MapFrom(c => c.EnvironmentDescription))
                .ForMember(c => c.OtherDetails, o => o.MapFrom(c => c.OtherDetails))                
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}