using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum EnergyCertificateType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyCertificateType_IsAvailable")]
        IsAvailable = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyCertificateType_IsNotNecessary")]
        IsNotNecessary = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_EnergyCertificateType_Missing")]
        Missing = 3
    }
}