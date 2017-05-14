using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public interface IListingForRent : IListing, IForRent
    {      
        bool? AcceptBailLetter { get; set; }
        
    }
}