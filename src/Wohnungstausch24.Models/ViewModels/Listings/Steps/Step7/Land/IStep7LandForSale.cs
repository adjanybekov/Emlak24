using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Land;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Land
{
    public interface IStep7LandForSale : IStep9Land, IStep9ListingForSale
    {
        int? ExploitationNum { get; set; }
        int? ExploitationDenum { get; set; }
        decimal? GRZ { get; set; }
        decimal? GFZ { get; set; }
        decimal? BuldingBank { get; set; }

        bool ZoneOfConstruction { get; set; }
        bool ContaminatedSites { get; set; }            
        bool Gaz { get; set; }
        bool Water { get; set; }
        bool Electricity { get; set; }
        bool TK { get; set; }
        BuildingType? BuildingType { get; set; }
        AllotmentType? AllotmentType { get; set; }
        int? NumberOfLevels { get; set; }
    }
}