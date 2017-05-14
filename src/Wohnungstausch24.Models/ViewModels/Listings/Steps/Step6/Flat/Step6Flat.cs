using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6.Flat
{
    public class Step6Flat : Step6Residence, IStep6Flat
    {
        [Display(ResourceType = typeof(Resource),Name = "Tercet")]
        public string Tercet { get; set; }
    }
}