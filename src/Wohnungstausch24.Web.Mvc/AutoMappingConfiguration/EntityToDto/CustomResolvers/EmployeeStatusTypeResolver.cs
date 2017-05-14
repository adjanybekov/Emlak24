using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto.CustomResolvers
{
    public class EmployeeStatusTypeResolver : IValueResolver<Residence, Step7Residence, List<EmploymentStatusViewModel>>
    {
        public List<EmploymentStatusViewModel> Resolve(Residence source, Step7Residence destination, List<EmploymentStatusViewModel> destMember, ResolutionContext context)
        {
            return Enum.GetValues(typeof(EmploymentStatus)).Cast<EmploymentStatus>()
                .Select(c => new EmploymentStatusViewModel
                {
                    EmploymentStatus = c,
                    Selected = source.EmployeeStatuses.Any(f => f.EmploymentStatus == c),
                    Id = source.EmployeeStatuses.FirstOrDefault(f => f.EmploymentStatus == c)?.Id
                }).ToList();
        }
    }
}