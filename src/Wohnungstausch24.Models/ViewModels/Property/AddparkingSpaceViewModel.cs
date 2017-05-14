using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class AddparkingSpaceViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AddparkingSpaceViewModel_ParkType")]
        public ParkSpaceType? ParkType { get; set; }
        [Required]
        [Display(ResourceType = typeof(Resource), Name = "AddparkingSpaceViewModel_Quantity")]
        public int? Quantity { get; set; }


        [Display(ResourceType = typeof(Resource), Name = "AddparkingSpaceViewModel_RentPrice")]
        public decimal? Price { get; set; }
        public int Id { get; set; }
    }
}
