using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class ListingConfiguration:AuditableEntityTypeConfiguration<Listing>
    {
        public ListingConfiguration()
        {
            Property(c => c.ListingHeader).HasMaxLength(300).IsOptional();
            Property(c => c.ListingStatus).IsOptional();
            Property(m => m.TypeOfUse).IsOptional();
            Property(c => c.TotalArea).IsOptional();
            Property(c => c.Price).IsOptional();
            Property(c => c.Latitude).IsOptional();
            Property(c => c.Longitude).IsOptional();
            Property(c => c.Locationlevel3).IsOptional();
            Property(c => c.Street).HasMaxLength(500).IsOptional();
            Property(c => c.Description).HasMaxLength(3000).IsOptional();
            Property(c => c.EnvironmentDescription).HasMaxLength(3000).IsOptional();
            Property(c => c.LocationDescription).HasMaxLength(3000).IsOptional();
            Property(c => c.Zipcode).IsOptional();
            Property(c => c.ShowFullAddressInPublic).IsOptional();
            Property(c => c.FreeTextPrice).IsOptional().HasMaxLength(3000);
            Property(c => c.FreeTextAvailableFrom).IsOptional().HasMaxLength(3000);
            Property(c => c.OtherDetails).IsOptional().HasMaxLength(3000);
            Property(c => c.Tercet).IsOptional().HasMaxLength(1000);
            Property(c => c.PublisherType).IsOptional().HasColumnName(nameof(IListing.PublisherType));
            Property(c => c.ActualContractTerminatedOn).IsOptional().HasColumnName(nameof(IListing.ActualContractTerminatedOn));
            Property(c => c.EarliestAvailableDate).IsOptional().HasColumnName(nameof(IListing.EarliestAvailableDate));
            Property(c => c.IsActualContractTerminated).IsOptional().HasColumnName(nameof(IListing.IsActualContractTerminated));
            Property(c => c.LatestAvailableDate).IsOptional().HasColumnName(nameof(IListing.LatestAvailableDate));
            Property(c => c.FreeTextPrice).HasColumnName(nameof(IListing.FreeTextPrice));
            HasRequired(c => c.User).WithMany(c => c.Listings).HasForeignKey(c => c.UserId);
            HasMany(c => c.Files).WithRequired(c => c.Listing).HasForeignKey(c => c.ListingId);
            HasMany(c => c.ObjectTextInAnotherLanguages).WithRequired(c => c.Listing).HasForeignKey(c => c.ListingId);
            Property(c => c.IsAllowedToBeIntroducedByAgent).HasColumnName(nameof(IListing.IsAllowedToBeIntroducedByAgent)).IsOptional();
            Property(c => c.PlotArea).IsOptional();
            Property(c => c.NumberOfLevels).IsOptional();
            Property(c => c.IsPriceOnDemand).IsOptional();
            Property(c => c.OrientationPrice).IsOptional();
        }
    }
}
