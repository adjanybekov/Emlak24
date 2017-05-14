using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum FeatureCategory
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureCategory_Default")]
        Default =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureCategory_Raised")]
        Raised = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureCategory_Luxury")]
        Luxury = 3
    }
}