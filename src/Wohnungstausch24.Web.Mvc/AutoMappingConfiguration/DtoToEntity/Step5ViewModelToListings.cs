using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step5ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Step5FlatForRent, FlatForRent>()
                 .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step5RoomForRent, RoomForRent>()
                 .ForAllOtherMembers(c => c.Ignore());
            
            cfg.CreateMap<Step5FlatForSale, FlatForSale>()
                 .ForAllOtherMembers(c => c.Ignore());
            
            cfg.CreateMap<Step5HouseForRent, HouseForRent>()
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step5HouseForSale, HouseForSale>()
                .ForAllOtherMembers(c => c.Ignore());
                       

            cfg.CreateMap<Step5LandForSale, LandForSale>()
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}