using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4
{
    public class Step4ViewModel : StepsViewModelBase
    {
        public Step4ViewModel()
        {

        }
        public Step4ViewModel(int id):base(id)
        {
        }
        public Step4FlatForRent Step4FlatForRent { get; set; }
        public Step4FlatForSale Step4FlatForSale { get; set; }
        public Step4HouseForRent Step4HouseForRent { get; set; }
        public Step4HouseForSale Step4HouseForSale { get; set; }
        public Step4LandForSale Step4LandForSale { get; set; }
        public Step4RoomForRent Step4RoomForRent { get; set; }
    }
}
