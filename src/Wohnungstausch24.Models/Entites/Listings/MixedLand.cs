using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings
{
    public class MixedLand : Entity<int>
    {
        public int LandId { get; set; }
        public virtual LandForSale LandForSale { get; set; }
        public TypeOfUse? TypeOfUse { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? PlotArea { get; set; }
        public decimal? SeparableFrom { get; set; }
    }
}
