using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class LandForSaleConfiguration : LandConfiguration<LandForSale>
    {
        public LandForSaleConfiguration()
        {
            Property(c => c.RentalIncomeActual).IsOptional().HasColumnName(nameof(IListingForSale.RentalIncomeActual));
            Property(c => c.RentalIncomeDebit).IsOptional().HasColumnName(nameof(IListingForSale.RentalIncomeDebit));
            Property(c => c.CommonCharge).IsOptional().HasColumnName(nameof(IListingForSale.CommonCharge));
            Property(c => c.CourtageAdvice).IsOptional().HasColumnName(nameof(IListingForSale.CourtageAdvice));
            Property(c => c.InsideCourtage).IsOptional().HasColumnName(nameof(IListingForSale.InsideCourtage));
            Property(c => c.IsPriceOnDemand).IsOptional().HasColumnName(nameof(IListingForSale.IsPriceOnDemand));
            Property(c => c.IsSubjectToCommission)
                .IsOptional()
                .HasColumnName(nameof(IListingForSale.IsSubjectToCommission));
            Property(c => c.NetYield).IsOptional().HasColumnName(nameof(IListingForSale.NetYield));
            Property(c => c.NetYieldActual).IsOptional().HasColumnName(nameof(IListingForSale.NetYieldActual));
            Property(c => c.NetYieldDebit).IsOptional().HasColumnName(nameof(IListingForSale.NetYieldDebit));            
            Property(c => c.OutsideCourtage).IsOptional().HasColumnName(nameof(IListingForSale.OutsideCourtage));
            Property(c => c.PurchasePricePerSqm).IsOptional().HasColumnName(nameof(IListingForSale.PurchasePricePerSqm));
            Property(c => c.XTimes).IsOptional().HasColumnName(nameof(IListingForSale.XTimes));
            Property(c => c.ComissionFee).IsOptional().HasColumnName(nameof(IListingForSale.ComissionFee));

            Property(c => c.ExploitationNum).IsOptional().HasColumnName(nameof(ILandForSale.ExploitationNum));
            Property(c => c.ExploitationDenum).IsOptional().HasColumnName(nameof(ILandForSale.ExploitationDenum));
            Property(c => c.GRZ).IsOptional().HasColumnName(nameof(ILandForSale.GRZ));
            Property(c => c.GFZ).IsOptional().HasColumnName(nameof(ILandForSale.GFZ));
            Property(c => c.BuldingBank).IsOptional().HasColumnName(nameof(ILandForSale.BuldingBank));
            Property(c => c.ZoneOfConstruction).IsOptional().HasColumnName(nameof(ILandForSale.ZoneOfConstruction));
            Property(c => c.ContaminatedSites).IsOptional().HasColumnName(nameof(ILandForSale.ContaminatedSites));
            Property(c => c.Gaz).IsOptional().HasColumnName(nameof(ILandForSale.Gaz));

            Property(c => c.Water).IsOptional().HasColumnName(nameof(ILandForSale.Water));
            Property(c => c.Electricity).IsOptional().HasColumnName(nameof(ILandForSale.Electricity));
            Property(c => c.TK).IsOptional().HasColumnName(nameof(ILandForSale.TK));

            Property(c => c.BuildingType).IsOptional().HasColumnName(nameof(ILandForSale.BuildingType));
            Property(c => c.AllotmentType).IsOptional().HasColumnName(nameof(ILandForSale.AllotmentType));
            Property(c => c.IsWillingToPay).IsOptional().HasColumnName(nameof(IListingForSale.IsWillingToPay));
        }

    }
}