using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base
{
    public interface IStep1Residence:IStep1Listing
    {
        int? NumberOfLevels { get; set; }
        bool IsFurnished { get; set; }
        bool IsShared { get; set; }
        FurnishType? FurnishType { get; set; }
        string HouseNumber { get; set; }
        int PropertySubType { get; set; }
    }
}
