using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum AllotmentType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_AllotmentType_Untapped")]
        Untapped =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_AllotmentType_PartlyColsed")]
        PartlyColsed =2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_AllotmentType_FullyDeveloped")]
        FullyDeveloped =3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_AllotmentType_Locality")]
        Locality =4
    }
}
