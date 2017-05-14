using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Room;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9
{
    public class Step9ViewModel : StepsViewModelBase
    {
        public Step9ViewModel()
        {
            
        }
        public Step9ViewModel(int id):base(id)
        {
        }

        public Step9FlatForRent Step9FlatForRent { get; set; }
        public Step9FlatForSale Step9FlatForSale { get; set; }
        public Step9HouseForRent Step9HouseForRent { get; set; }
        public Step9HouseForSale Step9HouseForSale { get; set; }        
        public Step9LandForSale Step9LandForSale { get; set; }
        public Step9RoomForRent Step9RoomForRent { get; set; }
    }
}
