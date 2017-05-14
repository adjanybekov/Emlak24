using System;
using System.Collections.Generic;
using Wohnungstausch24.Core.Models;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Base
{
    public interface ISearchProfileListing:IEntityBase<int>
    {
        string Title { get; set; }
        DateTime? AvailableFrom { get; set; }
        DateTime? AvailableTo { get; set; }
        RangedDecimalEntityNullable PriceRange { get; set; }
        string UserId { get; set; }
        ApplicationUser User { get; set; }
        List<Client> Clients { get; set; }
        List<SpLocation> Locations { get; set; }
    }
}