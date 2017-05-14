using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites.Locations
{
    public class Country:Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<LocationLevel1> Children { get; set; }
    }
}