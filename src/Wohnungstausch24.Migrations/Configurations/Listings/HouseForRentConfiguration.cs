using System.Data.Entity.ModelConfiguration;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence.House;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class HouseForRentConfiguration : HouseConfiguration<HouseForRent>
    {
        public HouseForRentConfiguration()
        {
            Property(c => c.AcceptBailLetter).HasColumnName(nameof(IListingForRent.AcceptBailLetter)).IsOptional();
            Property(c => c.AdditionalCosts).HasColumnName(nameof(IResidenceForRent.AdditionalCosts));
            Property(c => c.AllInRent).HasColumnName(nameof(IResidenceForRent.AllInRent)).IsOptional();
            Property(c => c.AllInRentPrice).HasColumnName(nameof(IResidenceForRent.AllInRentPrice)).IsOptional();
            Property(c => c.Bail).HasColumnName(nameof(IResidenceForRent.Bail));
            Property(c => c.BailText).HasColumnName(nameof(IResidenceForRent.BailText));
            Property(c => c.BasicRent).HasColumnName(nameof(IResidenceForRent.BasicRent));
            Property(c => c.CurrentColdRent).IsOptional().HasColumnName(nameof(IResidenceForRent.CurrentColdRent));
            Property(c => c.Duration).HasColumnName(nameof(IHouseForRent.Duration)).IsOptional();
            Property(c => c.Duration).HasColumnName(nameof(IResidenceForRent.Duration)).IsOptional();
            Property(c => c.EmploymentStatus).HasColumnName(nameof(IResidenceForRent.EmploymentStatus)).IsOptional();
            Property(c => c.ForHolidayUse).HasColumnName(nameof(IResidenceForRent.ForHolidayUse)).IsOptional();
            Property(c => c.ForIndustrialUse).HasColumnName(nameof(IResidenceForRent.ForIndustrialUse)).IsOptional();
            Property(c => c.FreeTextPrice).HasColumnName(nameof(IResidenceForRent.FreeTextPrice));
            Property(c => c.HasHousingPermission).HasColumnName(nameof(IResidenceForRent.HasHousingPermission)).IsOptional();
            Property(c => c.HasPositiveRating).HasColumnName(nameof(IResidenceForRent.HasPositiveRating)).IsOptional();
            Property(c => c.HasStatementOfLord).HasColumnName(nameof(IResidenceForRent.HasStatementOfLord)).IsOptional();
            Property(c => c.HeatingCosts).HasColumnName(nameof(IResidenceForRent.HeatingCosts));
            Property(c => c.Income).HasColumnName(nameof(IResidenceForRent.Income)).IsOptional();
            Property(c => c.IsHeatingCostsIncluded).HasColumnName(nameof(IResidenceForRent.IsHeatingCostsIncluded));
            Property(c => c.IsPetsAllowed).HasColumnName(nameof(IResidenceForRent.IsPetsAllowed));
            Property(c => c.IsRentedOut).HasColumnName(nameof(IForRent.IsRentedOut)).IsOptional();
            Property(c => c.IsSmokingAllowed).HasColumnName(nameof(IResidenceForRent.IsSmokingAllowed));
            Property(c => c.MaxAgeOfPersons).HasColumnName(nameof(IResidenceForRent.MaxAgeOfPersons));
            Property(c => c.MaxNumberOfChildren).HasColumnName(nameof(IResidenceForRent.MaxNumberOfChildren)).IsOptional();
            Property(c => c.MaxNumberOfPersons).HasColumnName(nameof(IResidenceForRent.MaxNumberOfPersons));
            Property(c => c.MinIncome).HasColumnName(nameof(IResidenceForRent.MinIncome));
            Property(c => c.OtherComments).HasColumnName(nameof(IResidenceForRent.OtherComments)).IsOptional();
            Property(c => c.PreferredAgeOfChildren).HasColumnName(nameof(IResidenceForRent.PreferredAgeOfChildren));
            Property(c => c.PreferredGender).HasColumnName(nameof(IResidenceForRent.PreferredGender));
            Property(c => c.RentalPricePerSqm).HasColumnName(nameof(IResidenceForRent.RentalPricePerSqm));
            Property(c => c.RentSubsidy).HasColumnName(nameof(IResidenceForRent.RentSubsidy)).IsOptional();
            Property(c => c.SpeakToOwner).HasColumnName(nameof(IResidenceForRent.SpeakToOwner)).IsOptional();
            Property(c => c.WarmRent).HasColumnName(nameof(IResidenceForRent.WarmRent));
        }
    }
}