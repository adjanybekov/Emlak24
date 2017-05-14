using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.ViewModels;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ClientToClientViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Client,ClientViewModel >()
                .ForMember(c => c.AboutMe, o => o.MapFrom(c => c.About))
                .ForMember(c => c.Age, o => o.MapFrom(c => c.Age))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Name, o => o.MapFrom(c => c.Name))
                .ForMember(c => c.Gender, o => o.MapFrom(c => c.Gender))
                .ForMember(c => c.Headline, o => o.MapFrom(c => c.Headline))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.Profession, o => o.MapFrom(c => c.Profession))
                .ForMember(c => c.Persons, o => o.MapFrom(c => c.Persons))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}