using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class AgentSettingsContactViewModel:AgentSettingsBase
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "PhoneNumber_1")]
        public string PhoneNumber1 { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "PhoneNumber_2")]
        public string PhoneNumber2 { get; set; }

        [Editable(false)]
        [Display(ResourceType = typeof(Resource), Name = "Common_Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Skype")]
        public string Skype { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Gender")]
        public Gender? SelectedGender { get; set; }

        public List<SelectListItem> Genders { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_Title")]
        public string Title { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_SalutationMessage")]
        public string SalutationMessage { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_AddressAddOn")]
        public string AddressAddOn { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_EmailPrivate")]
        public string EmailPrivate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_EmailOther")]
        public string EmailOther { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_EmailFeedBack")]
        public string EmailFeedBack { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_ApprovalOfAddress")]
        public bool ApprovalOfAddress { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_SalutationType")]
        public SalutationType? SalutationType { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_PhoneDirectAccess")]
        public string PhoneDirectAccess { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_PhoneFax")]
        public string PhoneFax { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_PhonePrivate")]
        public string PhonePrivate { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_OtherPhone")]
        public string OtherPhone { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_Url")]
        public string Url { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "AgentSettingsContactViewModel_FreeTextArray")]
        public string FreeTextArray { get; set; }
    }
}
