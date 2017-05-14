using System.Net;
using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Images;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class ImageDtoToImage : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<FileDto, Wt24File>()
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Id))
                .ForMember(c => c.Name, o => o.MapFrom(c => c.Name))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}