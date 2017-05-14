using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations.Security;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class AuthManager:IAuthManager
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private IAuthenticationManager _authenticationManager;

        public AuthManager(ApplicationSignInManager signInManager, ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        public Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            return _userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }
        public Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
            return _userManager.UpdateAsync(user);
        }

        public Task<IdentityResult> AddUserToRoleAsync(string userId, string role)
        {
            return _userManager.AddToRoleAsync(userId, role); ;
        }

        public Task<IdentityResult> RemoveFromRoleAsync(string userId, string role)
        {
            return _userManager.RemoveFromRoleAsync(userId, role); ;
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            return _userManager.IsInRoleAsync(userId, role);
        }

        public Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLockout)
        {
            return _signInManager.PasswordSignInAsync(email, password, rememberMe, shouldLockout);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<IdentityResult> ConfirmEmailAsync(string userId, string code)
        {
            return _userManager.ConfirmEmailAsync(userId, code);
        }

        public Task<ApplicationUser> FindByNameAsync(string email)
        {
            return _userManager.FindByNameAsync(email);
        }

        public Task<IdentityResult> ResetPasswordAsync(string userId, string code, string password)
        {
            return _userManager.ResetPasswordAsync(userId, code, password);
        }

        public Task<bool> IsEmailConfirmedAsync(string userId)
        {
            return _userManager.IsEmailConfirmedAsync(userId);
        }

        public void SignOut(string applicationCookie)
        {
            _authenticationManager.SignOut(applicationCookie);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string agentUserId, string modelPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(agentUserId);
            var result = await  _userManager.ResetPasswordAsync(agentUserId, token, modelPassword);
            return result;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(userId);
        }

        public Task SendEmailAsync(string userId, string subject, string body)
        {
            return _userManager.SendEmailAsync(userId, subject, body);
        }

        public bool IsInRole(string userId, string role)
        {
            return _userManager.IsInRole(userId, role);
        }

        public Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            return _signInManager.SignInAsync(user, isPersistent, rememberBrowser);
        }

        public ApplicationUser FindById(string userId)
        {
            return _userManager.FindById(userId);
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

    }
}
