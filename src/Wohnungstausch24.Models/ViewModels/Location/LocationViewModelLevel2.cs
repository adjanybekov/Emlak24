using System.Collections.Generic;

namespace Wohnungstausch24.Models.ViewModels.Location
{
    public class LocationViewModelLevel2 : BaseModelWithId<int>
    {
        public string Name { get; set; }
        public List<LocationViewModelLevel3> Children { get; set; }
    }
}