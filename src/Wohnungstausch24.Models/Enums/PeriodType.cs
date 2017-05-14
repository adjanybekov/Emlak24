using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum PeriodType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_PeriodType_Day")]
        Day =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PeriodType_Week")]
        Week = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PeriodType_Month")]
        Month =3
    }
}
