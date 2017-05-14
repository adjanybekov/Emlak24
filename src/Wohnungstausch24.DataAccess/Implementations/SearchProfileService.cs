using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Entites.SearchProfiles.Flat;
using Wohnungstausch24.Models.Entites.SearchProfiles.House;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Agent.SearchProfile;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Models.ViewModels.Search;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Flat;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.House;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class SearchProfileService: ISearchProfileService
    {
        private ApplicationDbContext _applicationDbContext;
        private IAutoMapper _autoMapper;
        public SearchProfileService(ApplicationDbContext applicationDbContext, IAutoMapper autoMapper)
        {
            _applicationDbContext = applicationDbContext;
            _autoMapper = autoMapper;
        }

        public SearchProfileDetailViewModel GetById(int id)
        {
            var model = new SearchProfileDetailViewModel();
            var searchProfile = _applicationDbContext.SearchProfiles.Find(id);

            if (searchProfile is SearchProfileFlatForRent)
            {
                model.SearchProfile = _autoMapper.Map<DetailedSearchFlatForRent>(searchProfile);
            }
            else if (searchProfile is SearchProfileFlatForSale)
            {
                model.SearchProfile = _autoMapper.Map<DetailedSearchFlatForSale>(searchProfile);
            }
            else if (searchProfile is SearchProfileHouseForRent)
            {
                model.SearchProfile = _autoMapper.Map<DetailedSearchHouseForRent>(searchProfile);
            }
            else if (searchProfile is SearchProfileHouseForSale)
            {
                model.SearchProfile = _autoMapper.Map<DetailedSearchHouseForSale>(searchProfile);
            }

            model.Clients = _autoMapper.Map<List<ClientViewModel>>(searchProfile.Clients);
            model.SearchProfile.SelectedAllLocations = (from loc3 in _applicationDbContext.LocationLevel3
                                                        join spLocId in searchProfile.Locations.Select(c=>c.LocationId) on loc3.Id equals spLocId
                                                        select loc3.Name).ToList();
            return model;
        }


        public bool AddClient(AddNewClientViewModel model)
        {
            var searchProfile = _applicationDbContext.SearchProfiles.Find(model.SearchProfileId);
            var client = _autoMapper.Map<Client>(model);

            if (searchProfile != null)
            {
                searchProfile.Clients.Add(client);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeletePerson(int? id, string userId)
        {
            var person = _applicationDbContext.Persons.Find(id);
            if (person == null) throw new ArgumentNullException(nameof(person));
            var personClient = person.Client;
            if (personClient == null) throw new ArgumentNullException(nameof(personClient));
            var searchProfile = personClient.SearchProfile;
            if (searchProfile == null) throw new ArgumentNullException(nameof(searchProfile));
            if (!searchProfile.UserId.Equals(userId))throw new UnauthorizedAccessException("Delete person unauthorized. " + "search profile id:" + id + " userId:" + userId);
            _applicationDbContext.Persons.Remove(person);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public bool AddPerson(AddPersonViewModel model, string getUserId)
        {
            var client = _applicationDbContext.Clients.Find(model.ClientId);
            if (client == null)throw new ArgumentNullException(nameof(client));
            var user = _applicationDbContext.Users.Find(getUserId);
            if (!user.Id.Equals(client.SearchProfile.UserId))
                throw new UnauthorizedAccessException("Unfortunately you can't edit someone else's listing...");
            client.Persons.Add(new Person
            {
                EmploymentStatus = model.EmploymentStatus,
                Profession = model.Profession,
                Income = model.Income,
                Gender = model.Gender,
                Age = model.Age
            });
            _applicationDbContext.SaveChanges();
            return true;
        }

        public bool DeleteClient(int? clientId, string getUserId)
        {
            var client = _applicationDbContext.Clients.Find(clientId);
            if (client == null) throw new ArgumentNullException(nameof(client));
            _applicationDbContext.Persons.RemoveRange(client.Persons);
            _applicationDbContext.Clients.Remove(client);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public ClientViewModel GetClient(int clientid, int searchprofileid)
        {

            var client = _applicationDbContext.Clients.Find(clientid);
            if(client==null) throw new ArgumentNullException(nameof(client));
            var clinetVm = _autoMapper.Map<ClientViewModel>(client);


            return clinetVm;
        }

        [HttpPost]
        public bool EditClient(ClientViewModel model)
        {
            var client = _applicationDbContext.Clients.Find(model.Id);
            _autoMapper.Map(model,client);
            if (client != null)
            {
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSearchProfile(int searchprofileid, string getUserId)
        {
            var spf = _applicationDbContext.SearchProfiles.Find(searchprofileid);
            if (spf == null) throw new ArgumentNullException(nameof(spf));
            for (int i = 0; i < spf.Clients.Count; i++)
            {
                _applicationDbContext.Persons.RemoveRange(spf.Clients[i].Persons);
            }
            _applicationDbContext.Clients.RemoveRange(spf.Clients);
            _applicationDbContext.SearchProfiles.Remove(spf);
            _applicationDbContext.SaveChanges();
            return true;
        }
    }

}

