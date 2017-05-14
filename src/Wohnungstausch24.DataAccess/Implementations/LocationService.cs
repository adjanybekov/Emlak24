using System.Collections.Generic;
using System.Linq;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites.Locations;
using Wohnungstausch24.Models.ViewModels.Location;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class LocationService:ILocationService
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CountryViewModel> GetCountries()
        {
            return _dbContext.Countries.Select(c=> new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public ICollection<LocationLevel1> GetLocationLevel1(int? countryId)
        {
            return _dbContext.LocationLevel1.OrderBy(c=>c.Name).Where(c => c.ParentId == countryId).ToList();
        }

        public ICollection<LocationLevel2> GetLocationLevel2(int locationLevel1Id)
        {
            return _dbContext.LocationLevel2.OrderBy(c => c.Name).Where(c => c.ParentId == locationLevel1Id).ToList();
        }

        public ICollection<LocationLevel3> GetLocationLevel3(int locationLevel2Id)
        {
            return _dbContext.LocationLevel3.OrderBy(c => c.Name).Where(c => c.ParentId == locationLevel2Id).ToList();
        }

        public int? GetLocationLevel2Id(int? locationlevel3)
        {
            var firstOrDefault = _dbContext.LocationLevel3.FirstOrDefault(c => c.Id == locationlevel3);
            if (firstOrDefault != null)
                return firstOrDefault.ParentId;
            return 0;
        }
        public int? GetLocationLevel1Id(int? locationlevel2)
        {
            var firstOrDefault = _dbContext.LocationLevel2.FirstOrDefault(c => c.Id == locationlevel2);
            if (firstOrDefault != null)
                return firstOrDefault.ParentId;
            return 0;
        }
        public int? GetCountryId(int? locationlevel1)
        {
            var firstOrDefault = _dbContext.LocationLevel1.FirstOrDefault(c => c.Id == locationlevel1);
            if (firstOrDefault != null)
                return firstOrDefault.ParentId;
            return 0;
        }

        public List<LocationViewModelLevel2> GetAllCities(int id)
        {
            return _dbContext.LocationLevel1.Find(id).Children.Select(loc2 => new LocationViewModelLevel2
            {
                Name = loc2.Name,
                Id = loc2.Id,
                Children = loc2.Children.Select(loc3 => new LocationViewModelLevel3
                {
                    Name = loc3.Name,
                    Id = loc3.Id
                }).ToList()
            }).ToList();
        }
    }
}
