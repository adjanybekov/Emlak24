using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base
{
    [Validator(typeof(Step1ListingModelValidator<Step1Listing>))]
    public class Step1Listing :Step1ViewModelBase, IStep1Listing
    {

        [Display(ResourceType = typeof(Resource), Name = "TypeOfUse")]
        public TypeOfUse? TypeOfUse { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "PropertyType")]
        public PropertyType? PropertyTpe { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "TypeOfMerchandising")]
        public TypeOfMerchandising? TypeOfMerchandising { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_SelectedCountry")]
        public int? SelectedCountry { get; set; }
        public List<SelectListItem> Countries { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_LocationLevel1")]
        public int? SelectedLocationlevel1 { get; set; }
        public List<SelectListItem> LocationsLevel1 { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_LocationLevel2")]
        public int? SelectedLocationlevel2 { get; set; }
        public List<SelectListItem> LocationsLevel2 { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_LocationLevel3")]
        public int? Locationlevel3 { get; set; }
        public List<SelectListItem> LocationsLevel3 { get; set; }
            
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_Street")]
        public string Street { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_ZipCode")]
        public string ZipCode { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_IsAddressPublic")]
        public bool ShowFullAddressInPublic { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_SubUrb_Select")]
        public string SubUrbLeft { get; set; }

        public List<SelectListItem> PropertySubTypes { get; set; }
        public ListingStatus ListingStatus { get; set; }
    }
    public class Step1ListingModelValidator<T> : AbstractValidator<T> where T:Step1Listing
    {
        public Step1ListingModelValidator()
        {
            RuleFor(m => m.SelectedCountry).NotEmpty();
            RuleFor(m => m.SelectedLocationlevel1).NotEmpty();
            RuleFor(m => m.SelectedLocationlevel2).NotEmpty();
            RuleFor(m => m.Locationlevel3).NotEmpty();
            RuleFor(m => m.ZipCode).NotEmpty().Length(1,20);
            RuleFor(m => m.Street).Length(1, 500);
        }
    }
}