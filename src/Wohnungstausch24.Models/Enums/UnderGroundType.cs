using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum UnderGroundType
    {
        [Display(Name = "Enum_UndergroundType_NotUnderground", ResourceType = typeof(Resource))]
        NotUnderground =1,
        [Display(Name = "Enum_UndergroundType_Complete", ResourceType = typeof(Resource))]
        Complete =2,
        [Display(Name = "Enum_UndergroundType_Partial", ResourceType = typeof(Resource))]
        Partial =3
    }
}
