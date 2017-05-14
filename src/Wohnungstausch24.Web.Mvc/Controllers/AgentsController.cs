using System.Threading.Tasks;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.ViewModels.Landing;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
    public class AgentsController : BaseController
    {
        private IAgentService _agentService;

        public AgentsController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        // GET: Agents
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Detail(int id)
        {
            var model = await _agentService.GetById(id);
            return View(model);
        }
        public ActionResult Listings(int id)
        {
            return View();
        }
    }
}