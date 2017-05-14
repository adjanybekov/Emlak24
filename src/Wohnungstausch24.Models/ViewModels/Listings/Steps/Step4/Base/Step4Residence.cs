using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Base
{
    [Validator(typeof(Step4ResidenceValidator<Step4Residence>))]
    public class Step4Residence :Step4Listing, IStep4Residence
    {
        public Step4Residence()
        {
            this.AddBalconyViewModel = new AddBalconyViewModel();
            this.AddparkingSpaceViewModel =  new AddparkingSpaceViewModel();
        }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_LivingArea")]
        public decimal? LivingArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_UsefulArea")]
        public decimal? UsefulArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Number_Of_Rooms")]
        public int? NumberOfRooms { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Number_Of_Bedrooms")]
        public int? NumberOfBedrooms { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Basement_area")]
        public decimal? BasementArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Garden_area")]
        public decimal? GardenArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Other_Area")]
        public decimal? OtherArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Number_Of_Living_Bedrooms")]
        public int? NumberOfLivingBedrooms { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsGardenUtilizationPossible")]
        public bool IsGardenUtilizationPossible { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasBalcony")]
        public bool HasBalcony { get; set; }
        public List<BalconyViewModel> BalconyModels { get; set; }
        public List<ParkSpaceViewModel> ParkingSpaceViewModels { get; set; }
        public AddparkingSpaceViewModel AddparkingSpaceViewModel { get; set; }
        public AddBalconyViewModel AddBalconyViewModel { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddProperty_Step4_UnderGroundType")]
        public UnderGroundType UnderGroundType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Number_Of_Bathrooms")]
        public int? NumberOfBathrooms { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasGuestToilet")]
        public bool HasGuestToilet { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "HasSeparateToilet")]
        public bool HasSeparateToilet { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "NumberOfSeparateToilets")]
        public int NumberOfSeparateToilets { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Enum_FeatureType_AtticSpace")]
        public decimal? AtticSpace { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step4_HasParkingSpace")]
        public bool HasParkingSpaces { get; set; }
    }

    public class Step4ResidenceValidator<T>:Step4ListingValidator<T> where T: Step4Residence
    {
        public Step4ResidenceValidator()
        {
            RuleFor(c => c.GardenArea).NotEmpty().When(c=>c.IsGardenUtilizationPossible);
        }
    }
}