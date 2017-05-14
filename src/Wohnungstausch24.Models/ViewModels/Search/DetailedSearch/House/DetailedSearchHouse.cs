using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House
{
    public class DetailedSearchHouse : DetailedSearchResidence, IDetailedSearchHouse
    {
        public DetailedSearchHouse()
        {
            this.HouseTypeViewModels =
                Enum.GetValues(typeof(HouseType))
                    .Cast<HouseType>()
                    .Select(c => new HouseTypeViewModel { HouseType = c, Selected = false })
                    .ToList();
        }
        public List<HouseTypeViewModel> HouseTypeViewModels { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Ranged_PlotArea")]
        public RangedDecimal PlotArea { get; set; }
    }
}