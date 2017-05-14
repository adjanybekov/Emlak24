using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public interface IListingForSale:IListing,IForSale
    {
        #region if object is rented & contract is not terminated
        /// <summary>
        /// if object is rented & contract is not terminated
        /// </summary>
        decimal? RentalIncomeActual { get; set; }
        decimal? RentalIncomeDebit { get; set; }
        /// <summary>
        /// About rental income for properties of type
        /// <see cref="TypeOfMerchandising.Sale"/>
        /// <see cref="RentalIncomeDebit"/>,
        /// <seealso cref="RentalIncomeActual"/>
        /// </summary>
        decimal? XTimes { get; set; }
        decimal? NetYield { get; set; }
        decimal? NetYieldDebit { get; set; }
        decimal? NetYieldActual { get; set; }

        #endregion


        #region will be displayed only for agents.
        bool? IsSubjectToCommission { get; set; }

        /// <summary>
        /// % or fixed price
        /// </summary>
        decimal? OutsideCourtage { get; set; }

        // one line
        string CourtageAdvice { get; set; }
        #endregion

        decimal? CommonCharge { get; set; }
        decimal? PurchasePricePerSqm { get; set; }
        decimal? ComissionFee { get; set; }
        bool? IsWillingToPay { get; set; }
    }
}