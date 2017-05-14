using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Wohnungstausch24.Models.Entites.Listings;
using Wohnungstausch24.Models.Entites.SearchProfiles.Base;
using Wohnungstausch24.Models.Enums;

namespace Wohnungstausch24.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Gender? Gender { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(1000)]
        public string About { get; set; }

        [StringLength(200)]
        public string Facebook { get; set; }

        [StringLength(200)]
        public string Twitter { get; set; }

        [StringLength(200)]
        public string Linkedin { get; set; }

        [StringLength(50)]
        public string PhoneNumber2 { get; set; }

        [StringLength(100)]
        public string Skype { get; set; }

        [StringLength(200)]
        public string GooglePlus { get; set; }

        public string Title { get; set; }
        public string SalutationMessage { get; set; }

        public string AddressAddOn { get; set; }
        public string EmailPrivate { get; set; }
        public string EmailOther { get; set; }
        public string EmailFeedBack { get; set; }
        public bool ShowContactInformation { get; set; }
        public int ListingLimit { get; set; }
        public string PhoneDirectAccess { get; set; }
        public string PhoneFax { get; set; }
        public string PhonePrivate { get; set; }
        public string OtherPhone { get; set; }
        public string Url { get; set; }
        public string FreeTextArray { get; set; }
        public bool? ApprovalOfAddress { get; set; }
        public SalutationType? SalutationType { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<UserFile> UserFiles { get; set; }
        public int? AvatarId { get; set; }
        public virtual Wt24File Avatar { get; set; }
        public virtual List<SearchProfileListing> SearchProfiles { get; set; }
    }
}