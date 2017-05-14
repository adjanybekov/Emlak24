using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum RoofType
    {
        [Display(Name = "Enum_RoofType_Crowdwalkroof", ResourceType = typeof(Resource))]
        Crowdwalkroof = 1,
        [Display(Name = "Enum_RoofType_Mansarddach", ResourceType = typeof(Resource))]
        Mansarddach = 2,
        [Display(Name = "Enum_RoofType_Pultdach", ResourceType = typeof(Resource))]
        Pultdach = 3,
        [Display(Name = "Enum_RoofType_Saddleroof", ResourceType = typeof(Resource))]
        Saddleroof = 4,
        [Display(Name = "Enum_RoofType_Walmdach", ResourceType = typeof(Resource))]
        Walmdach = 5,
        [Display(Name = "Enum_RoofType_Flatroof", ResourceType = typeof(Resource))]
        Flatroof = 6,
        [Display(Name = "Enum_RoofType_Pyramidendach", ResourceType = typeof(Resource))]
        Pyramidendach = 7


    }
}
