using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites.Locations
{
    public class LocationLevel2 : Entity<int>
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
        public virtual LocationLevel1 Parent { get; set; }

        public virtual ICollection<LocationLevel3> Children { get; set; }
    }
}