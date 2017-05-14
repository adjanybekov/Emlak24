namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Room
{
    public class Step1RoomForRent: Step1Room, IStep1RoomForRent
    {
        public bool ForIndustrialUse { get; set; }
        public bool ForHolidayUse { get; set; }
    }
}
