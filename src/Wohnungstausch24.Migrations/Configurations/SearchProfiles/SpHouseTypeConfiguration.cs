using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SpHouseTypeConfiguration:CustomEntityTypeConfiguration<SpHouseType>
    {
        public SpHouseTypeConfiguration()
        {
            ToTable(nameof(SpHouseType), Constants.SearchProfileSchemaName);
        }
    }
}