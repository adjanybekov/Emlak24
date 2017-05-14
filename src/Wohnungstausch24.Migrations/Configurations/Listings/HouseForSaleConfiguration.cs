using System.Data.Entity.ModelConfiguration;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class HouseForSaleConfiguration : HouseConfiguration<HouseForSale>
    {
        public HouseForSaleConfiguration()
        {
            Property(c => c.RentalIncomeActual).IsOptional().HasColumnName(nameof(IListingForSale.RentalIncomeActual));
            Property(c => c.RentalIncomeDebit).IsOptional().HasColumnName(nameof(IListingForSale.RentalIncomeDebit));
            Property(c => c.CommonCharge).IsOptional().HasColumnName(nameof(IListingForSale.CommonCharge));
            Property(c => c.CourtageAdvice).IsOptional().HasColumnName(nameof(IListingForSale.CourtageAdvice));
            Property(c => c.InsideCourtage).IsOptional().HasColumnName(nameof(IListingForSale.InsideCourtage));
            Property(c => c.IsPriceOnDemand).IsOptional().HasColumnName(nameof(IListingForSale.IsPriceOnDemand));
            Property(c => c.IsSubjectToCommission).IsOptional().HasColumnName(nameof(IListingForSale.IsSubjectToCommission));
            Property(c => c.MaintenanceSavings).IsOptional().HasColumnName(nameof(IResidenceForSale.MaintenanceSavings));
            Property(c => c.NetYield).IsOptional().HasColumnName(nameof(IListingForSale.NetYield));
            Property(c => c.NetYieldActual).IsOptional().HasColumnName(nameof(IListingForSale.NetYieldActual));
            Property(c => c.NetYieldDebit).IsOptional().HasColumnName(nameof(IListingForSale.NetYieldDebit));
            Property(c => c.OutsideCourtage).IsOptional().HasColumnName(nameof(IListingForSale.OutsideCourtage));
            Property(c => c.PurchasePricePerSqm).IsOptional().HasColumnName(nameof(IListingForSale.PurchasePricePerSqm));
            Property(c => c.XTimes).IsOptional().HasColumnName(nameof(IListingForSale.XTimes));
            Property(c => c.ComissionFee).IsOptional().HasColumnName(nameof(IListingForSale.ComissionFee));
            Property(c => c.IsWillingToPay).IsOptional().HasColumnName(nameof(IListingForSale.IsWillingToPay));
        }
    }
}