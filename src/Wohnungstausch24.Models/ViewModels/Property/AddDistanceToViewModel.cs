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
    public class AddDistanceToViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AddDistanceToViewModel_DistanceType")]
        public DistanceType? DistanceType { get; set; }
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AddDistanceToViewModel_Distance")]
        public decimal? Distance { get; set; }
        public int Id { get; set; }
    }
}
