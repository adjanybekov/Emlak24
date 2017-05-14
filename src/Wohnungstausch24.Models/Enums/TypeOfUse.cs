using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum TypeOfUse
    {
        [Display(ResourceType = typeof(Resource),Name = "Enum_TypeOfUse_Living")]
        Living = 1,

        [Display(ResourceType = typeof(Resource), Name = "Enum_TypeOfUse_Business")]
        Business = 2,

        [Display(ResourceType = typeof(Resource), Name = "Enum_TypeOfUse_Investment")]
        Investment = 3
    }
}