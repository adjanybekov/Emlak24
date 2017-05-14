using System.Data.Entity.ModelConfiguration;
using Wohnungstausch24.Migrations.Configurations.Base;
using Wohnungstausch24.Models.Entites.Listings.Objects;

namespace Wohnungstausch24.Migrations.Configurations.Listings
{
    public class LandConfiguration<T>:EntityTypeConfiguration<T> where T : Land 
    {

    }
}