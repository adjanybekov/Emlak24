using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base
{
    public class EmploymentStatusViewModel
    {
        public int? Id { get; set; }
        public bool Selected { get; set; }
        public EmploymentStatus EmploymentStatus{ get; set; }
    }
}
