using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum ParkSpaceType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_ParkspaceType_Garage")]
        Garage =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ParkspaceType_BasementGarage")]
        BasementGarage =2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ParkspaceType_Carport")]
        Carport =3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ParkspaceType_FreeSpace")]
        FreeSpace =4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ParkspaceType_CarPark")]
        CarPark = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ParkspaceType_Duplex")]
        Duplex = 6
    }
}