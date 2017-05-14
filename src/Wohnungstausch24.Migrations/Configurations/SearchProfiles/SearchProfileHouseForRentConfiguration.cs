using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SearchProfileHouseForRentConfiguration : CustomEntityTypeConfiguration<SearchProfileHouseForRent>
    {
        public SearchProfileHouseForRentConfiguration()
        {
            Property(c => c.HasHousingPermission).IsOptional().HasColumnName(nameof(ISearchProfileResidenceForRent.HasHousingPermission));
            Property(c => c.IsSmokingAllowed).IsOptional().HasColumnName(nameof(ISearchProfileResidenceForRent.IsSmokingAllowed));
            Property(c => c.IsPetsAllowed).IsOptional().HasColumnName(nameof(ISearchProfileResidenceForRent.IsPetsAllowed));
        }
    }
}