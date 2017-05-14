using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.ViewModels.Location;

namespace Wohnungstausch24.Models.ViewModels.Search.DetailedSearch.Base
{
    public interface IDetailedSearchListing
    {
        DateTime? AvailableFrom { get; set; }
        DateTime? AvailableTo { get; set; }
        RangedDecimal PriceRange { get; set; }
        string Name { get; set; }
        int Id { get; set; }
        List<string> SelectedAllLocations { get; set; }
    }
}