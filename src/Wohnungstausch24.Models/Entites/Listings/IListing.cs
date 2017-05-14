using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public interface IListing:IAuditableEntity
    {
        string UserId { get; set; }
        ApplicationUser User { get; set; }
        string ListingHeader { get; set; }
        string Description { set; get; }
        int? TotalArea { get; set; }
        int? Price { get; set; }
        float? Latitude { get; set; }
        float? Longitude { get; set; }
        int? Locationlevel3 { get; set; }
        string Street { get; set; }
        string HouseNumber { get; set; }
        string Zipcode { get; set; }
        string SubUrbLeft { get; set; }
        bool? ShowFullAddressInPublic { get; set; }
        TypeOfUse? TypeOfUse { get; set; }
        ListingStatus? ListingStatus { get; set; }
        string EnvironmentDescription { get; set; }
        string LocationDescription { get; set; }
        ICollection<ListingFile> Files { get; set; }
        PublisherType? PublisherType { get; set; }
        int? PropertySubType { get; set; }
        int? NumberOfLevels { get; set; }
        bool? IsActualContractTerminated { get; set; }
        DateTime? ActualContractTerminatedOn { get; set; }
        DateTime? EarliestAvailableDate { get; set; }
        DateTime? LatestAvailableDate { get; set; }

        /// <summary >
        /// When yes we need to hide  <see cref="LatestAvailableDate"/>
        /// </summary>
        bool? IsDateFlexible { get; set; }
        bool? IsCurrentlyRented { get; set; }
        bool? IsAllowedToBeIntroducedByAgent { get; set; }
        string FreeTextAvailableFrom { get; set; }
        string FreeTextPrice { get; set; }
        ICollection<Distance> Distances { get; set; }
        ICollection<Sight> Sights { get; set; }
        string OtherDetails { get; set; }

        /// <summary>
        /// a brief description
        /// </summary>
        string Tercet { get; set; }

        ICollection<ObjectTextInAnotherLanguage> ObjectTextInAnotherLanguages { get; set; }

        /// <summary>
        /// % or fixed price
        /// </summary>
        decimal? InsideCourtage { get; set; }
        decimal? PlotArea { get; set; }

        bool? IsPriceOnDemand { get; set; }
        /// <summary>
        /// if price is on demand then
        /// </summary>
        decimal? OrientationPrice { get; set; } // we dont display it
    }
}