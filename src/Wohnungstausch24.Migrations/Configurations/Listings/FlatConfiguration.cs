using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class FlatConfiguration<T>:ResidenceConfiguration<T> where T : Flat
    {
        public FlatConfiguration()
        {
            this.Property(c => c.Level).IsOptional();
            this.Property(c => c.IsShared).IsOptional().HasColumnName(nameof(IResidence.IsShared));
            this.Property(c => c.PositionInBuilding).IsOptional().HasColumnName(nameof(IFlat.PositionInBuilding));
            this.Property(c => c.NumberOfApartmentUnits).IsOptional().HasColumnName(nameof(IFlat.NumberOfApartmentUnits));
        }
    }
}