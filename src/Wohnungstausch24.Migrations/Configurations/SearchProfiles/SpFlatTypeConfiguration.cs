using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SpFlatTypeConfiguration : CustomEntityTypeConfiguration<SpFlatType>
    {
        public SpFlatTypeConfiguration()
        {
            ToTable(nameof(SpFlatType), Constants.SearchProfileSchemaName);
        }
    }
}