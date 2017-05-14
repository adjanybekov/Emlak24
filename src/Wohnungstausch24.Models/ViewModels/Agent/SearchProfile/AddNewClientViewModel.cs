using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.SearchProfile
{

    public class AddNewClientViewModel
    {
        public int SearchProfileId { get; set; }
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "SearchProfile_AddNewClient_AddAboutMe")]
        public string About { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Headline")]
        public string Headline { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "Common_Age")]
        public int Age { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "MinIncome")]
        public decimal? Income { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Profession")]
        public string Profession { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_Gender")]
        public Gender? Gender { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "EmploymentStatus")]
        public EmploymentStatus? EmploymentStatus { get; set; }

        public AddPersonViewModel AddPersonViewModel { get; set; }

        public List<PersonViewModel> Persons { get; set; }
    }
}
