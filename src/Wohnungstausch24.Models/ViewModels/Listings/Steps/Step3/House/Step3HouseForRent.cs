using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.House
{
    public class Step3HouseForRent : Step3House, IStep3HouseForRent
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_BailText")]
        public string BailText { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Bail")]
        public decimal? Bail { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_BasicRent")]
        public decimal? BasicRent { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_RentalPricePerSqm")]
        public decimal? RentalPricePerSqm { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_WarmRent")]
        public decimal? WarmRent { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Rent_Subsidy")]
        public decimal? RentSubsidy { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_AllInRent")]
        public bool AllInRent { get; set; }
        public decimal? AllInRentPrice { get; set; }
    }
}