using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites
{
    public class Qualification:Entity<int>
    {

        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }

        public QualificationType QualificationType { get; set; }
    }
}
