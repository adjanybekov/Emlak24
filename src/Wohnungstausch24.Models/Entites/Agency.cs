using System.Collections.Generic;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites
{
    public class Agency:Entity<int>
    {
        public Agency()
        {
            this.Agents = new HashSet<Agent>();
            this.AgencyBranches = new HashSet<AgencyBranch>();
            this.EmphasisList = new HashSet<Emphasis>();
            this.Organizations = new HashSet<Organization>();
        }
        public string Name { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string FaxNumber { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }

        public string ManagerId { get; set; }

        public string GooglePlus { get; set; }
        public string Email { get; set; }
        public int? YearOfEstablishment { get; set; }
        public  BusinessType BusinessType { get; set; }
        public virtual ApplicationUser Manager { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<AgencyBranch> AgencyBranches { get; set; }
        public virtual ICollection<Emphasis> EmphasisList { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public string OrganizationOther { get; set; }
        public int? Locationlevel3Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public int? LogoId { get; set; }
        public Wt24File Logo { get; set; }
    }
}
