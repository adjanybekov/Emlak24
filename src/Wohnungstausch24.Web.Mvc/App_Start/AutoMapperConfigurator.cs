using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Web.Mvc
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations)
        {
            Mapper.Initialize(cfg => autoMapperTypeConfigurations.ToList().ForEach(c => c.Configure(cfg)));        
            Mapper.AssertConfigurationIsValid();
        }
    }
}