using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum BeaconingType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Oil")]
        Oil = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Gas")]
        Gas = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Electronic")]
        Electronic = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Alternative")]
        Alternative = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Solar")]
        Solar = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_GeothermalEnergy")]
        GeothermalEnergy = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_AirHeatPump")]
        AirHeatPump = 7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Far")]
        Far = 8,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Block")]
        Block = 9,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_WaterElectronic")]
        WaterElectronic = 10,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Pellet")]
        Pellet = 11,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Coal")]
        Coal = 12,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_Wood")]
        Wood = 13,
        [Display(ResourceType = typeof(Resource), Name = "Enum_BeaconingType_LiquidGas")]
        LiquidGas = 14,
    }
}