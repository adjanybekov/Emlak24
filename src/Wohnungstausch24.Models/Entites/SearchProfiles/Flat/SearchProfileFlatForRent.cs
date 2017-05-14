using System.ComponentModel.DataAnnotations.Schema;
using Wohnungstausch24.Core.Models;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Flat
{
    public class SearchProfileFlatForRent :  SearchProfileFlat, ISearchProfileFlatForRent
    {
        public bool? HasHousingPermission { get; set; }
        public bool? IsSmokingAllowed { get; set; }
        public bool? IsPetsAllowed { get; set; }
    }
}
