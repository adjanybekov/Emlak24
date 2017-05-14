using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum TypeOfMerchandising
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_TypeOfMerchandising_Sale")]
        Sale =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_TypeOfMerchandising_Rent")]
        Rent =2
    }
}