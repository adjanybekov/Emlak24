namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    public interface IStep3ListingForRent : IStep3Listing, IStepsForRent
    {
        string BailText { get; set; }
        decimal? Bail { get; set; }
        decimal? BasicRent { get; set; }
        decimal? RentalPricePerSqm { get; set; }
    }
}