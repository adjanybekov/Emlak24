using System.Collections.Generic;

namespace Wohnungstausch24.Models.ViewModels.Location
{
    public class CountryViewModel:BaseModelWithId<int>
    {
        public string Name { get; set; }

        public List<LocationViewModelLevel1> Children { get; set; }
    }
}