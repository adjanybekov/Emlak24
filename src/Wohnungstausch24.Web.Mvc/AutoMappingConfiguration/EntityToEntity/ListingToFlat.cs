using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToEntity
{
    public class ListingToFlat : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Listing, Flat>()
                .ForMember(c => c.Level, o => o.Ignore())
                .ForMember(c => c.LivingArea, o => o.Ignore())
                .ForMember(c => c.UsefulArea, o => o.Ignore())
                .ForMember(c => c.NumberOfLevels, o => o.Ignore())
                .ForMember(c => c.IsFurnished, o => o.Ignore())
                .ForMember(c => c.IsShared, o => o.Ignore())
                .ForMember(c => c.FurnishType, o => o.Ignore())
                .ForMember(c => c.BasementArea, o => o.Ignore())
                .ForMember(c => c.GardenArea, o => o.Ignore())
                .ForMember(c => c.OtherArea, o => o.Ignore())
                .ForMember(c => c.NumberOfRooms, o => o.Ignore())
                .ForMember(c => c.NumberOfBedrooms, o => o.Ignore())
                .ForMember(c => c.NumberOfBathrooms, o => o.Ignore())
                .ForMember(c => c.NumberOfSeperateToilet, o => o.Ignore())
                .ForMember(c => c.NumberOfLivingBedrooms, o => o.Ignore())
                .ForMember(c => c.ParkingSpaces, o => o.Ignore())
                .ForMember(c => c.Balconies, o => o.Ignore())
                .ForMember(c => c.ConstructionYear, o => o.Ignore());
        }
    }
}