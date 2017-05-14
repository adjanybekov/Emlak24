using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToEntity
{
    public class FlatToFlatForRent : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Flat, FlatForRent>()
                .Ignore(c => c.CurrentColdRent)
                .Ignore(c => c.IsActualContractTerminated)
                .Ignore(c => c.ActualContractTerminatedOn)
                .Ignore(c => c.EarliestAvailableDate)
                .Ignore(c => c.LatestAvailableDate)
                .Ignore(c => c.AdditionalCosts)
                .Ignore(c => c.Bail)
                .Ignore(c => c.BailText)
                .Ignore(c => c.BasicRent)
                .Ignore(c => c.IsHeatingCostsIncluded)
                .Ignore(c => c.RentalPricePerSqm)
                .Ignore(c => c.HeatingCosts)
                .Ignore(c => c.WarmRent)
                .Ignore(c => c.FreeTextPrice);
        }
    }
}