using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Landing;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class AgentService: IAgentService
    {
        private ApplicationDbContext _dbContext;
        public AgentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> CreateAgentAsync(string userId)
        {
            _dbContext.Agents.Add(new Agent
            {
                UserId = userId
            });
           return _dbContext.SaveChangesAsync();
        }
        public Task CreateAgentAsync(string newUserId, int agencyId, AddAgentViewModel model)
        {
            _dbContext.Agents.Add(new Agent
            {
                UserId = newUserId,
                AgencyId = agencyId,
                Languages = model.Languages.Where(c=>c.Item.Selected).Select(c=>new Language {LanguageCulture = c.Item.Value,Level = c.LanguageLevel.GetValueOrDefault()}).ToList(),
                Qualifications = model.Qualifications.Where(c=>c.Selected).Select(c=>new Qualification{ QualificationType = c.QualificationType.GetValueOrDefault()}).ToList(),
                Education = model.Education,
                BranchId = model.SelectedBranchId,
                FieldOfResponsibility = model.FieldOfResponsibility,
                PositionInCompany = model.PositionInCompany,

            });
            return _dbContext.SaveChangesAsync();
        }
        public async Task<AgentDetailViewModel> GetById(int id)
        {
            var model = new AgentDetailViewModel();
            var agent = await _dbContext.Agents.FindAsync(id);
            if (agent == null) throw new ArgumentNullException(nameof(agent));
            model.FirstName = agent.User.FirstName;
            model.LastName = agent.User.LastName;
            model.PhoneNumber = agent.User.PhoneNumber;
            model.PhoneNumber2 = agent.User.PhoneNumber2;
            model.Email = agent.User.Email;
            model.Skype = agent.User.Skype;
            model.About = agent.User.About;
            model.Facebook = agent.User.Facebook;
            model.Linkedin = agent.User.Linkedin;
            model.Twitter = agent.User.Twitter;
            model.GooglePlus = agent.User.GooglePlus;
            model.Branch = agent.Branch;
            model.Education = agent.Education;
            model.FieldOfResponsibility = agent.FieldOfResponsibility;
            model.Languages = agent.Languages;
            model.PositionInCompany = agent.PositionInCompany;

            if (agent.Agency != null)
            {
                var agency = agent.Agency;
                model.AgencyName = agency.Name;
            }
            return model;
        }
        public Task<Agent> FindByUserIdAsync(string userId)
        {
            return _dbContext.Agents.FirstOrDefaultAsync(c => c.UserId.Equals(userId));
        }
        public Task<int> RemoveAgentAsync(int agentId)
        {
            var agent = _dbContext.Agents.Find(agentId);
            if (agent != null)
            {
                _dbContext.Agents.Remove(agent);
            }
            return _dbContext.SaveChangesAsync();
        }

    }
}
