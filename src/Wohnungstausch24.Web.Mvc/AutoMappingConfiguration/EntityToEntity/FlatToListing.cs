using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToEntity
{
    public class FlatToListing : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Flat, Listing>();
        }
    }
}