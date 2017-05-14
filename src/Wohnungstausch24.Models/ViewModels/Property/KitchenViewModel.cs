using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Property
{
    public class KitchenViewModel
    {
        public int Id { get; set; }
        public bool IsFitted { get; set; }
        public bool IsOpen { get; set; }
        public bool IsPantry { get; set; }
    }
}