using Wohnungstausch24.Core.Models;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base
{
    public interface IDetailedSearchResidenceForRent :IDetailedSearchResidence, IDetailedSearchListingForRent
    {
        bool HasHousingPermission { get; set; }
        bool IsSmokingAllowed { get; set; }
        bool IsPetsAllowed { get; set; }
    }
}