using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum SalutationType
    {
        [Display(ResourceType = typeof(Resource),Name= "Enum_SalutationType_Mr")]
        Mr =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_SalutationType_Mrs")]
        Mrs =2 ,
        [Display(ResourceType = typeof(Resource), Name = "Enum_SalutationType_Ms")]
        Ms =3
    }
}
