using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels
{
    [Validator(typeof(InitListingViewModelViewModelValidator))]
    public class InitListingViewModel
    {
        public TypeOfMerchandising TypeOfMerchandising { get; set; }
        public TypeOfUse TypeOfUse { get; set; }
        public PropertyType PropertyType { get; set; }
    }
    public class InitListingViewModelViewModelValidator : AbstractValidator<InitListingViewModel>
    {
        public InitListingViewModelViewModelValidator()
        {
            RuleFor(c => c.TypeOfMerchandising).NotEmpty();
        }
    }
}