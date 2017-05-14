using System.Collections.Generic;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat;

namespace Wohnungstausch24.Models.ViewModels.Search
{
    public class SearchProfileDetailViewModel
    {
        public DetailedSearchListing SearchProfile { get; set; }
        public List<ClientViewModel> Clients { get; set; }
        public AddPersonViewModel AddPersonViewModel { get; set; }
    }
}
