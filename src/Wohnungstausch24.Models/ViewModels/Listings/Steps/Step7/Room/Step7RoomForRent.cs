using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Room
{
    public class Step7RoomForRent: Step7Room, IStep7RoomForRent
    {
        public bool IsSmokingAllowed { get; set; }
        public bool HasPositiveRating { get; set; }
        public bool HasStatementOfLord { get; set; }
        public bool PetsAllowed { get; set; }
        public string OtherComments { get; set; }
        public int MaxAgeOfPerson { get; set; }
        public int PreferredAgeOfChildren { get; set; }
        public int MinDuration { get; set; }
        public int MaxNumberOfPersons { get; set; }
        public int MaxNumberOfChildren { get; set; }
        public List<EmploymentStatusViewModel> EmploymentStatuses { get; set; }
        public Gender? PreferredGender { get; set; }
        public int Income { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
    }
}