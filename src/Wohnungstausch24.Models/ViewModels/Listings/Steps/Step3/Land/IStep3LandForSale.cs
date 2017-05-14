using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Land
{
    public interface IStep3LandForSale :IStep3Land, IStep3ListingForSale
    {
        decimal? PurchasePricePerSqm { get; set; }
    }
}