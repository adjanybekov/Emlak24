using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House
{
    public class HouseForSale:House,IHouseForSale
    {
        public decimal? RentalIncomeActual { get; set; }
        public decimal? RentalIncomeDebit { get; set; }
        public decimal? XTimes { get; set; }
        public decimal? NetYield { get; set; }
        public decimal? NetYieldDebit { get; set; }
        public decimal? NetYieldActual { get; set; }
        public bool? IsSubjectToCommission { get; set; }
        public decimal? OutsideCourtage { get; set; }
        public string CourtageAdvice { get; set; }
        public decimal? CommonCharge { get; set; }
        public decimal? PurchasePricePerSqm { get; set; }
        public decimal? MaintenanceSavings { get; set; }
        public decimal? ComissionFee { get; set; }
        public bool? IsWillingToPay { get; set; }
    }
}