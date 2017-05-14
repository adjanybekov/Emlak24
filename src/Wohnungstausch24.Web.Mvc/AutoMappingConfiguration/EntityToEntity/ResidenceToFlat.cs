using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToEntity
{
    public class ResidenceToFlat : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Residence, Flat>().Ignore(c => c.Level);
        }
    }
}