using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum KitchenType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_KitchenType_Fitted")]
        Fitted=1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_KitchenType_Open")]
        Open = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_KitchenType_Pantry")]
        Pantry = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_None")]
        None =4
    }
}