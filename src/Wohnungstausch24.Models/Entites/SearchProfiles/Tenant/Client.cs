using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Entites.SearchProfiles.Tenant
{
    public class Client:Entity<int>
    {
        public Client()
        {
            this.Persons = new List<Person>();
        }
        public int SearchProfileId { get; set; }
        public virtual SearchProfileListing SearchProfile { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Headline { get; set; }
        public int Age { get; set; }
        public decimal? Income { get; set; }
        public string Profession { get; set; }
        public Gender? Gender { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public virtual List<Person> Persons { get; set; }
        public virtual List<ClientDocument> ClientDocuments { get; set; }
    }


}
