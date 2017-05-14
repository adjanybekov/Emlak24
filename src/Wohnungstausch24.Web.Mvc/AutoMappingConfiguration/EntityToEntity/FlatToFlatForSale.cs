using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToEntity
{
    public class FlatToFlatForSale : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Flat, FlatForSale>();
        }
    }
}