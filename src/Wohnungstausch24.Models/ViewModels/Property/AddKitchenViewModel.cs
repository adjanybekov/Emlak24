using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class AddKitchenViewModel
    {
        [Required]
        public KitchenType? KitchenType { get; set; }
    }
}