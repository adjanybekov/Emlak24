using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;

namespace Wohnungstausch24.Migrations.Configurations.SearchProfiles
{
    public class SearchProfileResidenceConfiguration: CustomEntityTypeConfiguration<SearchProfileResidence>
    {
        public SearchProfileResidenceConfiguration()
        {
            HasMany(c => c.SelectedFeatureCategories).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedFloors).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedHeatings).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedBeaconings).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedParkSpaces).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.GeoDirection).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedSights).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedEnergies).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
            HasMany(c => c.SelectedRollerBlinds).WithRequired(c => c.SpResidence).HasForeignKey(c => c.SpResidenceId);
        }
    }
}