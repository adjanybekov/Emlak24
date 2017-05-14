using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House
{
    public interface IHouse:IResidence
    {
        RoofType? RoofType { get; set; }                  
    }
}