using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Locations;

namespace Wohnungstausch24.Migrations.Configurations.Locations
{
    public class CountryConfiguration:CustomEntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(c => c.Name).HasMaxLength(100).IsRequired();
            HasMany(c => c.Children).WithRequired(c => c.Parent).HasForeignKey(c => c.ParentId);
        }
    }
}
