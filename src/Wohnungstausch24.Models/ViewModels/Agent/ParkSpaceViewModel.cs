using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class ParkSpaceViewModel
    {
        public int Id { get; set; }
        public ParkSpaceType ParkSpaceType { get; set; }
        public int Quantity { get; set; }
        public decimal RentPrice { get; set; }
    }
}