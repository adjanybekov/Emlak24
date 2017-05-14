using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3
{
    public class Step3ViewModel : StepsViewModelBase
    {
        public Step3FlatForRent Step3FlatForRent { get; set; }
        public Step3FlatForSale Step3FlatForSale { get; set; }
        public Step3HouseForRent Step3HouseForRent { get; set; }
        public Step3HouseForSale Step3HouseForSale { get; set; }
        public Step3LandForSale Step3LandForSale { get; set; }
        public Step3RoomForRent Step3RoomForRent { get; set; }
    }
}
