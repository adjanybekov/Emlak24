using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Flat
{
    public class DetailFlat : DetailResidence, IDetailFlat
    {
        [Display(Name = "Level", ResourceType = typeof(Resource))]
        public int Level { get; set; }
        [Display(Name = "Property_Detail_Num_Of_Apartment_Units", ResourceType = typeof(Resource))]
        public int NumberOfApartmentUnits { get; set; }
        [Display(Name = "Flat_Type", ResourceType = typeof(Resource))]
        public FlatType? FlatType
        {
            get
            {
                var propertySubType = this.PropertySubType;
                if (propertySubType != null)
                {
                    var type = (FlatType)propertySubType;
                    return type;
                }
                return null;
            }
        }
    }
}