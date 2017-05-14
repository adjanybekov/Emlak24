using System;

namespace Wohnungstausch24.Models.Entites.Base
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTime CreatedOnUTC { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOnUTC { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime? DeletedOnUTC { get; set; }
        public string DeletedBy { get; set; }
    }
}
