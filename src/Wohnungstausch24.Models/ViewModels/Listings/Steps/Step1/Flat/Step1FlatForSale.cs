using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat
{
    [Validator(typeof(Step1FlatForSaleValidator))]
    public class Step1FlatForSale:Step1Flat, IStep1FlatForSale
    {
    }

    public class Step1FlatForSaleValidator:Step1FlatModelValidator<Step1FlatForSale>
    {
        public Step1FlatForSaleValidator()
        {
        }
    }
}