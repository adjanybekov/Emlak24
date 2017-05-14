using Wohnungstausch24.Models.Entites.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class UserFile:Entity<int>
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int FileId { get; set; }
        public virtual Wt24File File { get; set; }

        public TenantFileType TenantFileType { get; set; }
    }
}