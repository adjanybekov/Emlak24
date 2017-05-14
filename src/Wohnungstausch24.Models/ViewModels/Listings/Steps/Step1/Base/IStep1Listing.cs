using System.Collections.Generic;
using System.Web.Mvc;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base
{
    public interface IStep1Listing:IStep1ViewModelBase
    {
        TypeOfUse? TypeOfUse { get; set; }
        PropertyType? PropertyTpe { get; set; }
        TypeOfMerchandising? TypeOfMerchandising { get; set; }

        int? SelectedCountry { get; set; }
        List<SelectListItem> Countries { get; set; }
        int? SelectedLocationlevel1 { get; set; }
        List<SelectListItem> LocationsLevel1 { get; set; }
        int? SelectedLocationlevel2 { get; set; }
        List<SelectListItem> LocationsLevel2 { get; set; }
        int? Locationlevel3 { get; set; }
        List<SelectListItem> LocationsLevel3 { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }        
        string SubUrbLeft { get; set; }
        bool ShowFullAddressInPublic { get; set; }
       
        List<SelectListItem> PropertySubTypes { get; set; }
        ListingStatus ListingStatus { get; set; }
    }
}