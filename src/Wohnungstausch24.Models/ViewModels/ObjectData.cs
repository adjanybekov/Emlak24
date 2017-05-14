using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels
{
    public class ObjectData
    {
        public int id;
        public string detailUrl;
        public string address { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public string area { get; set; }
        public string bedrooms { get; set; }
        public string price { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
