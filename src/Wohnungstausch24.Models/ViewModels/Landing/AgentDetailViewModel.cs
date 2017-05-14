using System.Collections.Generic;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Models.ViewModels.Landing
{
    public class AgentDetailViewModel
    {
        public PositionInCompany? PositionInCompany { get; set; }
        public FieldOfResponsibility? FieldOfResponsibility { get; set; }
        public ICollection<Language> Languages { get; set; }
        public string Education { get; set; }
        public AgencyBranch Branch { get; set; }
        public string AgencyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string About { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
    }
}
