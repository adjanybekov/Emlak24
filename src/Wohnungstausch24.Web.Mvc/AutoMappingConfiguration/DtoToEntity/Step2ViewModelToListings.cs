using System.Globalization;
using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step2ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {

            cfg.CreateMap<Step2FlatForRent, FlatForRent>()
                .ForMember(c => c.Latitude, o => o.MapFrom(c => float.Parse(c.Latitude,CultureInfo.InvariantCulture)))
                .ForMember(c => c.Longitude, o => o.MapFrom(c => float.Parse(c.Longitude, CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(c=>c.Ignore());
            cfg.CreateMap<Step2RoomForRent, RoomForRent>()
                .ForMember(c => c.Latitude, o => o.MapFrom(c => float.Parse(c.Latitude,CultureInfo.InvariantCulture)))
                .ForMember(c => c.Longitude, o => o.MapFrom(c => float.Parse(c.Longitude, CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(c=>c.Ignore());

            cfg.CreateMap<Step2FlatForSale, FlatForSale>()
                .ForMember(c => c.Latitude, o => o.MapFrom(c => float.Parse(c.Latitude, CultureInfo.InvariantCulture)))
                .ForMember(c => c.Longitude, o => o.MapFrom(c => float.Parse(c.Longitude, CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step2HouseForRent, HouseForRent>()
                .ForMember(c => c.Latitude, o => o.MapFrom(c => float.Parse(c.Latitude, CultureInfo.InvariantCulture)))
                .ForMember(c => c.Longitude, o => o.MapFrom(c => float.Parse(c.Longitude, CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step2HouseForSale, HouseForSale>()
                .ForMember(c => c.Latitude, o => o.MapFrom(c => float.Parse(c.Latitude, CultureInfo.InvariantCulture)))
                .ForMember(c => c.Longitude, o => o.MapFrom(c => float.Parse(c.Longitude, CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step2LandForSale, LandForSale>()
                .ForMember(c => c.Latitude, o => o.MapFrom(c => float.Parse(c.Latitude, CultureInfo.InvariantCulture)))
                .ForMember(c => c.Longitude, o => o.MapFrom(c => float.Parse(c.Longitude, CultureInfo.InvariantCulture)))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}