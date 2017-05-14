using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1
{
    public class Step1ViewModel:StepsViewModelBase
    {
        public Step1FlatForRent Step1FlatForRent { get; set; }
        public Step1FlatForSale Step1FlatForSale { get; set; }
        public Step1HouseForRent Step1HouseForRent { get; set; }
        public Step1HouseForSale Step1HouseForSale { get; set; }
        public Step1LandForSale Step1LandForSale { get; set; }
        public Step1RoomForRent Step1RoomForRent { get; set; }
    }
}
