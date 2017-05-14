using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Flat
{
    [Validator(typeof(Step3FlatForRentValidator))]
    public class Step3FlatForRent:Step3Flat, IStep3FlatForRent
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_BailText")]
        public string BailText { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Bail")]
        public decimal? Bail { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_BasicRent")]
        public decimal? BasicRent { get; set; }

        //overrides display attribute for rent objects
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_Cold_Rent")]
        public new decimal Price { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_RentalPricePerSqm")]
        public decimal? RentalPricePerSqm { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_WarmRent")]
        public decimal? WarmRent { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_RentSubsidy")]
        public decimal? RentSubsidy { get; set; }
        [Display(ResourceType = typeof(Resource),Name = "Property_Step3_AllInRent")]
        public bool AllInRent { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_AllInRentPrice")]
        public decimal? AllInRentPrice { get; set; }
    }

    public class Step3FlatForRentValidator:Step3FlatValidator<Step3FlatForRent>
    {
        public Step3FlatForRentValidator()
        {
            RuleFor(c => c.Price).NotEmpty().When(c => !c.AllInRent && !c.IsPriceOnDemand).WithLocalizedMessage(()=>Resource.PropertyAddStepAddPrice);
            RuleFor(c => c.AllInRentPrice).NotEmpty().When(c => c.AllInRent).WithLocalizedMessage(()=>Resource.PropertyAddStepAddPrice);
            RuleFor(c => c.AllInRent).NotEqual(c => c.IsPriceOnDemand).When(c => c.IsPriceOnDemand==true);
        }
    }
}
