using System;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3.Base
{
    public interface IStep3Listing:IStep3ViewModelBase
    {
        PublisherType PublisherType { get; set; }
        bool IsActualContractTerminated { get; set; }
        DateTime? ActualContractTerminatedOn { get; set; }
        DateTime? EarliestAvailableDate { get; set; }
        DateTime? LatestAvailableDate { get; set; }
        bool IsCurrentlyRented { get; set; }
        string FreeTextAvailableFrom { get; set; }
        string FreeTextPrice { get; set; }
        decimal AdditionalCosts { get; set; }        
        bool IsDateFlexible { get; set; }
        bool AcceptBailLetter { get; set; }
        bool IsPriceOnDemand { get; set; }
        bool IsAllowedToBeIntroducedByAgent { get; set; }
        decimal Price { get; set; }
        decimal OrientationPrice { get; set; }
    }
}