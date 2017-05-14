namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base
{
    public interface IStep9ResidenceForRent :IStep9Residence, IStep9ListingForRent
    {
        bool HasHousingPermission { get; set; }
    }
}