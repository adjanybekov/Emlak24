using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat
{
    public class DetailedSearchFlatForRent :  DetailedSearchFlat, IDetailedSearchFlatForRent
    {
        [Display(ResourceType = typeof(Resource), Name = "HasHousingPermission")]
        public bool HasHousingPermission { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Is_Smoking_Allowed")]
        public bool IsSmokingAllowed { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Home_DetailedSearch_Are_Pets_Allowed")]        
        public bool IsPetsAllowed { get; set; }
    }
}
