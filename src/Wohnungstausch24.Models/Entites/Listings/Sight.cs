using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public class Sight:Entity<int>
    {
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }
        public SightType? SightType { get; set; }
    }
}