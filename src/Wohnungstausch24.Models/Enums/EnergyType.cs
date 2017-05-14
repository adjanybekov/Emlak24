using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum EnergyType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyType_Passivehouse")]
        Passivehouse = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyType_Lowenergyhouse")]
        Lowenergyhouse = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyType_Newbuilding")]
        Newbuilding = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyType_Standardkfw40")]
        Standardkfw40 = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyType_Kfw60")]
        Kfw60 = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyType_MinimumEnergieCosthouse")]
        MinimumEnergieCosthouse = 6

    }
}
