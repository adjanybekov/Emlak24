using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.Migrations.Security;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
    public class RedirectController : BaseController
    {
        public ActionResult RedirectForRoles()
        {
            if (User.IsInRole(RoleDefinitions.Admin.ToString()))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return RedirectToAction("Index", "Home", new { area = "Agent" });
        }
    }
}