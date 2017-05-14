using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites
{
    public enum PositionInCompany
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_Ceo")]
        Ceo =1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_Secretary")]
        Secretary =2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_Customer")]
        Customer = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_HeadOfLetting")]
        HeadOfLetting =4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_HeadOfSale")]
        HeadOfSale =5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_HeadOfInvestment")]
        HeadOfInvestment =6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_KeyAccountManager")]
        KeyAccountManager =7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_HeadOfAcquisitions")]
        HeadOfAcquisitions =8,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_PropertyManager")]
        PropertyManager =9,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_Inbound")]
        Inbound =10,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_Outbound")]
        Outbound =11,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_MarketingManager")]
        MarketingManager =12,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_SalesAgent")]
        SalesAgent =13,
        [Display(ResourceType = typeof(Resource), Name = "Enum_PositionInCompany_LettingAgent")]
        LettingAgent =14
    }
}