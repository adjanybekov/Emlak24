using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step4ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Step4FlatForRent, FlatForRent>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                 .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeperateToilet, o => o.MapFrom(c => c.NumberOfSeparateToilets))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step4RoomForRent, RoomForRent>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step4FlatForSale, FlatForSale>()
                 .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                 .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeperateToilet, o => o.MapFrom(c => c.NumberOfSeparateToilets))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
               .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step4HouseForRent, HouseForRent>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeperateToilet, o => o.MapFrom(c => c.NumberOfSeparateToilets))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step4HouseForSale, HouseForSale>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeperateToilet, o => o.MapFrom(c => c.NumberOfSeparateToilets))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step4LandForSale, LandForSale>()
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForMember(c => c.SeparableFrom, o => o.MapFrom(c => c.SeparableFrom))
                .ForAllOtherMembers(c => c.Ignore());

        }
    }
}