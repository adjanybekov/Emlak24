using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Flat
{
    public class Step3FlatForSale : Step3Flat, IStep3FlatForSale
    {
        [Display(ResourceType = typeof(Resource), Name = "Xtimes")]
        public decimal XTimes { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "NetYield")]
        public decimal NetYield { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "NetYieldDebit")]
        public decimal NetYieldDebit { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "NetYieldActual")]
        public decimal NetYieldActual { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Rental_Income_Actual")]
        public decimal RentalIncomeActual { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Rental_Income_Debit")]
        public decimal RentalIncomeDebit { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "PurchasePrice")]
        public decimal Price { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "IsSubject_To_Comission")]
        public bool IsSubjectToCommission { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Outside_Courtage")]
        public decimal OutsideCourtage { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_CourtageAdvice")]
        public string CourtageAdvice { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_CommonCharge")]
        public decimal CommonCharge { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_MaintenanceSavings")]
        public decimal MaintenanceSavings { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_WillingToPay")]
        public bool IsWillingToPay { get; set; }
        public decimal? ComissionFee { get; set; }
    }
}