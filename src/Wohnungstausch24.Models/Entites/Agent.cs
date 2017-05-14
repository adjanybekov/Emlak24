using System;
using System.Collections.Generic;
using System.Linq;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;

namespace Wohnungstausch24.Models.Entites
{
    public class Agent : Entity<int>
    {
        public Agent()
        {
            Languages = new HashSet<Language>();
            Qualifications = new HashSet<Qualification>();
        }

        public string Education { get; set; }

        public PositionInCompany? PositionInCompany { get; set; }

        public FieldOfResponsibility? FieldOfResponsibility { get; set; }

        public int? AgencyId { get; set; }
        public virtual Agency Agency { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }


        public int? BranchId { get; set; }
        public virtual AgencyBranch Branch { get; set; }

        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Qualification> Qualifications { get; set; }
    }
}