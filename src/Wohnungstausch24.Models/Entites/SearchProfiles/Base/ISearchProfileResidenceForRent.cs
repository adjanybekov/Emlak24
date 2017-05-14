using Wohnungstausch24.Core.Models;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Base
{
    public interface ISearchProfileResidenceForRent :ISearchProfileResidence, ISearchProfileListingForRent
    {
        bool? HasHousingPermission { get; set; }
        bool? IsSmokingAllowed { get; set; }
        bool? IsPetsAllowed { get; set; }
    }
}