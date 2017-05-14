using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4.Base
{
    public interface IStep4Residence:IStep4Listing
    {
        decimal? LivingArea { get; set; }
        decimal? UsefulArea { get; set; }
        int? NumberOfRooms { get; set; }
        int? NumberOfBedrooms { get; set; }
        decimal? BasementArea { get; set; }
        decimal? GardenArea { get; set; }
        decimal? OtherArea { get; set; }
        int? NumberOfLivingBedrooms { get; set; }
        UnderGroundType UnderGroundType { get; set; }
        bool IsGardenUtilizationPossible { get; set; }
        bool HasBalcony { get; set; }
        bool HasParkingSpaces { get; set; }
        List<BalconyViewModel> BalconyModels { get; set; }
        List<ParkSpaceViewModel> ParkingSpaceViewModels { get; set; }
        AddparkingSpaceViewModel AddparkingSpaceViewModel { get; set; }
        AddBalconyViewModel AddBalconyViewModel { get; set; }
        int? NumberOfBathrooms { get; set; }
        bool HasSeparateToilet { get; set; }
        bool HasGuestToilet{ get; set; }
        int NumberOfSeparateToilets { get; set; }
        decimal? AtticSpace { get; set; }

    }
}
