using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class HouseConfiguration<T>: ResidenceConfiguration<T> where T : Residence
    {
        public HouseConfiguration()
        {
            this.Property(c => c.IsShared).IsOptional().HasColumnName(nameof(IResidence.IsShared));
        }
    }
}