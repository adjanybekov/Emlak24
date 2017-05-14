using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class BalconyViewModelToBalcony : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BalconyViewModel, Balcony>()
                .ForMember(c => c.Direction, o => o.MapFrom(c => c.Direction))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForMember(c => c.BalconyType, o => o.MapFrom(c => c.BalconyType))
                .ForMember(c => c.Level, o => o.MapFrom(c => c.Level))
                .ForMember(c => c.SightType, o => o.MapFrom(c => c.SightType))
                .ForMember(c => c.Size, o => o.MapFrom(c => c.Size))
                .ForAllOtherMembers(c=>c.Ignore());
        }
    }
}