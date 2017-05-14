using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House
{
    public class DetailedSearchHouseForRent :DetailedSearchHouse, IDetailedSearchHouseForRent
    {
        public bool HasHousingPermission { get; set; }
        [Display(Name="Is_Smoking_Allowed",ResourceType = typeof(Resource))]
        public bool IsSmokingAllowed { get; set; }
        [Display(Name = "Home_DetailedSearch_Are_Pets_Allowed", ResourceType = typeof(Resource))]
        public bool IsPetsAllowed { get; set; }
    }
}