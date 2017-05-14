namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class PropertyStepsViewModelBase
    {
        public PropertyStepsViewModelBase()
        {
            this.StepsProgressModel = new StepsProgressModel();
        }
        public int? Id { get; set; }
        public StepsProgressModel StepsProgressModel { get; set; }
    }
}