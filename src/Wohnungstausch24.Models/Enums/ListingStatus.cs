using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum ListingStatus
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_ListingStatus_Draft")]
        Draft = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ListingStatus_Active")]
        Active = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_ListingStatus_OnHold")]
        OnHold = 3
    }
}