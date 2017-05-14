using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public class Listing:AuditableEntity<int>, IListing
    {
        public bool? IsPriceOnDemand { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string ListingHeader { get; set; }
        public string Description { set; get; }
        public int? TotalArea { get; set; }
        public decimal? InsideCourtage { get; set; }
        public int? Price { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int? Locationlevel3 { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public bool? ShowFullAddressInPublic { get; set; }
        public TypeOfUse? TypeOfUse { get; set; }
        public ListingStatus? ListingStatus { get; set; }
        public string EnvironmentDescription { get; set; }
        public string LocationDescription { get; set; }
        public virtual ICollection<ListingFile> Files { get; set; }
        public PublisherType? PublisherType { get; set; }
        public int? PropertySubType { get; set; }
        public int? NumberOfLevels { get; set; }
        public bool? IsActualContractTerminated { get; set; }
        public DateTime? ActualContractTerminatedOn { get; set; }
        public DateTime? EarliestAvailableDate { get; set; }
        public DateTime? LatestAvailableDate { get; set; }
        /// <summary>
        /// Specifies if moving out or moving in date is flexible.
        /// </summary>
        public bool? IsDateFlexible { get; set; }
        public bool? IsCurrentlyRented { get; set; }
        public bool? IsAllowedToBeIntroducedByAgent { get; set; }
        public string FreeTextAvailableFrom { get; set; }
        public string FreeTextPrice { get; set; }
        public virtual ICollection<Distance> Distances { get; set; }
        public virtual ICollection<Sight> Sights { get; set; }
        public string OtherDetails { get; set; }
        public string Tercet { get; set; }
        public string SubUrbLeft { get; set; }
        public virtual ICollection<ObjectTextInAnotherLanguage> ObjectTextInAnotherLanguages { get; set; }
        public decimal? PlotArea { get; set; }
        public decimal? OrientationPrice { get; set; }
    }
}
