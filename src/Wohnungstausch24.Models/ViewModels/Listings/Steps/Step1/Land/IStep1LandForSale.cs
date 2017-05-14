using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Land
{
    public interface IStep1LandForSale :IStep1Land, IStep1ListingForSale
    {
        int? Floor { get; set; }
        int? FloorTypeNumerator { get; set; }
        int? FloorTypeDenumerator { get; set; }
        string Boundary { get; set; }
    }
}