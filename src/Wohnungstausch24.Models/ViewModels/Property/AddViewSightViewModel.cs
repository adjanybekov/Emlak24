﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class AddViewSightViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "ViewSightViewModel_SightType" )]
        public SightType? SightType{ get; set; }
    }
}
