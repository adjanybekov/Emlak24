using System.Collections.Generic;
using Wohnungstausch24.Models.ViewModels.Landing;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail;
using Wohnungstausch24.Models.ViewModels.Location;
using Wohnungstausch24.Models.ViewModels.Search.BasicSearch;

namespace Wohnungstausch24.Models.ViewModels
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            this.BasicSearchModel = new BasicSearchViewModel();          
        }
        public ICollection<SummaryViewModel> Listings { get; set; }
        public BasicSearchViewModel BasicSearchModel { get; set; }        
    }
}
