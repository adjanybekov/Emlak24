using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step11.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step11.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step11.Land;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step11
{
    public class Step11ViewModel : StepsViewModelBase
    {
        public Step11FlatForRent Step11FlatForRent { get; set; }
        public Step11FlatForSale Step11FlatForSale { get; set; }
        public Step11HouseForRent Step11HouseForRent { get; set; }
        public Step11HouseForSale Step11HouseForSale { get; set; }       
        public Step11LandForSale Step11LandForSale { get; set; }
    }
}
