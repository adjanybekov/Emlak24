using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class TextInAnotherLanguageViewModelToObjectTextInAnotherLanguage : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ObjectTextInAnotherLanguage, TextInAnotherLanguageViewModel>()
                .ForMember(c => c.LanguageCode, o => o.MapFrom(c => c.LanguageCode))
                .ForMember(c => c.Description, o => o.MapFrom(c => c.Description))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}