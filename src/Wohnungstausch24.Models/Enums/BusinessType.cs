using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum BusinessType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_OrganizationType_GmbH")]
        GmbH=1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_OrganizationType_Ag")]
        Ag =2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_OrganizationType_SingleOwned")]
        SingleOwned =3,

        [Display(ResourceType = typeof(Resource), Name = "Enum_OrganizationType_Other")]
        Other =99,
    }
}
