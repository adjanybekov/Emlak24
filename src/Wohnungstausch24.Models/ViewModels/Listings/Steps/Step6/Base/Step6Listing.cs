using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Base
{
    public class Step6Listing :Step6ViewModelBase, IStep6Listing
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_ListingHeader")]

        public string ListingHeader { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Object_description")]
        public string ObjectDescription { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Location_description")]

        public string LocationDescription { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Environment_description")]

        public string EnvironmentDescription { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Other_details")]

        public string OtherDetails { get; set; }
        public AddTextInAnotherLanguageViewModel AddTextInAnotherLanguageViewModel { get; set; }
        public IEnumerable<SelectListItem> LanguagesList=>CultureHelper.GetAvailableAgentCultures().Select(c => new SelectListItem { Value = c.Name, Text = c.NativeName }).ToList();
    }
}