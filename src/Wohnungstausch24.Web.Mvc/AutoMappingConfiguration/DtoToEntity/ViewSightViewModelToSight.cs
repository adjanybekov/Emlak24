using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class ViewSightViewModelToSight : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ViewSightViewModel, Sight>()
                .ForMember(c => c.SightType, o => o.MapFrom(c => c.SightType))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
               .ForAllOtherMembers(c => c.Ignore());
        }
    }        
}