using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites.Locations
{
    public class LocationLevel3 : Entity<int>
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
        public virtual LocationLevel2 Parent { get; set; }
    }
}
