using System.Collections.Generic;
using System.Linq;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class ListingSecurityService: IListingSecurityService
    {
        private ApplicationDbContext _dbContext;
        public ListingSecurityService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CanEditListing(string userId, Listing listing)
        {
            var userIds = new List<string> { userId };
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId.Equals(userId));
            if (agency != null)
            {
                userIds.AddRange(agency.Agents.Select(c => c.UserId).ToList());
            }
            return userIds.Any(c => c == listing.UserId);
        }
    }
}
