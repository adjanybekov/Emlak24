using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class AgentSettingsSocialViewModel : AgentSettingsBase
    {
        [Display(ResourceType = typeof(Resource), Name = "Facebook")]
        public string Facebook { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Twitter")]
        public string Twitter { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Linkedin")]
        public string Linkedin { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "GooglePlus")]
        public string GooglePlus { get; set; }
    }
}