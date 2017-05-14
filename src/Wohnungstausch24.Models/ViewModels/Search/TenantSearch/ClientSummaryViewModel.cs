using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Core.Models;

namespace Wohnungstausch24.Models.ViewModels.Search.TenantSearch
{
    public class ClientSummaryViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int  ClientId { get; set; }
        public string  UserId { get; set; }
        public string Headline { get; set; }
        public decimal? Income { get; set; }
        public string About { get; set; }
        public decimal? AreaTo { get; set; }
        public decimal? AreaFrom { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? NumberOfLivingRoomsFrom { get; set; }
        public int? NumberOfLivingRoomsTo { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
    }
}
