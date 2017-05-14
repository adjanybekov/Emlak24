using System.Web.Mvc;
using Wohnungstausch24.Core;

namespace Wohnungstausch24.Web.Mvc.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "{culture}/Admin/{controller}/{action}/{id}",
                new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}