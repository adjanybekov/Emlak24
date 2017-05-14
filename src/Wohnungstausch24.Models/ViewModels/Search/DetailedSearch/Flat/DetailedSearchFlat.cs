using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat
{
    public class DetailedSearchFlat : DetailedSearchResidence, IDetailedSearchFlat
    {
        public DetailedSearchFlat()
        {

            this.FlatTypeViewModels =
                Enum.GetValues(typeof(FlatType))
                    .Cast<FlatType>()
                    .Select(c => new FlatTypeViewModel { FlatType = c, Selected = false })
                    .ToList();
        }
        public List<FlatTypeViewModel> FlatTypeViewModels { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Level")]
        public RangedInt Level { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_NumberOfLevels")]
        public RangedInt NumberOfLevels { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsApartmentTower")]
        public bool IsApartmentTower { get; set; }
    }
}