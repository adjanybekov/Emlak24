using System.ComponentModel.DataAnnotations.Schema;

namespace Wohnungstausch24.Core.Models
{
    public abstract class Ranged<T>
    {
        public T From { get; set; }
        public T To { get; set; }
        public T Max { get; set; }
        public T Min { get; set; }
        public string Range { get; set; }
        public abstract bool IsMaxSelected { get;}
        public abstract bool IsMinSelected { get; }
    }
}