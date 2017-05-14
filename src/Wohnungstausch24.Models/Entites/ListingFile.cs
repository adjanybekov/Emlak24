using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.Models.Entites
{
    public class ListingFile:Entity<int>
    {
        public int ListingId  { get; set; }
        public virtual Listing Listing { get; set; }

        public int FileId { get; set; }
        public virtual Wt24File File { get; set; }
    }
}
