using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Land;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch
{
    public class DetailedSearchResultsModel:SearchModelBase
    {
        public DetailedSearchFlatForRent DetailedSearchFlatForRent { get; set; }
        public DetailedSearchFlatForSale DetailedSearchFlatForSale { get; set; }
        public DetailedSearchHouseForRent DetailedSearchHouseForRent { get; set; }
        public DetailedSearchHouseForSale DetailedSearchHouseForSale { get; set; }
        public DetailedSearchLandForSale DetailedSearchLandForSale { get; set; }

        [Display(Name = "DetailedSearch_SaveSearch",ResourceType = typeof(Resource))]
        public bool SaveSearch { get; set; }

        public string SearchName { get; set; }
    }
}