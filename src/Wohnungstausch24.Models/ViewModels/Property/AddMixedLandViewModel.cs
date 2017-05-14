using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Property
{
   public class AddMixedLandViewModel
    {
        [Display(ResourceType = typeof(Resource), Name = "AddMixedLandViewModel_TypeOfUse")]
        public TypeOfUse? TypeOfUse { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddMixedLandViewModel_TotalArea")]
        public decimal? TotalArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddMixedLandViewModel_PlotArea")]
        public decimal? PlotArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddMixedLandViewModel_SeparableFrom")]
        public decimal? SeparableFrom { get; set; }
    }
}
