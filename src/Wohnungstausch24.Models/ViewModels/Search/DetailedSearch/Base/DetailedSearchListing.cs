using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base
{
    public class DetailedSearchListing : IDetailedSearchListing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Home_DetailedSearch_AvailableFrom")]
        public DateTime? AvailableFrom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Home_DetailedSearch_AvailableTo")]
        public DateTime? AvailableTo { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Ranged_Price")]
        public RangedDecimal PriceRange { get; set; }
        public List<string> SelectedAllLocations { get; set; }
    }
}