using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    [Validator(typeof(Step3ListingValidator<Step3Listing>))]
    public class Step3Listing :Step3ViewModelBase, IStep3Listing
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_PublisherType")]
        public PublisherType PublisherType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Is_the_actual_terminated")]
        public bool IsActualContractTerminated { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Terminated_On")]
        public DateTime? ActualContractTerminatedOn { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Earliest_Date")]
        public DateTime? EarliestAvailableDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Latest_Date")]
        public DateTime? LatestAvailableDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Is_Currently_Rented")]
        public bool IsCurrentlyRented { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_FreeTextavailablefrom")]
        public string FreeTextAvailableFrom { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_FreeTextPrice")]
        public string FreeTextPrice { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_AdditionalCosts")]
        public decimal AdditionalCosts { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_IsDateFlexible")]
        public bool IsDateFlexible { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_IsPriceOnDemand")]
        public bool IsPriceOnDemand { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_AcceptBailLetter")]
        public bool AcceptBailLetter { get; set; }

        [Display(Name = "Property_Add_IsAllowedToBeIntroducedByAgent", ResourceType = typeof(Resource))]
        public bool IsAllowedToBeIntroducedByAgent { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Price")]
        public decimal Price { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Orientation_Price")]
        public decimal OrientationPrice { get; set; }
    }

    public class Step3ListingValidator<T>:AbstractValidator<T> where T : Step3Listing
    {
        public Step3ListingValidator()
        {
            RuleFor(c => c.ActualContractTerminatedOn).NotEmpty().When(c => c.IsActualContractTerminated).WithLocalizedMessage(() => Resource.PropertyAddStepAddDate);
        }
    }
}