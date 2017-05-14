using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class PersonsViewModel
    {
        public List<PersonViewModel> Persons{ get; set; }
        public int ClientId { get; set; }

    }
}
