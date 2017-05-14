using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class MixedLandViewModel
    {
        public int Id { get; set; }
        public TypeOfUse? TypeOfUse { get; set; }
        public decimal? TotalArea{ get; set; }
        public decimal? PlotArea{ get; set; }
        public decimal? SeparableFrom{ get; set; }
    }
}
