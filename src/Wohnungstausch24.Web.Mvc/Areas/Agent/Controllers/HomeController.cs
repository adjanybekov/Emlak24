using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IAuthManager _authManager;
        private IAgentService _agentService;

        public HomeController(IAuthManager authManager, IAgentService agentService)
        {
            _authManager = authManager;
            _agentService = agentService;
        }


        public ActionResult Index()
        {
            var model = new AgentHomePageViewModel();
            return View(model);
        }

        public ActionResult GetAgentSidebar()
        {
            var model = new AgentSidebarViewModel();
            model.User = _authManager.FindById(User.Identity.GetUserId());
            return PartialView("_AgentSidebar", model);
        }
    }
}