using System.Collections.Generic;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Search.SearchProfiles;
using Wohnungstausch24.Models.ViewModels.Search.TenantSearch;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IUserService
    {
        SearchProfilePagedListViewModel GetSearchProfiles(string userId, int? page, int? itemsPerpage);
        List<ClientSummaryViewModel> TenantSearch(TenantSearchViewModel model);
        ClientViewModel GetClientSummary(int clientId);
        ApplicationUser FindById(string id);
    }
}
