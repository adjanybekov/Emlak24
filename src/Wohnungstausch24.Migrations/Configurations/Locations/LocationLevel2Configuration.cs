using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Locations;

namespace Wohnungstausch24.Migrations.Configurations.Locations
{
    public class LocationLevel2Configuration : CustomEntityTypeConfiguration<LocationLevel2>
    {
        public LocationLevel2Configuration()
        {
            Property(c => c.Name).HasMaxLength(100).IsRequired();
            HasMany(c => c.Children).WithRequired(c => c.Parent).HasForeignKey(c => c.ParentId);
            HasRequired(c => c.Parent).WithMany(c => c.Children).HasForeignKey(c => c.ParentId);
        }
    }
}