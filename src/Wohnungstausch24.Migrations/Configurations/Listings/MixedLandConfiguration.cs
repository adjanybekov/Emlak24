using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class MixedLandConfiguration : CustomEntityTypeConfiguration<MixedLand>
    {
        public MixedLandConfiguration()
        {
            HasRequired(c => c.LandForSale).WithMany(c=>c.MixedLands).HasForeignKey(c => c.LandId);
            Property(c => c.TypeOfUse).IsRequired();
            Property(c => c.TotalArea).IsRequired();
            Property(c => c.PlotArea).IsRequired();
            Property(c => c.SeparableFrom).IsOptional();
        }
    }
}
