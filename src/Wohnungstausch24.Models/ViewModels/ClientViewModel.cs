using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels
{
    public class ClientViewModel
    {
        public ClientViewModel()
        {
            this.Persons = new List<PersonViewModel>();
        }

        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "SearchProfile_AddNewClient_AddAboutMe")]
        public string AboutMe { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Headline")]
        public string Headline { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_Age")]
        public int Age { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "MinIncome")]
        public decimal? Income { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Profession")]
        public string Profession { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_Gender")]
        public Gender? Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "EmploymentStatus")]
        public EmploymentStatus? EmploymentStatus { get; set; }

        public ClientDocumentType? ClientDocumentType { get; set; }

        public List<PersonViewModel> Persons { get; set; }
        public int Id { get; set; }
        public int SearchProfileId { get; set; }
    }
}