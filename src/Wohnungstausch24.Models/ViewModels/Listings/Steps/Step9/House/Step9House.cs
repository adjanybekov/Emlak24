using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.House
{
    public class Step9House : Step9Residence, IStep9House
    {
        [Display(ResourceType = typeof(Resource), Name = "RoofType")]
        public RoofType? RoofType { get; set; }
    }
}