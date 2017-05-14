using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum DesignType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_DesignType_Massive")]
        Massive = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DesignType_Precast")]
        Precast = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_DesignType_ElementsOfWood")]
        ElementsOfWood = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_None")]
        None =4,
    }
}