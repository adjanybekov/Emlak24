using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat
{
    public interface IDetailedSearchFlat : IDetailedSearchResidence
    {
        List<FlatTypeViewModel> FlatTypeViewModels { get; set; }
        RangedInt Level { get; set; }
        RangedInt NumberOfLevels { get; set; }
        bool IsApartmentTower { get; set; }
    }
}