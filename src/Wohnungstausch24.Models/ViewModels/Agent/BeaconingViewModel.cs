using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class BeaconingViewModel
    {
        public int Id { get; set; }
        public BeaconingType BeaconingType { get; set; }
    }
}
