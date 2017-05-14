using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum Epart
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_Epart_Demand")]
        Demand =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_Epart_Consumption")]
        Consumption =2
    }
}