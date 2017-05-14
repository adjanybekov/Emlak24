using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class AgencyService : IAgencyService
    {
        private ApplicationDbContext _dbContext;
        private IAgentService _agentService;
        private IAuthManager _authManager;

        public AgencyService(ApplicationDbContext dbContext, IAgentService agentService, IAuthManager authManager)
        {
            _dbContext = dbContext;
            _agentService = agentService;
            _authManager = authManager;
        }

        public ICollection<Agency> GetAll()
        {
            return _dbContext.Agencies.ToList();
        }
        public Task<int> UpdateAgencyAsync(string userId, AgencySettingsStep1ViewModel model)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId.Equals(userId));
            if (agency != null)
            {
                agency.Name = model.CompanyName;
                agency.BusinessType = model.BusinessType;
                agency.OrganizationOther = model.OrganizationOther;

                agency.PhoneNumber = model.PhoneNumber;
                agency.PhoneNumber2 = model.PhoneNumber2;
                agency.FaxNumber = model.FaxNumber;
                agency.Email = model.Email;

                agency.Facebook = model.Facebook;
                agency.Linkedin = model.Linkedin;
                agency.Twitter = model.Twitter;
                agency.GooglePlus = model.GooglePlus;

                agency.Locationlevel3Id = model.SelectedLocationlevel3;
                agency.Street = model.Street;
                agency.HouseNumber = model.HouseNumber;
                agency.ZipCode = model.ZipCode;
            }
            return _dbContext.SaveChangesAsync();
        }
        public Task<int> RemoveAgencyAsync(string userId)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId == userId);
            if (agency != null)
            {
                _dbContext.Agencies.Remove(agency);
            }
            return _dbContext.SaveChangesAsync();
        }
        public async Task<AgencySettingsStep1ViewModel> GetStep1ByUserIdAsync(string userId)
        {
            var agency = await _dbContext.Agencies.FirstOrDefaultAsync(c => c.ManagerId.Equals(userId));
            var isAgent = _dbContext.Agencies.Any(c => c.ManagerId.Equals(userId));
            if (agency != null)
            {
                return new AgencySettingsStep1ViewModel
                {
                    IsAgent = isAgent,
                    CompanyName = agency.Name,
                    PhoneNumber = agency.PhoneNumber,
                    PhoneNumber2 = agency.PhoneNumber2,
                    Facebook = agency.Facebook,
                    FaxNumber = agency.FaxNumber,
                    Linkedin = agency.Linkedin,
                    Twitter = agency.Twitter,
                    BusinessType = agency.BusinessType,
                    OrganizationOther = agency.OrganizationOther,
                    Email = agency.Email,
                    GooglePlus = agency.GooglePlus,
                    SelectedLocationlevel3 = agency.Locationlevel3Id,
                    Street = agency.Street,
                    HouseNumber = agency.HouseNumber,
                    ZipCode = agency.ZipCode
                };
            }
            return null;
        }

        public Task<int> CreateAgencyAsync(string userId, AgencySettingsStep1ViewModel model)
        {
            var agency = new Agency
            {
                Name = model.CompanyName,
                BusinessType = model.BusinessType,
                OrganizationOther = model.OrganizationOther,
                ManagerId = userId,
                PhoneNumber = model.PhoneNumber,
                PhoneNumber2 = model.PhoneNumber2,
                FaxNumber = model.FaxNumber,
                Email = model.Email,
                Facebook = model.Facebook,
                Linkedin = model.Linkedin,
                Twitter = model.Twitter,
                GooglePlus = model.GooglePlus,
                Locationlevel3Id = model.SelectedLocationlevel3,
                Street = model.Street,
                HouseNumber = model.HouseNumber,
                ZipCode = model.ZipCode
            };
            _dbContext.Agencies.Add(agency);
            return _dbContext.SaveChangesAsync();
        }

        public async Task CreateAgentAsync(string managerUserId, ApplicationUser newUser, AddAgentViewModel model)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId.Equals(managerUserId));
            if (agency != null) await _agentService.CreateAgentAsync(newUser.Id, agency.Id,model);
        }

        public async Task<List<AgentSummaryViewModel>> GetAllAgentsAsync(string managerId)
        {
            var agency = await _dbContext.Agencies.FirstOrDefaultAsync(c => c.ManagerId == managerId);
            if (agency == null) throw new ArgumentNullException(nameof(agency));
            return agency.Agents.Select(c=>new AgentSummaryViewModel
            {
                Name = c.User.FirstName,
                LastName = c.User.LastName,
                Email = c.User.Email,
                Id = c.Id,
                About = c.User.About,
                FieldOfResponsibility = c.FieldOfResponsibility,
                AgencyName = c.Agency.Name,
                UserId = c.UserId,
                EmailConfirmed = c.User.EmailConfirmed
            }).ToList();
        }

        public async Task<AgencySettingsStep2ViewModel> GetStep2ByUserIdAsync(string userId)
        {
            var agency = await _dbContext.Agencies.FirstOrDefaultAsync(c => c.ManagerId == userId);

            var agencyViewModel = new AgencySettingsStep2ViewModel
            {
                YearOfEstablishment = agency.YearOfEstablishment.GetValueOrDefault(),
                About = agency.About,
                Id = agency.Id,
                OrganizationOther = agency.OrganizationOther,
            };
            agencyViewModel.Emphases = Enum.GetValues(typeof(EmphasisType)).Cast<EmphasisType>().Select(c => new EmphasisViewModel
            {
                Selected = agency.EmphasisList.Any(e=>e.EmphasisType==c),
                EmphasisType = c
            }).ToList();

            agencyViewModel.Organizations = Enum.GetValues(typeof(OrganizationType)).Cast<OrganizationType>().Select(c => new OrganizationViewModel
            {
                Selected = agency.Organizations.Any(e=>e.Type==c),
                OrganizationType = c
            }).ToList();

            return agencyViewModel;
        }

        public async Task SaveStep2ByUserId(AgencySettingsStep2ViewModel model, string userId)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId == userId);
            if (agency == null) throw new ArgumentNullException(nameof(agency));
            agency.YearOfEstablishment = model.YearOfEstablishment;
            agency.About= model.About;
            agency.OrganizationOther= model.OrganizationOther;

            foreach (var emphasisViewModel in model.Emphases)
            {
                if (emphasisViewModel.Selected && agency.EmphasisList.All(c => c.EmphasisType!= emphasisViewModel.EmphasisType))
                {
                    agency.EmphasisList.Add(new Emphasis{ EmphasisType = emphasisViewModel.EmphasisType});
                }
                else if (!emphasisViewModel.Selected && agency.EmphasisList.Any(c => c.EmphasisType== emphasisViewModel.EmphasisType))
                {
                    var item = agency.EmphasisList.FirstOrDefault(c => c.EmphasisType == emphasisViewModel.EmphasisType);
                    if (item != null) _dbContext.Emphases.Remove(item);
                }
            }
            foreach (var organization in model.Organizations)
            {
                if (organization.Selected && agency.Organizations.All(c => c.Type!= organization.OrganizationType))
                {
                    agency.Organizations.Add(new Organization{ Type = organization.OrganizationType});
                }
                else if (!organization.Selected && agency.Organizations.Any(c => c.Type== organization.OrganizationType))
                {
                    var item = agency.Organizations.FirstOrDefault(c => c.Type== organization.OrganizationType);
                    if (item != null) _dbContext.Organizations.Remove(item);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public List<AddBranchModel> GetBranches(string userId)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId == userId);
            if (agency == null) throw new ArgumentNullException(nameof(agency));
            return agency.AgencyBranches.Select(c => new AddBranchModel { Name = c.Name, Address = c.Address,Id = c.Id}).ToList();
        }

        public async Task<EditAgentViewModel> GetAgent(int? id, string getUserId)
        {
            var agency = await _dbContext.Agencies.FirstOrDefaultAsync(c => c.ManagerId.Equals(getUserId));
            var model = new EditAgentViewModel();
            if (agency != null)
            {
                var agent = agency.Agents.FirstOrDefault(c => c.Id == id);
                if (agent != null)
                {
                    model.SelectedBranchId = agent.BranchId;
                    model.FirstName = agent.User.FirstName;
                    model.LastName = agent.User.LastName;
                    model.Education = agent.Education;
                    model.Email = agent.User.Email;
                    model.Languages = CultureHelper.GetAvailableAgentCultures().Select(c => new AddLanguageModel
                    {
                        Item = new SelectListItem
                        {
                            Value = c.Name, Text = c.NativeName,
                            Selected = agent.Languages.Any(t=>t.LanguageCulture==c.Name)
                        },
                        LanguageLevel = agent.Languages.FirstOrDefault(t => t.LanguageCulture == c.Name)?.Level
                    }).ToList();


                    model.Qualifications = Enum.GetValues(typeof(QualificationType))
                                  .Cast<QualificationType>()
                                  .Select(c => new AddQualificationModel { QualificationType = c, Selected = (agent.Qualifications.Any(m=>m.QualificationType == c))})
                                  .ToList();

                    model.Branches = GetBranches(getUserId).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                    model.FieldOfResponsibility = agent.FieldOfResponsibility;
                    model.PositionInCompany = agent.PositionInCompany;
                    model.SelectedBranchId = agent.BranchId;
                    model.AgentId = agent.Id;
                }

            }
            return model;
        }

        public async Task<bool> UpdateAgentAsync(EditAgentViewModel model, string userId)
        {
            var agency = await _dbContext.Agencies.FirstOrDefaultAsync(c => c.ManagerId.Equals(userId));
            if (agency != null)
            {
                var agent = agency.Agents.FirstOrDefault(c => c.Id == model.AgentId);
                if (agent != null)
                {
                    agent.User.FirstName = model.FirstName;
                    agent.User.LastName = model.LastName;
                    agent.Education = model.Education;
                    agent.FieldOfResponsibility = model.FieldOfResponsibility;
                    agent.PositionInCompany = model.PositionInCompany;
                    agent.BranchId = model.SelectedBranchId;
                    foreach (var languageModel in model.Languages)
                    {
                        if (languageModel.Item.Selected && agent.Languages.All(c => c.LanguageCulture!= languageModel.Item.Value))
                        {
                            agent.Languages.Add(new Language{ LanguageCulture= languageModel.Item.Value,Level = languageModel.LanguageLevel.GetValueOrDefault()});
                        }
                        if (languageModel.Item.Selected && agent.Languages.Any(c => c.LanguageCulture== languageModel.Item.Value))
                        {
                            var lang = agent.Languages.FirstOrDefault(c=>c.LanguageCulture==languageModel.Item.Value);
                            if (lang != null)
                                lang.Level = languageModel.LanguageLevel.GetValueOrDefault(LanguageLevel.Basic);
                        }
                        else if (!languageModel.Item.Selected && agent.Languages.Any(c => c.LanguageCulture== languageModel.Item.Value))
                        {
                            var item = agent.Languages.FirstOrDefault(c => c.LanguageCulture == languageModel.Item.Value);
                            if (item != null) _dbContext.Languages.Remove(item);
                        }
                    }
                    foreach(var qual in model.Qualifications)
                    {
                        if (qual.Selected && qual.QualificationType.HasValue && agent.Qualifications.All(c=>c.QualificationType != qual.QualificationType.Value))
                        {
                            agent.Qualifications.Add(new Qualification{QualificationType = qual.QualificationType.Value});
                        }
                        else if (!qual.Selected && qual.QualificationType.HasValue && agent.Qualifications.Any(c=>c.QualificationType == qual.QualificationType.Value))
                        {
                            var item = agent.Qualifications.FirstOrDefault(c => c.QualificationType == qual.QualificationType.Value);
                            if (item != null) _dbContext.Qualifications.Remove(item);
                        }
                    }

                    if (!string.IsNullOrEmpty(model.Password) && model.Password.Equals(model.ConfirmPassword))
                    {
                       var result = await _authManager.ChangePasswordAsync(agent.UserId, model.Password);
                        return result.Succeeded;
                    }
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public List<AddBranchModel> AddBranch(AddBranchModel model, string userId)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId == userId);
            if (agency == null) throw new ArgumentNullException(nameof(agency));
            agency.AgencyBranches.Add(new AgencyBranch {Name = model.Name,Address = model.Address});
            _dbContext.SaveChanges();
            return agency.AgencyBranches.Select(c => new AddBranchModel {Name = c.Name, Address = c.Address, Id = c.Id }).ToList();
        }

        public async Task<List<AddBranchModel>> DeleteBranchAsync(int branchId, string userId)
        {
            var agency = _dbContext.Agencies.FirstOrDefault(c => c.ManagerId == userId);
            if (agency == null) throw new ArgumentNullException(nameof(agency));
            var branch = await _dbContext.AgencyBranches.FindAsync(branchId);
            if (branch.AgencyId == agency.Id)
            {
                _dbContext.AgencyBranches.Remove(branch);
                await _dbContext.SaveChangesAsync();
            }
            return agency.AgencyBranches.Select(c => new AddBranchModel { Name = c.Name, Address = c.Address, Id = c.Id }).ToList();
        }
    }
}