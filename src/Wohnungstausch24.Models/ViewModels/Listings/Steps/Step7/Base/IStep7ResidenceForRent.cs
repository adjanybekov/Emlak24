using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base
{
    public interface IStep7ResidenceForRent :IStep7Residence, IStep7ListingForRent
    {
        bool IsSmokingAllowed { get; set; }
        bool HasPositiveRating { get; set; }
        bool HasStatementOfLord { get; set; }
        bool PetsAllowed { get; set; }
        string OtherComments { get; set; }

        int MaxAgeOfPerson { get; set; }
        int PreferredAgeOfChildren { get; set; }
        int MinDuration { get; set; }
        int MaxNumberOfPersons { get; set; }
        int MaxNumberOfChildren { get; set; }

        List<EmploymentStatusViewModel> EmploymentStatuses { get; set; }
        Gender? PreferredGender { get; set; }
        int Income { get; set; }
        EmploymentStatus EmploymentStatus { get; set; }
    }
}