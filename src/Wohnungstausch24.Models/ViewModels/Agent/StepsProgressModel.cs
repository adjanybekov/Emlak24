namespace Wohnungstausch24.Models.ViewModels.Agent
{
    public class StepsProgressModel
    {
        public StepsProgressModel(int? id)
        {
            ListingId = id;
        }

        public StepsProgressModel()
        {
        }

        public int Step { get; set; }
        public int? ListingId { get; set; }

    }
}
