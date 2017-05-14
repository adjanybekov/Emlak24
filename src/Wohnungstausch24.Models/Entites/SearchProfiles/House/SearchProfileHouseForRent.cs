using Wohnungstausch24.Core.Models;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.House
{
    public class SearchProfileHouseForRent :SearchProfileHouse, ISearchProfileHouseForRent
    {
        public bool? HasHousingPermission { get; set; }
        public bool? IsSmokingAllowed { get; set; }
        public bool? IsPetsAllowed { get; set; }
    }
}