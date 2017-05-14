using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.House
{
    public interface IDetailHouse : IDetailResidence
    {
        HouseType HouseType { get; set; }
    }
}