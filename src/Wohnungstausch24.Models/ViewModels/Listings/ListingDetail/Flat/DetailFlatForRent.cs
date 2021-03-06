﻿using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Flat
{
    public class DetailFlatForRent : DetailFlat, IDetailFlatForRent
    {
        public decimal? Bail { get; set; }
        public string BailText { get; set; }
        public decimal? BasicRent { get; set; }
        public decimal? RentalPricePerSqm { get; set; }
        public decimal? WarmRent { get; set; }
        public bool ForHolidayUse { get; set; }
        public bool ForIndustrialUse { get; set; }
        public decimal? RentSubsidy { get; set; }
    }
}
