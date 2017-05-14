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
    public class BathroomToBathroomViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Bathroom,BathroomViewModel>()
                .ForMember(c => c.HasBidet, o => o.MapFrom(c => c.HasBidet))
                .ForMember(c => c.HasUrinal, o => o.MapFrom(c => c.HasUrinal))
                .ForMember(c => c.HasShower, o => o.MapFrom(c => c.HasShower))
                .ForMember(c => c.HasTub, o => o.MapFrom(c => c.HasTub))
                .ForMember(c => c.HasWindow, o => o.MapFrom(c => c.HasWindow))
                .ForMember(c => c.Size, o => o.MapFrom(c => c.Size))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}