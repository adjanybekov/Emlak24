using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep4 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<FlatForRent, Step4FlatForRent>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.ParkingSpaceViewModels, o => o.MapFrom(c => c.ParkingSpaces))
                .ForMember(c => c.BalconyModels, o => o.MapFrom(c => c.Balconies))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.Balconies.Count > 0))
                .ForMember(c => c.IsGardenUtilizationPossible, o => o.MapFrom(c => c.GardenArea > 0))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeparateToilets, o => o.MapFrom(c => c.NumberOfSeperateToilet))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.HasParkingSpaces, o => o.MapFrom(c => c.ParkingSpaces.Count > 0))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent, Step4RoomForRent>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.ParkingSpaceViewModels, o => o.MapFrom(c => c.ParkingSpaces))
                .ForMember(c => c.BalconyModels, o => o.MapFrom(c => c.Balconies))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.Balconies.Count > 0))
                .ForMember(c => c.IsGardenUtilizationPossible, o => o.MapFrom(c => c.GardenArea > 0))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.HasParkingSpaces, o => o.MapFrom(c => c.ParkingSpaces.Count > 0))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<FlatForSale, Step4FlatForSale>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.ParkingSpaceViewModels, o => o.MapFrom(c => c.ParkingSpaces))
                .ForMember(c => c.BalconyModels, o => o.MapFrom(c => c.Balconies))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.Balconies.Count > 0))
                .ForMember(c => c.IsGardenUtilizationPossible, o => o.MapFrom(c => c.GardenArea > 0))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeparateToilets, o => o.MapFrom(c => c.NumberOfSeperateToilet))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.HasParkingSpaces, o => o.MapFrom(c => c.ParkingSpaces.Count > 0))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForRent, Step4HouseForRent>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.ParkingSpaceViewModels, o => o.MapFrom(c => c.ParkingSpaces))
                .ForMember(c => c.BalconyModels, o => o.MapFrom(c => c.Balconies))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.Balconies.Count > 0))
                .ForMember(c => c.IsGardenUtilizationPossible, o => o.MapFrom(c => c.GardenArea > 0))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeparateToilets, o => o.MapFrom(c => c.NumberOfSeperateToilet))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.HasParkingSpaces, o => o.MapFrom(c => c.ParkingSpaces.Count>0))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step4HouseForSale>()
                .ForMember(c => c.LivingArea, o => o.MapFrom(c => c.LivingArea))
                .ForMember(c => c.PlotArea, o => o.MapFrom(c => c.PlotArea))
                .ForMember(c => c.UsefulArea, o => o.MapFrom(c => c.UsefulArea))
                .ForMember(c => c.BasementArea, o => o.MapFrom(c => c.BasementArea))
                .ForMember(c => c.GardenArea, o => o.MapFrom(c => c.GardenArea))
                .ForMember(c => c.OtherArea, o => o.MapFrom(c => c.OtherArea))
                .ForMember(c => c.TotalArea, o => o.MapFrom(c => c.TotalArea))
                .ForMember(c => c.NumberOfRooms, o => o.MapFrom(c => c.NumberOfRooms))
                .ForMember(c => c.NumberOfBedrooms, o => o.MapFrom(c => c.NumberOfBedrooms))
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.MapFrom(c => c.NumberOfLivingBedrooms))
                .ForMember(c => c.ParkingSpaceViewModels, o => o.MapFrom(c => c.ParkingSpaces))
                .ForMember(c => c.BalconyModels, o => o.MapFrom(c => c.Balconies))
                .ForMember(c => c.HasBalcony, o => o.MapFrom(c => c.Balconies.Count > 0))
                .ForMember(c => c.IsGardenUtilizationPossible, o => o.MapFrom(c => c.GardenArea > 0))
                .ForMember(c => c.UnderGroundType, o => o.MapFrom(c => c.UnderGroundType))
                .ForMember(c => c.NumberOfBathrooms, o => o.MapFrom(c => c.NumberOfBathrooms))
                .ForMember(c => c.HasSeparateToilet, o => o.MapFrom(c => c.HasSeparateToilet))
                .ForMember(c => c.NumberOfSeparateToilets, o => o.MapFrom(c => c.NumberOfSeperateToilet))
                .ForMember(c => c.AtticSpace, o => o.MapFrom(c => c.AtticSpace))
                .ForMember(c => c.HasParkingSpaces, o => o.MapFrom(c => c.ParkingSpaces.Count > 0))
                .ForMember(c => c.HasGuestToilet, o => o.MapFrom(c => c.HasGuestToilet))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<LandForSale, Step4LandForSale>()
                .ForMember(c=>c.PlotArea, o=>o.MapFrom(c=>c.PlotArea))
                .ForMember(c=>c.SeparableFrom, o=>o.MapFrom(c=>c.SeparableFrom))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}