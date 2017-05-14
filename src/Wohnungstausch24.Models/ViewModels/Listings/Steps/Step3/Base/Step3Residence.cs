using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    [Validator(typeof(Step3ResidenceValidator<Step3Residence>))]
    public class Step3Residence :Step3Listing, IStep3Residence
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_IsHeatingCostsIncluded")]
        public bool IsHeatingCostsIncluded { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_HeatingCosts")]
        public decimal? HeatingCosts { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Clearence")]
        public decimal? Clearance { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_ClearenceText")]
        public string ClearanceText { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_SpeakToOwner")]
        public bool SpeakToOwner { get; set; }

        [Display(Name = "Inside_Courtage", ResourceType = typeof(Resource))]
        public decimal? InsideCourtage { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Current_Cold_Rent")]
        public decimal? CurrentColdRent { get; set; }
    }

    public class Step3ResidenceValidator<T> : Step3ListingValidator<T> where T : Step3Residence
    {
        public Step3ResidenceValidator()
        {

        }
    }
}