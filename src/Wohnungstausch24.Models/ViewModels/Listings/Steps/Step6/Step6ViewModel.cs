using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6
{
    public class Step6ViewModel : StepsViewModelBase
    {
        public Step6ViewModel()
        {
            
        }
        public Step6ViewModel(int id):base(id)
        {
        }

        public Step6FlatForRent Step6FlatForRent { get; set; }
        public Step6FlatForSale Step6FlatForSale { get; set; }
        public Step6HouseForRent Step6HouseForRent { get; set; }
        public Step6HouseForSale Step6HouseForSale { get; set; }        
        public Step6LandForSale Step6LandForSale { get; set; }
        public Step6RoomForRent Step6RoomForRent { get; set; }


    }
}
