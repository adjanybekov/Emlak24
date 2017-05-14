using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House
{
    public class House:Residence, IHouse
    {
        public RoofType? RoofType { get; set; }        
    }
}