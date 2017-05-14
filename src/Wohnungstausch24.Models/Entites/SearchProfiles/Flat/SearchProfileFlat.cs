using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Flat
{
    public class SearchProfileFlat : SearchProfileResidence, ISearchProfileFlat
    {
        public SearchProfileFlat()
        {
            this.Level = new RangedIntEntityNullable();
            this.NumberOfLevels = new RangedIntEntityNullable();
            this.SelectedFlatTypes = new HashSet<SpFlatType>();
        }
        public bool? IsApartmentTower { get; set; }
        public RangedIntEntityNullable Level { get; set; }
        public RangedIntEntityNullable NumberOfLevels { get; set; }
        public ICollection<SpFlatType> SelectedFlatTypes { get; set; }
    }

    public class SpFlatType:Entity<int>
    {
        public int SpFlatId { get; set; }
        public SearchProfileFlat SpFlat { get; set; }
        public FlatType FlatType { get; set; }
    }
}