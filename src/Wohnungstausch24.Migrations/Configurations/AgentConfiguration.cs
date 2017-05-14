using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Migrations.Configurations
{
    public class AgentConfiguration:CustomEntityTypeConfiguration<Agent>
    {
        public AgentConfiguration()
        {
            HasRequired(c => c.User);
            HasOptional(c => c.Agency).WithMany(c => c.Agents).HasForeignKey(c => c.AgencyId);
            Property(c => c.FieldOfResponsibility).IsOptional();
            Property(c => c.PositionInCompany).IsOptional();
            HasMany(c => c.Qualifications).WithRequired(c=>c.Agent).HasForeignKey(c=>c.AgentId);
        }
    }
}
