using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Common;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Flat
{
    public interface ISearchProfileFlat : ISearchProfileResidence
    {
        bool? IsApartmentTower { get; set; }
        RangedIntEntityNullable Level { get; set; }
        RangedIntEntityNullable NumberOfLevels { get; set; }
        ICollection<SpFlatType> SelectedFlatTypes { get; set; }
    }
}