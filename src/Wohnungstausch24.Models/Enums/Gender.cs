using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum Gender
    {
        [Display(Name = "Enum_Gender_Male",ResourceType = typeof(Resource))]
        Male=1,
        [Display(Name = "Enum_Gender_Female", ResourceType = typeof(Resource))]
        Female=2,
        [Display(Name = "Enum_Gender_None",ResourceType = typeof(Resource))]
        None = 3
    }
}
