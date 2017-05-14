using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IAuthManager
    {
        IAuthenticationManager AuthenticationManager { get; }
        Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser);
        ApplicationUser FindById(string userId);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        Task<IdentityResult> AddUserToRoleAsync(string userId, string role);
        Task<IdentityResult> RemoveFromRoleAsync(string userId, string role);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLockout);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string code);
        Task<ApplicationUser> FindByNameAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(string userId, string code, string password);
        Task<bool> IsEmailConfirmedAsync(string userId);
        void SignOut(string applicationCookie);
        Task<IdentityResult> ChangePasswordAsync(string agentUserId, string modelPassword);
        Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        Task SendEmailAsync(string userId, string subject, string body);
        bool IsInRole(string userId, string role);
    }
}
