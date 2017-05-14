using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Models.Images
{
    public class DeleteResponse
    {
        public DeleteResponse()
        {
            this.files = new Dictionary<string, bool>();
        }
        public Dictionary<string, bool> files { get; set; }
    }
}
