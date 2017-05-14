using System.Collections.Generic;
using System.Linq;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Common;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base;
using Wohnungstausch24.Models.ViewModels.Search.SearchProfiles;
using Wohnungstausch24.Models.ViewModels.Search.TenantSearch;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _dbContext;
        private IAutoMapper _autoMapper;
        public UserService(ApplicationDbContext dbContext, IAutoMapper autoMapper)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
        }


        public SearchProfilePagedListViewModel GetSearchProfiles(string userId, int? page, int? itemsPerpage)
        {
            var model = new SearchProfilePagedListViewModel();
            model.Pager = new Pager(_dbContext.SearchProfiles.Count(c => c.UserId.Equals(userId)), page, itemsPerpage);
            model.Items = _dbContext.SearchProfiles
                .Where(c => c.UserId.Equals(userId)).OrderBy(c => c.Id).Skip((model.Pager.CurrentPage - 1) * model.Pager.ItemsPerPage).Take(model.Pager.ItemsPerPage)
                .ToList()
                .Select(c => new DetailedSearchListing
                {
                    PriceRange = new RangedDecimal { From = c.PriceRange.From ?? 0, To = c.PriceRange.To ?? 0 },
                    AvailableFrom = c.AvailableFrom,
                    AvailableTo = c.AvailableTo,
                    Name = c.Title,
                    Id = c.Id
                })

                .ToList();
            return model;
        }


        public List<ClientSummaryViewModel> TenantSearch(TenantSearchViewModel model)
        {
            var selectedEmploymentStatuses = model.EmploymentStatusViewModel.Where(c => c.Selected).Select(c => c.EmploymentStatus).ToList();
            var slectedLocation = model.Locations.SelectMany(s => s.Children).SingleOrDefault(c => c.Selected);
            int? selectedLocationId = slectedLocation?.Id;

            IQueryable<SearchProfileListing> query = _dbContext.SearchProfiles
                .Where(s => model.Price == null || (s.PriceRange.From <= model.Price) && (s.PriceRange.To >= model.Price))
                .Where(spl => selectedLocationId == null || spl.Locations.Any(l => l.LocationId == selectedLocationId));

            #region Residence filter
            if (model.SelectedPropertyType != PropertyType.Land)
            {
                query = query.OfType<SearchProfileResidence>()
                    .Where(c => model.LivingArea == null || (c.ResidentialArea.From <= model.LivingArea) && (c.ResidentialArea.To >= model.LivingArea))
                    .Where(c => model.NumberOfLivingRooms == null || (c.NumberOfLivingRooms.From <= model.NumberOfLivingRooms) && (c.NumberOfLivingRooms.To >= model.NumberOfLivingRooms));
            }
            #endregion

            List<ClientSummaryViewModel> clients = null;

            if (model.SelectedTypeOfMerchandising == TypeOfMerchandising.Sale)
            {
                if (model.SelectedPropertyType == PropertyType.House)
                {
                    query = query.OfType<SearchProfileHouseForSale>();
                }
                if (model.SelectedPropertyType == PropertyType.Flat)
                {
                    query = query.OfType<SearchProfileFlatForSale>();
                }
            }

            if (model.SelectedTypeOfMerchandising == TypeOfMerchandising.Rent)
            {
                query = from searchProfile in query
                        from client in searchProfile.Clients
                        join agent in _dbContext.Agents on client.SearchProfile.UserId equals agent.UserId
                        where
                        (client.Income + ((client.Persons.Sum(d => d.Income) == null) ? 0 : (client.Income + client.Persons.Sum(d => d.Income))) >= model.MinIncome) &&
                        (selectedEmploymentStatuses.Count == 0 || selectedEmploymentStatuses.Any(es => es == client.EmploymentStatus))
                        && model.MaxNumberOfMembers == null || (client.Persons.Count < model.MaxNumberOfMembers)
                        select searchProfile;

                if (model.SelectedPropertyType == PropertyType.House)
                {
                    query = from searchProfile in query.OfType<SearchProfileHouseForRent>()
                            where
                            (model.PetsAreAllowed || searchProfile.IsPetsAllowed == model.PetsAreAllowed) &&
                            (model.IsSmokingAllowed || searchProfile.IsSmokingAllowed == model.IsSmokingAllowed)
                            select searchProfile;
                }
                else if (model.SelectedPropertyType == PropertyType.Flat)
                {
                    query = from searchProfile in query.OfType<SearchProfileFlatForRent>()
                        from client in searchProfile.Clients
                        where
                        (model.PetsAreAllowed || searchProfile.IsPetsAllowed == model.PetsAreAllowed) &&
                        (model.IsSmokingAllowed || searchProfile.IsSmokingAllowed == model.IsSmokingAllowed)
                        select searchProfile;
                }
            }

            clients = (from searchProfile in query.OfType<SearchProfileResidence>()
                               from client in searchProfile.Clients
                               join agent in _dbContext.Agents on client.SearchProfile.UserId equals agent.UserId
                               select new ClientSummaryViewModel
                               {
                                   Name = agent.User.FirstName + " " + agent.User.LastName,
                                   ClientId = client.Id,
                                   UserId = client.SearchProfile.UserId,
                                   Headline = client.Headline,
                                   Income = client.Income,
                                   About = client.About,
                                   PriceFrom = searchProfile.PriceRange.From,
                                   PriceTo = searchProfile.PriceRange.To,
                                   AreaFrom = searchProfile.ResidentialArea.From,
                                   AreaTo = searchProfile.ResidentialArea.To,
                                   NumberOfLivingRoomsFrom = searchProfile.NumberOfLivingRooms.From,
                                   NumberOfLivingRoomsTo = searchProfile.NumberOfLivingRooms.To,
                                   AvailableFrom = searchProfile.AvailableFrom,
                                   AvailableTo = searchProfile.AvailableTo,
                               }
                           ).ToList();
            return clients;
        }

        public ClientViewModel GetClientSummary(int clientId)
        {
            var client = _dbContext.Clients.Find(clientId);
            return _autoMapper.Map<ClientViewModel>(client); ;
        }

        public ApplicationUser FindById(string id)
        {
            return _dbContext.Users.Find(id);
        }
    }
}
