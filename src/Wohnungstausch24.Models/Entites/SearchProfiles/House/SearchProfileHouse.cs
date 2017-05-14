using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.House
{
    public class SearchProfileHouse : SearchProfileResidence, ISearchProfileHouse
    {
        public ICollection<SpHouseType> SelectedHouseTypes { get; set; }
        public RangedDecimal PlotArea { get; set; }
    }

    public class SpHouseType:Entity<int>
    {
        public int SpHouseId { get; set; }
        public SearchProfileHouse SpHouse { get; set; }
        public HouseType HouseType { get; set; }
    }
}