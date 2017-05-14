using System;

namespace Wohnungstausch24.Models.Entites.Base
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUTC { get; set; }
        string CreatedBy { get; set; }

        DateTime? UpdatedOnUTC { get; set; }
        string UpdatedBy { get; set; }

        DateTime? DeletedOnUTC { get; set; }
        string DeletedBy { get; set; }
    }
}
