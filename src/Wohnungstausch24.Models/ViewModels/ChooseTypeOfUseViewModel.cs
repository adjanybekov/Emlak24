using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels
{
    [Validator(typeof(ChooseTypeOfUseViewModelValidator))]
    public class ChooseTypeOfUseViewModel
    {
        public TypeOfUse TypeOfUse { get; set; }
    }
    public class ChooseTypeOfUseViewModelValidator : AbstractValidator<ChooseTypeOfUseViewModel>
    {
        public ChooseTypeOfUseViewModelValidator()
        {
            RuleFor(c => c.TypeOfUse).NotEmpty();
        }
    }
}