using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class AddBalconyViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AddBalconyViewModel_Direction")]
        public GeoDirection? Direction { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBalconyViewModel_Size")]
        public int Size { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBalconyViewModel_BalconyType")]
        public BalconyType? BalconyType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBalconyViewModel_SightType")]
        public SightType? SightType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "AddBalconyViewModel_Level")]
        public int Level { get; set; }

        public int Id { get; set; }
    }
}
