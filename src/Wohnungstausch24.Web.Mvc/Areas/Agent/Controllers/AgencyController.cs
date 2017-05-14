using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations.Security;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Models.ViewModels.Email;
using Wohnungstausch24.Resources;
using Wohnungstausch24.Web.Mvc.Filters;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent.Controllers
{
    [AuthorizeRoles(RoleDefinitions.SuperAgent)]
    public class AgencyController : BaseController
    {
        private IAgencyService _agencyService;
        private IAgentService _agentService;
        private IAuthManager _authManager;
        private ILocationService _locationService;

        public AgencyController(IAgencyService agencyService, IAuthManager authManager, IAgentService agentService,
            ILocationService locationService)
        {
            _agencyService = agencyService;
            _authManager = authManager;
            _agentService = agentService;
            _locationService = locationService;
        }

        public async Task<ActionResult> Step3()
        {
            var model = new AgentsListViewModel();
            var agents = await _agencyService.GetAllAgentsAsync(User.Identity.GetUserId());
            model.Items = agents;
            return View(model);
        }


        [HttpGet]
        public ActionResult AddAgent()
        {
            var model = new AddAgentViewModel();
            model.Languages =
                CultureHelper.GetAvailableAgentCultures()
                    .Select(c => new AddLanguageModel {Item = new SelectListItem {Value = c.Name, Text = c.NativeName}})
                    .ToList();
            model.Qualifications = Enum.GetValues(typeof(QualificationType))
              .Cast<QualificationType>()
              .Select(c => new AddQualificationModel { QualificationType = c, Selected = false })
              .ToList();

            model.Branches =
                _agencyService.GetBranches(User.Identity.GetUserId())
                    .Select(c => new SelectListItem {Value = c.Id.ToString(), Text = c.Name})
                    .ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddAgent(AddAgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var result = await _authManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    var newUser = await _authManager.FindByNameAsync(model.Email);
                    await _agencyService.CreateAgentAsync(User.Identity.GetUserId(), newUser, model);

                    #region Send confirmation Email to agent

                    string code = await _authManager.GenerateEmailConfirmationTokenAsync(newUser.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account",
                        new {userId = newUser.Id, code = code, area = ""}, protocol: Request.Url.Scheme);
                    var emailModel = new CreateAgentMailViewModel();
                    emailModel.Name = model.FirstName + " " + model.LastName;
                    emailModel.ConfirmationUrl = callbackUrl;
                    emailModel.Password = model.Password;
                    emailModel.Email = model.Email;
                    var mailContent = EmailSender.GetRazorViewAsString(emailModel,
                        "~/Views/EmailTemplates/CreateAgent.cshtml");
                    try
                    {
                        await _authManager.SendEmailAsync(userId: newUser.Id, subject: Resource.Email_Register_Mail_Title, body: mailContent);
                    }
                    catch (Exception)
                    {
                        this.AddToastMessage(Resource.Error, Resource.An_error_occurred_while_processing_your_request,ToastType.Error);
                    }
                    #endregion

                    var roleResult = await _authManager.AddUserToRoleAsync(newUser.Id, RoleDefinitions.Agent.ToString());
                    if (!roleResult.Succeeded)
                    {
                        roleResult.Errors.ForEach(c => ModelState.AddModelError("", c));
                    }
                    return RedirectToAction("Step3", "Agency", new {area="Agent"});
                }

                result.Errors.ForEach( c=> ModelState.AddModelError("", c));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> EditAgent(int id)
        {
            var model = await _agencyService.GetAgent(id,User.Identity.GetUserId());
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditAgent(EditAgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _agencyService.UpdateAgentAsync(model, User.Identity.GetUserId());
                if (!result)
                {
                    this.AddToastMessage(Resource.Error, Resource.General_Operation_Failed, ToastType.Error);
                }
                else
                {
                    this.AddToastMessage(Resource.Success,Resource.General_Operation_Successfull, ToastType.Success);
                }
                return RedirectToAction(nameof(EditAgent), new {id = model.AgentId});
            }
            model.Languages = CultureHelper.GetAvailableAgentCultures().Select(c => new AddLanguageModel { Item = new SelectListItem { Value = c.Name, Text = c.NativeName } }).ToList();
            model.Branches = _agencyService.GetBranches(User.Identity.GetUserId()).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Step1()
        {
            var agencyViewModel = await _agencyService.GetStep1ByUserIdAsync(User.Identity.GetUserId());
            if (agencyViewModel == null)
            {
                agencyViewModel = new AgencySettingsStep1ViewModel();
            }

            FillLocInfo(agencyViewModel);

            agencyViewModel.ProgressPercentage = 80;
            agencyViewModel.Message = Resource.Agent_Home_EditUserAgencyInfo;
            return View(agencyViewModel);
        }

        private void FillLocInfo(AgencySettingsStep1ViewModel data)
        {
            data.Countries = _locationService.GetCountries().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            data.LocationsLevel1 = new List<SelectListItem>();
            data.LocationsLevel2 = new List<SelectListItem>();
            data.LocationsLevel3 = new List<SelectListItem>();
            if (data.SelectedLocationlevel3 != null && data.SelectedLocationlevel3 != 0)
            {
                data.SelectedLocationlevel2 = _locationService.GetLocationLevel2Id(data.SelectedLocationlevel3);
                data.SelectedLocationlevel1 = _locationService.GetLocationLevel1Id(data.SelectedLocationlevel2);
                data.SelectedCountry = _locationService.GetCountryId(data.SelectedLocationlevel1);

                data.LocationsLevel1 = _locationService.GetLocationLevel1(data.SelectedCountry).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                data.LocationsLevel2 = _locationService.GetLocationLevel2(data.SelectedLocationlevel1.Value).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                data.LocationsLevel3 = _locationService.GetLocationLevel3(data.SelectedLocationlevel2.Value).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Step1(AgencySettingsStep1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agent = await _agentService.FindByUserIdAsync(User.Identity.GetUserId());
                var agency = await _agencyService.GetStep1ByUserIdAsync(User.Identity.GetUserId());
                var hasRole = await _authManager.IsInRoleAsync(User.Identity.GetUserId(), RoleDefinitions.SuperAgent.ToString());

                if (model.IsAgent)
                {
                    //if (agent == null) //does it exist?
                    //{
                    //    await _agentService.CreateAgentAsync(User.Identity.GetUserId());
                    //}

                    if (agency == null)
                    {
                        await _agencyService.CreateAgencyAsync(User.Identity.GetUserId(), model);
                    }
                    else
                    {
                        await _agencyService.UpdateAgencyAsync(User.Identity.GetUserId(), model);
                    }

                    if (!hasRole)
                    {
                        await _authManager.AddUserToRoleAsync(User.Identity.GetUserId(), RoleDefinitions.SuperAgent.ToString());
                        this.AddToastMessage("Please Login again.", "Your agent account will be activated after next login.");
                    }
                    return RedirectToAction("Step2");
                }
                else
                {
                    if (agent != null) //does it exist?
                    {
                        await _agentService.RemoveAgentAsync(agent.Id);
                    }
                    if (agency != null)
                    {
                        await _agencyService.RemoveAgencyAsync(User.Identity.GetUserId());
                    }
                    if (hasRole)
                    {
                        await _authManager.RemoveFromRoleAsync(User.Identity.GetUserId(), RoleDefinitions.SuperAgent.ToString());
                        this.AddToastMessage("Please Login again.", "Your changes will be affected after next login.");
                    }
                    return RedirectToAction("Step2");
                }
            }
            FillLocInfo(model);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Step2()
        {
            var model = await _agencyService.GetStep2ByUserIdAsync(User.Identity.GetUserId());
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Step2(AgencySettingsStep2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _agencyService.SaveStep2ByUserId(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step3));
            }
            return View(model);
        }

        public ActionResult GetBranches(int? id)
        {
            List<AddBranchModel> list = _agencyService.GetBranches(User.Identity.GetUserId());
            return PartialView("_BranchesTablePartial", list);
        }

        public async Task<ActionResult> DeleteBranch(int id)
        {
            List<AddBranchModel> list = await _agencyService.DeleteBranchAsync(id, User.Identity.GetUserId());
            return PartialView("_BranchesTablePartial", list);
        }

        public ActionResult AddBranch(AgencySettingsStep2ViewModel model)
        {
            var list = _agencyService.AddBranch(model.AddBranchModel, User.Identity.GetUserId());
            return PartialView("_BranchesTablePartial",list);
        }
    }
}