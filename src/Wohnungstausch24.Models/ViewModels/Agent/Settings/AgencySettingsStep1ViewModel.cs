using System.Collections.Generic;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    [Validator(typeof(AgentSettingsAgencyViewModelValidator))]
    public class AgencySettingsStep1ViewModel : AgentSettingsBase
    {
        [Display(ResourceType = typeof(Resource), Name = "IamAgent")]
        public bool IsAgent { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "CompanyName")]
        public string CompanyName { get; set; }



        public string Address { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "PhoneNumber_1")]
        public string PhoneNumber { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "PhoneNumber_2")]
        public string PhoneNumber2 { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "General_Fax_Number")]
        public string FaxNumber { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }

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
        public int? SelectedLocationlevel3 { get; set; }
        public List<SelectListItem> LocationsLevel3 { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_Street")]
        public string Street { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_ZipCode")]
        public string ZipCode { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_HouseNumber")]
        public string HouseNumber { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "General_IsWorkingForAnAgency")]
        public bool IsWorkingForAnAgency { get; set; }

        public string GooglePlus { get; set; }
        
        public string Email { get; set; }

        public BusinessType BusinessType { get; set; }
        public string OrganizationOther { get; set; }
    }

    public class AgentSettingsAgencyViewModelValidator : AbstractValidator<AgencySettingsStep1ViewModel>
    {
        public AgentSettingsAgencyViewModelValidator()
        {
            RuleFor(c => c.CompanyName)
                .NotEmpty().When(c => c.IsAgent)
                .WithLocalizedMessage(() => Resource.Agent_AddAgencyDescription);

            RuleFor(m => m.PhoneNumber).NotEmpty().When(c => c.IsAgent);
            RuleFor(m => m.Email).EmailAddress().NotEmpty();
        }
    }
}