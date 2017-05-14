using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public class ObjectTextInAnotherLanguage:Entity<int>
    {
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }

        public string LanguageCode { get; set; }
        public string Description { get; set; }
    }
}