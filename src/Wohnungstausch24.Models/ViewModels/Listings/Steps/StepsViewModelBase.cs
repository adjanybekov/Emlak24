using Wohnungstausch24.Models.ViewModels.Agent;

namespace Wohnungstausch24.Models.ViewModels.Listings.Steps
{
    public class StepsViewModelBase : ViewModelBase, IStepsViewModelBase
    {
        protected StepsViewModelBase()
        {
            this.StepsProgressModel = new StepsProgressModel(this.Id);
        }
        protected StepsViewModelBase(int id)
        {
            this.Id = id;
            this.StepsProgressModel = new StepsProgressModel(this.Id);
        }
        public int? Id { get; set; }
        public StepsProgressModel StepsProgressModel { get; set; }
    }
}