using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class Emphasis:Entity<int>
    {
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public EmphasisType EmphasisType { get; set; }
    }
}