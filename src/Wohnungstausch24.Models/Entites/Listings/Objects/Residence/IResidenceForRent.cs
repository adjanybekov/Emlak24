using System.Collections.Generic;
using System.Net.Mime;
using Newtonsoft.Json;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public interface IResidenceForRent:IResidence,IListingForRent
    {
        decimal? Bail { get; set; }
        string BailText { get; set; }
        decimal? BasicRent { get; set; }
        decimal? RentalPricePerSqm { get; set; }
        decimal? WarmRent { get; set; }
        int? MaxNumberOfPersons { get; set; }
        int? MaxNumberOfChildren { get; set; }
        int? Income { get; set; }
        bool? IsSmokingAllowed { get; set; }
        bool? IsPetsAllowed { get; set; }
        Gender? PreferredGender { get; set; }
        int? MinIncome { get; set; }
        List<EmploymentStatus> EmploymentStatuses { get;set; }
        EmploymentStatus? EmploymentStatus { get;set; }
        bool? SpeakToOwner { get; set; }
        bool? ForIndustrialUse { get; set; }
        bool? ForHolidayUse { get; set; }
        bool? HasPositiveRating { get; set; }
        bool? HasStatementOfLord { get; set; }
        decimal? RentSubsidy { get; set; }
        string OtherComments{ get; set; }
        bool? AllInRent{ get; set; }
        bool? HasHousingPermission { get; set; }
        decimal? AllInRentPrice{ get; set; }
        int? Duration{ get; set; }
        int? PreferredAgeOfChildren { get; set; }
        int? MaxAgeOfPersons { get; set; }
    }
}