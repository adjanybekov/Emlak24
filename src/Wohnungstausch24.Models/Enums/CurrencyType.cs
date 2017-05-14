using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum CurrencyType
    {
        [Display(ResourceType = typeof(Resource),Name = "Enum_CurrencyType_Euro")]
        Euro=1
    }
}