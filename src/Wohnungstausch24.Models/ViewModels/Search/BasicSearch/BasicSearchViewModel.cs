using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.ViewModels.Location;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.BasicSearch
{
    public class BasicSearchViewModel : SearchModelBase
    {
        public BasicSearchViewModel()
        {
            this.Locations = new List<LocationViewModelLevel2>();
        }

        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        [Display(ResourceType=typeof(Resource),Name="Price")]
        public string PriceRange { get; set; }
        public int AreaFrom { get; set; }
        public int AreaTo { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Ranged_TotalArea")]
        public string AreaRange { get; set; }
    }
}
