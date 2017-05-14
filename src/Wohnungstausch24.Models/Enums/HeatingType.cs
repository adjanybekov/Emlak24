using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum HeatingType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_HeatingType_Oven")]
        Oven = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_HeatingType_Center")]
        Center = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_HeatingType_Level")]
        Level = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_HeatingType_Far")]
        Far = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_HeatingType_Ground")]
        Ground = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_HeatingType_None")]
        None = 6
    }
}