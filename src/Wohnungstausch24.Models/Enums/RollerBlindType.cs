using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum RollerBlindType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_RollerBlindType_Manual")]
        Manual = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_RollerBlindType_Electric")]
        Electric = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_RollerBlindType_PartlyElectric")]
        PartlyElectric = 3

    }
}
