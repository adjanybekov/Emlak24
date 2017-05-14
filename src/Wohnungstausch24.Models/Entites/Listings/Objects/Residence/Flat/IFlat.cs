using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat
{
    public interface IFlat:IResidence
    {
        int? Level { get; set; }
        PositionInBuilding? PositionInBuilding { get; set; }
        int? NumberOfApartmentUnits { get; set; }
        int? FlatNumber { get; set; }
    }
}