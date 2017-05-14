using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    class SearchProfileClientDocConfiguration : CustomEntityTypeConfiguration<ClientDocument>
    {
        public SearchProfileClientDocConfiguration()
        {
            ToTable(nameof(ClientDocument), Constants.SearchProfileSchemaName);
            HasRequired(c => c.Client).WithMany(d=>d.ClientDocuments).HasForeignKey(c=>c.ClientId);
            Property(c => c.DocumentType).IsRequired();
            Property(c => c.FileId).IsRequired();
            Property(c => c.Id).IsRequired();
        }
    }
}
