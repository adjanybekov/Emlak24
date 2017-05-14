using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class BeaconingConfiguration:CustomEntityTypeConfiguration<Beaconing>
    {
        public BeaconingConfiguration()
        {
            HasRequired(c => c.Residence).WithMany(c => c.Beaconings).HasForeignKey(c => c.ResidenceId);
            Property(c => c.BeaconingType).IsRequired();
        }
    }
}
