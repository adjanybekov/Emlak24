using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Account;
using Wohnungstausch24.Models.ViewModels.Search;
using Wohnungstausch24.Models.ViewModels.Search.BasicSearch;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;
using Wohnungstausch24.Resources;
using Wohnungstausch24.Models.ViewModels.Search.TenantSearch;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IListingService _listingService;
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;
        private readonly IAuthManager _authManager;
        private ISearchService _searchService;


        public HomeController(IListingService listingService, ILocationService locationService, IUserService userService, IAuthManager authManager, ISearchService searchService)
        {
            _listingService = listingService;
            _locationService = locationService;
            _userService = userService;
            _authManager = authManager;
            _searchService = searchService;
        }

        public ActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Listings = _listingService.GetAll();
            PopulateBasicSearch(model.BasicSearchModel);

            return View(model);
        }

        private void PopulateBasicSearch(BasicSearchViewModel model)
        {
            model.MerchandisingTypes = Enum.GetValues(typeof(TypeOfMerchandising)).Cast<TypeOfMerchandising>()
                .Select(c => new SelectListItem { Value = c.ToString(), Text = c.GetDisplayName() })
                .ToList();
            model.PropertyTypes = Enum.GetValues(typeof(PropertyType)).Cast<PropertyType>()
                .Select(c => new SelectListItem { Value = c.ToString(), Text = c.GetDisplayName() })
                .ToList();
            FillLocInfo(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(BasicSearchViewModel model)
        {
            var results = _listingService.Search(model);
            PopulateBasicSearch(model);
            return View(results);
        }

        [HttpGet]
        public ActionResult DetailedSearch(TypeOfMerchandising mt=TypeOfMerchandising.Rent, PropertyType pt=PropertyType.Flat)
        {
            var model = Session["SearchViewModel"] as DetailedSearchResultsModel;
            if (model != null)
            {
                model.SummaryViewModels = _listingService.DetailedSearch(model);
                Session["SearchViewModel"] = null;
            }
            else
            {
                model = _listingService.GetDetailedSearchViewModel(mt, pt);
            }
            model.SaveSearch = false;
            FillLocInfo(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult DetailedSearch(DetailedSearchResultsModel model)
        {
            if (model.SaveSearch && User.Identity.IsAuthenticated)
            {
                _searchService.SaveDetailedSearchCriterias(model, User.Identity.GetUserId());
                this.AddToastMessage(Resource.Success, Resource.YourSearchCriteriasSavedSuccessfully, ToastType.Success);
                model.SaveSearch = false;
            }
            else if (model.SaveSearch)
            {
                Session["SearchViewModel"] = model;
                return RedirectToAction("Register", "Account");
            }
            else
            {
                this.AddToastMessage(Resource.Info, Resource.YouCanSaveYourDetailedSearchCriteriasForLaterUse);
            }
            model.SummaryViewModels = _listingService.DetailedSearch(model);
            FillLocInfo(model);
            return View(model);
        }

        public void FillLocInfo(SearchModelBase model)
        {
            model.Countries = _locationService.GetCountries();
            model.Locationlevel1 = new List<SelectListItem>();
            foreach (var country in model.Countries)
            {
                var states = _locationService.GetLocationLevel1(country.Id)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = $"({country.Name.Substring(0, 2).ToUpper()}) - {c.Name}"
                    })
                    .ToList();
                model.Locationlevel1.AddRange(states);
            }
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            RouteData.Values["culture"] = culture;  // set culture
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            if (Request.UrlReferrer != null && Request.UrlReferrer.LocalPath.Contains("Admin"))
            {
                return RedirectToRoute(new { area = "Admin", controller = "Home", action = "Index", culture = CultureHelper.GetCurrentCulture() });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Impressum()
        {
            return View();
        }


        public ActionResult TenantSearch()
        {
            TenantSearchAndDetailViewModel model = new TenantSearchAndDetailViewModel
            {
                TenantSearchViewModel = new TenantSearchViewModel
                {
                    IsSmokingAllowed = true,
                    PetsAreAllowed = true
                }
            };
            FillLocInfo(model.TenantSearchViewModel);
            return View(model);
        }

        private void FillLocInfo(TenantSearchViewModel model)
        {
            model.Countries = _locationService.GetCountries();
            model.Locationlevel1 = new List<SelectListItem>();
            foreach (var country in model.Countries)
            {
                var states = _locationService.GetLocationLevel1(country.Id)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = $"({country.Name.Substring(0, 2).ToUpper()}) - {c.Name}"
                    })
                    .ToList();
                model.Locationlevel1.AddRange(states);
            }
        }


        [HttpPost]
        public ActionResult TenantSearch(TenantSearchViewModel model)
        {
            TenantSearchAndDetailViewModel result = new TenantSearchAndDetailViewModel {TenantSearchViewModel = model};
            result.TenantList= _userService.TenantSearch(result.TenantSearchViewModel);
            FillLocInfo(result.TenantSearchViewModel);
            Session["TenantSearchModel"] = model;
            return View(result);
        }

        public ActionResult TenantDetail(string id)
        {
            TenantSearchAndDetailViewModel tenantSearchAndDetailViewModel = new TenantSearchAndDetailViewModel();
            tenantSearchAndDetailViewModel.TenantResultViewModel.ClientViewModel = _userService.GetClientSummary(id.ToInt32());
            tenantSearchAndDetailViewModel.TenantResultViewModel.TotalIncome =
                                                                        (tenantSearchAndDetailViewModel.TenantResultViewModel.ClientViewModel==null?
                                                                         0: tenantSearchAndDetailViewModel.TenantResultViewModel.ClientViewModel.Income) +
                                                                         ((tenantSearchAndDetailViewModel.TenantResultViewModel.ClientViewModel==null)?
                                                                         0: tenantSearchAndDetailViewModel.TenantResultViewModel.ClientViewModel.Persons.Sum(d => d.Income));
            if (Session?["TenantSearchModel"] != null)
                tenantSearchAndDetailViewModel.TenantSearchViewModel = (TenantSearchViewModel)Session["TenantSearchModel"];
            FillLocInfo(tenantSearchAndDetailViewModel.TenantSearchViewModel);
            return View(tenantSearchAndDetailViewModel);
        }
    }
}