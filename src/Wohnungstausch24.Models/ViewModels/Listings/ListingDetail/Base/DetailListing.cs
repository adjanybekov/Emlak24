using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.Images;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base
{
    public class DetailListing :DetailViewModelBase, IDetailListing
    {
        public DetailListing()
        {
            this.ContactAgentModel = new ContactAgentModel();
        }
        public DateTime CreatedOnUtc { get; set; }
        public List<FileDto> Files { get; set; }
        public List<DistanceToViewModel> Distances { get; set; }
        public string FreeTextPrice { get; set; }
        public ListingAgentViewModel AgentViewModel { get; set; }
        public string ListingHeader { get; set; }
        public string Description { get; set; }
        public TypeOfMerchandising? TypeOfMerchandising { get; set; }
        public TypeOfUse? TypeOfUse { get; set; }
        public ListingStatus? ListingStatus { get; set; }
        [Display(Name = "PropertyType", ResourceType = typeof(Resource))]
        public PropertyType? PropertyType { get; set; }
        [Display(Name = "Property_Add_TotalArea", ResourceType = typeof(Resource))]
        public int? TotalArea { get; set; }
        public int? Price { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public string LocationLevel1 { get; set; }
        public string LocationLevel2 { get; set; }
        public string LocationLevel3 { get; set; }
        public string Country { get; set; }
        public int Id { get; set; }
        public string FullAddress => $"{(IsAddressPublic ? (HouseNo + "," + Street +",") : "")}{LocationLevel3},{LocationLevel2},{LocationLevel1}";
        public string LocationDescription { get; set; }
        public string EnvironmentDescription { get; set; }
        public bool? IsActualContractTerminated { get; set; }
        public DateTime? ActualContractTerminatedOn { get; set; }
        [Display(Name = "Property_Add_Earliest_Date", ResourceType = typeof(Resource))]
        public DateTime? EarliestAvailableDate { get; set; }
        [Display(Name = "Property_Add_Latest_Date", ResourceType = typeof(Resource))]
        public DateTime? LatestAvailableDate { get; set; }

        public PublisherType? PublisherType { get; set; }
        public int? PropertySubType { get; set; }
        public List<TextInAnotherLanguageViewModel> ObjectTextInAnotherLanguages { get; set; }
        [Display(Name = "Property_Detail_PlotArea", ResourceType = typeof(Resource))]
        public decimal? PlotArea { get; set; }
        public string OtherDetails { get; set; }
        public ContactAgentModel ContactAgentModel { get; set; }
        public bool IsAddressPublic { get; set; }
    }
}