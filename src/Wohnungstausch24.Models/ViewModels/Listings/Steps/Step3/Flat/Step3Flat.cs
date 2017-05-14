using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Flat
{
    [Validator(typeof(Step3FlatValidator<Step3Flat>))]
    public class Step3Flat : Step3Residence, IStep3Flat
    {
    }

    public class Step3FlatValidator<T>:Step3ResidenceValidator<T> where T : Step3Flat
    {
    }
}