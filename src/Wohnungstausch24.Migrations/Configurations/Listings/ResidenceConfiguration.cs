using System.Data.Entity.ModelConfiguration;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class ResidenceConfiguration<T> : EntityTypeConfiguration<T> where T : Residence
    {
        public ResidenceConfiguration()
        {
            HasMany(c => c.Balconies);
            HasMany(c => c.Bathrooms);
            HasMany(c => c.Beaconings);
            HasMany(c => c.Floors);
            HasMany(c => c.Heatings);
            HasMany(c => c.ParkingSpaces);
            HasMany(c => c.Sights);
            Property(c => c.BasementArea).IsOptional();
            Property(c => c.Clearance).IsOptional();
            Property(c => c.ClearanceText).IsOptional().HasMaxLength(3000);
            Property(c => c.DateOfIssue).IsOptional();
            Property(c => c.EnergyCertificateType).IsOptional();
            Property(c => c.Epart).IsOptional();
            Property(c => c.FurnishType).IsOptional();
            Property(c => c.GardenArea).IsOptional();
            Property(c => c.IsFurnished).IsOptional();
            Property(c => c.LivingArea).IsOptional();
            Property(c => c.NumberOfBathrooms).IsOptional();
            Property(c => c.NumberOfBedrooms).IsOptional();
            Property(c => c.NumberOfLivingBedrooms).IsOptional();
            Property(c => c.NumberOfRooms).IsOptional();
            Property(c => c.NumberOfSeperateToilet).IsOptional();
            Property(c => c.OtherArea).IsOptional();
            Property(c => c.PrimaryEnegySource).IsOptional();
            Property(c => c.TotalArea).IsOptional();
            Property(c => c.UnderGroundType).IsOptional();
            Property(c => c.UsefulArea).IsOptional();
            Property(c => c.UsefulArea);
            Property(c => c.ValidUntil).IsOptional();
            Property(c => c.ConstructionYear).IsOptional();
            Property(c => c.IsConstructionYearProjected).IsOptional();
            Property(c => c.InternetType).IsOptional();
            Property(c => c.SpeedOfInternet).IsOptional();
            Property(c => c.CurrentColdRent).IsOptional();
            Property(c => c.HouseNumber).IsOptional();
            Property(c => c.PropertySubType).IsOptional();
            Property(c => c.EnergyType).IsOptional();
            Property(c => c.RollerBlindType).IsOptional();
            Property(c => c.HasGrannyPart).IsOptional();
            Property(c => c.HasGuestToilet).IsOptional();
        }
    }
}