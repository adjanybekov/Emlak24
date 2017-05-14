using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat
{
    public class FlatForRent : Flat, IFlatForRent
    {
        public decimal? Bail { get; set; }
        public string BailText { get; set; }
        public decimal? BasicRent { get; set; }
        public decimal? RentalPricePerSqm { get; set; }
        public decimal? WarmRent { get; set; }
        public int? MaxNumberOfPersons { get; set; }
        public bool? IsSmokingAllowed { get; set; }
        public bool? IsPetsAllowed { get; set; }
        public Gender? PreferredGender { get; set; }
        public int? MinIncome { get; set; }
        public List<EmploymentStatus> EmploymentStatuses { get; set; }
        public bool? SpeakToOwner { get; set; }
        public bool? IsRentedOut { get; set; }
        public bool? AcceptBailLetter { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public int? Income { get; set; }
        public int? MaxNumberOfChildren { get; set; }
        public bool? ForIndustrialUse { get; set; }
        public bool? ForHolidayUse { get; set; }
        public decimal? RentSubsidy { get; set; }
        public bool? HasPositiveRating { get; set; }
        public bool? HasStatementOfLord { get; set; }
        public string OtherComments { get; set; }
        public bool? AllInRent { get; set; }
        public decimal? AllInRentPrice { get; set; }
        public bool? HasHousingPermission { get; set; }
        public int? Duration { get; set; }
        public int? PreferredAgeOfChildren { get; set; }
        public int? MaxAgeOfPersons { get; set; }
    }
}