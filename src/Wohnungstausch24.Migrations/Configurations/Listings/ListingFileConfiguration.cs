using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class ListingFileConfiguration:CustomEntityTypeConfiguration<ListingFile>
    {
        public ListingFileConfiguration()
        {
            this.HasRequired(c => c.Listing).WithMany(c => c.Files).HasForeignKey(c => c.ListingId).WillCascadeOnDelete(true);
        }
    }
}
