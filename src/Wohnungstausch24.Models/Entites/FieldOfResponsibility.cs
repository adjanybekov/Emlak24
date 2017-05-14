using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites
{
    public enum FieldOfResponsibility
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_Acquisitions")]
        Acquisitions = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_Letting")]
        Letting=2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_Sale")]
        Sale =3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_EnergyContracting")]
        EnergyContracting =4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_CommunicationEntertainmentContracting")]
        CommunicationEntertainmentContracting =5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_Moving")]
        Moving =6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FieldOfResponsibility_PropertyManagement")]
        PropertyManagement =7
    }
}