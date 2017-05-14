namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base
{
    public interface IStep1ResidenceForRent :IStep1Residence, IStep1ListingForRent
    {
        bool ForIndustrialUse { get; set; }
        bool ForHolidayUse { get; set; }
    }
}