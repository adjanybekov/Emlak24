using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Base
{
    [Validator(typeof(Step4ListingValidator<Step4Listing>))]
    public class Step4Listing :Step4ViewModelBase, IStep4Listing
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_TotalArea")]
        public int? TotalArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Ranged_PlotArea")]
        public decimal? PlotArea { get; set; }
    }

    public class Step4ListingValidator<T> : AbstractValidator<T> where T : Step4Listing
    {
        public Step4ListingValidator()
        {
        }
    }
}