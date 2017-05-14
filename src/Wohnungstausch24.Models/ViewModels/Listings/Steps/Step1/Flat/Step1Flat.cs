using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat
{
    [Validator(typeof(Step1FlatModelValidator<Step1Flat>))]
    public class Step1Flat : Step1Residence, IStep1Flat
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Level")]
        public int? Level { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_PositionInBuilding")]
        public PositionInBuilding? PositionInBuilding { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Num_Of_Units")]
        public int? NumberOfApartmentUnits { get; set; }
    }

    public class Step1FlatModelValidator<T>:Step1ResidenceModelValidator<T> where T : Step1Flat
    {
        public Step1FlatModelValidator()
        {
            RuleFor(c => c.Level).NotEmpty();
        }
    }
}