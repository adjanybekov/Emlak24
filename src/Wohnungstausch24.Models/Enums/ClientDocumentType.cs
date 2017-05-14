using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum ClientDocumentType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_ClientDocumentType_SchufaAuskuft")]
        SchufaAuskuft = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ClientDocumentType_Mietschuldenfreiheitsbescheinigung")]
        Mietschuldenfreiheitsbescheinigung = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ClientDocumentType_Einkommensnachweis")]
        Einkommensnachweis = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ClientDocumentType_Selbstauskunft")]
        Selbstauskunft = 4
    }
}
