using System;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8.Base
{
    public interface IStep8Residence:IStep8Listing
    {
        AddHeatingViewModel AddHeatingViewModel { get; set; }
        AddBeaconingViewModel AddBeaconingViewModel { get; set; }
        Epart Epart { get; set; }
        EnergyCertificateType EnergyCertificateType { get; set; }
        EnergyType? EnergyType { get; set; }
        DateTime? DateOfIssue { get; set; }
        DateTime? ValidUntil { get; set; }

        decimal? EnergyConsumptionParameter { get; set; }
        bool IncludedHotWater { get; set; }
        decimal? UltimateEnergyDemand { get; set; }
        decimal? ElectricityValue { get; set; }
        decimal? WarmnessValue { get; set; }
        int? ValueRating { get; set; }

        AgeGroup AgeGroup { get; set; }
        BeaconingType PrimaryEnegySource { get; set; }
        bool WantEnergyCertificate { get; set; }
    }
}
