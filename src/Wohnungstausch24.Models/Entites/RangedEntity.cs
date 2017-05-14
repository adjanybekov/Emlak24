using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Models.Entites
{
    public abstract class RangedEntity<T>
    {
        public T From { get; set; }
        public T To { get; set; }
        public T Max { get; set; }
        public T Min { get; set; }
    }

    public class RangedIntEntityNullable: RangedEntity<int?>
    {
    }
    public class RangedDecimalEntityNullable: RangedEntity<decimal?>
    {
    }
}
