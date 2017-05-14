using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SearchProfileFlatConfiguration: CustomEntityTypeConfiguration<SearchProfileFlat>
    {
        public SearchProfileFlatConfiguration()
        {
            HasMany(c => c.SelectedFlatTypes).WithRequired(c => c.SpFlat).HasForeignKey(c => c.SpFlatId);
        }
    }
}