using System.Collections.Generic;

namespace Wohnungstausch24.Models.ViewModels.Location
{
    public class LocationViewModelLevel1 : BaseModelWithId<int>
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
        public CountryViewModel Parent { get; set; }

        public  List<LocationViewModelLevel2> Children { get; set; }
    }
}