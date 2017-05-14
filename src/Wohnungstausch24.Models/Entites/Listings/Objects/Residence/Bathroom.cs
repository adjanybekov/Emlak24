using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public class Bathroom : Entity<int>
    {
        public int ResidenceId { get; set; }
        public virtual Residence Residence { get; set; }
        public int? Size { get; set; }
        public bool? HasShower { get; set; }
        public bool? HasTub { get; set; }
        public bool? HasWindow { get; set; }
        public bool? HasUrinal { get; set; }
        public bool? HasBidet { get; set; }
    }
}