using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep5 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            #region flat
            cfg.CreateMap<FlatForRent, Step5FlatForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent, Step5RoomForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale, Step5FlatForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region house
            cfg.CreateMap<HouseForRent, Step5HouseForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step5HouseForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region Land

            cfg.CreateMap<LandForSale, Step5LandForSale>()
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}