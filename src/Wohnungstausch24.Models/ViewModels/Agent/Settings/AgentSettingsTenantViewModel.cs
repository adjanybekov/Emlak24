using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class AgentSettingsTenantViewModel : AgentSettingsBase
    {
        public string UserId { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_PetsAllowed")]
        public bool HasPets{ get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Is_Smoking_Allowed")]
        public bool IsSmoker { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "SearchProfile_AddNewClient_AddAboutMe")]
        public string AboutMe { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Headline")]
        public string Headline { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Pet_Species")]
        public string PetSpecies { get; set; }
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
        public AddPersonViewModel AddPersonViewModel { get; set; }
    }
}