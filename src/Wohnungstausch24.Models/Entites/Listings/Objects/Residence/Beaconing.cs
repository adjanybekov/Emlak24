using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public class Beaconing : Entity<int>
    {
        public int ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }
        public BeaconingType? BeaconingType { get; set; }
    }
}