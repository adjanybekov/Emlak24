using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels
{
    [Validator(typeof(ChooseTypeOfMerchandisingViewModelValidator))]
    public class ChooseTypeOfMerchandisingViewModel
    {
        public TypeOfUse TypeOfUse { get; set; }
        public TypeOfMerchandising TypeOfMerchandising { get; set; }
    }
    public class ChooseTypeOfMerchandisingViewModelValidator : AbstractValidator<ChooseTypeOfMerchandisingViewModel>
    {
        public ChooseTypeOfMerchandisingViewModelValidator()
        {
            RuleFor(c => c.TypeOfMerchandising).NotEmpty();
        }
    }

}