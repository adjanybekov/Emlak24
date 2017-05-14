using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class ParkingSpaceConfiguration:CustomEntityTypeConfiguration<ParkingSpace>
    {
        public ParkingSpaceConfiguration()
        {
            Property(c => c.Quantity).IsOptional();
            Property(c => c.RentPrice).IsOptional();
            HasRequired(c => c.Residence).WithMany(c => c.ParkingSpaces).HasForeignKey(c => c.ResidenceId);
        }
    }
}
