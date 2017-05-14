using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SearchProfileHouseConfiguration: CustomEntityTypeConfiguration<SearchProfileHouse>
    {
        public SearchProfileHouseConfiguration()
        {
            HasMany(c => c.SelectedHouseTypes).WithRequired(c => c.SpHouse).HasForeignKey(c => c.SpHouseId);
        }
    }
}