using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites
{
    public class ClientDocument : Entity<int>
    {
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int FileId { get; set; }
        public virtual Wt24File File { get; set; }

        public ClientDocumentType DocumentType { get; set; }
    }

}
