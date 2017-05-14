using System.Threading.Tasks;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Landing;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IAgentService
    {
        Task<int> CreateAgentAsync(string userId);
        Task<int> RemoveAgentAsync(int agentId);
        Task CreateAgentAsync(string newUserId, int agencyId, AddAgentViewModel model);
        Task<AgentDetailViewModel> GetById(int id);
        Task<Agent> FindByUserIdAsync(string userId);
    }
}
