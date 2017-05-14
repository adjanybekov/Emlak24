using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class BalconyConfiguration:CustomEntityTypeConfiguration<Balcony>
    {
        public BalconyConfiguration()
        {
            Property(c => c.Direction).IsOptional();
            HasRequired(c => c.Residence).WithMany(c => c.Balconies).HasForeignKey(c => c.ResidenceId);
        }
    }
}
