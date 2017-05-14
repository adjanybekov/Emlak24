using System;
using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.Images;

namespace Wohnungstausch24.Models.ViewModels
{
    public class SummaryViewModel 
    {
        public SummaryViewModel()
        {
            Files = new List<FileDto>();
        }

        public DateTime CreatedOnUtc;
        public string ListingHeader { get; set; }
        public string Description { set; get; }
        public TypeOfMerchandising? TypeOfMerchandising { get; set; }
        public TypeOfUse? TypeOfUse { get; set; }
        public ListingStatus? ListingStatus { get; set; }
        public PropertyType? PropertyType { get; set; }
        public int? TotalArea { get; set; }
        public int? Price { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Street { get; set; }
        public string LocationLevel1 { get; set; }
        public string LocationLevel2 { get; set; }
        public string LocationLevel3 { get; set; }
        public string Country { get; set; }
        public int Id { get; set; }
        public List<FileDto> Files { get; set; }
        public string Owner { get; set; }
    }
}
