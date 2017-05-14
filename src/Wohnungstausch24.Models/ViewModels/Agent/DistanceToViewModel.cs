using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class DistanceToViewModel
    {
        public int? Id { get; set; }
        public DistanceType? DistanceType { get; set; }
        public decimal? DistanceInKm { get; set; }
    }
}
