using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SpFeatureCategoryConfiguration : CustomEntityTypeConfiguration<SpFeatureCategory>
    {
        public SpFeatureCategoryConfiguration()
        {
            ToTable(nameof(SpFeatureCategory), Constants.SearchProfileSchemaName);
        }
    }
}