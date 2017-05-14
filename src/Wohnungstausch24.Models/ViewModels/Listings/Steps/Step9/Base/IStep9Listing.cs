using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base
{
    public interface IStep9Listing:IStep9ViewModelBase
    {
        ListingStatus ListingStatus { get; set; }
    }
}