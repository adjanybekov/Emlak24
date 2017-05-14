using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Base;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Land
{
    public interface IStep4LandForSale :IStep4Land, IStep4ListingForSale
    {
        decimal? SeparableFrom { get; set; }
        AddMixedLandViewModel AddMixedLandViewModel { get; set; }
    }
}