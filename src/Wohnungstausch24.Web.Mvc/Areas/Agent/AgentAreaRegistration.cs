using System.Web.Mvc;
using Wohnungstausch24.Core;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent
{
    public class AgentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Agent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Agent_default",
                "{culture}/Agent/{controller}/{action}/{id}",
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