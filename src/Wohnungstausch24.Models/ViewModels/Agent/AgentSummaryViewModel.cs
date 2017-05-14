using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.ViewModels.Listings;

namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class AgentSummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string FullName => Name + " " + LastName;
        public string Email { get; set; }
        public string About { get; set; }
        public FieldOfResponsibility? FieldOfResponsibility { get; set; }
        public string AgencyName { get; set; }
        public string UserId { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}