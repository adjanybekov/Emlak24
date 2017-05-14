using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Room;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7
{
    public class Step7ViewModel : StepsViewModelBase
    {
        public Step7ViewModel()
        {

        }
        public Step7ViewModel(int id):base(id)
        {
        }

        public Step7FlatForRent Step7FlatForRent { get; set; }
        public Step7FlatForSale Step7FlatForSale { get; set; }
        public Step7HouseForRent Step7HouseForRent { get; set; }
        public Step7HouseForSale Step7HouseForSale { get; set; }
        public Step7LandForSale Step7LandForSale { get; set; }
        public Step7RoomForRent Step7RoomForRent { get; set; }
    }
}