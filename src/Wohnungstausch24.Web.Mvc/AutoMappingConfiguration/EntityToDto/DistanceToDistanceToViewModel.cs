using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class DistanceToDistanceToViewModel : IAutoMapperTypeConfigurator
    {

        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Distance, DistanceToViewModel>()
                .ForMember(c => c.DistanceInKm, o => o.MapFrom(c => c.DistanceInKm))
                .ForMember(c => c.DistanceType, o => o.MapFrom(c => c.DistanceType))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}