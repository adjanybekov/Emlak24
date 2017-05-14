using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum FurnishType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_FurnishType_Partial")]
        Partial = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FurnishType_Full")]
        Full = 2
    }
}