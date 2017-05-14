using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Wohnungstausch24.Models;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IAgencyService
    {
        ICollection<Agency> GetAll();
        Task<int> UpdateAgencyAsync(string userId, AgencySettingsStep1ViewModel model);
        Task<int> RemoveAgencyAsync(string userId);
        Task<AgencySettingsStep1ViewModel> GetStep1ByUserIdAsync(string userId);
        Task<int> CreateAgencyAsync(string userId, AgencySettingsStep1ViewModel model);
        Task CreateAgentAsync(string managerUserId, ApplicationUser newUser, AddAgentViewModel model);
        Task<List<AgentSummaryViewModel>> GetAllAgentsAsync(string managerId);
        Task<AgencySettingsStep2ViewModel> GetStep2ByUserIdAsync(string userId);
        Task SaveStep2ByUserId(AgencySettingsStep2ViewModel userId, string getUserId);
        List<AddBranchModel> AddBranch(AddBranchModel model, string userId);
        Task<List<AddBranchModel>> DeleteBranchAsync(int branchId, string userId);
        List<AddBranchModel> GetBranches(string getUserId);
        Task<EditAgentViewModel> GetAgent(int? id, string getUserId);
        Task<bool> UpdateAgentAsync(EditAgentViewModel model, string v);
    }
}
