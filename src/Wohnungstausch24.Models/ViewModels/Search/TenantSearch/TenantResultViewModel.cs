using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Entites;

namespace Wohnungstausch24.Models.ViewModels.Search.TenantSearch
{
    public class TenantResultViewModel
    {
        public ClientViewModel ClientViewModel { get; set; }
        public decimal? TotalIncome { get; set; }
    }
}
