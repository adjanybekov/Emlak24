using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum BuildingType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_NewardShip34")]
        NewardShip34 = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_ProductiveArea35")]
        ProductiveArea35 = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_Bplan")]
        Bplan = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_NoBuilding")]
        NoBuilding = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_Maintenance")]
        Maintenance = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_Specifications")]
        Specifications = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BuildingType_BaulandOhneBPlan")]
        BaulandOhneBPlan = 7
    }
}
