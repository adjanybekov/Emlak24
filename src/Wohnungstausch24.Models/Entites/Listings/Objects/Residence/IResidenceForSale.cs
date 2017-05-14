using System.ComponentModel.DataAnnotations;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public interface IResidenceForSale:IResidence,IListingForSale
    {
        decimal? MaintenanceSavings { get; set; }
    }
}