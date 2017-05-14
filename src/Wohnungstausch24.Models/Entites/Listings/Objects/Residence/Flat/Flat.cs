using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat
{
    public class Flat:Residence, IFlat
    {
        public int? Level { get; set; }
        public PositionInBuilding? PositionInBuilding { get; set; }
        public int? NumberOfApartmentUnits { get; set; }
        public int? FlatNumber { get; set; }
    }
}
