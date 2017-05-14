using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class AddPersonViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "EmploymentStatus")]
        public EmploymentStatus? EmploymentStatus { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Profession")]
        public string Profession { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "MinIncome")]
        public decimal? Income { get; set; }
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Gender")]
        public Gender? Gender { get; set; }
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Age")]
        public int Age { get; set; }

        public int ClientId { get; set; }
        public int SearchProfileId { get; set; }
    }
}
