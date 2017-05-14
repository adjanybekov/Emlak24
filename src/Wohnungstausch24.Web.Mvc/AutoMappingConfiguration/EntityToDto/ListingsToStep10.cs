using AutoMapper;
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

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep10 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {           
            #region flat            

            cfg.CreateMap<FlatForRent, Step10FlatForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale, Step10FlatForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region house            
            cfg.CreateMap<HouseForRent, Step10HouseForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step10HouseForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region Land                   

            cfg.CreateMap<LandForSale, Step10LandForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}