using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum AgeGroup
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_AgeGroup_Old")]
        Old=1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_AgeGroup_New")]
        New =2
    }
}