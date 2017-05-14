using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum LandType
    {
        [Display(ResourceType = typeof(Resource), Name = "LandType_Living_WOHNEN")]
        Living=1,
        [Display(ResourceType = typeof(Resource), Name = "LandType_Business_GEWERBE")]
        Business =2,
        [Display(ResourceType = typeof(Resource), Name = "LandType_IndustryIndustrie_INDUSTRIE")]
        IndustryIndustrie = 3,
        [Display(ResourceType = typeof(Resource), Name = "LandType_CountryForg_LAND_FORSTWIRSCHAFT")]
        CountryForg =4,
        [Display(ResourceType = typeof(Resource), Name = "LandType_Leisure_FREIZEIT")]
        Leisure =5,
        [Display(ResourceType = typeof(Resource), Name = "LandType_Mixed_GEMISCHT")]
        Mixed =6,
        [Display(ResourceType = typeof(Resource), Name = "LandType_IndustryGewerbepark_GEWERBEPARK")]
        IndustryGewerbepark = 7,
        [Display(ResourceType = typeof(Resource), Name = "LandType_SpecialUse_SONDERNUTZUNG")]
        SpecialUse =8,
        [Display(ResourceType = typeof(Resource), Name = "LandType_Society_SEELIEGENSCHAFT")]
        Society =9
    }
}