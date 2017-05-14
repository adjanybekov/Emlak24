using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class AddBathroomViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel_Size")]
        public int Size { get; set; }        
        public int Id { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel_HasShower")]
        public bool HasShower { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel_HasTub")]
        public bool HasTub { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel_HasWindow")]
        public bool HasWindow { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel_HasUrinal")]
        public bool HasUrinal { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBathroomViewModel_HasBidet")]
        public bool HasBidet { get; set; }
    }
}
