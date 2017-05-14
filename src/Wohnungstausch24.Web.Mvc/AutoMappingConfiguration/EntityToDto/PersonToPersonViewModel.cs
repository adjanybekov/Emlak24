using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class PersonToPersonViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Person, PersonViewModel>()
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForMember(c => c.Gender, o => o.MapFrom(c => c.Gender))
                .ForMember(c => c.Profession, o => o.MapFrom(c => c.Profession))
                .ForMember(c => c.Age, o => o.MapFrom(c => c.Age))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}