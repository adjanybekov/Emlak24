using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum BalconyType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_BalconyType_Balcony")]
        Balcony =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BalconyType_Terrace")]
        Terrace = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BalconyType_TinyBalcony")]
        TinyBalcony = 3
    }
}