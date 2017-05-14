using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep2 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<FlatForRent,Step2FlatForRent>()
             .ForMember(c => c.Latitude, o => o.MapFrom(c => c.Latitude.ToString().Replace(",",".")))
             .ForMember(c => c.Longitude, o => o.MapFrom(c => c.Longitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Sights, o => o.MapFrom(c => c.Sights))
             .ForMember(c => c.DistanceToViewModels, o => o.MapFrom(c => c.Distances))
             .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent,Step2RoomForRent>()
             .ForMember(c => c.Latitude, o => o.MapFrom(c => c.Latitude.ToString().Replace(",",".")))
             .ForMember(c => c.Longitude, o => o.MapFrom(c => c.Longitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Sights, o => o.MapFrom(c => c.Sights))
             .ForMember(c => c.DistanceToViewModels, o => o.MapFrom(c => c.Distances))
             .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale,Step2FlatForSale>()
             .ForMember(c => c.Latitude, o => o.MapFrom(c => c.Latitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Longitude, o => o.MapFrom(c => c.Longitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Sights, o => o.MapFrom(c => c.Sights))
                .ForMember(c => c.DistanceToViewModels, o => o.MapFrom(c => c.Distances))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForRent,Step2HouseForRent>()
             .ForMember(c => c.Latitude, o => o.MapFrom(c => c.Latitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Longitude, o => o.MapFrom(c => c.Longitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Sights, o => o.MapFrom(c => c.Sights))
                .ForMember(c => c.DistanceToViewModels, o => o.MapFrom(c => c.Distances))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale,Step2HouseForSale>()
             .ForMember(c => c.Latitude, o => o.MapFrom(c => c.Latitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Longitude, o => o.MapFrom(c => c.Longitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Sights, o => o.MapFrom(c => c.Sights))
                .ForMember(c => c.DistanceToViewModels, o => o.MapFrom(c => c.Distances))
                .ForAllOtherMembers(c => c.Ignore());


            cfg.CreateMap<LandForSale, Step2LandForSale>()
             .ForMember(c => c.Latitude, o => o.MapFrom(c => c.Latitude.ToString().Replace(",", ".")))
             .ForMember(c => c.Longitude, o => o.MapFrom(c => c.Longitude.ToString().Replace(",", ".")))
                .ForMember(c => c.DistanceToViewModels, o => o.MapFrom(c => c.Distances))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}