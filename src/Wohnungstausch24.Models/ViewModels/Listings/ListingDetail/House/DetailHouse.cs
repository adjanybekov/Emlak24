using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.House
{
    public class DetailHouse : DetailResidence, IDetailHouse
    {
        public HouseType HouseType { get; set; }
    }
}