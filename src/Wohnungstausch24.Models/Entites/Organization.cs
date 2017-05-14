using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class Organization:Entity<int>
    {
        public OrganizationType Type { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}