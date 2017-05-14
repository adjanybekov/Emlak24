using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum FlatType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_AtticFloor")]
        AtticFloor = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_Maisonette")]
        Maisonette = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_LoftStudioAtelier")]
        LoftStudioAtelier = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_Penthouse")]
        Penthouse = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_Terraces_Terraces")]
        Terraces = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_FloorAppartment")]
        FloorAppartment = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_GroundFloor")]
        GroundFloor = 7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_Souterrain")]
        Souterrain = 8,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_Apartment")]
        Apartment = 9,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_HolidayApartment")]
        HolidayApartment = 10,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_Gallery")]
        Gallery = 11,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_RoofCoatings")]
        RoofCoatings = 12,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_AtticApartment")]
        AtticApartment = 13,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FlatType_NoInformation")]
        NoInformation = 14,
    }
}
