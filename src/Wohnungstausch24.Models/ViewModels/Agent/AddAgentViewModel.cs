using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class AddAgentViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "Common_Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "General_The__0__must_be_at_least__2__characters_long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "General_Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resource), Name = "Confirm_Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "The_password_and_confirmation_password_do_not_match_")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "LastName")]
        public string LastName { get; set; }

        public List<AddLanguageModel> Languages { get; set; }
        public List<AddQualificationModel> Qualifications{ get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Education")]
        public string Education { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Branch")]
        public int? SelectedBranchId { get; set; }
        public List<SelectListItem> Branches { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "FieldOfResponsibility")]
        public FieldOfResponsibility FieldOfResponsibility { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "PositionInCompany")]
        public PositionInCompany PositionInCompany { get; set; }
    }

    public class AddLanguageModel
    {
        public SelectListItem Item { get; set; }
        public  LanguageLevel? LanguageLevel { get; set; }
    }

    public class AddQualificationModel
    {
        public bool Selected { get; set; }
        public QualificationType? QualificationType { get; set; }
    }
}