using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface ISearchService
    {
        void SaveDetailedSearchCriterias(DetailedSearchResultsModel model, string userId);
    }
}
