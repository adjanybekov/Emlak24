namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    public interface IStep3ResidenceForRent :IStep3Residence, IStep3ListingForRent
    {
        decimal? WarmRent { get; set; }      
        decimal? RentSubsidy { get; set; }        
        bool AllInRent { get; set; }
        decimal? AllInRentPrice { get; set; }
    }
}