using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Wohnungstausch24.Core;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels.Account;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations.Security;
using Wohnungstausch24.Models.ViewModels.Email;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
	[Authorize]
	public class AccountController : BaseController
	{
	    private readonly IAuthManager _authManager;
	    private ISearchService _searchProfileService;
	    public AccountController(IAuthManager authManager, ISearchService searchProfileService)
	    {
	        _authManager = authManager;
	        _searchProfileService = searchProfileService;
	    }

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(AccountModels model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

            // Require the user to have a confirmed email before they can log on.
            var user = await _authManager.FindByNameAsync(model.LoginViewModel.Email);
            if (user != null)
            {
                if (!await _authManager.IsEmailConfirmedAsync(user.Id))
                {
                    ViewBag.errorMessage = Resource.Account_Confirm_Email_To_Logon;
                    return View("Error");
                }
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _authManager.PasswordSignInAsync(model.LoginViewModel.Email, model.LoginViewModel.Password, model.LoginViewModel.RememberMe, shouldLockout: false);
			switch (result)
			{
				case SignInStatus.Success:
			    {
			        if (!string.IsNullOrEmpty(returnUrl))
			        {
			            return RedirectToLocal(returnUrl);
			        }
			        return RedirectToAction("RedirectForRoles", "Redirect");
			    }
			    case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", "Invalid login attempt.");
					return View(model);
			}
		}

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

		//
		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountModels model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.RegisterViewModel.Email,
                    FirstName = model.RegisterViewModel.FirstName,
                    LastName = model.RegisterViewModel.LastName,
                    Email = model.RegisterViewModel.Email
                };
                var result = await _authManager.CreateAsync(user, model.RegisterViewModel.Password);
                if (result.Succeeded)
                {
                    await _authManager.AddUserToRoleAsync(user.Id, RoleDefinitions.SuperAgent.ToString());
                    string code = await _authManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    var emailModel = new RegistrationMailViewModel();
                    emailModel.Name = model.RegisterViewModel.FirstName + " " + model.RegisterViewModel.LastName;
                    emailModel.ConfirmationUrl = callbackUrl;
                    var mailContent = EmailSender.GetRazorViewAsString(emailModel, "~/Views/EmailTemplates/Register.cshtml");
                    await _authManager.SendEmailAsync(userId: user.Id, subject: Resource.Email_Register_Mail_Title, body: mailContent);

                    var detailedSearchVm = Session["SearchViewModel"] as DetailedSearchResultsModel;
                    if (detailedSearchVm != null)
                    {
                        _searchProfileService.SaveDetailedSearchCriterias(detailedSearchVm, user.Id);
                        this.AddToastMessage(Resource.Success, Resource.Please_Check_Your_Email_Account_To_Confirm_Your_Email_Address, ToastType.Success);
                        return RedirectToAction("DetailedSearch", "Home");
                    }
                    return View("RegisterConfirmation");
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
		public async Task<ActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return View("Error");
			}
			var result = await _authManager.ConfirmEmailAsync(userId, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}

		//
		// GET: /Account/ForgotPassword
		[AllowAnonymous]
		public ActionResult ForgotPassword()
		{
			return View();
		}

		//
		// POST: /Account/ForgotPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ForgotPassword(AccountModels model)
		{
			if (ModelState.IsValid)
			{
				var user = await _authManager.FindByNameAsync(model.ForgotPasswordViewModel.Email);
				if (user == null || !(await _authManager.IsEmailConfirmedAsync(user.Id)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View("ForgotPasswordConfirmation");
				}

				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				// Send an email with this link
				// string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
				// var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
				// await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
				// return RedirectToAction("ForgotPasswordConfirmation", "Account");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ForgotPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		//
		// GET: /Account/ResetPassword
		[AllowAnonymous]
		public ActionResult ResetPassword(string code)
		{
			return code == null ? View("Error") : View();
		}

		//
		// POST: /Account/ResetPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ResetPassword(AccountModels model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await _authManager.FindByNameAsync(model.ResetPasswordViewModel.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			var result = await _authManager.ResetPasswordAsync(user.Id, model.ResetPasswordViewModel.Code, model.ResetPasswordViewModel.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			AddErrors(result);
			return View();
		}

		//
		// GET: /Account/ResetPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			_authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction("Index", "Home");
		}
	}
}