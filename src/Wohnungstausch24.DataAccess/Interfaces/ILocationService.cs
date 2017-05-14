using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Locations;
using Wohnungstausch24.Models.ViewModels.Location;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface ILocationService
    {
        List<CountryViewModel> GetCountries();
        ICollection<LocationLevel1> GetLocationLevel1(int? countryId);
        ICollection<LocationLevel2> GetLocationLevel2(int locationLevel1Id);
        ICollection<LocationLevel3> GetLocationLevel3(int locationLevel2Id);
        int? GetLocationLevel2Id(int? locationlevel3);
        int? GetLocationLevel1Id(int? locationlevel2);
        int? GetCountryId(int? locationlevel1);
        List<LocationViewModelLevel2> GetAllCities(int id);
    }
}