using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites.Listings.Objects.Residence
{
    public class EmployeeStatusObject
    {
        public int? Id { get; set; }
        public bool Selected { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }

    }
}
