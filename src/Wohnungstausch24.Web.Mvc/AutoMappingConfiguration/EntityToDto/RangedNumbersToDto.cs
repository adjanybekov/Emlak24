using AutoMapper;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class RangedNumbersToDto:IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<RangedDecimalEntityNullable, RangedDecimal>()
                .ForMember(c => c.From, o => o.MapFrom(c => c.From))
                .ForMember(c => c.To, o => o.MapFrom(c => c.To))
                .ForMember(c => c.Min, o => o.MapFrom(c => c.Min))
                .ForMember(c => c.Max, o => o.MapFrom(c => c.Max))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RangedIntEntityNullable, RangedInt>()
                .ForMember(c => c.From, o => o.MapFrom(c => c.From))
                .ForMember(c => c.To, o => o.MapFrom(c => c.To))
                .ForMember(c => c.Min, o => o.MapFrom(c => c.Min))
                .ForMember(c => c.Max, o => o.MapFrom(c => c.Max))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}