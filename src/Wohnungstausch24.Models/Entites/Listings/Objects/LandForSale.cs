using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites.Listings.Objects
{
    public class LandForSale:Land,ILandForSale
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
        public int? Floor { get; set; }
        public string Boundary { get; set; }
        public int? FloorTypeNumerator { get; set; }
        public int? FloorTypeDenumerator { get; set; }
        public decimal? ComissionFee { get; set; }
        public decimal? SeparableFrom { get; set; }
        public virtual ICollection<MixedLand> MixedLands { get; set; }
        public int? ExploitationNum { get; set; }
        public int? ExploitationDenum { get; set; }
        public decimal? GRZ { get; set; }
        public decimal? GFZ { get; set; }
        public decimal? BuldingBank { get; set; }
        public bool? ZoneOfConstruction { get; set; }
        public bool? ContaminatedSites { get; set; }
        public bool? Gaz { get; set; }
        public bool? Water { get; set; }
        public bool? Electricity { get; set; }
        public bool? TK { get; set; }
        public BuildingType? BuildingType { get; set; }
        public AllotmentType? AllotmentType { get; set; }
        public bool? IsWillingToPay { get; set; }
    }
}