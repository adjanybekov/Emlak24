using System.Collections.Generic;
using System.Linq;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class SearchService: ISearchService
    {
        private ApplicationDbContext _dbContext;
        private IAutoMapper _autoMapper;

        public SearchService(ApplicationDbContext dbContext, IAutoMapper autoMapper)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
        }

        public void SaveDetailedSearchCriterias(DetailedSearchResultsModel model, string userId)
        {
            var user = _dbContext.Users.Find(userId);
            var selectedLocationIds = (from loc2 in model.Locations
                                       let children = loc2.Children
                                       from loc3 in children
                                       where loc3.Selected
                                       select loc3.Id).ToList();

            if (model.DetailedSearchFlatForRent!=null)
            {
                var spEntity = _autoMapper.Map<SearchProfileFlatForRent>(model.DetailedSearchFlatForRent);
                spEntity.Title = model.SearchName;
                FillSpLoc(spEntity, selectedLocationIds);
                user.SearchProfiles.Add(spEntity);
                _dbContext.SaveChanges();
            }
            if (model.DetailedSearchFlatForSale!=null)
            {
                var spEntity = _autoMapper.Map<SearchProfileFlatForSale>(model.DetailedSearchFlatForSale);
                spEntity.Title = model.SearchName;
                FillSpLoc(spEntity, selectedLocationIds);
                user.SearchProfiles.Add(spEntity);
                _dbContext.SaveChanges();
            }
            if (model.DetailedSearchHouseForRent!=null)
            {
                var spEntity = _autoMapper.Map<SearchProfileHouseForRent>(model.DetailedSearchHouseForRent);
                spEntity.Title = model.SearchName;
                FillSpLoc(spEntity, selectedLocationIds);
                user.SearchProfiles.Add(spEntity);
                _dbContext.SaveChanges();
            }
            if (model.DetailedSearchHouseForSale!=null)
            {
                var spEntity = _autoMapper.Map<SearchProfileHouseForSale>(model.DetailedSearchHouseForSale);
                spEntity.Title = model.SearchName;
                FillSpLoc(spEntity, selectedLocationIds);
                user.SearchProfiles.Add(spEntity);
                _dbContext.SaveChanges();
            }
        }

        private static void FillSpLoc(SearchProfileListing spEntity, List<int> selectedLocationIds)
        {
            spEntity.Locations = selectedLocationIds.Select(c => new SpLocation {LocationId = c}).ToList();
        }
    }
}
