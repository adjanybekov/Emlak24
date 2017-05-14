using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.AspNet.Identity.EntityFramework;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Entites.Base;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.Listings.Objects.Residence;
using Wohnungstausch24.Models.Entites.Locations;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;

namespace Wohnungstausch24.Migrations
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<AgencyBranch> AgencyBranches { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<LocationLevel1> LocationLevel1 { get; set; }
        public virtual DbSet<LocationLevel2> LocationLevel2 { get; set; }
        public virtual DbSet<LocationLevel3> LocationLevel3 { get; set; }
        public virtual DbSet<Balcony> Balconies { get; set; }
        public virtual DbSet<ParkingSpace> ParkingSpaces{ get; set; }
        public virtual DbSet<Sight> Sights { get; set; }
        public virtual DbSet<Distance> Distances { get; set; }
        public virtual DbSet<Heating> Heatings { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Bathroom> Bathrooms { get; set; }
        public virtual DbSet<Beaconing> Beaconings { get; set; }
        public virtual DbSet<Emphasis> Emphases { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<ObjectTextInAnotherLanguage> ObjectTextInAnotherLanguages { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Qualification> Qualifications{ get; set; }
        public virtual DbSet<Wt24File> Files { get; set; }
        public virtual DbSet<ListingFile> ListingFiles { get; set; }
        public virtual DbSet<EmployeeStatusObject> EmployeeStatuses { get; set; }
        public virtual DbSet<MixedLand> MixedLands { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SearchProfileListing> SearchProfiles  { get; set; }
        public virtual DbSet<Client> Clients  { get; set; }
        public virtual DbSet<ClientDocument> ClientDocuments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Add<IdKeyDiscoveryConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedOnUTC = now;

                        this.Entry(entity).Property(x => x.DeletedBy).IsModified = false;
                        this.Entry(entity).Property(x => x.DeletedOnUTC).IsModified = false;
                    }
                    entity.UpdatedBy = identityName;
                    entity.UpdatedOnUTC = now;
                }
            }
            return base.SaveChanges();
        }
    }
}
