using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.Land;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step10ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
           

           

            #region flat

            cfg.CreateMap<Step10FlatForRent, FlatForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step10FlatForSale, FlatForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region House            

            cfg.CreateMap<Step10HouseForRent, HouseForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step10HouseForSale, HouseForSale>()
                .ForAllOtherMembers(c => c.Ignore());


            #endregion

            #region Land        
          
            cfg.CreateMap<Step10LandForSale, LandForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}