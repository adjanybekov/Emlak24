using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Base;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base
{
    [Validator(typeof(Step9ResidenceValidator))]
    public class Step9Residence :Step9Listing, IStep9Residence
    {
        public Step9Residence()
        {
            this.FloorTypes = Enum.GetValues(typeof(FloorType))
                .Cast<FloorType>()
                .Select(c => new FloorViewModel { FloorType = c, Selected = false })
                .ToList();
            this.AddBathroomViewModel = new AddBathroomViewModel();
        }


        [Display(ResourceType = typeof(Resource),Name = "FeatureCategory")]
        public FeatureCategory? FeatureCategory { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "ConditionArtType")]
        public ConditionArtType? ConditionArtType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "LastRenovationDate")]
        public DateTime? LastRenovationDate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "DesignType")]
        public DesignType? DesignType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "InternetType")]
        public InternetType? InternetType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "RollerBlindType")]
        public RollerBlindType? RollerBlindType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AddKitchenViewModel")]
        public AddKitchenViewModel AddKitchenViewModel { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel")]
        public AddBathroomViewModel AddBathroomViewModel { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "FloorTypes")]
        public List<FloorViewModel> FloorTypes { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "HasWinterGarden")]
        public bool HasWinterGarden { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "HasStorageRoom")]
        public bool HasStorageRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasBicycleRoom")]
        public bool HasBicycleRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasWashDryingRoom")]
        public bool HasWashDryingRoom { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasElevator")]
        public bool HasElevator { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasChimney")]
        public bool HasChimney { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasRollerBlind")]
        public bool HasRollerBlind { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasCableSatTv")]
        public bool HasCableSatTv { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasGermanTvByAntenna")]
        public bool HasGermanTvByAntenna { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasInternet")]
        public bool HasInternet { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasCableDucts")]
        public bool HasCableDucts { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsSeniorFocused")]
        public bool IsSeniorFocused { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsWheelchairAccessible")]
        public bool IsWheelchairAccessible { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsBarrierFree")]
        public bool IsBarrierFree { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsApartmentTower")]
        public bool IsApartmentTower { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasLibrary")]
        public bool HasLibrary { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasAttic")]
        public bool HasAttic { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasAirCondition")]
        public bool HasAirCondition { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasSauna")]
        public bool HasSauna { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasSwimmingPool")]
        public bool HasSwimmingPool { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasAlarmSystem")]
        public bool HasAlarmSystem { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasCamera")]
        public bool HasCamera { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasPoliceCall")]
        public bool HasPoliceCall { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsKitchenFitted")]
        public bool IsKitchenFitted { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsKitchenOpen")]
        public bool IsKitchenOpen { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasGrannyPart")]
        public bool HasGrannyPart { get; set; }

        private int _startDate = 1900;
        private int _intervalInFuture = 10;

        [Display(ResourceType = typeof(Resource), Name = "Is_Construction_Year_Projected")]
        public bool IsConstructionYearProjected { get; set; }
        public bool LandMarked { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step8_ConstructionYear")]
        public int? ConstructionYear { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step9_SpeedOfInternet")]
        public decimal? SpeedOfInternet { get; set; }

        public IEnumerable<SelectListItem> ConstructionYearList
        {
            get
            {
                Int32.TryParse(WebConfigurationManager.AppSettings["StartDate"], out _startDate);
                Int32.TryParse(WebConfigurationManager.AppSettings["IntervalInFuture"], out _intervalInFuture);
                var list = Enumerable.Range(_startDate, DateTime.Now.Year + 1 - _startDate + _intervalInFuture)
                        .Select(c => new SelectListItem { Value = c.ToString(), Text = c.ToString() });
                return list;
            }
        }


    }
    public class Step9ResidenceValidator : AbstractValidator<Step9Residence>
    {
        public Step9ResidenceValidator()
        {
            RuleFor(c => c.ConstructionYear)
                .GreaterThan(1900)
                .LessThan(DateTime.Now.Year)
                .When(c => !c.IsConstructionYearProjected).WithMessage("Construction year is not projected. Please enable projected!");

            RuleFor(c => c.ConstructionYear)
                .GreaterThan(1900)
                .When(c => c.IsConstructionYearProjected)
                .LessThan(DateTime.Now.Year + 10 + 1);
        }
    }
  }
