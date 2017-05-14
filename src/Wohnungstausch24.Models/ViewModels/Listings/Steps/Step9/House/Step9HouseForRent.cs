using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.House
{
    public class Step9HouseForRent :Step9House, IStep9HouseForRent
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Step9_HasHousingPermission")]
        public bool HasHousingPermission { get; set; }
    }
}