using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Land
{
    public class Step4LandForSale : Step4Land, IStep4LandForSale
    {
        public decimal? SeparableFrom { get; set; }
        public AddMixedLandViewModel AddMixedLandViewModel { get; set; }
    }
}