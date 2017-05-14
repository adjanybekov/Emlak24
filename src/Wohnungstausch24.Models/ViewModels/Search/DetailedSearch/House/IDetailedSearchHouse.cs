using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House
{
    public interface IDetailedSearchHouse : IDetailedSearchResidence
    {
        List<HouseTypeViewModel> HouseTypeViewModels { get; set; }
        RangedDecimal PlotArea { get; set; }
    }
}