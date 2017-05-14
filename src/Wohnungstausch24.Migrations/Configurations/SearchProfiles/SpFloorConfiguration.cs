using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SpFloorConfiguration:CustomEntityTypeConfiguration<SpFloor>
    {
        public SpFloorConfiguration()
        {
            ToTable(nameof(SpFloor), Constants.SearchProfileSchemaName);
        }
    }
}