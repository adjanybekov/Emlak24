using System;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    public interface IStep3ResidenceForSale:IStep3Residence, IStep3ListingForSale
    {
        decimal MaintenanceSavings { get; set; }
    }
}