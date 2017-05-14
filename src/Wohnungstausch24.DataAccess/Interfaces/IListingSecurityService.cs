using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IListingSecurityService
    {
        bool CanEditListing(string userId, Listing listing);
    }
}
