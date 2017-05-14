using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Account;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent.Controllers
{
    [Authorize]
    public class SettingsController : BaseController
    {
        private IAuthManager _authManager;

        public SettingsController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        // GET: Agent/Settings
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Contact()
        {
            var user = await _authManager.FindByIdAsync(User.Identity.GetUserId());

            AgentSettingsContactViewModel model = new AgentSettingsContactViewModel();
            model.Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                                    .Select(c => new SelectListItem { Value = c.ToString(), Text = c.GetDisplayName() })
                                    .ToList();
            model.ProgressPercentage = 25;
            model.Message = Resource.Agent_Home_EditUserInformations;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.SelectedGender = user.Gender;
            model.PhoneNumber1 = user.PhoneNumber;
            model.PhoneNumber2 = user.PhoneNumber2;
            model.Email = user.Email;
            model.Skype = user.Skype;
            model.Title = user.Title;
            model.SalutationMessage = user.SalutationMessage;
            model.AddressAddOn = user.AddressAddOn;
            model.EmailPrivate = user.EmailPrivate;
            model.EmailOther = user.EmailOther;
            model.EmailFeedBack = user.EmailFeedBack;
            model.PhoneDirectAccess = user.PhoneDirectAccess;
            model.PhoneFax = user.PhoneFax;
            model.PhonePrivate = user.PhonePrivate;
            model.OtherPhone = user.OtherPhone;
            model.Url = user.Url;
            model.FreeTextArray = user.FreeTextArray;
            model.ApprovalOfAddress = user.ApprovalOfAddress.GetValueOrDefault();
            model.SalutationType = user.SalutationType;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(AgentSettingsContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _authManager.FindByIdAsync(User.Identity.GetUserId());
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber1;
                user.PhoneNumber2 = model.PhoneNumber2;
                user.Skype = model.Skype;
                user.Gender = model.SelectedGender;
                user.Title = model.Title;
                user.SalutationMessage = model.SalutationMessage;
                user.AddressAddOn = model.AddressAddOn;
                user.EmailPrivate = model.EmailPrivate;
                user.EmailOther = model.EmailOther;
                user.EmailFeedBack = model.EmailFeedBack;
                user.PhoneDirectAccess = model.PhoneDirectAccess;
                user.PhoneFax = model.PhoneFax;
                user.PhonePrivate = model.PhonePrivate;
                user.OtherPhone = model.OtherPhone;
                user.Url = model.Url;
                user.FreeTextArray = model.FreeTextArray;
                user.ApprovalOfAddress = model.ApprovalOfAddress;
                user.SalutationType = model.SalutationType;
                var result = await _authManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Social()
        {
            var user = await _authManager.FindByIdAsync(User.Identity.GetUserId());
            var model = new AgentSettingsSocialViewModel();
            model.Facebook = string.IsNullOrEmpty(user.Facebook)?"": user.Facebook;
            model.Twitter = string.IsNullOrEmpty(user.Twitter)? "" : user.Twitter;
            model.Linkedin = string.IsNullOrEmpty(user.Linkedin)?"" : user.Linkedin;
            model.GooglePlus = string.IsNullOrEmpty(user.GooglePlus) ? "" : user.GooglePlus;
            model.ProgressPercentage = 50;
            model.Message = Resource.Agent_Home_EditUserSocialInformations;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Social(AgentSettingsSocialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _authManager.FindByIdAsync(User.Identity.GetUserId());
                user.Facebook = model.Facebook;
                user.Twitter =  model.Twitter;
                user.Linkedin = model.Linkedin;
                user.GooglePlus = model.GooglePlus;

                var result = await _authManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }



        public async Task<ActionResult> EditSettings()
        {
            var model = new AgentHomePageViewModel();
            var user = await _authManager.FindByIdAsync(User.Identity.GetUserId());
            if (user.Gender == null || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.PhoneNumber))
            {
                return RedirectToAction(nameof(this.Contact));
            }
            if (string.IsNullOrEmpty(user.Facebook) || string.IsNullOrEmpty(user.Twitter) || string.IsNullOrEmpty(user.Linkedin) || string.IsNullOrEmpty(user.GooglePlus))
            {
                return RedirectToAction(nameof(this.Social));
            }
            return null;
        }

        public PartialViewResult Progress()
        {
            var checkList = new List<bool>();
            var progress = 100;

            var user = _authManager.FindById(User.Identity.GetUserId());

            checkList.Add(user.Gender == null);
            checkList.Add(string.IsNullOrEmpty(user.FirstName));
            checkList.Add(string.IsNullOrEmpty(user.LastName));
            checkList.Add(string.IsNullOrEmpty(user.PhoneNumber));
            checkList.Add(string.IsNullOrEmpty(user.PhoneNumber2));
            checkList.Add(string.IsNullOrEmpty(user.Skype));
            checkList.Add(string.IsNullOrEmpty(user.Facebook));
            checkList.Add(string.IsNullOrEmpty(user.Twitter));
            checkList.Add(string.IsNullOrEmpty(user.Linkedin));
            checkList.Add(string.IsNullOrEmpty(user.GooglePlus));

            foreach (var item in checkList)
            {
                if (item)
                {
                    progress -= 100 / checkList.Count;
                }
            }
            return PartialView("_Progress", progress);
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(AccountModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _authManager.ChangePasswordAsync(User.Identity.GetUserId(), model.ChangePasswordViewModel.OldPassword, model.ChangePasswordViewModel.NewPassword);
            if (result.Succeeded)
            {
                var user = await _authManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await _authManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                //todo: translate
                this.AddToastMessage("Success", "You successfully changed your password", ToastType.Success);
                return View();
            }
            AddErrors(result);
            return View(model);
        }
    }
}