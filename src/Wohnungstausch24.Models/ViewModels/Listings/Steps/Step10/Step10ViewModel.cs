using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10.Land;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step10
{
    public class Step10ViewModel : StepsViewModelBase
    {
        public Step10FlatForRent Step10FlatForRent { get; set; }
        public Step10FlatForSale Step10FlatForSale { get; set; }
        public Step10HouseForRent Step10HouseForRent { get; set; }
        public Step10HouseForSale Step10HouseForSale { get; set; }        
        public Step10LandForSale Step10LandForSale { get; set; }
    }
}
