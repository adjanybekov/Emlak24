using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites
{
    public class Person:Entity<int>
    {
        public EmploymentStatus? EmploymentStatus { get; set; }
        public string Profession { get; set; }
        public decimal? Income { get; set; }
        public Gender? Gender { get; set; }
        public int Age { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
