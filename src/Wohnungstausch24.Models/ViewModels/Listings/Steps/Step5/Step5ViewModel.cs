using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5
{
    public class Step5ViewModel : StepsViewModelBase
    {
        public Step5ViewModel()
        {

        }
        public Step5ViewModel(int id):base(id)
        {
        }

        public Step5FlatForRent Step5FlatForRent { get; set; }
        public Step5FlatForSale Step5FlatForSale { get; set; }
        public Step5HouseForRent Step5HouseForRent { get; set; }
        public Step5HouseForSale Step5HouseForSale { get; set; }
        public Step5LandForSale Step5LandForSale { get; set; }
        public Step5RoomForRent Step5RoomForRent { get; set; }
        public int MaxRequestLength { get; set; }
    }
}
