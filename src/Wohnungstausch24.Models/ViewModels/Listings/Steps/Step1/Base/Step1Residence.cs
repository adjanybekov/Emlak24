using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base
{
    [Validator(typeof(Step1ResidenceModelValidator<Step1Residence>))]
    public class Step1Residence :Step1Listing, IStep1Residence
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_NumberOfLevels")]
        public int? NumberOfLevels { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_IsFurnished")]
        public bool IsFurnished { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_IsFlatSharePossible")]
        public bool IsShared { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_FurnishType_Select")]
        public FurnishType? FurnishType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_HouseNumber")]
        public string HouseNumber { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Address_SelectedPropertySubType")]
        public int PropertySubType { get; set; }
    }
    public class Step1ResidenceModelValidator<T> : Step1ListingModelValidator<T> where T : Step1Residence
    {
        public Step1ResidenceModelValidator()
        {
            RuleFor(c => c.FurnishType).NotEmpty().When(c => c.IsFurnished);
            RuleFor(c => c.PropertySubType).NotEmpty();
            RuleFor(m => m.HouseNumber).Length(1, 10);
        }
    }
}