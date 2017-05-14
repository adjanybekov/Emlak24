using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public class Distance:Entity<int>
    {
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }
        public DistanceType? DistanceType { get; set; }
        public decimal? DistanceInKm { get; set; }
    }
}