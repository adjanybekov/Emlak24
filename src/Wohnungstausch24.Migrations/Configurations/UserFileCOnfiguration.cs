using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Migrations.Configurations
{
   public class UserFileConfiguration : CustomEntityTypeConfiguration<UserFile>
    {
        public UserFileConfiguration()
        {
            this.Property(c => c.UserId).IsRequired();
            this.Property(c => c.TenantFileType).IsOptional();
            this.Property(c => c.FileId).IsOptional();            
        }
    }
}
