﻿using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Land
{
    public class Step3LandForSale : Step3Land, IStep3LandForSale
    {
        public decimal XTimes { get; set; }
        public decimal NetYield { get; set; }
        public decimal NetYieldDebit { get; set; }
        public decimal NetYieldActual { get; set; }
        public decimal RentalIncomeActual { get; set; }
        public decimal RentalIncomeDebit { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Inside_Courtage")]
        public decimal? InsideCourtage { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IsSubject_To_Comission")]
        public bool IsSubjectToCommission { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Outside_Courtage")]
        public decimal OutsideCourtage { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_CourtageAdvice")]
        public string CourtageAdvice { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_CommonCharge")]
        public decimal CommonCharge { get; set; }
        public decimal? ComissionFee { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "LandForSale_PurchasePricePerSquaremeter_kaufpreis_pro_qm")]
        public decimal? PurchasePricePerSqm { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step3_WillingToPay")]
        public bool IsWillingToPay { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "PurchasePrice")]
        public decimal Price { get; set; }
    }
}