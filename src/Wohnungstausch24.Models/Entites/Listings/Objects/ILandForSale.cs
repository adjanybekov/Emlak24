using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects
{
    public interface ILandForSale:ILand,IListingForSale
    {
        int? Floor { get; set; }
        int? FloorTypeNumerator { get; set; }
        int? FloorTypeDenumerator { get; set; }
        string Boundary { get; set; }
        decimal? SeparableFrom { get; set; }
        ICollection<MixedLand> MixedLands { get; set; }
        int? ExploitationNum { get; set; }
        int? ExploitationDenum { get; set; }
        decimal? GRZ { get; set; }
        decimal? GFZ { get; set; }
        decimal? BuldingBank { get; set; }
        bool? ZoneOfConstruction { get; set; }
        bool? ContaminatedSites { get; set; }
        bool? Gaz { get; set; }
        bool? Water { get; set; }
        bool? Electricity { get; set; }
        bool? TK { get; set; }
        BuildingType? BuildingType { get; set; }
        AllotmentType? AllotmentType { get; set; }
    }
}