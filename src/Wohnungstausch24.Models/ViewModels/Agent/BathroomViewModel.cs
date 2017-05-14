using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class BathroomViewModel
    {
        public int Id { get; set; }

        public int Size { get; set; }
        public bool HasShower { get; set; }
        public bool HasTub { get; set; }
        public bool HasWindow { get; set; }
        public bool HasUrinal { get; set; }
        public bool HasBidet { get; set; }
    }
}
