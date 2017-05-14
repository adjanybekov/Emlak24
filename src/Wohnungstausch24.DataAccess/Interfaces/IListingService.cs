using System.Collections.Generic;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.ViewModels.Agent;
using Wohnungstausch24.Models.ViewModels.Listings;
using Wohnungstausch24.Models.ViewModels.Listings.ListingDetail.Base;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step1;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step2;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step3;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step4;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step5;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step6;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step7;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step8;
using Wohnungstausch24.Models.ViewModels.Listings.Steps.Step9;
using Wohnungstausch24.Models.ViewModels.Property;
using Wohnungstausch24.Models.ViewModels.Search.BasicSearch;
using Wohnungstausch24.Models.ViewModels.Search.DetailedSearch;

namespace Wohnungstausch24.DataAccess.Interfaces
{
    public interface IListingService
    {
        DetailListing GetById(int id);
        ICollection<SummaryViewModel> GetAll();
        ListingsDisplayViewModel GetMyListingsByUserId(string userId, int? page, int? itemsPerPage);
        ICollection<ObjectData> GetAllForHomePage();
        BasicSearchViewModel Search(BasicSearchViewModel model);
        List<SummaryViewModel> DetailedSearch(DetailedSearchResultsModel modelDetailedBasicSearchFfrViewModel);
        Step1ViewModel GetStep1ById(int? id);
        Step2ViewModel GetStep2ById(int id);
        Step3ViewModel GetStep3ById(int? id);
        Step4ViewModel GetStep4ById(int id);
        Step5ViewModel GetStep5ById(int id);
        Step6ViewModel GetStep6ById(int id);
        Step7ViewModel GetStep7ById(int id);
        Step8ViewModel GetStep8ById(int id);
        Step9ViewModel GetStep9ById(int id);
        void SaveListingStep1(Step1ViewModel model, string userId);
        void SaveListingStep2(Step2ViewModel model, string userId);
        void SaveListingStep3(Step3ViewModel model, string userId);
        void SaveListingStep4(Step4ViewModel model, string userId);
        void SaveListingStep5(Step5ViewModel model, string userId);
        void SaveListingStep6(Step6ViewModel model, string userId);
        void SaveListingStep7(Step7ViewModel model, string userId);
        void SaveListingStep8(Step8ViewModel model, string userId);
        void SaveListingStep9(Step9ViewModel model, string userId);
        List<ParkSpaceViewModel> AddParkingSpace(AddparkingSpaceViewModel model,int Id);
        List<BalconyViewModel> AddBalcony(AddBalconyViewModel model,int Id);
        List<BalconyViewModel> DeleteBalcony(int id, string userId);
        List<ParkSpaceViewModel> DeleteParkSpace(int id, string userId);
        List<BalconyViewModel> GetBalconies(int? id, string userId);
        List<ParkSpaceViewModel> GetParkSpaces(int? id, string userId);
        int InitNewListing(InitListingViewModel model, string userId);
        List<ViewSightViewModel> AddViewSight(Step2ViewModel model);
        List<ViewSightViewModel> GetViewSights(int? id, string userId);
        List<ViewSightViewModel> DeleteViewSight(int id, string userId);
        List<DistanceToViewModel> AddDistanceTo(AddDistanceToViewModel model, int id, string userId);
        List<DistanceToViewModel> DeleteDistanceTo(int id, string userId);
        List<DistanceToViewModel> GetDistanceTos(int? id, string userId);
        List<HeatingViewModel> AddHeating(AddHeatingViewModel model, int id, string userId);
        List<HeatingViewModel> DeleteHeating(int id, string userId);
        List<HeatingViewModel> GetHeatings(int? id, string userId);
        List<BathroomViewModel> AddBathroom(AddBathroomViewModel model, int Id, string userId);
        List<BathroomViewModel> DeleteBathroom(int id, string userId);
        List<BathroomViewModel> GetBathrooms(int? id, string userId);
        List<BeaconingViewModel> AddBeaconing(AddBeaconingViewModel model,int Id, string userId);
        List<BeaconingViewModel> DeleteBeaconing(int id, string userId);
        List<BeaconingViewModel> GetBeaconings(int? id, string userId);
        List<TextInAnotherLanguageViewModel> AddTextInAnotherLanguage(Step6ViewModel model, string userId);
        List<TextInAnotherLanguageViewModel> DeleteTextInAnotherLanguage(int id, string userId);
        List<TextInAnotherLanguageViewModel> GetTextsInAnotherLanguage(int? id, string userId);
        List<MixedLandViewModel> AddMixedLand(Step4ViewModel model, string userId);
        List<MixedLandViewModel> DeleteMixedLand(int id, string userId);
        List<MixedLandViewModel> GetMixedLands(int? id, string userId);
        DetailedSearchResultsModel GetDetailedSearchViewModel(TypeOfMerchandising? mt, PropertyType? pt);
        List<string> GetContactEmailsByListingId(int id);
    }
}