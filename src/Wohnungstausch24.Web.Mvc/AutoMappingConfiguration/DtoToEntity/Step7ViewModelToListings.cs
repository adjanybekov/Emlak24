using AutoMapper;
using Wohnungstausch24.Core.Extensions;
using Wohnungstausch24.Core.TypeMapping;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.Flat.Room;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Flat;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.House;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Land;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7.Room;

namespace Wohnungstausch24.Web.Mvc.AutoMappingConfiguration.DtoToEntity
{
    public class Step7ViewModelToListings : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {

            #region flat


            cfg.CreateMap<Step7FlatForRent, FlatForRent>()
                .ForMember(c => c.PreferredGender, o => o.MapFrom(c => c.PreferredGender))
                .ForMember(c => c.IsPetsAllowed, o => o.MapFrom(c => c.PetsAllowed))
                .ForMember(c => c.MaxNumberOfPersons, o => o.MapFrom(c => c.MaxNumberOfPersons))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.MaxNumberOfChildren, o => o.MapFrom(c => c.MaxNumberOfChildren))
                .ForMember(c => c.HasPositiveRating, o => o.MapFrom(c => c.HasPositiveRating))
                .ForMember(c => c.HasStatementOfLord, o => o.MapFrom(c => c.HasStatementOfLord))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.Duration, o => o.MapFrom(c => c.MinDuration))
                .ForMember(c => c.MaxAgeOfPersons, o => o.MapFrom(c => c.MaxAgeOfPerson))
                .ForMember(c => c.PreferredAgeOfChildren, o => o.MapFrom(c => c.PreferredAgeOfChildren))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step7RoomForRent, RoomForRent>()
                .ForMember(c => c.PreferredGender, o => o.MapFrom(c => c.PreferredGender))
                .ForMember(c => c.IsPetsAllowed, o => o.MapFrom(c => c.PetsAllowed))
                .ForMember(c => c.MaxNumberOfPersons, o => o.MapFrom(c => c.MaxNumberOfPersons))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.MaxNumberOfChildren, o => o.MapFrom(c => c.MaxNumberOfChildren))
                .ForMember(c => c.HasPositiveRating, o => o.MapFrom(c => c.HasPositiveRating))
                .ForMember(c => c.HasStatementOfLord, o => o.MapFrom(c => c.HasStatementOfLord))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.Duration, o => o.MapFrom(c => c.MinDuration))
                .ForMember(c => c.MaxAgeOfPersons, o => o.MapFrom(c => c.MaxAgeOfPerson))
                .ForMember(c => c.PreferredAgeOfChildren, o => o.MapFrom(c => c.PreferredAgeOfChildren))
                .ForAllOtherMembers(c => c.Ignore());

            cfg.CreateMap<Step7FlatForSale, FlatForSale>()
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

            #region House

            cfg.CreateMap<Step7HouseForRent, HouseForRent>()
                .ForMember(c => c.PreferredGender, o => o.MapFrom(c => c.PreferredGender))
                .ForMember(c => c.IsPetsAllowed, o => o.MapFrom(c => c.PetsAllowed))
                .ForMember(c => c.MaxNumberOfPersons, o => o.MapFrom(c => c.MaxNumberOfPersons))
                .ForMember(c => c.IsSmokingAllowed, o => o.MapFrom(c => c.IsSmokingAllowed))
                .ForMember(c => c.EmploymentStatus, o => o.MapFrom(c => c.EmploymentStatus))
                .ForMember(c => c.Income, o => o.MapFrom(c => c.Income))
                .ForMember(c => c.MaxNumberOfChildren, o => o.MapFrom(c => c.MaxNumberOfChildren))
                .ForMember(c => c.HasPositiveRating, o => o.MapFrom(c => c.HasPositiveRating))
                .ForMember(c => c.HasStatementOfLord, o => o.MapFrom(c => c.HasStatementOfLord))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.MaxAgeOfPersons, o => o.MapFrom(c => c.MaxAgeOfPerson))
                .ForMember(c => c.PreferredAgeOfChildren, o => o.MapFrom(c => c.PreferredAgeOfChildren))
                .ForMember(c => c.OtherComments, o => o.MapFrom(c => c.OtherComments))
                .ForMember(c => c.Duration, o => o.MapFrom(c => c.MinDuration))
                .ForAllOtherMembers(c => c.Ignore());


            cfg.CreateMap<Step7HouseForSale, HouseForSale>()
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

            cfg.CreateMap<Step7LandForSale, LandForSale>()
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
                .ForAllOtherMembers(c => c.Ignore());
            #endregion
        }
    }
}