using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum PublisherType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_PublisherType_ActualTenant")]
        ActualTenant =1,

        [Display(ResourceType = typeof(Resource), Name = "Enum_PublisherType_Owner")]
        Owner = 2,

        [Display(ResourceType = typeof(Resource), Name = "Enum_PublisherType_ContactPersonWorkingForOwner")]
        ContactPersonWorkingForOwner = 3
    }
}