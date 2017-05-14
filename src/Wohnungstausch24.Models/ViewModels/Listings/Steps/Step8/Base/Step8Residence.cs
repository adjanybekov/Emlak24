using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Base
{
    public class Step8Residence :Step8Listing,  IStep8Residence
    {
        public Step8Residence()
        {
            this.AddBeaconingViewModel = new AddBeaconingViewModel();
            this.AddHeatingViewModel = new AddHeatingViewModel();
        }
        public AddHeatingViewModel AddHeatingViewModel { get; set; }
        public AddBeaconingViewModel AddBeaconingViewModel { get; set; }
        [Display(ResourceType = typeof(Resource),Name = "Epart")]
        public Epart Epart { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "EnergyCertificateType")]
        public EnergyCertificateType EnergyCertificateType { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "DateOfIssue")]
        public DateTime? DateOfIssue { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "ValidUntil")]
        public DateTime? ValidUntil { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "EnergyConsumptionParameter")]
        public decimal? EnergyConsumptionParameter { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "IncludedHotWater")]
        public bool IncludedHotWater { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "UltimateEnergyDemand")]
        public decimal? UltimateEnergyDemand { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "ElectricityValue")]
        public decimal? ElectricityValue { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "WarmnessValue")]
        public decimal? WarmnessValue { get; set; }
        [Range(0, 250)]
        [Display(ResourceType = typeof(Resource), Name = "ValueRating")]
        public int? ValueRating { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Property_Step8_AgeGroup")]
        public AgeGroup AgeGroup { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "PrimaryEnegySource")]
        public BeaconingType PrimaryEnegySource { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "EnergyType")]
        public EnergyType? EnergyType { get; set; }
        public bool WantEnergyCertificate { get; set; }
    }
}