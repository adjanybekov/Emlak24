using System;
using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.House;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Land;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToDto
{
    public class DetailListingToDetailDto:IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DetailResidence,DetailListing>().ReverseMap();
            cfg.CreateMap<DetailFlatForRent,DetailResidence>().ReverseMap();
            cfg.CreateMap<DetailFlatForSale,DetailResidence>().ReverseMap();
            cfg.CreateMap<DetailHouseForRent,DetailResidence>().ReverseMap();
            cfg.CreateMap<DetailHouseForSale,DetailResidence>().ReverseMap();           
            cfg.CreateMap<DetailLandForSale,DetailListing>().ReverseMap();
            cfg.CreateMap<DetailRoomForRent,DetailResidence>().ReverseMap();
        }
    }
}