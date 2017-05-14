using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class BalconyViewModel
    {
        public int Id { get; set; }
        public GeoDirection Direction { get; set; }
        public decimal Size { get; set; }
        public BalconyType BalconyType { get; set; }
        public SightType? SightType { get; set; }
        public int Level { get; set; }
    }
}