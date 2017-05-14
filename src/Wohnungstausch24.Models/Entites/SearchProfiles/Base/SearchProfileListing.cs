using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Base
{
    public class SearchProfileListing : Entity<int>, ISearchProfileListing
    {
        public SearchProfileListing()
        {
            this.PriceRange = new RangedDecimalEntityNullable();
            this.Clients = new List<Client>();
        }

        public string Title { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public virtual RangedDecimalEntityNullable PriceRange { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Client> Clients { get; set; }
        public virtual List<SpLocation> Locations { get; set; }
    }

    public class SpLocation:Entity<int>
    {
        public int SpListingId { get; set; }
        public SearchProfileListing SpListing { get; set; }
        public int LocationId { get; set; }
    }
}