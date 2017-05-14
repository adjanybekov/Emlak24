using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Locations;

namespace Wohnungstausch24.Migrations.Configurations.Locations
{
    public class LocationLevel3Configuration : CustomEntityTypeConfiguration<LocationLevel3>
    {
        public LocationLevel3Configuration()
        {
            Property(c => c.Name).HasMaxLength(100).IsRequired();
            HasRequired(c => c.Parent).WithMany(c => c.Children).HasForeignKey(c => c.ParentId);
        }
    }
}