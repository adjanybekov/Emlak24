using System;
using System.Linq;
using System.Web.Mvc;
using Wohnungstausch24.Core;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using Wohnungstausch24.Resources;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Core.EnumExtensions;
using Wohnungstausch24.Core.Toastr;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9;
using Wohnungstausch24.Models.ViewModels.Property;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly ILocationService _locationService;
        private readonly IListingService _listingService;

        public PropertyController(ILocationService locationService, IListingService listingService)
        {
            _locationService = locationService;
            _listingService = listingService;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return RedirectToAction(nameof(ChooseTypeOfUse));
        }

        [HttpGet]
        public ActionResult ChooseTypeOfUse()
        {
            var model = new ChooseTypeOfUseViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChooseTypeOfUse(ChooseTypeOfUseViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TypeOfMerchandising", "Property", new {typeOfUse = model.TypeOfUse});
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult TypeOfMerchandising(TypeOfUse typeOfUse)
        {
            var model = new ChooseTypeOfMerchandisingViewModel {TypeOfUse = typeOfUse};
            return View(model);
        }

        [HttpPost]
        public ActionResult TypeOfMerchandising(ChooseTypeOfMerchandisingViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ChoosePropertyType",
                    new {typeOfMerchandising = model.TypeOfMerchandising, typeOfUse = model.TypeOfUse});
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ChoosePropertyType(TypeOfMerchandising typeOfMerchandising, TypeOfUse typeOfUse)
        {
            var model = new InitListingViewModel
            {
                TypeOfUse = typeOfUse,
                TypeOfMerchandising = typeOfMerchandising
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ChoosePropertyType(InitListingViewModel model)
        {
            if (ModelState.IsValid)
            {
                int listingId = _listingService.InitNewListing(model, User.Identity.GetUserId());
                return RedirectToAction("Step1", "Property", new {id = listingId});
            }
            return View(model);
        }


        public ActionResult Index(int? itemsPerPage, int? page)
        {
            var model = _listingService.GetMyListingsByUserId(User.Identity.GetUserId(),page,itemsPerPage);
            return View(model);
        }


        public ActionResult Step1(int id)
        {
            var model = _listingService.GetStep1ById(id);

            model.StepsProgressModel.Step = 1;
            model.StepsProgressModel.ListingId = id;
            ViewBag.Title = Resource.Property_EditProperty;

            if (model.Step1FlatForRent != null)
            {
                FillLocInfo(model.Step1FlatForRent);
                model.Step1FlatForRent.PropertySubTypes = Enum.GetValues(typeof(FlatType)).Cast<FlatType>()
                    .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                    .ToList();
                return View("FlatForRent/Step1", model);
            }
            if (model.Step1FlatForSale != null)
            {
                FillLocInfo(model.Step1FlatForSale);
                model.Step1FlatForSale.PropertySubTypes =
                    Enum.GetValues(typeof(FlatType)).Cast<FlatType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                return View("FlatForSale/Step1", model);
            }
            if (model.Step1HouseForRent != null)
            {
                FillLocInfo(model.Step1HouseForRent);
                model.Step1HouseForRent.PropertySubTypes =
                    Enum.GetValues(typeof(HouseType)).Cast<HouseType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                return View("HouseForRent/Step1", model);
            }
            if (model.Step1HouseForSale != null)
            {
                FillLocInfo(model.Step1HouseForSale);
                model.Step1HouseForSale.PropertySubTypes =
                    Enum.GetValues(typeof(HouseType)).Cast<HouseType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                return View("HouseForSale/Step1", model);
            }
            if (model.Step1LandForSale != null)
            {
                model.Step1LandForSale.PropertySubTypes =
                    Enum.GetValues(typeof(LandType)).Cast<LandType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                FillLocInfo(model.Step1LandForSale);
                return View("LandForSale/Step1", model);
            }
            if (model.Step1RoomForRent != null)
            {
                model.Step1RoomForRent.PropertySubTypes =
                    Enum.GetValues(typeof(FlatType)).Cast<FlatType>()
                        .Select(c => new SelectListItem { Value = ((int)c).ToString(), Text = c.GetDisplayName() })
                        .ToList();
                FillLocInfo(model.Step1RoomForRent);
                return View("RoomForRent/Step1", model);
            }
            return View("FlatForRent/Step1", model);
        }

        [HttpPost]
        public ActionResult Step1(Step1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Step1FlatForRent != null)
                {
                    model.Step1FlatForRent.ListingStatus = ListingStatus.Active;
                }
                if (model.Step1FlatForSale != null)
                {
                    model.Step1FlatForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step1HouseForRent != null)
                {
                    model.Step1HouseForRent.ListingStatus = ListingStatus.Active;
                }
                if (model.Step1HouseForSale != null)
                {
                    model.Step1HouseForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step1LandForSale != null)
                {
                    model.Step1LandForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step1RoomForRent != null)
                {
                    model.Step1RoomForRent.ListingStatus = ListingStatus.Active;
                }
                _listingService.SaveListingStep1(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step2), new {model.Id});
            }
            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 1;


            if (model.Step1FlatForRent != null)
            {
                model.Step1FlatForRent.PropertySubTypes =
                    Enum.GetValues(typeof(FlatType)).Cast<FlatType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                FillLocInfo(model.Step1FlatForRent);

                return View("FlatForRent/Step1", model);
            }
            if (model.Step1FlatForSale != null)
            {
                model.Step1FlatForSale.PropertySubTypes =
                    Enum.GetValues(typeof(FlatType)).Cast<FlatType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                FillLocInfo(model.Step1FlatForSale);

                return View("FlatForSale/Step1", model);
            }
            if (model.Step1HouseForRent != null)
            {
                model.Step1HouseForRent.PropertySubTypes =
                    Enum.GetValues(typeof(HouseType)).Cast<HouseType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                FillLocInfo(model.Step1HouseForRent);

                return View("HouseForRent/Step1", model);
            }
            if (model.Step1HouseForSale != null)
            {
                model.Step1HouseForSale.PropertySubTypes =
                    Enum.GetValues(typeof(HouseType)).Cast<HouseType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                FillLocInfo(model.Step1HouseForSale);

                return View("HouseForSale/Step1", model);
            }
            if (model.Step1LandForSale != null)
            {
                FillLocInfo(model.Step1LandForSale);
                model.Step1LandForSale.PropertySubTypes =
                    Enum.GetValues(typeof(LandType)).Cast<LandType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                return View("LandForSale/Step1", model);
            }
            if (model.Step1RoomForRent != null)
            {
                FillLocInfo(model.Step1RoomForRent);
                model.Step1RoomForRent.PropertySubTypes =
                    Enum.GetValues(typeof(FlatType)).Cast<FlatType>()
                        .Select(c => new SelectListItem {Value = ((int) c).ToString(), Text = c.GetDisplayName()})
                        .ToList();
                return View("RoomForRent/Step1", model);
            }

            return View("FlatForRent/Step1", model);
        }

        public ActionResult Step2(int id)
        {
            Step2ViewModel model = _listingService.GetStep2ById(id);
            model.StepsProgressModel.Step = 2;
            model.StepsProgressModel.ListingId = id;


            if (model.Step2FlatForRent != null)
            {
                return View("FlatForRent/Step2", model);
            }
            if (model.Step2FlatForSale != null)
            {
                return View("FlatForSale/Step2", model);
            }
            if (model.Step2HouseForRent != null)
            {
                return View("HouseForRent/Step2", model);
            }
            if (model.Step2HouseForSale != null)
            {
                return View("HouseForSale/Step2", model);
            }
            if (model.Step2LandForSale != null)
            {
                return View("LandForSale/Step2", model);
            }
            if (model.Step2RoomForRent != null)
            {
                return View("RoomForRent/Step2", model);
            }

            return null;
        }

        [HttpPost]
        public ActionResult Step2(Step2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _listingService.SaveListingStep2(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step3), new {id = model.Id});
            }

            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 2;

            if (model.Step2FlatForRent != null)
            {
                return View("FlatForRent/Step2", model);
            }
            if (model.Step2FlatForSale != null)
            {
                return View("FlatForSale/Step2", model);
            }
            if (model.Step2HouseForRent != null)
            {
                return View("HouseForRent/Step2", model);
            }
            if (model.Step2HouseForSale != null)
            {
                return View("HouseForSale/Step2", model);
            }
            if (model.Step2LandForSale != null)
            {
                return View("LandForSale/Step2", model);
            }
            if (model.Step2RoomForRent != null)
            {
                return View("RoomForRent/Step2", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Step3(int id)
        {
            Step3ViewModel model = _listingService.GetStep3ById(id);
            model.StepsProgressModel.Step = 3;
            model.StepsProgressModel.ListingId = id;

            if (model.Step3FlatForRent != null)
            {
                return View("FlatForRent/Step3", model);
            }
            if (model.Step3FlatForSale != null)
            {
                return View("FlatForSale/Step3", model);
            }
            if (model.Step3HouseForRent != null)
            {
                return View("HouseForRent/Step3", model);
            }
            if (model.Step3HouseForSale != null)
            {
                return View("HouseForSale/Step3", model);
            }
            if (model.Step3LandForSale != null)
            {
                return View("LandForSale/Step3", model);
            }
            if (model.Step3RoomForRent != null)
            {
                return View("RoomForRent/Step3", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Step3(Step3ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _listingService.SaveListingStep3(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step4), new {id = model.Id});
            }

            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 3;

            if (model.Step3FlatForRent != null)
            {
                return View("FlatForRent/Step3", model);
            }
            if (model.Step3FlatForSale != null)
            {
                return View("FlatForSale/Step3", model);
            }
            if (model.Step3HouseForRent != null)
            {
                return View("HouseForRent/Step3", model);
            }
            if (model.Step3HouseForSale != null)
            {
                return View("HouseForSale/Step3", model);
            }
            if (model.Step3LandForSale != null)
            {
                return View("LandForSale/Step3", model);
            }
            if (model.Step3RoomForRent != null)
            {
                return View("RoomForRent/Step3", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Step4(int id)
        {
            Step4ViewModel model = _listingService.GetStep4ById(id);
            model.StepsProgressModel.Step = 4;
            model.StepsProgressModel.ListingId = id;
            if (model.Step4FlatForRent != null)
            {
                return View("FlatForRent/Step4", model);
            }
            if (model.Step4FlatForSale != null)
            {
                return View("FlatForSale/Step4", model);
            }
            if (model.Step4HouseForRent != null)
            {
                return View("HouseForRent/Step4", model);
            }
            if (model.Step4HouseForSale != null)
            {
                return View("HouseForSale/Step4", model);
            }
            if (model.Step4LandForSale != null)
            {
                return View("LandForSale/Step4", model);
            }
            if (model.Step4RoomForRent != null)
            {
                return View("RoomForRent/Step4", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Step4(Step4ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _listingService.SaveListingStep4(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step5), new {id = model.Id});
            }

            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 4;


            if (model.Step4FlatForRent != null)
            {
                return View("FlatForRent/Step4", model);
            }
            if (model.Step4FlatForSale != null)
            {
                return View("FlatForSale/Step4", model);
            }
            if (model.Step4HouseForRent != null)
            {
                return View("HouseForRent/Step4", model);
            }
            if (model.Step4HouseForSale != null)
            {
                return View("HouseForSale/Step4", model);
            }
            if (model.Step4LandForSale != null)
            {
                return View("LandForSale/Step4", model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Step5(int id)
        {
            Step5ViewModel model = _listingService.GetStep5ById(id);
            model.StepsProgressModel.Step = 5;
            model.StepsProgressModel.ListingId = id;
            try
            {
                HttpRuntimeSection section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
                var maxAlloweLength = section.MaxRequestLength;
                model.MaxRequestLength = maxAlloweLength;
            }
            catch (Exception e)
            {
                this.AddToastMessage(Resource.Error, Resource.Error, ToastType.Error);

            }
            return View("Common/Step5", model);
        }

        [HttpPost]
        public ActionResult Step5(Step5ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _listingService.SaveListingStep5(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step6), new { id = model.Id });
            }
            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 5;
            return View("Common/Step5", model);
        }

        public ActionResult Step6(int id)
        {
            Step6ViewModel model = _listingService.GetStep6ById(id);
            model.StepsProgressModel.Step = 6;
            model.StepsProgressModel.ListingId = id;
            if (model.Step6FlatForRent != null)
            {
                return View("FlatForRent/Step6", model);
            }
            if (model.Step6FlatForSale != null)
            {
                return View("FlatForSale/Step6", model);
            }
            if (model.Step6HouseForRent != null)
            {
                return View("HouseForRent/Step6", model);
            }
            if (model.Step6HouseForSale != null)
            {
                return View("HouseForSale/Step6", model);
            }
            if (model.Step6LandForSale != null)
            {
                return View("LandForSale/Step6", model);
            }
            if (model.Step6RoomForRent != null)
            {
                return View("RoomForRent/Step6", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Step6(Step6ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _listingService.SaveListingStep6(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step7), new { id = model.Id });
            }

            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 6;

            if (model.Step6FlatForRent != null)
            {
                return View("FlatForRent/Step6", model);
            }
            if (model.Step6FlatForSale != null)
            {
                return View("FlatForSale/Step6", model);
            }
            if (model.Step6HouseForRent != null)
            {
                return View("HouseForRent/Step6", model);
            }
            if (model.Step6HouseForSale != null)
            {
                return View("HouseForSale/Step6", model);
            }
            if (model.Step6LandForSale != null)
            {
                return View("LandForSale/Step6", model);
            }
            if (model.Step6RoomForRent != null)
            {
                return View("RoomForRent/Step6", model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Step7(int id)
        {
            Step7ViewModel model = _listingService.GetStep7ById(id);
            model.StepsProgressModel.Step = 7;
            model.StepsProgressModel.ListingId = id;

            if (model.Step7FlatForRent != null)
            {
                return View("FlatForRent/Step7", model);
            }
            if (model.Step7FlatForSale != null)
            {
                model.Step7FlatForSale.Id = model.Id;
                model.Step7FlatForSale.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step7FlatForSale);
            }
            if (model.Step7HouseForRent != null)
            {
                return View("HouseForRent/Step7", model);
            }
            if (model.Step7HouseForSale != null)
            {
                model.Step7HouseForSale.Id = model.Id;
                model.Step7HouseForSale.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step7HouseForSale);
            }
            if (model.Step7LandForSale != null)
            {
                return View("LandForSale/Step7", model);
            }
            if (model.Step7RoomForRent != null)
            {
                return View("RoomForRent/Step7", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Step7(Step7ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _listingService.SaveListingStep7(model, User.Identity.GetUserId());
                if (model.Step7LandForSale != null)
                {
                    model.Step7LandForSale.ListingStatus = ListingStatus.Active;
                    return RedirectToAction("Index", new {id = model.Id});
                }

                return RedirectToAction(nameof(Step8), new { id = model.Id });
            }
            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 7;

            if (model.Step7FlatForRent != null)
            {
                return View("FlatForRent/Step7", model);
            }
            if (model.Step7FlatForSale != null)
            {
                model.Step7FlatForSale.Id = model.Id;
                model.Step7HouseForSale.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step7FlatForSale);
            }
            if (model.Step7HouseForRent != null)
            {
                return View("HouseForRent/Step7", model);
            }
            if (model.Step7HouseForSale != null)
            {
                model.Step7HouseForSale.Id = model.Id;
                model.Step7HouseForSale.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step7HouseForSale);
            }
            if (model.Step7LandForSale != null)
            {
                return View("LandForSale/Step7", model);
            }
            if (model.Step7RoomForRent != null)
            {
                return View("RoomForRent/Step7", model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Step8(int id)
        {
            Step8ViewModel model = _listingService.GetStep8ById(id);
            model.StepsProgressModel.Step = 8;
            model.StepsProgressModel.ListingId = id;
            if (model.Step8FlatForRent != null)
            {
                model.Step8FlatForRent.Id = model.Id;
                model.Step8FlatForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8FlatForRent);
            }
            if (model.Step8FlatForSale != null)
            {
                if (model.Step8FlatForSale.ConstructionYear == null)
                {
                    model.Step8FlatForSale.ConstructionYear = DateTime.Now.Year - 10;
                }
                return View("FlatForSale/Step8", model);
            }
            if (model.Step8HouseForRent != null)
            {
                model.Step8HouseForRent.Id = model.Id;
                model.Step8HouseForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8HouseForRent);
            }
            if (model.Step8HouseForSale != null)
            {
                if (model.Step8HouseForSale.ConstructionYear == null)
                {
                    model.Step8HouseForSale.ConstructionYear = DateTime.Now.Year - 10;
                }
                return View("HouseForSale/Step8", model);
            }
            if (model.Step8LandForSale != null)
            {
                return View("LandForSale/Step8", model);
            }
            if (model.Step8RoomForRent != null)
            {
                model.Step8RoomForRent.Id = model.Id;
                model.Step8RoomForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8RoomForRent);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Step8(Step8ViewModel model)
        {
            if (ModelState.IsValid && (model.Step8FlatForRent!=null || model.Step8HouseForRent != null || model.Step8RoomForRent != null))
            {
                _listingService.SaveListingStep8(model, User.Identity.GetUserId());
                return RedirectToAction(nameof(Step9), new { id = model.Id });
            }
            else if (ModelState.IsValid && (model.Step8FlatForSale != null || model.Step8HouseForSale != null))
            {
                if (model.Step8FlatForSale != null)
                {
                    model.Step8FlatForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step8HouseForSale != null)
                {
                    model.Step8HouseForSale.ListingStatus = ListingStatus.Active;
                }
                _listingService.SaveListingStep8(model, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }

            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 8;

            if (model.Step8FlatForRent != null)
            {
                model.Step8FlatForRent.Id = model.Id;
                model.Step8FlatForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8FlatForRent);
            }
            if (model.Step8FlatForRent != null)
            {
                model.Step8FlatForRent.Id = model.Id;
                model.Step8FlatForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8FlatForRent);
            }
            if (model.Step8FlatForSale != null)
            {
                return View("FlatForSale/Step8", model);
            }
            if (model.Step8HouseForRent != null)
            {
                model.Step8HouseForRent.Id = model.Id;
                model.Step8HouseForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8HouseForRent);
            }
            if (model.Step8HouseForSale != null)
            {
                return View("HouseForSale/Step8", model);
            }
            if (model.Step8LandForSale != null)
            {
                return View("LandForSale/Step8", model);
            }
            if (model.Step8RoomForRent != null)
            {
                model.Step8RoomForRent.Id = model.Id;
                model.Step8RoomForRent.StepsProgressModel = model.StepsProgressModel;
                return View("Common/EnergyStep", model.Step8RoomForRent);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Step9(int id)
        {
            Step9ViewModel model = _listingService.GetStep9ById(id);
            model.StepsProgressModel.Step = 9;
            model.StepsProgressModel.ListingId = id;

            if (model.Step9FlatForRent != null)
            {
                if (model.Step9FlatForRent.ConstructionYear==null)
                {
                    model.Step9FlatForRent.ConstructionYear = DateTime.Now.Year - 10;
                }

                return View("FlatForRent/Step9", model);
            }
            if (model.Step9FlatForSale != null)
            {
                if (model.Step9FlatForSale.ConstructionYear ==null)
                {
                    model.Step9FlatForSale.ConstructionYear = DateTime.Now.Year - 10;
                }

                return View("FlatForSale/Step9", model);
            }
            if (model.Step9HouseForRent != null)
            {
                model.Step9HouseForRent.ConstructionYear = DateTime.Now.Year - 10;
                return View("HouseForRent/Step9", model);
            }
            if (model.Step9HouseForSale != null)
            {
                if (model.Step9HouseForSale.ConstructionYear == null)
                {
                    model.Step9HouseForSale.ConstructionYear = DateTime.Now.Year - 10;
                }
                return View("HouseForSale/Step9", model);
            }
            if (model.Step9RoomForRent != null)
            {
                model.Step9RoomForRent.ConstructionYear = DateTime.Now.Year - 10;
                return View("RoomForRent/Step9", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Step9(Step9ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Step9FlatForRent != null)
                {
                    model.Step9FlatForRent.ListingStatus = ListingStatus.Active;
                }
                if (model.Step9FlatForSale != null)
                {
                    model.Step9FlatForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step9HouseForRent != null)
                {
                    model.Step9HouseForRent.ListingStatus = ListingStatus.Active;
                }
                if (model.Step9HouseForSale != null)
                {
                    model.Step9HouseForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step9LandForSale != null)
                {
                    model.Step9LandForSale.ListingStatus = ListingStatus.Active;
                }
                if (model.Step9RoomForRent != null)
                {
                    model.Step9RoomForRent.ListingStatus = ListingStatus.Active;
                }

                _listingService.SaveListingStep9(model, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }

            model.StepsProgressModel.ListingId = model.Id;
            model.StepsProgressModel.Step = 9;

            if (model.Step9FlatForRent != null)
            {
                return View("FlatForRent/Step9", model);
            }
            if (model.Step9FlatForSale != null)
            {
                return View("FlatForSale/Step9", model);
            }
            if (model.Step9HouseForRent != null)
            {
                return View("HouseForRent/Step9", model);
            }
            if (model.Step9HouseForSale != null)
            {
                return View("HouseForSale/Step9", model);
            }
            if (model.Step9RoomForRent != null)
            {
                return View("RoomForRent/Step9", model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddParkingSpace(AddparkingSpaceViewModel model,int id)
        {
            List<ParkSpaceViewModel> list = _listingService.AddParkingSpace(model,id);
            return PartialView("Property/_ParkingSpaceTablePartial", list);
        }

        [HttpPost]
        public ActionResult AddBalcony(AddBalconyViewModel model,int id)
        {
            List<BalconyViewModel> list = _listingService.AddBalcony(model,id);
            return PartialView("Property/_BalconyTablePartial", list);
        }

        public ActionResult DeleteBalcony(int id)
        {
            List<BalconyViewModel> list = _listingService.DeleteBalcony(id, User.Identity.GetUserId());
            return PartialView("Property/_BalconyTablePartial", list);
        }

        public ActionResult DeleteParkSpace(int id)
        {
            List<ParkSpaceViewModel> list = _listingService.DeleteParkSpace(id, User.Identity.GetUserId());
            return PartialView("Property/_ParkingSpaceTablePartial", list);
        }

        public ActionResult GetBalconies(int? id)
        {
            List<BalconyViewModel> list = _listingService.GetBalconies(id, User.Identity.GetUserId());
            return PartialView("Property/_BalconyTablePartial", list);
        }

        public ActionResult GetParkSpaces(int? id)
        {
            List<ParkSpaceViewModel> list = _listingService.GetParkSpaces(id, User.Identity.GetUserId());
            return PartialView("Property/_ParkingSpaceTablePartial", list);
        }

        #region Helpers

        private void FillLocInfo(Step1Listing data)
        {
            data.Countries = _locationService.GetCountries().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            data.LocationsLevel1 = new List<SelectListItem>();
            data.LocationsLevel2 = new List<SelectListItem>();
            data.LocationsLevel3 = new List<SelectListItem>();
            if (data.Locationlevel3 != null && data.Locationlevel3 != 0)
            {
                data.SelectedLocationlevel2 = _locationService.GetLocationLevel2Id(data.Locationlevel3);
                data.SelectedLocationlevel1 = _locationService.GetLocationLevel1Id(data.SelectedLocationlevel2);
                data.SelectedCountry = _locationService.GetCountryId(data.SelectedLocationlevel1);

                data.LocationsLevel1 = _locationService.GetLocationLevel1(data.SelectedCountry).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                data.LocationsLevel2 = _locationService.GetLocationLevel2(data.SelectedLocationlevel1.Value).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                data.LocationsLevel3 = _locationService.GetLocationLevel3(data.SelectedLocationlevel2.Value).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            }
        }

        #endregion
        [HttpPost]
        public ActionResult AddViewSight(Step2ViewModel model)
        {
            List<ViewSightViewModel> list = _listingService.AddViewSight(model);
            return PartialView("Property/_ViewSightTablePartial", list);
        }

        public ActionResult GetViewSights(int? id)
        {
            List<ViewSightViewModel> list = _listingService.GetViewSights(id, User.Identity.GetUserId());
            return PartialView("Property/_ViewSightTablePartial", list);
        }

        public ActionResult DeleteViewSight(int id)
        {
            List<ViewSightViewModel> list = _listingService.DeleteViewSight(id, User.Identity.GetUserId());
            return PartialView("Property/_ViewSightTablePartial", list);
        }


        [HttpPost]
        public ActionResult AddDistanceTo(AddDistanceToViewModel model,int id)
        {
            List<DistanceToViewModel> list = _listingService.AddDistanceTo(model,id,User.Identity.GetUserId());
            return PartialView("Property/_DistanceToTablePartial", list);
        }

        public ActionResult DeleteDistanceTo(int id)
        {
            List<DistanceToViewModel> list = _listingService.DeleteDistanceTo(id, User.Identity.GetUserId());
            return PartialView("Property/_DistanceToTablePartial", list);
        }

        public ActionResult GetDistanceTos(int? id)
        {
            List<DistanceToViewModel> list = _listingService.GetDistanceTos(id, User.Identity.GetUserId());
            return PartialView("Property/_DistanceToTablePartial", list);
        }
        [HttpPost]
        public ActionResult AddHeating(AddHeatingViewModel heating, int id)
        {
            List<HeatingViewModel> list = _listingService.AddHeating(heating, id, User.Identity.GetUserId());
            return PartialView("Property/_HeatingPartialTable", list);
        }

        public ActionResult DeleteHeating(int id)
        {
            List<HeatingViewModel> list = _listingService.DeleteHeating(id, User.Identity.GetUserId());
            return PartialView("Property/_HeatingPartialTable", list);
        }

        public ActionResult GetHeatings(int? id)
        {
            List<HeatingViewModel> list = _listingService.GetHeatings(id, User.Identity.GetUserId());
            return PartialView("Property/_HeatingPartialTable", list);
        }

        [HttpPost]
        public ActionResult AddBathroom(AddBathroomViewModel model, int Id)
        {
            List<BathroomViewModel> list = _listingService.AddBathroom(model,Id, User.Identity.GetUserId());
            return PartialView("Property/_BathroomPartialTable", list);
        }

        public ActionResult DeleteBathroom(int id)
        {
            List<BathroomViewModel> list = _listingService.DeleteBathroom(id, User.Identity.GetUserId());
            return PartialView("Property/_BathroomPartialTable", list);
        }

        public ActionResult GetBathrooms(int? id)
        {
            List<BathroomViewModel> list = _listingService.GetBathrooms(id, User.Identity.GetUserId());
            return PartialView("Property/_BathroomPartialTable", list);
        }

        [HttpPost]
        public ActionResult AddBeaconing(AddBeaconingViewModel model,int Id)
        {
            List<BeaconingViewModel> list = _listingService.AddBeaconing(model,Id, User.Identity.GetUserId());
            return PartialView("Property/_BeaconingTablePartial", list);
        }

        public ActionResult DeleteBeaconing(int id)
        {
            List<BeaconingViewModel> list = _listingService.DeleteBeaconing(id, User.Identity.GetUserId());
            return PartialView("Property/_BeaconingTablePartial", list);
        }

        public ActionResult GetBeaconings(int? id)
        {
            List<BeaconingViewModel> list = _listingService.GetBeaconings(id, User.Identity.GetUserId());
            return PartialView("Property/_BeaconingTablePartial", list);
        }

        [HttpPost]
        public ActionResult AddTextInAnotherLanguage(Step6ViewModel model)
        {
            List<TextInAnotherLanguageViewModel> list = _listingService.AddTextInAnotherLanguage(model, User.Identity.GetUserId());
            return PartialView("Property/_TextInAnotherLanguageTablePartial", list);
        }

        public ActionResult DeleteTextInAnotherLanguage(int id)
        {
            List<TextInAnotherLanguageViewModel> list = _listingService.DeleteTextInAnotherLanguage(id, User.Identity.GetUserId());
            return PartialView("Property/_TextInAnotherLanguageTablePartial", list);
        }

        public ActionResult GetTextsInAnotherLanguage(int? id)
        {
            List<TextInAnotherLanguageViewModel> list = _listingService.GetTextsInAnotherLanguage(id, User.Identity.GetUserId());
            return PartialView("Property/_TextInAnotherLanguageTablePartial", list);
        }

        [HttpPost]
        public ActionResult AddMixedLand(Step4ViewModel model)
        {
            List<MixedLandViewModel> list = _listingService.AddMixedLand(model, User.Identity.GetUserId());
            return PartialView("Property/_MixedLandTablePartial", list);
        }

        public ActionResult DeleteMixedLand(int id)
        {
            List<MixedLandViewModel> list = _listingService.DeleteMixedLand(id, User.Identity.GetUserId());
            return PartialView("Property/_MixedLandTablePartial", list);
        }

        public ActionResult GetMixedLands(int? id)
        {
            List<MixedLandViewModel> list = _listingService.GetMixedLands(id, User.Identity.GetUserId());
            return PartialView("Property/_MixedLandTablePartial", list);
        }

    }
}