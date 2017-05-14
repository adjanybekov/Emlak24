using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public class ParkingSpace:Entity<int>
    {
        public int ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }
        public ParkSpaceType? ParkSpaceType { get; set; }
        public int? Quantity { get; set; }
        public decimal? RentPrice { get; set; }
    }
}
