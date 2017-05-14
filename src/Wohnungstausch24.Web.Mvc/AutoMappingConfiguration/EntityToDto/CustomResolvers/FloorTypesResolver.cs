using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9.Base;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto.CustomResolvers
{
    public class FloorTypesResolver : IValueResolver<Residence, Step9Residence, List<FloorViewModel>>
    {
        public List<FloorViewModel> Resolve(Residence source, Step9Residence destination, List<FloorViewModel> destMember, ResolutionContext context)
        {
            return Enum.GetValues(typeof(FloorType)).Cast<FloorType>()
                .Select(c => new FloorViewModel
                {
                    FloorType = c,
                    Selected = source.Floors.Any(f=>f.FloorType==c),
                    Id = source.Floors.FirstOrDefault(f => f.FloorType == c)?.Id
                }).ToList();
        }
    }
}