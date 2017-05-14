using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class DistanceConfiguration:CustomEntityTypeConfiguration<Distance>
    {
        public DistanceConfiguration()
        {
            Property(c => c.DistanceInKm).IsOptional();
            Property(c => c.DistanceType).IsOptional();
            HasRequired(c => c.Listing).WithMany(c => c.Distances).HasForeignKey(c => c.ListingId);
        }
    }
}