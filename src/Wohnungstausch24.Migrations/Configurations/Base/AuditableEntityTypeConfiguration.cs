using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Migrations.Configurations.Base
{
    public class AuditableEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : AuditableEntity<int>
    {
        public AuditableEntityTypeConfiguration()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.CreatedBy).HasMaxLength(256).IsOptional();
            this.Property(p => p.CreatedOnUTC).IsRequired();
            this.Property(p => p.UpdatedOnUTC).IsOptional();
            this.Property(p => p.UpdatedBy).HasMaxLength(256).IsOptional();
            this.Property(p => p.DeletedOnUTC).IsOptional();
            this.Property(p => p.DeletedBy).HasMaxLength(256).IsOptional();
        }
    }
}
