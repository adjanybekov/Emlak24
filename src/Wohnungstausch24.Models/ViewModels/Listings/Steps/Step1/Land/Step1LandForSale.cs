using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Land
{
    public class Step1LandForSale : Step1Land, IStep1LandForSale
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Step1Land_Floor")]
        public int? Floor { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step1Land_Boundary")]
        public string Boundary { get; set; }
        public int? FloorTypeNumerator { get; set; }
        public int? FloorTypeDenumerator { get; set; }
    }
}