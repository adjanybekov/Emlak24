using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.House
{
    public class Step7HouseForRent : Step7House, IStep7HouseForRent
    {
        [Display(ResourceType = typeof(Resource), Name = "Property_Add_PrefferedGender")]
        public Gender? PreferredGender { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Common_Income")]
        public int Income { get; set; }

        public EmploymentStatus EmploymentStatus { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_Duration")]
        public int MinDuration { get; set; }

        [Display(Name = "Is_Smoking_Allowed", ResourceType = typeof(Resource))]
        public bool IsSmokingAllowed { get; set; }

        [Display(Name = "Has_Positive_Rating", ResourceType = typeof(Resource))]
        public bool HasPositiveRating { get; set; }

        [Display(Name = "Has_Statement_Of_Lord", ResourceType = typeof(Resource))]
        public bool HasStatementOfLord { get; set; }

        [Display(Name = "General_Other_Comments", ResourceType = typeof(Resource))]
        public string OtherComments { get; set; }

        [Display(Name = "Property_Add_MaxAgeOfPerson", ResourceType = typeof(Resource))]
        public int MaxAgeOfPerson { get; set; }

        [Display(Name = "Property_Add_PreferredAgeOfChildren", ResourceType = typeof(Resource))]
        public int PreferredAgeOfChildren { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_MaxNumberOfPersons")]
        public int MaxNumberOfPersons { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_MaxNumberOfChildren")]
        public int MaxNumberOfChildren { get; set; }

        [Display(ResourceType = typeof(Resource), Name = "Property_Add_PetsAllowed")]
        public bool PetsAllowed { get; set; }

        public List<EmploymentStatusViewModel> EmploymentStatuses { get; set; }

    }
}