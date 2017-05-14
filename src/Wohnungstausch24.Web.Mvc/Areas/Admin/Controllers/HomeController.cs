using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Security;
using Wohnungstausch24.Web.Mvc.Filters;

namespace Wohnungstausch24.Web.Mvc.Areas.Admin.Controllers
{
    [AuthorizeRoles(RoleDefinitions.Admin)]
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}