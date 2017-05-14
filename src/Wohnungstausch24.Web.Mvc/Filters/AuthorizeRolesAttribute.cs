using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Wohnungstausch24.Migrations.Security;

namespace Wohnungstausch24.Web.Mvc.Filters
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params RoleDefinitions[] acceptedRoles)
        {
            Roles = string.Join(",", acceptedRoles);
        }
    }
}