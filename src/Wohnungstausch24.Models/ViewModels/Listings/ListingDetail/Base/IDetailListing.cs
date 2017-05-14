using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.Images;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base
{
    public interface IDetailListing:IDetailViewModelBase
    {
        DateTime CreatedOnUtc { get; set; }
        List<FileDto> Files { get; set; }
        ListingAgentViewModel AgentViewModel { get; set; }
        string ListingHeader { get; set; }
        string Description { set; get; }
        TypeOfMerchandising? TypeOfMerchandising { get; set; }
        TypeOfUse? TypeOfUse { get; set; }
        ListingStatus? ListingStatus { get; set; }
        PropertyType? PropertyType { get; set; }
        int? TotalArea { get; set; }
        int? Price { get; set; }
        float? Latitude { get; set; }
        float? Longitude { get; set; }
        string Street { get; set; }
        string LocationLevel1 { get; set; }
        string LocationLevel2 { get; set; }
        string LocationLevel3 { get; set; }
        string Country { get; set; }
        int Id { get; set; }
        string FullAddress { get; }
        string LocationDescription { get; set; }
        string EnvironmentDescription { get; set; }
        bool? IsActualContractTerminated { get; set; }
        DateTime? ActualContractTerminatedOn { get; set; }
        DateTime? EarliestAvailableDate { get; set; }
        DateTime? LatestAvailableDate { get; set; }

        List<DistanceToViewModel> Distances { get; set; }

        string FreeTextPrice { get; set; }
        PublisherType? PublisherType { get; set; }
        int? PropertySubType { get; set; }
        List<TextInAnotherLanguageViewModel> ObjectTextInAnotherLanguages { get; set; }
        decimal? PlotArea { get; set; }
        string OtherDetails { get; set; }
        ContactAgentModel ContactAgentModel { get; set; }
        bool IsAddressPublic { get; set; }
    }
}