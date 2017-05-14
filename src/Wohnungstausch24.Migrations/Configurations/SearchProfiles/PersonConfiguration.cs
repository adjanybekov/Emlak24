using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class PersonConfiguration:CustomEntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable(nameof(Person), Constants.SearchProfileSchemaName);
            HasRequired(c => c.Client).WithMany(c => c.Persons).HasForeignKey(c => c.ClientId);
            Property(c => c.Profession).IsOptional();
            Property(c => c.Income).IsOptional();
            Property(c => c.EmploymentStatus).IsOptional();
            Property(c => c.Age).IsOptional();
            Property(c => c.Gender).IsOptional();
        }
    }
}
