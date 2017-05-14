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
    public class SightConfiguration : CustomEntityTypeConfiguration<Sight>
    {
        public SightConfiguration()
        {            
            Property(c => c.SightType).IsOptional();
            HasRequired(c => c.Listing).WithMany(c => c.Sights).HasForeignKey(c => c.ListingId);
        }
    }
}
