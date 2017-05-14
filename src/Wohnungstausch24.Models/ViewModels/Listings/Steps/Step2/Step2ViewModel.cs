using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2
{
    public class Step2ViewModel : StepsViewModelBase
    {
        public Step2ViewModel()
        {

        }
        public Step2ViewModel(int id):base(id)
        {
        }

        public Step2FlatForRent Step2FlatForRent { get; set; }
        public Step2FlatForSale Step2FlatForSale { get; set; }
        public Step2HouseForRent Step2HouseForRent { get; set; }
        public Step2HouseForSale Step2HouseForSale { get; set; }
        public Step2LandForSale Step2LandForSale { get; set; }
        public Step2RoomForRent Step2RoomForRent { get; set; }
    }
}
