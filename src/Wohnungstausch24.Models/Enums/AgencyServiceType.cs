using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum AgencyServiceType
    {
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_ObjectRecordingExposeService")]
        ObjectRecordingExposeService = 1,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_DrivesAway_Fahrtweg")]
        DrivesAway = 2,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_CreateObjectRetrieveFiles")]
        CreateObjectRetrieveFiles = 3,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Description")]
        Description = 4,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_ProfessionalPhotos")]
        ProfessionalPhotos,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_SimpleVideo")]
        SimpleVideo,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_ElaborateVideo")]
        ElaborateVideo,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_DocumentProcessingResearch")]
        DocumentProcessingResearch,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_BasicServices")]
        BasicServices,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Optimization2D")]
        Optimization2D,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Optimization3D")]
        Optimization3D,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_EvaluationMarketAssessment")]
        EvaluationMarketAssessment,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_PriceEstimate")]
        PriceEstimate,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_ReasonedPriceEstimation")]
        ReasonedPriceEstimation,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_TrafficReports")]
        TrafficReports,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Insertion")]
        Insertion,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Selection")]
        Selection,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_TermCoordination")]
        TermCoordination,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Sightseeing")]
        Sightseeing,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_VisitSingleDate")]
        VisitSingleDate,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_Sightseeing2")]
        Sightseeing2,
        [Display(ResourceType = typeof(Resource), Name = "AgencyServiceType_ContractSignature")]
        ContractSignature
    }
}