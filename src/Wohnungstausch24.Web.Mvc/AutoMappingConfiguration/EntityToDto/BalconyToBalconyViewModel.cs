using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class BalconyToBalconyViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Balcony, BalconyViewModel>()
                .ForMember(c => c.Direction, o => o.MapFrom(c => c.Direction))
                .ForMember(c => c.BalconyType, o => o.MapFrom(c => c.BalconyType))
                .ForMember(c => c.SightType, o => o.MapFrom(c => c.SightType))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.Size, o => o.MapFrom(c => c.Size))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}