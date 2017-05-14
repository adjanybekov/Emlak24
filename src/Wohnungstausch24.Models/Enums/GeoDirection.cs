using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum GeoDirection
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_North")]
        North = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_NorthEast")]
        NorthEast = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_East")]
        East = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_SouthEast")]
        SouthEast = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_South")]
        South = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_SouthWest")]
        SouthWest = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_West")]
        West = 7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_GeoDirection_NorthWest")]
        NorthWest = 8
    }
}