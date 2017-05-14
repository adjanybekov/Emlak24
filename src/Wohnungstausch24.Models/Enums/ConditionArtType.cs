using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum ConditionArtType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_FirstOccupation")]
        FirstOccupation = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_NeedToBeRenovated")]
        NeedToBeRenovated = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_AsNew")]
        AsNew = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_ByAppointment")]
        ByAppointment = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Modernized")]
        Modernized = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_CaredFor")]
        CaredFor = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Rohbau")]
        Rohbau = 7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Discovered")]
        Discovered = 8,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Abrissobject")]
        Abrissobject = 9,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Projected")]
        Projected = 10,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_NewConstruction")]
        NewConstruction = 11,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Older")]
        Older = 12,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ConditionArtType_Altbau")]
        Altbau = 13
    }
}
