using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class BathroomConfiguration : CustomEntityTypeConfiguration<Bathroom>
    {
        public BathroomConfiguration()
        {
            Property(c => c.Size).IsOptional();
            Property(c => c.HasUrinal).IsOptional();
            Property(c => c.HasShower).IsOptional();
            Property(c => c.HasTub).IsOptional();
            Property(c => c.HasBidet).IsOptional();
            Property(c => c.HasWindow).IsOptional();
            HasRequired(c => c.Residence).WithMany(c => c.Bathrooms).HasForeignKey(c => c.ResidenceId);
        }
    }
}
