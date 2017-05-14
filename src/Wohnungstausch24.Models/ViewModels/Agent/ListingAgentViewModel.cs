using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class ListingAgentViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Facebook { get; set; }

        public string GooglePlus { get; set; }

        public string Linkedin { get; set; }

        public string Twitter { get; set; }

        public string Email { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public bool? ApprovalOfAddress { get; set; }
        public int ListingsCount { get; set; }
        public string UserId { get; set; }
        public string AgencyName { get; set; }
        public string Avatar { get; set; }
        public string CompanyLogo { get; set; }
    }
}
