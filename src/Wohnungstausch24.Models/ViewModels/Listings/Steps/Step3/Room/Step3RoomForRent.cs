using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Room
{
    public class Step3RoomForRent: Step3Room, IStep3RoomForRent
    {
        public string BailText { get; set; }
        public decimal? Bail { get; set; }
        public decimal? BasicRent { get; set; }
        public decimal? RentalPricePerSqm { get; set; }
        public decimal? WarmRent { get; set; }
        public decimal? RentSubsidy { get; set; }
        public bool AllInRent { get; set; }
        public decimal? AllInRentPrice { get; set; }
        public PeriodType? PeriodType { get; set; }
    }
}
