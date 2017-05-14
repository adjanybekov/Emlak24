using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Land;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Land
{
    public class Step7LandForSale : Step9Land, IStep9LandForSale
    {
        public int? ExploitationNum { get; set; }
        public int? ExploitationDenum { get; set; }
        public decimal? GRZ { get; set; }
        public decimal? GFZ { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step7Land_BuldingBank")]
        public decimal? BuldingBank { get; set; }
        public bool ZoneOfConstruction { get; set; }
        public bool ContaminatedSites { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step7_AmountOfAllotment_Gaz")]
        public bool Gaz { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step7_AmountOfAllotment_Water")]
        public bool Water { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step7_AmountOfAllotment_electricity")]
        public bool Electricity { get; set; }
        public bool TK { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step7Land_BuldingType")]
        public BuildingType? BuildingType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step7Land_AllotmentType")]
        public AllotmentType? AllotmentType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_NumberOfLevels")]
        public int? NumberOfLevels { get; set; }
    }
}