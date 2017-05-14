using AutoMapper;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Room;
using Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto.CustomResolvers;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.EntityToDto
{
    public class ListingsToStep7 : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            #region flat

            cfg.CreateMap<FlatForRent, Step7FlatForRent>()
                .ForMember(c => c.PreferredGender, o => o.MapFrom(c => c.PreferredGender))
                .ForMember(c => c.PetsAllowed, o => o.MapFrom(c => c.IsPetsAllowed))
                .ForMember(c => c.MaxNumberOfPersons, o => o.MapFrom(c => c.MaxNumberOfPersons))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.MaxNumberOfChildren, o => o.MapFrom(c => c.MaxNumberOfChildren))
                .ForMember(c => c.HasPositiveRating, o => o.MapFrom(c => c.HasPositiveRating))
                .ForMember(c => c.HasStatementOfLord, o => o.MapFrom(c => c.HasStatementOfLord))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.EmploymentStatuses, o => o.ResolveUsing<EmployeeStatusTypeResolver>())
                .ForMember(c => c.MinDuration, o => o.MapFrom(c => c.Duration))
                .ForMember(c => c.MaxAgeOfPerson, o => o.MapFrom(c => c.MaxAgeOfPersons))
                .ForMember(c => c.PreferredAgeOfChildren, o => o.MapFrom(c => c.PreferredAgeOfChildren))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<RoomForRent, Step7RoomForRent>()
                .ForMember(c => c.PreferredGender, o => o.MapFrom(c => c.PreferredGender))
                .ForMember(c => c.PetsAllowed, o => o.MapFrom(c => c.IsPetsAllowed))
                .ForMember(c => c.MaxNumberOfPersons, o => o.MapFrom(c => c.MaxNumberOfPersons))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.MaxNumberOfChildren, o => o.MapFrom(c => c.MaxNumberOfChildren))
                .ForMember(c => c.HasPositiveRating, o => o.MapFrom(c => c.HasPositiveRating))
                .ForMember(c => c.HasStatementOfLord, o => o.MapFrom(c => c.HasStatementOfLord))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.EmploymentStatuses, o => o.ResolveUsing<EmployeeStatusTypeResolver>())
                .ForMember(c => c.MinDuration, o => o.MapFrom(c => c.Duration))
                .ForMember(c => c.MaxAgeOfPerson, o => o.MapFrom(c => c.MaxAgeOfPersons))
                .ForMember(c => c.PreferredAgeOfChildren, o => o.MapFrom(c => c.PreferredAgeOfChildren))
                .ForAllOtherMembers(c => c.Ignore());



            cfg.CreateMap<FlatForSale, Step7FlatForSale>()
                .ForMember(o => o.EnergyCertificateType, o => o.MapFrom(c => c.EnergyCertificateType))
                .ForMember(o => o.Epart, o => o.MapFrom(c => c.Epart))
                .ForMember(o => o.DateOfIssue, o => o.MapFrom(c => c.DateOfIssue))
                .ForMember(o => o.ValidUntil, o => o.MapFrom(c => c.ValidUntil))
                .ForMember(o => o.EnergyConsumptionParameter, o => o.MapFrom(c => c.EnergyConsumptionParameter))
                .ForMember(o => o.IncludedHotWater, o => o.MapFrom(c => c.IncludedHotWater))
                .ForMember(o => o.UltimateEnergyDemand, o => o.MapFrom(c => c.UltimateEnergyDemand))
                .ForMember(o => o.ElectricityValue, o => o.MapFrom(c => c.ElectricityValue))
                .ForMember(o => o.WarmnessValue, o => o.MapFrom(c => c.WarmnessValue))
                .ForMember(o => o.ValueRating, o => o.MapFrom(c => c.ValueRating))
                .ForMember(o => o.AgeGroup, o => o.MapFrom(c => c.AgeGroup))
                .ForMember(o => o.PrimaryEnegySource, o => o.MapFrom(c => c.PrimaryEnegySource))
                .ForMember(o => o.EnergyType, o => o.MapFrom(c => c.EnergyType))
                .ForMember(c => c.WantEnergyCertificate, o => o.MapFrom(c => c.WantEnergyCertificate))
                .ForAllOtherMembers(c => c.Ignore());


            #endregion

            #region house

            cfg.CreateMap<HouseForRent, Step7HouseForRent>()
                .ForMember(c => c.PreferredGender, o => o.MapFrom(c => c.PreferredGender))
                .ForMember(c => c.PetsAllowed, o => o.MapFrom(c => c.IsPetsAllowed))
                .ForMember(c => c.MaxNumberOfPersons, o => o.MapFrom(c => c.MaxNumberOfPersons))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.MaxNumberOfChildren, o => o.MapFrom(c => c.MaxNumberOfChildren))
                .ForMember(c => c.HasPositiveRating, o => o.MapFrom(c => c.HasPositiveRating))
                .ForMember(c => c.HasStatementOfLord, o => o.MapFrom(c => c.HasStatementOfLord))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.EmploymentStatuses, o => o.ResolveUsing<EmployeeStatusTypeResolver>())
                 .ForMember(c => c.MaxAgeOfPerson, o => o.MapFrom(c => c.MaxAgeOfPersons))
                .ForMember(c => c.PreferredAgeOfChildren, o => o.MapFrom(c => c.PreferredAgeOfChildren))
                .ForMember(c => c.MinDuration, o => o.MapFrom(c => c.Duration))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<HouseForSale, Step7HouseForSale>()
               .ForMember(o => o.EnergyCertificateType, o => o.MapFrom(c => c.EnergyCertificateType))
                .ForMember(o => o.Epart, o => o.MapFrom(c => c.Epart))
                .ForMember(o => o.DateOfIssue, o => o.MapFrom(c => c.DateOfIssue))
                .ForMember(o => o.ValidUntil, o => o.MapFrom(c => c.ValidUntil))
                .ForMember(o => o.EnergyConsumptionParameter, o => o.MapFrom(c => c.EnergyConsumptionParameter))
                .ForMember(o => o.IncludedHotWater, o => o.MapFrom(c => c.IncludedHotWater))
                .ForMember(o => o.UltimateEnergyDemand, o => o.MapFrom(c => c.UltimateEnergyDemand))
                .ForMember(o => o.ElectricityValue, o => o.MapFrom(c => c.ElectricityValue))
                .ForMember(o => o.WarmnessValue, o => o.MapFrom(c => c.WarmnessValue))
                .ForMember(o => o.ValueRating, o => o.MapFrom(c => c.ValueRating))
                .ForMember(o => o.AgeGroup, o => o.MapFrom(c => c.AgeGroup))
                .ForMember(o => o.PrimaryEnegySource, o => o.MapFrom(c => c.PrimaryEnegySource))
                .ForMember(o => o.EnergyType, o => o.MapFrom(c => c.EnergyType))
                .ForMember(c => c.WantEnergyCertificate, o => o.MapFrom(c => c.WantEnergyCertificate))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion

            #region Land

            cfg.CreateMap<LandForSale, Step7LandForSale>()
                 .ForMember(o => o.AllotmentType, o => o.MapFrom(c => c.AllotmentType))
                .ForMember(o => o.BuldingBank, o => o.MapFrom(c => c.BuldingBank))
                .ForMember(o => o.BuildingType, o => o.MapFrom(c => c.BuildingType))
                .ForMember(o => o.ExploitationNum, o => o.MapFrom(c => c.ExploitationNum))
                .ForMember(o => o.ExploitationDenum, o => o.MapFrom(c => c.ExploitationDenum))
                .ForMember(o => o.GRZ, o => o.MapFrom(c => c.GRZ))
                .ForMember(o => o.GFZ, o => o.MapFrom(c => c.GFZ))
                .ForMember(o => o.ZoneOfConstruction, o => o.MapFrom(c => c.ZoneOfConstruction))
                .ForMember(o => o.ContaminatedSites, o => o.MapFrom(c => c.ContaminatedSites))
                .ForMember(o => o.Gaz, o => o.MapFrom(c => c.Gaz))
                .ForMember(o => o.Water, o => o.MapFrom(c => c.Water))
                .ForMember(o => o.Electricity, o => o.MapFrom(c => c.Electricity))
                .ForMember(o => o.TK, o => o.MapFrom(c => c.TK))
                .ForMember(o => o.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForMember(o => o.NumberOfLevels, o => o.MapFrom(c => c.NumberOfLevels))
                .ForAllOtherMembers(c => c.Ignore());

            #endregion
        }
    }
}