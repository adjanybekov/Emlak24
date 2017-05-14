using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Account
{
    public class AccountModels
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public ResetPasswordViewModel ResetPasswordViewModel { get; set; }
        public ForgotPasswordViewModel ForgotPasswordViewModel { get; set; }
        public IndexViewModel IndexViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "General_Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Remember_me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "Common_Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "General_The__0__must_be_at_least__2__characters_long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource),Name = "General_Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "Confirm_Password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "The_password_and_confirmation_password_do_not_match_")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LastName")]
        public string LastName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "General_The__0__must_be_at_least__2__characters_long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "General_Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "ResetPasswordViewModel_ConfirmPassword_Confirm_password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "The_password_and_confirmation_password_do_not_match_")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "ForgotPasswordViewModel_Email_Enter_your_e_mail")]
        public string Email { get; set; }
    }
}
