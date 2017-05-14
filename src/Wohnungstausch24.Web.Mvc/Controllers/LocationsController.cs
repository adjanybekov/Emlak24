using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Search;
using Wohnungstausch24.Models.ViewModels.Search.BasicSearch;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
    public class LocationsController : BaseController
    {
        private ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public ActionResult GetCountries()
        {
            var data = _locationService.GetCountries().Select(o => new { Text = o.Name, Value = o.Id });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocationLevel1(int? countryId)
        {
            if (!countryId.HasValue)
            {
                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }

            var data = _locationService.GetLocationLevel1(countryId.Value).Select(o => new { Text = o.Name, Value = o.Id });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLocationLevel2(int? locationLevel1)
        {
            if (!locationLevel1.HasValue)
            {
                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }

            var data = _locationService.GetLocationLevel2(locationLevel1.Value).Select(o => new { Text = o.Name, Value = o.Id });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLocationLevel3(int? locationLevel2)
        {
            if (!locationLevel2.HasValue)
            {
                return Json(new List<object>(), JsonRequestBehavior.AllowGet);
            }

            var data = _locationService.GetLocationLevel3(locationLevel2.Value).Select(o => new { Text = o.Name, Value = o.Id });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLocationLevelTree(int id)
        {
            SearchModelBase model = new SearchModelBase {Locations = _locationService.GetAllCities(id)};
            return PartialView("_LocationsTreeView", model);
        }


    }
}