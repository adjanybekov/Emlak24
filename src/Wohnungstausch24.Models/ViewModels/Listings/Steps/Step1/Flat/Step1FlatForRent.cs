using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat
{
    [Validator(typeof(Step1FlatForRentValidator))]
    public class Step1FlatForRent:Step1Flat, IStep1FlatForRent
    {
        [Display(ResourceType = typeof(Resource), Name = "For_Industrial_Use")]
        public bool ForIndustrialUse { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "For_Holiday_Use")]
        public bool ForHolidayUse { get; set; }
    }

    public class Step1FlatForRentValidator:Step1FlatModelValidator<Step1FlatForRent>
    {
    }
}
