using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum HouseType
    {
        [Display(ResourceType = typeof(Resource), Name = "HouseType_Townhouse")]
        Townhouse=1,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Series")]
        Series=2,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Series2")]
        Series2=3,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Reiheneck")]
        Reiheneck=4,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_DoubleHouses")]
        DoubleHouses=5,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_DetachedHouse")]
        DetachedHouse=6,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Stadthaus")]
        Stadthaus=7,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Bungalow")]
        Bungalow=8,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Villa")]
        Villa=9,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Resthof")]
        Resthof=10,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Farmhouse")]
        Farmhouse=11,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Landhaus")]
        Landhaus=12,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Castle")]
        Castle=13,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_TwoFamilyHouse")]
        TwoFamilyHouse=14,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_MoreFamilyHouse")]
        MoreFamilyHouse=15,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_HolidayHouse")]
        HolidayHouse=16,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Berghuette")]
        Berghuette=17,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Chalet")]
        Chalet=18,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_BeachHouse")]
        BeachHouse=19,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_LaubeDatscheGartenhaus")]
        LaubeDatscheGartenhaus=20,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_ApartmentHouse")]
        ApartmentHouse=21,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_CastleBurg")]
        CastleBurg=22,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_MansHouse")]
        MansHouse=23,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Finca")]
        Finca=24,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_Rustico")]
        Rustico=25,

        [Display(ResourceType = typeof(Resource), Name = "HouseType_FinishedHouse")]
        FinishedHouse=26
    }
}