using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Base
{
    public interface IStep2Listing:IStep2ViewModelBase
    {
        string Latitude { get; set; }
        string Longitude { get; set; }
        List<ViewSightViewModel> Sights { get; set; }
        AddViewSightViewModel AddViewSightViewModel { get; set; }
        List<DistanceToViewModel> DistanceToViewModels { get; set; }
        AddDistanceToViewModel AddDistanceToViewModel { get; set; }
    }
}