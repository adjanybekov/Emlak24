using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum QualificationType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_DINEN15733")]
        DINEN15733 =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_GeprüfterImmobilienmakler")]
        GeprüfterImmobilienmakler =2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_ImmobilienkaufmannFrau")]
        ImmobilienkaufmannFrau = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_ImmobilienfachwirtIn")]
        ImmobilienfachwirtIn =4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_ImmobilienökonomIn")]
        ImmobilienökonomIn =5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_MRICS")]
        MRICS =6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_GeprüfteSachverständige")]
        GeprüfteSachverständige =7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_QualificationType_SachverständigeRöbuv")]
        SachverständigeRöbuv =8
    }
}
