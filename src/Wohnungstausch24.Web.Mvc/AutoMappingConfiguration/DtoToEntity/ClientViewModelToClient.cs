using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Agent.SearchProfile;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class ClientViewModelToClient : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ClientViewModel, Client>()
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.About, o => o.MapFrom(c => c.AboutMe))
                .ForMember(c => c.Age, o => o.MapFrom(c => c.Age))
                .ForMember(c => c.Name, o => o.MapFrom(c => c.Name))
                .ForMember(c => c.Gender, o => o.MapFrom(c => c.Gender))
                .ForMember(c => c.Headline, o => o.MapFrom(c => c.Headline))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.Profession, o => o.MapFrom(c => c.Profession))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}