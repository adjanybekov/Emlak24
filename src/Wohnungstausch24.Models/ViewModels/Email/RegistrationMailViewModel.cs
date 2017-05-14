using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wohnungstausch24.Models.ViewModels.Email
{
    public class RegistrationMailViewModel
    {
        public string Name { get; set; }
        public string ConfirmationUrl { get; set; }
    }
}
