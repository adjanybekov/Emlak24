using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class AgencyBranch:Entity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }
        public string Address { get; set; }
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
    }
}