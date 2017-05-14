using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public class Balcony:Entity<int>
    {
        public int ResidenceId { get; set; }
        public Residence Residence { get; set; }
        public GeoDirection? Direction { get; set; }
        public int Size { get; set; }
        public BalconyType? BalconyType { get; set; }
        public SightType? SightType { get; set; }
        public int Level { get; set; }
    }
}
