using System.Collections.Generic;

namespace Wohnungstausch24.Models.ViewModels.Search.TenantSearch
{
    public class TenantSearchAndDetailViewModel
    {
        public TenantSearchAndDetailViewModel()
        {
            this.TenantList = new List<ClientSummaryViewModel>();
            TenantSearchViewModel = new TenantSearchViewModel();
            this.TenantResultViewModel = new TenantResultViewModel();

        }
        public TenantSearchViewModel TenantSearchViewModel { get; set; }

        public List<ClientSummaryViewModel> TenantList { get; set; }
        public TenantResultViewModel TenantResultViewModel { get; set; }
    }
}