using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum ObjectTypes
    {
        [Display(Name = "Enum_ObjectTypes_FlatSale", ResourceType = typeof(Resource))]
        FlatSale = 1,
        [Display(Name = "Enum_ObjectTypes_FlatRent", ResourceType = typeof(Resource))]
        FlatRent = 2,
        [Display(Name = "Enum_ObjectTypes_HouseSale", ResourceType = typeof(Resource))]
        HouseSale = 3,
        [Display(Name = "Enum_ObjectTypes_HouseRent", ResourceType = typeof(Resource))]
        HouseRent = 4,
        [Display(Name = "Enum_ObjectTypes_LandSale", ResourceType = typeof(Resource))]
        LandSale = 5,
        [Display(Name = "Enum_ObjectTypes_LandRent", ResourceType = typeof(Resource))]
        LandRent = 6
    }
}
