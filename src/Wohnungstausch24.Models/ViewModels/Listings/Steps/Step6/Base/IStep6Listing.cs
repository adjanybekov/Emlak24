using System.Collections.Generic;
using System.Web.Mvc;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Base
{
    public interface IStep6Listing:IStep6ViewModelBase
    {
        string ListingHeader { get; set; }
        string ObjectDescription { get; set; }
        string LocationDescription { get; set; }
        string EnvironmentDescription { get; set; }
        string OtherDetails { get; set; }
        AddTextInAnotherLanguageViewModel AddTextInAnotherLanguageViewModel { get; set; }
        IEnumerable<SelectListItem> LanguagesList { get; }
    }
}