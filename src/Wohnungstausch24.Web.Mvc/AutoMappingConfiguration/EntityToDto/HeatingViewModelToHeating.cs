using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class HeatingViewModelToHeating : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Heating, HeatingViewModel>()
                .ForMember(c => c.HeatingType, o => o.MapFrom(c => c.HeatingType))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}