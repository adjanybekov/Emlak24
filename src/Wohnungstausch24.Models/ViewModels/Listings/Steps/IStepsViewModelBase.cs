using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps
{
    public interface IStepsViewModelBase : IViewModelBase
    {
        int? Id { get; set; }
        StepsProgressModel StepsProgressModel { get; set; }
    }
}