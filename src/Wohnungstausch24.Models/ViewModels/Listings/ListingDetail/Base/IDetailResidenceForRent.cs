namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base
{
    public interface IDetailResidenceForRent :IDetailResidence, IDetailListingForRent
    {
        decimal? Bail { get; set; }
        string BailText { get; set; }
        decimal? BasicRent { get; set; }
        decimal? RentalPricePerSqm { get; set; }
        decimal? WarmRent { get; set; }
        bool ForHolidayUse { get; set; }
        bool ForIndustrialUse { get; set; }
        decimal? RentSubsidy { get; set; }
    }
}