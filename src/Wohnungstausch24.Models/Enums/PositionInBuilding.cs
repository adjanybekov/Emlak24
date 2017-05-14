using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum PositionInBuilding
    {
        [Display(Name = "Enum_PositionInBuilding_Left", ResourceType = typeof(Resource))]
        Left = 1,
        [Display(Name = "Enum_PositionInBuilding_Right", ResourceType = typeof(Resource))]
        Right = 2,
        [Display(Name = "Enum_PositionInBuilding_Front", ResourceType = typeof(Resource))]
        Front = 3,
        [Display(Name = "Enum_PositionInBuilding_Back", ResourceType = typeof(Resource))]
        Back = 4
    }
}