using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.ViewModels.Agent.Settings
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public string Profession { get; set; }
        public decimal? Income { get; set; }
        public Gender? Gender { get; set; }
        public int Age { get; set; }
    }
}