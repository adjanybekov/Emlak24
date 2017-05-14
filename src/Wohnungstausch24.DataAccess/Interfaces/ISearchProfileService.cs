using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Agent.SearchProfile;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Models.ViewModels.Search;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface ISearchProfileService
    {
        SearchProfileDetailViewModel GetById(int id);
        bool AddClient(AddNewClientViewModel model);
        bool DeletePerson(int? id, string userId);
        bool AddPerson(AddPersonViewModel model, string getUserId);
        bool DeleteClient(int? clientId, string getUserId);
        ClientViewModel GetClient(int clientid, int searchprofileid);
        bool EditClient(ClientViewModel model);
        bool DeleteSearchProfile(int searchprofileid, string getUserId);
    }
}
