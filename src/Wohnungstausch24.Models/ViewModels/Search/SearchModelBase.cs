using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Location;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search
{
    public class SearchModelBase
    {
        public SearchModelBase()
        {
            SummaryViewModels = new List<SummaryViewModel>();
            MerchandisingTypes = Enum.GetValues(typeof(TypeOfMerchandising)).Cast<TypeOfMerchandising>()
                .Select(c => new SelectListItem {Value = c.ToString(), Text = c.GetDisplayName()})
                .ToList();
            PropertyTypes = Enum.GetValues(typeof(PropertyType)).Cast<PropertyType>()
                .Select(c => new SelectListItem {Value = c.ToString(), Text = c.GetDisplayName()})
                .ToList();
            this.Locations = new List<LocationViewModelLevel2>();
            this.Locationlevel1 = new List<SelectListItem>();
        }

        public List<SummaryViewModel> SummaryViewModels { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "TypeOfMerchandising")]
        public TypeOfMerchandising? SelectedTypeOfMerchandising { get; set; }
        public List<SelectListItem> MerchandisingTypes { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PropertyType")]
        public PropertyType? SelectedPropertyType { get; set; }
        public List<SelectListItem> PropertyTypes { get; set; }

        public List<LocationViewModelLevel2> Locations { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_LocationLevel1")]
        public int SelectedLocationLevel1 { get; set; }
        public List<SelectListItem> Locationlevel1 { get; set; }

        public ICollection<CountryViewModel> Countries { get; set; }
    }
}