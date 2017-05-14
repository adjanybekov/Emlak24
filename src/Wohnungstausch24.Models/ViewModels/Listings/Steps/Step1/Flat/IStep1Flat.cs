using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Flat
{
    public interface IStep1Flat : IStep1Residence
    {
        int? Level { get; set; }
        PositionInBuilding? PositionInBuilding { get; set; }
        int? NumberOfApartmentUnits { get; set; }
    }
}