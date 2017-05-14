using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Wohnungstausch24.Core;

namespace Wohnungstausch24.Web.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new
                {
                    culture = CultureHelper.GetDefaultCulture(),
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }, 
                namespaces: new[] { "Wohnungstausch24.Web.Mvc.Controllers" }
            );
        }
    }
}
