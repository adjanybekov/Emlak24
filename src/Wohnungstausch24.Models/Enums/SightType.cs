using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum SightType
    {
        [Display(Name = "Enum_SightType_Not_Defined", ResourceType = typeof(Resource))]
        NotDefined = 0,
        [Display(Name = "Enum_SightType_Sea", ResourceType = typeof(Resource))]
        Sea = 1,
        [Display(Name = "Enum_SightType_Lake", ResourceType = typeof(Resource))]
        Lake = 2,
        [Display(Name = "Enum_SightType_Mountain", ResourceType = typeof(Resource))]
        Mountain = 3,
        [Display(Name = "Enum_SightType_Distance", ResourceType = typeof(Resource))]
        Distance = 4,
    }
}