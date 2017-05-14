using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class ParkingSpacesViewToParkingSpace : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ParkSpaceViewModel, ParkingSpace>()
                .ForMember(c => c.ParkSpaceType, o => o.MapFrom(c => c.ParkSpaceType))
                .ForMember(c => c.Quantity, o => o.MapFrom(c => c.Quantity))
                .ForMember(c => c.RentPrice, o => o.MapFrom(c => c.RentPrice))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}