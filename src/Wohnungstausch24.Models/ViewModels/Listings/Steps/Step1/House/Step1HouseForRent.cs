namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.House
{
    public class Step1HouseForRent :Step1House, IStep1HouseForRent
    {
        public bool ForIndustrialUse { get; set; }
        public bool ForHolidayUse { get; set; }
    }
}