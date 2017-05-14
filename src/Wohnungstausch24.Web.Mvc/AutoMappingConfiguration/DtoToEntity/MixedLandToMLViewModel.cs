using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class MixedLandToMLViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MixedLandViewModel, MixedLand>()
                .ForMember(c => c.TypeOfUse, o => o.MapFrom(c => c.TypeOfUse))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.SeparableFrom, o => o.MapFrom(c => c.SeparableFrom))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}