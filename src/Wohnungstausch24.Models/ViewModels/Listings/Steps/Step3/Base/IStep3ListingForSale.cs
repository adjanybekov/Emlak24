using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    public interface IStep3ListingForSale : IStep3Listing, IStepsForSale
    {
        decimal XTimes { get; set; }
        decimal NetYield { get; set; }
        decimal NetYieldDebit { get; set; }
        decimal NetYieldActual { get; set; }
        decimal RentalIncomeActual { get; set; }
        decimal RentalIncomeDebit { get; set; }
        decimal? InsideCourtage { get; set; }
        bool IsSubjectToCommission { get; set; }
        decimal OutsideCourtage { get; set; }
        string CourtageAdvice { get; set; }
        decimal CommonCharge { get; set; }
        decimal? ComissionFee { get; set; }
        bool IsWillingToPay { get; set; }
    }
}