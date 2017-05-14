using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Migrations.Configurations
{
    public class AgencyConfiguration:CustomEntityTypeConfiguration<Agency>
    {
        public AgencyConfiguration AgencyConfiguration1 { get; set; }

        public AgencyConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(300);
            Property(c => c.About).IsOptional().HasMaxLength(3000);
            Property(c => c.PhoneNumber).IsRequired().HasMaxLength(200);
            Property(c => c.PhoneNumber2).IsOptional().HasMaxLength(200);
            Property(c => c.FaxNumber).IsOptional().HasMaxLength(200);
            Property(c => c.Facebook).IsOptional().HasMaxLength(200);
            Property(c => c.Linkedin).IsOptional().HasMaxLength(200);
            Property(c => c.Twitter).IsOptional().HasMaxLength(200);
            Property(c => c.YearOfEstablishment).IsOptional();
            HasMany(c => c.Agents).WithOptional(c => c.Agency).HasForeignKey(c => c.AgencyId);
            HasRequired(c => c.Manager);
            HasOptional(c => c.Logo);
        }
    }
}
