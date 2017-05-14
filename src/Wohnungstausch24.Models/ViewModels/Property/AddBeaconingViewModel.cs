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
    public class AddBeaconingViewModel
    {
        [Display(ResourceType = typeof(Resource), Name = "AddBeaconingViewModel_BeaconingType")]
        public BeaconingType? BeaconingType { get; set; }
        public int Id { get; set; }
    }
}
