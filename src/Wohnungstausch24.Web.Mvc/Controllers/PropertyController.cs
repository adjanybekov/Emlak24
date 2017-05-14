using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Web.Mvc.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IListingService _listingService;
        private IMailService _mailService;

        public PropertyController(IListingService listingService, IMailService mailService)
        {
            _listingService = listingService;
            _mailService = mailService;
        }

        public ActionResult GetProperties()
        {
            var model = _listingService.GetAllForHomePage();
            foreach (var objectData in model)
            {
                objectData.type = ((TypeOfMerchandising)Enum.Parse(typeof(TypeOfMerchandising), objectData.type)).GetDisplayName();
                objectData.detailUrl = Url.Action("Detail", "Property", new {id=objectData.id});
            }

            return Json(model,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetPropertySubTypes(PropertyType propertyType)
        {
            switch (propertyType)
            {
                case PropertyType.Flat:
                    return Json(Enum.GetValues(typeof(FlatType)).Cast<FlatType>().Select(c => new SelectListItem { Value = c.ToString(), Text = c.GetDisplayName()}).ToList(), JsonRequestBehavior.AllowGet);
                default:
                    return this.Json(null,JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int id)
        {
            var model = _listingService.GetById(id);
            model.ContactAgentModel.ListingId = id;
            return View("Detail", model);
        }
        public ActionResult SendMail(ContactAgentModel model)
        {
            _mailService.SendContactAgentMail(model);
            this.AddToastMessage(Resource.Success, Resource.General_Operation_Successfull, ToastType.Success);
            return RedirectToAction("Index", "Property", new {id=model.ListingId});
        }
    }
}
