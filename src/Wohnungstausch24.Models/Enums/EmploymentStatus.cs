using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum EmploymentStatus
    {
        [Display(Name = "EmploymentStatus_Employee", ResourceType = typeof(Resource))]
        Employee=1,

        [Display(Name = "EmploymentStatus_SelfEmployed", ResourceType = typeof(Resource))]
        SelfEmployed=2,

        [Display(Name = "EmploymentStatus_Unemployed", ResourceType = typeof(Resource))]
        Unemployed=3,

        [Display(Name = "EmploymentStatus_Student", ResourceType = typeof(Resource))]
        Student = 4,

        [Display(Name = "EmploymentStatus_Retired", ResourceType = typeof(Resource))]
        Retired = 5,

        [Display(Name = "EmploymentStatus_Pensioneer", ResourceType = typeof(Resource))]
        Pensioneer = 6
    }
}