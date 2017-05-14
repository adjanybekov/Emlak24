namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2.Room
{
    public class Step2RoomForRent: Step2Room, IStep2RoomForRent
    {
        public bool ForIndustrialUse { get; set; }
        public bool ForHolidayUse { get; set; }
    }
}
