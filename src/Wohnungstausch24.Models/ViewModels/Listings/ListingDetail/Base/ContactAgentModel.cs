using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base
{
    public class ContactAgentModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Name")]
        public string Name { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resource), Name = "Common_Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resource),Name="Contact_Agent_NumberOfPersons")]
        public int? NumberOfPersons { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_Gender")]
        public Gender? Gender { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_Income")]
        public decimal? Income { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_NumberOfChildren")]
        public int? NumberOfChildren { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Common_Age")]
        public int? Age { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "EmploymentStatus")]
        public EmploymentStatus? EmploymentStatus { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Is_Smoker")]
        public bool IsSmoker { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Have_Pets")]
        public bool HasPets { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Pet_Species")]
        public string PetsFreeText { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resource), Name = "Common_Message")]
        public string Text { get; set; }

        public int ListingId { get; set; }
    }
}