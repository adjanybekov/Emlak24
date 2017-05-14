using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum PropertyType    
    {
        [Display(ResourceType = typeof(Resource),Name = "Enum_PropertyType_House")]
        House =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PropertyType_Flat")]
        Flat =2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PropertyType_Land")]
        Land =3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PropertyType_WazRoom")]
        WazRoom=4

    }
}