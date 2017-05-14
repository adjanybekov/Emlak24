using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Room;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8
{
    public class Step8ViewModel : StepsViewModelBase
    {
        public Step8ViewModel()
        {         
        }
        public Step8ViewModel(int id)
        {
            this.Id = id;
        }

        public Step8FlatForRent Step8FlatForRent { get; set; }
        public Step8FlatForSale Step8FlatForSale { get; set; }
        public Step8HouseForRent Step8HouseForRent { get; set; }
        public Step8HouseForSale Step8HouseForSale { get; set; }        
        public Step8LandForSale Step8LandForSale { get; set; }       
        public Step8RoomForRent Step8RoomForRent { get; set; }       
    }
}
