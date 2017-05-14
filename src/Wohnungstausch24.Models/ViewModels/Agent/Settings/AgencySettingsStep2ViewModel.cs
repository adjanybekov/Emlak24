using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class AgencySettingsStep2ViewModel:AgentSettingsBase
    {
        public int YearOfEstablishment { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "General_Description")]
        public string About { get; set; }

        public AddBranchModel AddBranchModel { get; set; }
        public int Id { get; set; }

        public List<EmphasisViewModel> Emphases { get; set; }
        public List<OrganizationViewModel> Organizations { get; set; }
        public string OrganizationOther { get; set; }
    }

    public class OrganizationViewModel
    {
        public OrganizationType OrganizationType { get; set; }
        public bool Selected { get; set; }
    }

    public class EmphasisViewModel
    {
        public bool Selected { get; set; }
        public EmphasisType EmphasisType { get; set; }
    }

    public class AddBranchModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}
