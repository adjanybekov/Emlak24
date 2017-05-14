using System.Collections.Generic;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Base
{
    public class Step2Listing :Step2ViewModelBase, IStep2Listing
    {
        public Step2Listing()
        {
            this.AddDistanceToViewModel = new AddDistanceToViewModel();
            this.AddViewSightViewModel = new AddViewSightViewModel();
        }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<ViewSightViewModel> Sights { get; set; }
        public AddViewSightViewModel AddViewSightViewModel { get; set; }

        public List<DistanceToViewModel> DistanceToViewModels { get; set; }
        public AddDistanceToViewModel AddDistanceToViewModel { get; set; }
    }
}