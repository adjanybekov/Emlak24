using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SearchProfileListingConfiguration: CustomEntityTypeConfiguration<SearchProfileListing>
    {
        public SearchProfileListingConfiguration()
        {
            ToTable(nameof(SearchProfileListing), Constants.SearchProfileSchemaName);
            Property(c => c.Title).IsOptional().HasMaxLength(100);
            Property(c => c.AvailableFrom).IsOptional();
            Property(c => c.AvailableTo).IsOptional();
            HasRequired(c => c.User).WithMany(c => c.SearchProfiles).HasForeignKey(c => c.UserId);
        }
    }
}
