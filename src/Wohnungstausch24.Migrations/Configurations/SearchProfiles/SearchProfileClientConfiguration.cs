using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SearchProfileClientConfiguration : CustomEntityTypeConfiguration<Client>
    {
        public SearchProfileClientConfiguration()
        {
            ToTable(nameof(Client), Constants.SearchProfileSchemaName);
            HasMany(c => c.Persons).WithRequired(c => c.Client).HasForeignKey(c => c.ClientId);
            HasRequired(c => c.SearchProfile).WithMany(d => d.Clients).HasForeignKey(c => c.SearchProfileId);
            Property(c => c.Name).IsRequired().HasMaxLength(100);
            Property(c => c.About).IsRequired().HasMaxLength(1000);
            Property(c => c.Age).IsOptional();
            Property(c => c.Income).IsRequired();
            Property(c => c.Profession).IsOptional().HasMaxLength(100);
            Property(c => c.Gender).IsOptional();
            Property(c => c.EmploymentStatus).IsRequired();
            Property(c => c.Headline).IsRequired();
            Property(c => c.Id).IsRequired();
        }
    }
}
