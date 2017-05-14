using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Agent.SearchProfile;
using Wohnungstausch24.Models.ViewModels.Agent.Settings;
using Wohnungstausch24.Models.ViewModels.Common;
using Wohnungstausch24.Models.ViewModels.Search;
using Wohnungstausch24.Models.ViewModels.Search.SearchProfiles;
using Wohnungstausch24.Resources;
using IndexViewModel = Wohnungstausch24.Models.ViewModels.Account.IndexViewModel;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent.Controllers
{
    public class SearchProfileController : BaseController
    {
        private IUserService _userService;
        private ISearchProfileService _searchProfileService;

        public SearchProfileController(IUserService userService, ISearchProfileService searchProfileService)
        {
            _userService = userService;
            _searchProfileService = searchProfileService;
        }

        // GET: Agent/SearchProfile
        public ActionResult Index(int? itemsPerPage, int? page)
        {
            var model = _userService.GetSearchProfiles(User.Identity.GetUserId(),page, itemsPerPage);
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            SearchProfileDetailViewModel model = _searchProfileService.GetById(id);
            return View(model);
        }
        public ActionResult DeletePerson(int id, int spId)
        {
            if (_searchProfileService.DeletePerson(id, User.Identity.GetUserId()))
            {
                return RedirectToAction("Detail", new {id = spId});
            }
            return RedirectToAction("Detail", new { area = "" });
        }

        [HttpGet]
        public ActionResult AddPerson(int id, int spId)
        {
            AddPersonViewModel model = new AddPersonViewModel { ClientId = id, SearchProfileId = spId};
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPerson(AddPersonViewModel model)
        {
            if (_searchProfileService.AddPerson(model, User.Identity.GetUserId()))
            {
                return RedirectToAction("Detail","SearchProfile", new { id = model.SearchProfileId });
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult AddNewClient(int id)
        {
            var model = new AddNewClientViewModel { SearchProfileId = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewClient(AddNewClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_searchProfileService.AddClient(model))
                {
                    return RedirectToAction("Detail", "SearchProfile", new { id = model.SearchProfileId});
                }
            }
            return View(model);
        }

        public ActionResult DeleteClient(int searchprofileid, int clientid)
        {
            if (_searchProfileService.DeleteClient(clientid, User.Identity.GetUserId()))
            {
                this.AddToastMessage(Resource.Success, Resource.General_Operation_Successfull,ToastType.Success);
            }
            else
            {
                this.AddToastMessage(Resource.Error, Resource.General_Operation_Failed, ToastType.Error);
            }
            return RedirectToAction("Detail", "SearchProfile", new { id = searchprofileid });
        }

        [HttpGet]
        public ActionResult EditClient(int searchprofileid, int clientid)
        {
            var model = _searchProfileService.GetClient(clientid, searchprofileid);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClient(ClientViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_searchProfileService.EditClient(model))
                {
                    return RedirectToAction("Detail", "SearchProfile", new { id = model.SearchProfileId });
                }
            }
            return View(model);

        }

        public ActionResult DeleteSearchProfile(int searchprofileid)
        {
            bool a= _searchProfileService.DeleteSearchProfile(searchprofileid,User.Identity.GetUserId());
            if (a)
            {
                this.AddToastMessage(Resource.Success, Resource.General_Operation_Successfull, ToastType.Success);
            }
            else
            {
                this.AddToastMessage(Resource.Error, Resource.General_Operation_Failed, ToastType.Error);
            }

            return RedirectToAction("Index", "SearchProfile", new { id = searchprofileid });

        }
    }
}