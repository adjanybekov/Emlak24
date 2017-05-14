using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites.Locations
{
    public class LocationLevel1 : Entity<int>
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
        public virtual Country Parent { get; set; }

        public virtual ICollection<LocationLevel2> Children { get; set; }
    }
}