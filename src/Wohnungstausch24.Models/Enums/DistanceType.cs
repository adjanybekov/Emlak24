using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum DistanceType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Airport")]
        Airport = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Fernbahnhof")]
        Fernbahnhof = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Highway")]
        Highway = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_UsBahn")]
        UsBahn = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Bus")]
        Bus = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Center")]
        Center = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Purchasing")]
        Purchasing = 7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Restaurants")]
        Restaurants = 8,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_DistancesSports")]
        DistancesSports = 9,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_DistanzZuSport")]
        DistanzZuSport = 10,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Children")]
        Children = 11,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_PrimarySchool")]
        PrimarySchool = 12,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_MainHousing")]
        MainHousing = 13,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_SecondarySchool")]
        SecondarySchool = 14,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_ComprehensiveSchool")]
        ComprehensiveSchool = 15,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DistanceType_Gymnasium")]
        Gymnasium = 16
    }
}