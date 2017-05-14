using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base
{
    public class Step9Listing :Step9ViewModelBase, IStep9Listing
    {
        public ListingStatus ListingStatus { get; set; }
        public bool IsKitchenPantry { get; set; }
    }
}