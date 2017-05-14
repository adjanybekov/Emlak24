using System;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Flat
{
    public class Step9Flat : Step9Residence, IStep9Flat
    {
        [Display(ResourceType = typeof(Resource),Name = "Property_Step9_FlatNumber")]
        public int? FlatNumber { get; set; }
    }
}