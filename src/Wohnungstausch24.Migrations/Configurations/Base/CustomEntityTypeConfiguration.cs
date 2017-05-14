using System.Data.Entity.ModelConfiguration;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Migrations.Configurations.Base
{
    public class CustomEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : Entity<int>
    {
        public CustomEntityTypeConfiguration()
        {
            this.HasKey(p => p.Id);
        }
    }
}
