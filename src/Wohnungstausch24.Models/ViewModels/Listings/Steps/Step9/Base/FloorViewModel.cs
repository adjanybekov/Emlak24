using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base
{
    public class FloorViewModel
    {
        public int? Id { get; set; }
        public bool Selected { get; set; }
        public FloorType FloorType { get; set; }
    }
}