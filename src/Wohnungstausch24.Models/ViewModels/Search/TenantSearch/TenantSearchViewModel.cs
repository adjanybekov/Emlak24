using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.ViewModels.Search.TenantSearch
{
    public class TenantSearchViewModel:SearchModelBase
    {
        public TenantSearchViewModel()
        {

            this.EmploymentStatusViewModel =
                Enum.GetValues(typeof(EmploymentStatus))
                    .Cast<EmploymentStatus>()
                    .Select(c => new EmploymentStatusViewModel { EmploymentStatus = c, Selected = false })
                    .ToList();
        }
        [Display(ResourceType = typeof(Resource), Name = "TenantSearch_PetsAllowed")]
        public bool PetsAreAllowed { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Is_Smoking_Allowed")]
        public bool IsSmokingAllowed { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "EmploymentStatus")]
        public List<EmploymentStatusViewModel> EmploymentStatusViewModel { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "MinIncome")]
        public int MinIncome { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "MaxNumberOfMembers")]
        public int? MaxNumberOfMembers { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Ranged_ResidentialArea")]
        public decimal? LivingArea { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Ranged_NumberOfLivingRooms")]
        public int? NumberOfLivingRooms { get; set; }
        [Display(ResourceType = typeof(Resource), Name = "Price")]
        public int? Price { get; set; }
    }
}
