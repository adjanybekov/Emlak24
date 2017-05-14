using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.House
{
    public interface ISearchProfileHouse : ISearchProfileResidence
    {
        ICollection<SpHouseType> SelectedHouseTypes { get; set; }
        RangedDecimal PlotArea { get; set; }
    }
}